using System.Collections.Generic;
using System.Xml.Schema;

namespace Solid
{
    public class PolymorphicSalaryCalculator
    {
        public double CalculateSalary(List<PolymorphicEmployee> employees)
        {
            double totalSalaries = 0;
            foreach (var employee in employees)
            {
                totalSalaries += employee.Salary;
            }
            return totalSalaries;
        }
    }
}