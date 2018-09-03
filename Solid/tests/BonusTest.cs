using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Solid
{
    [TestFixture]
    public class BonusTest
    {
        private readonly List<EmployeeWithTypeProperty> employeesWithTypeProperty = new List<EmployeeWithTypeProperty>()
        {
            new EmployeeWithTypeProperty(EmployeeType.Good),
            new EmployeeWithTypeProperty(EmployeeType.Indifferent),
            new EmployeeWithTypeProperty(EmployeeType.Bad),
            new EmployeeWithTypeProperty(EmployeeType.Ugly)
        };
        [Test]
        public void EmployeeWithTypePropertyBonus()
        {
            var bonusCalculatorWithSwitch = new BonusCalculatorWithSwitch();

            var bonus = bonusCalculatorWithSwitch.CalculateBonus(employeesWithTypeProperty);
            Assert.AreEqual(422.0, bonus, 2);
        }



        private readonly List<PolymorphicEmployee> polymorphicEmployees = new List<PolymorphicEmployee>()
        {
            PolymorphicEmployee.Create(EmployeeType.Good),
            PolymorphicEmployee.Create(EmployeeType.Indifferent),
            PolymorphicEmployee.Create(EmployeeType.Bad),
            PolymorphicEmployee.Create(EmployeeType.Ugly)
        };

        [Test]
        public void PolymorphicEmployeeBonus()
        {
            var polymorphicBonusCalculator = new PolymorphicBonusCalculator();
            var bonus = polymorphicBonusCalculator.CalculateBonus(polymorphicEmployees);
            Assert.AreEqual(422.0, bonus, 2);
        }

    }
}