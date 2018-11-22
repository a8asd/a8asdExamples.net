namespace Refactoring
{
    public class CountryDTO
    {
        private int id;
        private RegulatorDTO regulator;

        public int Id
        {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        public RegulatorDTO Regulator
        {
            get {
                return regulator;
            }
            set {
                regulator = value;
            }
        }
    }
}
