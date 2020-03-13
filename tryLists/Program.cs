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


    class Employee
    {
        public string Name { get; set; }
        public int? Age { get; set; }

        public Employee()
        {
            this.Name = "Unknown";
            this.Age = null;
        }
        public Employee(string Name)
        {
            this.Name = Name;
            this.Age = null;
        }
        public Employee(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee("Alice", 19),
                new Employee("Bob", 21),
                new Employee("Chack", 55)
            };


            Console.WriteLine($"Записей всего: {employees.Count}");


            Console.WriteLine($"{employees[1].Name} is {employees[1].Age }");
            employees[0].Name = Console.ReadLine();

            foreach (Employee human in employees) Console.WriteLine(human.Name + " is " + human.Age);

            Console.ReadKey();
        }
    }
}
