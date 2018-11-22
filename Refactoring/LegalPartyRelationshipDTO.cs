
using System;

namespace Refactoring
{
    public class LegalPartyRelationshipDTO
    {
        private int relatedLegalPartyId;
        private LegalPartyRelationshipTypeDTO relationshipType;
        private int legalPartyId;
        private LegalPartyDTO accountOperator;

        public int RelatedLegalPartyId
        {
            get {
                return relatedLegalPartyId;
            }
            set {
                relatedLegalPartyId = value;
            }
        }

        public LegalPartyRelationshipTypeDTO RelationshipType
        {
            get {
                return relationshipType;
            }
            set {
                relationshipType = value;
            }
        }

        public int LegalPartyId
        {
            get {
                return legalPartyId;
            }
            set {
                legalPartyId = value;
            }
        }

        public LegalPartyDTO AccountOperator
        {
            get {
                return accountOperator;
            }
            set {
                accountOperator = value;
            }
        }
    }
}
