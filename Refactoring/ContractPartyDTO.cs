using System;
using System.Collections.Generic;

namespace Refactoring
{
    public class ContractPartyDTO
    {
        private TypeDTO type;
        private List<LegalPartyRelationshipDTO> relationships;
        private LegalPartyRelationshipDTO applicationSource;

        public int LegalPartyId
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TypeDTO Type
        {
            get {
                return type;
            }
            set {
                type = value;
            }
        }

        public List<LegalPartyRelationshipDTO> Relationships
        {
            get {
                return relationships;
            }
            set {
                relationships = value;
            }
        }

        public LegalPartyRelationshipDTO ApplicationSource
        {
            get {
                return applicationSource;
            }
            set {
                applicationSource = value;
            }
        }
    }
}
