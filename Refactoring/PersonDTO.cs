using System;
using System.Collections.Generic;

namespace Refactoring
{
    public class PersonDTO
    {
        private int regulatoryClassification;
        private int legalPartyId;
        private Employment employment;
        private int id;
        private List<AddressDTO> addresses;

        public int LegalPartyId
        {
            get
            {
                return legalPartyId;
            }
            set
            {
                legalPartyId = value;
            }
        }

        public int RegulatoryClassification
        {
            get {
                return regulatoryClassification;
            }
            set {
                regulatoryClassification = value;
            }
        }

        public List<LegalPartyEvents> Events
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Employment Employment
        {
            get {
                return employment;
            }
            set {
                employment = value;
            }
        }

        public int Id
        {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        public List<AddressDTO> Addresses
        {
            get {
                return addresses;
            }
            set {
                addresses = value;
            }
        }
    }
}
