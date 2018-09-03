using System;

namespace Solid
{

    public abstract class PolymorphicEmployee
    {
        public int Salary { get; protected set; }
        public abstract double Bonus { get; }

        public static PolymorphicEmployee Create(EmployeeType type)
        {
            switch (type)
            {
                case EmployeeType.Good:
                    return new GoodPolymorphicEmployee();
                case EmployeeType.Bad:
                    return new BadPolymorphicEmployee();
                case EmployeeType.Ugly:
                    return new UglyPolymorphicEmployee();
                case EmployeeType.Indifferent:
                    return new IndifferentPolymorphicEmployee();
                default:
                    throw new ArgumentException();
            }
        }
    }
}