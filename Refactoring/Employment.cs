
using System;

namespace Refactoring
{
    public class Employment
    {
        private PersonDTO regulator;
        private AddressDTO employerAddress;

        public PersonDTO Regulator
        {
            get {
                return regulator;
            }
            set {
                regulator = value;
            }
        }

        public AddressDTO EmployerAddress
        {
            get {
                return employerAddress;
            }
            set {
                employerAddress = value;
            }
        }
    }
}
