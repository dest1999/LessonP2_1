using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tryLists
{
    class Department
    {
        public string DepartmentName { get; set; }

        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
        }

    }

    struct Address
    {
        public uint Code;
        public string Country;
        public string City;
        public string Street;
    }

    class Human
    {
        Random rnd = new Random();
        public int Age { get; set; }
        public int Weigth { get; set; }
        public Address address = new Address();

        public virtual void TestingWrite()
        {
            Console.WriteLine("Testing Write from HumanClass");
        }
    }


    class Employee: Human
    {
        public string Name { get; set; }
        new public int? Age { get; set; }

        public Employee()
        {
            Name = "Unknown";
            Age = null;
        }
        public Employee(string Name)
        {
            this.Name = Name;
            Age = null;
        }
        public Employee(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public override void TestingWrite()
        {
            Console.WriteLine("Testing Write from EmployeeClass");
            base.TestingWrite();
        }

        

    }

    public class TClass
    {

    }


    class Program
    {



        static void Main(string[] args)
        {

            



            List<Employee> employees = new List<Employee>
            {
                new Employee("Alice", 19),
                new Employee("Bob", 21),
                new Employee("Ched", 55)
            };

            Console.WriteLine($"Записей всего: {employees.Count}");
            employees.Add(new Employee("Diana", 48));

            Console.Write("Enter zip-code for employee #2: ");
            employees[1].address.Code = (uint)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{employees[1].Name} is {employees[1].Age }");

            Console.Write("Enter new name for employee #1: ");
            employees[0].Name = Console.ReadLine();

            employees[0].TestingWrite();

            foreach (Employee human in employees)
                Console.WriteLine(human.Name + " is " + human.Age);

            Console.ReadKey();
        }
    }
}
