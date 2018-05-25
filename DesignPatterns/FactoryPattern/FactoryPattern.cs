using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public enum EmployeeType
    {
        Permanant = 1, Contract, Intern
    }

    interface IEmployee
    {
        string Name { get; set; }
        string Department { get; set; }
        double Salary { get; set; }
        double calculateBonus();
    }

    class PermanantEmployee : IEmployee
    {
        public string Department { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public PermanantEmployee(string name, string dept, double salary)
        {
            Name = name;
            Department = dept;
            Salary = salary;
        }

        public double calculateBonus()
        {
            return Salary * 10;
        }
    }

    class ContractEmployee : IEmployee
    {
        public string Department { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public ContractEmployee(string name, string dept, double salary)
        {
            Name = name;
            Department = dept;
            Salary = salary;
        }

        public double calculateBonus()
        {
            return Salary * 5;
        }
    }
    class InternEmployee : IEmployee
    {
        public string Department { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public InternEmployee(string name, string dept, double salary)
        {
            Name = name;
            Department = dept;
            Salary = salary;
        }

        public double calculateBonus()
        {
            return Salary * 1;
        }
    }

    // Add Factory to create employee as per type
    abstract class EmployeeFactory
    {
        public abstract IEmployee GetEmployee(string name, string dept, double salary, EmployeeType type);
    }

    class ConcreteEmployeeFactory : EmployeeFactory
    {
        public override IEmployee GetEmployee(string name, string dept, double salary, EmployeeType type)
        {
            IEmployee newEmployee = null;
            switch (type)
            {
                case EmployeeType.Permanant:
                    newEmployee = new PermanantEmployee(name, dept, salary);
                    break;
                case EmployeeType.Contract:
                    newEmployee = new ContractEmployee(name, dept, salary);
                    break;
                case EmployeeType.Intern:
                    newEmployee = new InternEmployee(name, dept, salary);
                    break;
                default:
                    break;
            }
            return newEmployee;
        }
    }

}
