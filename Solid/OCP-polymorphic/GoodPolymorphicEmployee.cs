namespace Solid
{
    public class GoodPolymorphicEmployee : PolymorphicEmployee
    {
        public override double Bonus
        {
            get { return Salary*0.2; }
        }

        public GoodPolymorphicEmployee()
        {
            Salary = 1000;
        }
    }
}