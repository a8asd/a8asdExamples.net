namespace Refactoring
{
    public class AddressDTO
    {
        private CountryDTO country;
        private StatusDTO status;
        private TypeDTO type;

        public CountryDTO Country
        {
            get {
                return country;
            }
            set {
                country = value;
            }
        }

        public StatusDTO Status
        {
            get {
                return status;
            }
            set {
                status = value;
            }
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
    }
}
