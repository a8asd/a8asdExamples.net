using System.Collections.Generic;
using NUnit.Framework;

namespace Solid
{
    [TestFixture]
    public class SalaryTest
    {
        private readonly List<EmployeeWithTypeProperty> employeesWithTypeProperty = new List<EmployeeWithTypeProperty>()
        {
            new EmployeeWithTypeProperty(EmployeeType.Good),
            new EmployeeWithTypeProperty(EmployeeType.Indifferent),
            new EmployeeWithTypeProperty(EmployeeType.Bad),
            new EmployeeWithTypeProperty(EmployeeType.Ugly)
        };

        [Test]
        public void EmployeeWithTypeProperty()
        {
            var salaryCalculatorWithSwitch = new SalaryCalculatorWithSwitch();
            var salary = salaryCalculatorWithSwitch.CalculateSalary(employeesWithTypeProperty);
            Assert.AreEqual(3400.0, salary);
        }

        private readonly List<PolymorphicEmployee> polymorphicEmployees = new List<PolymorphicEmployee>()
        {
            Solid.PolymorphicEmployee.Create(EmployeeType.Good),
            Solid.PolymorphicEmployee.Create(EmployeeType.Indifferent),
            Solid.PolymorphicEmployee.Create(EmployeeType.Bad),
            Solid.PolymorphicEmployee.Create(EmployeeType.Ugly)
        };

        [Test]
        public void PolymorphicEmployee()
        {
            var polymorphicSalaryCalculator = new PolymorphicSalaryCalculator();
            var salary = polymorphicSalaryCalculator.CalculateSalary(polymorphicEmployees);
            Assert.AreEqual(3400.0, salary);
        }
    }
}