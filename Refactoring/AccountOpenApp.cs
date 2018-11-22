using System.Collections.Generic;

namespace Refactoring
{
    public class AccountOpenApp
    {
        public ResponseMsg PersonOpen(PersonDTO person, int contractPartyId, int signatoryTypeId, int modifiedBy)
        {
            const int AccountHolder = 1;
            const int AuthorisedSignatory = 9;
            const int AuthorisedUser = 2;
            const int Director = 3;
            const int NonSignatory = 10;
            const int Trustee = 11;
            const int SingleContract = 1;
            const int JointContract = 2;

            ResponseMsg response = new ResponseMsg();

            //Load the contract party details...
            ContractPartyDTO contract = ContractPartyApp.ContractPartyGet(contractPartyId, LegalPartyLoadType.Full);

            if (IsInvalidContract(contractPartyId, contract)) return response;
            PersonDTO person2 = null;

            //1 - Load details if existing person has been supplied...
            if (person.LegalPartyId > 0)
            {
                person2 = PersonApp.PersonGet(person.LegalPartyId);

                if ((person2 == null) || (person2.LegalPartyId != person.LegalPartyId))
                {
                    response.ErrorCode = ErrorCode.Warning;
                    response.Message = "Person party identifier does not exist.";
                    return response;
                }
            }
            else
            {
                //Add the person's useful events...
                person.Events = CreateLegalPartyEvents(person.RegulatoryClassification);

                //Determine the regulator associated with the employer's country...
                if ((person.Employment != null) && (person.Employment.Regulator != null))
                {
                    CountryDTO country = CountryApp.CountryGet(person.Employment.EmployerAddress.Country.Id);
                    person.Employment.Regulator.Id = country.Regulator.Id;
                }
            }

            //2 - Determine that party has a current registered address...
            response = CheckForRegisteredAddress(person.Addresses);

            if (response.ErrorCode != ErrorCode.Ok)
            {
                return response;
            }

            //3 - Build the relationships between the person, corporate and contract parties...
            List<LegalPartyRelationshipDTO> relationships = new List<LegalPartyRelationshipDTO>();
            LegalPartyRelationshipDTO relationship;
            bool found = false;

            //Contract party is single or joint type...
            if (contract.Type.Id == SingleContract || contract.Type.Id == JointContract)
            {
                //Existing person has been supplied so check for existing 'account holder' relationship with contract...
                if (person.LegalPartyId > 0 && contract.Relationships != null)
                {
                    foreach (LegalPartyRelationshipDTO item in contract.Relationships)
                    {
                        if ((item.RelatedLegalPartyId == person.LegalPartyId) &&
                            (item.RelationshipType.Id == AccountHolder))
                        {
                            found = true;
                            break;
                        }
                    }
                }

                //If it doesn't exist then specify an 'account holder' relationship between the individual and the contract...
                if (found == false)
                {
                    relationship = CreateLegalPartyRelationship(contract.LegalPartyId, person.LegalPartyId,
                        AccountHolder);
                    relationships.Add(relationship);
                }
            }
            else
            {
                //Contract type is corporate, superannuation or trust...
                CorporateDTO corporate = null;

                //Determine that there is an existing 'account holder' relationship between the contract and a corporate party...
                if (contract.Relationships != null)
                {
                    foreach (LegalPartyRelationshipDTO item in contract.Relationships)
                    {
                        if (item.RelationshipType.Id == AccountHolder)
                        {
                            //Load the corporate details...
                            corporate = CorporateApp.CorporateGet(item.RelatedLegalPartyId);

                            if (corporate != null)
                            {
                                found = true;
                                break;
                            }
                        }
                    }
                }

                //Construct the relationship between the corporate and individual...
                if (found == false)
                {
                    response.ErrorCode = ErrorCode.Warning;
                    response.Message =
                        "Corporate contract must have an associated corporate party as an account holder prior to adding individuals.";
                    return response;
                }
                else
                {
                    found = false;

                    //Existing individual has been supplied so check for existing relationship with the contract...
                    if (person.LegalPartyId > 0 && ((corporate != null) && (corporate.Relationships != null)))
                    {
                        foreach (LegalPartyRelationshipDTO item in corporate.Relationships)
                        {
                            if (item.RelatedLegalPartyId != person.LegalPartyId ||
                                item.RelationshipType.Id != signatoryTypeId) continue;
                            found = true;
                            break;
                        }
                    }

                    //No relationship was found...
                    if (found == false)
                    {
                        relationship = new LegalPartyRelationshipDTO();
                        relationship.LegalPartyId = corporate.LegalPartyId;
                        relationship.RelatedLegalPartyId = person.LegalPartyId;
                        relationship.RelationshipType = new LegalPartyRelationshipTypeDTO();

                        switch (signatoryTypeId)
                        {
                            case Director:
                                relationship.RelationshipType.Id = Director;
                                break;
                            case AuthorisedSignatory:
                                relationship.RelationshipType.Id = AuthorisedSignatory;
                                break;
                            case NonSignatory:
                                relationship.RelationshipType.Id = NonSignatory;
                                break;
                            case Trustee:
                                relationship.RelationshipType.Id = Trustee;
                                break;
                        }

                        relationships.Add(relationship);
                    }
                }

                //Construct the 'authorised user' relationship between the contract and individual...
                found = false;

                //Construct the 'authorised user' relationship between the contract and individual...
                if (person.LegalPartyId > 0 && contract.Relationships != null)
                {
                    foreach (LegalPartyRelationshipDTO item in contract.Relationships)
                    {
                        if ((item.RelatedLegalPartyId == person.LegalPartyId) &&
                            (item.RelationshipType.Id == AuthorisedUser))
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (found == false)
                {
                    relationship = CreateLegalPartyRelationship(contract.LegalPartyId, person.LegalPartyId,
                        AuthorisedUser);
                    relationships.Add(relationship);
                }
            }

            //4 - Validate each new relationship against any existing contract relationships...
            if (person.LegalPartyId > 0 && relationships != null)
            {
                foreach (LegalPartyRelationshipDTO item in relationships)
                {
                    response = LegalPartyApp.LegalPartyRelationshipValidate(item);

                    if (response.ErrorCode != ErrorCode.Ok)
                    {
                        break;
                    }
                }
            }

            //5 - If person exists then set any values that can be confidently updated...
            PersonDTO updatePerson = null;
            List<AccountUserDTO> users = null;

            if (person.LegalPartyId >= 0)
            {
                updatePerson = PersonUpdateMapper(person, person2);
                users = new List<AccountUserDTO>();

                if (updatePerson != null)
                {
                    PersonApp.PersonValidate(updatePerson, users);
                }
            }

            bool insertAirmilesRegistration = false;
            int AMOperatorId = 0;

            ClientAccountDTO client = ClientAccountDA.ClientAccountGetByLegalPartyId(contract.LegalPartyId);

            //The following only applies if the contract type is Single or Joint...
            if (contract.Type.Id == AccountHolder || contract.Type.Id == SingleContract ||
                contract.Type.Id == JointContract)
            {
                //Check whether an operator account exists for using airmiles.
                int accountOperatorId = contract.ApplicationSource.AccountOperator.LegalPartyId;
                AMOperatorId = AirmilesDA.ClientAirmilesAccountOperatorExists(accountOperatorId);


                if (AMOperatorId != 0)
                {
                    AddressDTO address = null;

                    foreach (AddressDTO item in person.Addresses)
                    {
                        if (item.Status.Id == 1 && item.Type.Id == 1)
                        {
                            address = item;
                            break;
                        }
                    }


                    CountryDTO countryDTO = address.Country;
                    int countryId = countryDTO.Id;

                    // Check if country accepted by account operator
                    if (AirmilesDA.AccountOperatorCountry(countryId, AMOperatorId))
                    {
                        //Check whether the client account already has a person registered for AirMiles associated.
                        //ClientAccountApplication.getClientAccountIdByLegalPartyId(person.LegalPartyId);
                        if (!AirmilesDA.ClientAirmilesRegistrationExists(client.ClientAccountId))
                        {
                            insertAirmilesRegistration = true;
                        }
                    }
                }
            }

            //Commit the data...
            if (response.ErrorCode == ErrorCode.Ok)
            {
                using (TransactionBlock transactionBlock = new TransactionBlock(DbName.Atlas))
                {
                    //Commit person details...
                    if (person.LegalPartyId <= 0)
                    {
                        person.LegalPartyId = PersonApp.PersonAdd(transactionBlock, person, modifiedBy);
                    }
                    else if (updatePerson != null)
                    {
                        PersonApp.PersonUpdate(transactionBlock, updatePerson, users, modifiedBy);
                    }

                    //Commit any relationships...
                    if (relationships != null)
                    {
                        foreach (LegalPartyRelationshipDTO item in relationships)
                        {
                            item.RelatedLegalPartyId = person.LegalPartyId;
                            LegalPartyDA.LegalPartyRelationshipAdd(transactionBlock, item, modifiedBy);
                        }
                    }

                    if (insertAirmilesRegistration)
                    {
                        //a new airmiles registration
                        AirmilesDA.AddClientAirmilesRegistration(null, AMOperatorId, client.ClientAccountId,
                            person.LegalPartyId, 2);
                    }

                    response.Id = person.LegalPartyId;

                    transactionBlock.Complete();
                }
            }
            else
            {
                response.ErrorCode = ErrorCode.Warning;
                response.Message = "Contract party identifier does not exist.";
                return response;
            }
            return response;
        }

        private bool IsInvalidContract(int contractPartyId, ContractPartyDTO contract)
        {
            return (contract == null) || (contract.LegalPartyId != contractPartyId);
        }

        #region DummyMethodsOnlyHereToMakeItCompile
            private static
            PersonDTO PersonUpdateMapper(PersonDTO person, PersonDTO person2)
        {
            return new PersonDTO();
        }

        private static LegalPartyRelationshipDTO CreateLegalPartyRelationship(int id, int i, int holder)
        {
            return null;
        }

        private static ResponseMsg CheckForRegisteredAddress(List<AddressDTO> addresses)
        {
            return null;
        }

        private static List<LegalPartyEvents> CreateLegalPartyEvents(int classification)
        {
            return null;
        }
    }
    public enum DbName
    {
        Atlas
    }
    public enum ErrorCode
    {
        Warning,
        Ok
    }
    public enum LegalPartyLoadType
    {
        Full
    }
#endregion
}