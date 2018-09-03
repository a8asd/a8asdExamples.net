using System;
using System.Collections.Generic;

namespace Solid
{
    public class SalaryCalculatorWithSwitch
    {
        public double CalculateSalary(List<EmployeeWithTypeProperty> employees)
        {
            var total = 0.0d;
            foreach (var employee in employees)
            {
                switch (employee.Type)
                {
                    case EmployeeType.Good:
                        total += 1000;
                        break;
                    case EmployeeType.Indifferent:
                        total += 900;
                        break;
                    case EmployeeType.Bad:
                        total += 800;
                        break;
                    case EmployeeType.Ugly:
                        total += 700;
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            return total;
        }
    }
}
