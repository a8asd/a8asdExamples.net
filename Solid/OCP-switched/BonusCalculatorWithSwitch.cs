using System;
using System.Collections.Generic;

namespace Solid
{
    public class BonusCalculatorWithSwitch
    {
        public double CalculateBonus(List<EmployeeWithTypeProperty> employees)
        {
            var total = 0.0d;
            foreach (var employee in employees)
            {
                switch (employee.Type)
                {
                    case EmployeeType.Good:
                        total += 1000*.20;
                        break;
                    case EmployeeType.Indifferent:
                        total += 900*.15;
                        break;
                    case EmployeeType.Bad:
                        total += 800*.10;
                        break;
                    case EmployeeType.Ugly:
                        total += 700*0.01;
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            return total;
        }
    }
}