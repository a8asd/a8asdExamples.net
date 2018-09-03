namespace Solid
{
    public class BadPolymorphicEmployee : PolymorphicEmployee
    {
        public override double Bonus
        {
            get { return Salary*0.10; }
        }

        public BadPolymorphicEmployee()
        {
            Salary = 800;
        }
    }
}

