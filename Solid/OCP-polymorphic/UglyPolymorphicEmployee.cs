namespace Solid
{
    public class UglyPolymorphicEmployee : PolymorphicEmployee
    {
        public override double Bonus
        {
            get { return 0.01*Salary; }
        }

        public UglyPolymorphicEmployee()
        {
            Salary = 700;
        }
    }
}