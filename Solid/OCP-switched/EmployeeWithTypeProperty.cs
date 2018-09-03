namespace Solid
{
    public class EmployeeWithTypeProperty
    {
        public EmployeeType Type {get; private set; }

        public EmployeeWithTypeProperty(EmployeeType type)
        {
            Type = type;
        }
    }
}