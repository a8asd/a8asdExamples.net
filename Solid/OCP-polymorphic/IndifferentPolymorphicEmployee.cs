namespace Solid
{
    public class IndifferentPolymorphicEmployee : PolymorphicEmployee
    {
        public override double Bonus
        {
            get { return Salary*0.15; }
        }

        public IndifferentPolymorphicEmployee()
        {
            Salary = 900;
        }
    }
}