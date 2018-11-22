using System;
using System.Collections.Generic;

namespace Refactoring
{
    public class CorporateDTO
    {
        private List<LegalPartyRelationshipDTO> relationships;

        public List<LegalPartyRelationshipDTO> Relationships
        {
            get {
                return relationships;
            }
            set {
                relationships = value;
            }
        }

        public int LegalPartyId
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
