using System.Collections.Generic;

namespace Solid
{
    public class PolymorphicBonusCalculator
    {
        public double CalculateBonus(List<PolymorphicEmployee> employees)
        {
            double totalBonuses = 0;
            foreach (var employee in employees)
            {
                totalBonuses += employee.Bonus;
            }
            return totalBonuses;
        }
    }
}
