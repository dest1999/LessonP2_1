//расчет повременной и постоянной оплаты
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
    abstract class Employee
    {
        public double Pay { get; protected set; }
        public abstract double GetPay(int fee);
    }

    class TimeFeeWorker : Employee
    {
        public override double GetPay(int hourFee)
        {
            Pay = 20.8 * 8 * hourFee;
            return Pay;
        }
    }

    class ConstantFeeWorker : Employee
    {
        public override double GetPay(int constFee)
        {
            Pay = constFee;
            return constFee;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[10];//в организации 10 сотрудников
            Random rndForFee = new Random();

            for (int i = 0; i < employees.Length; i++)
            {
                if (i % 2 == 0)//заполняем массив сотрудников, постоянная и повременная оплаты чередуются
                {
                    TimeFeeWorker timeEmpl = new TimeFeeWorker();
                    timeEmpl.GetPay(rndForFee.Next(8, 15));
                    employees[i] = timeEmpl;
                }
                else
                {
                    ConstantFeeWorker constEmpl = new ConstantFeeWorker();
                    constEmpl.GetPay(rndForFee.Next(800, 1800));
                    employees[i] = constEmpl;
                }
            }

            double totalCostEmpls = 0;
            foreach (var e in employees)//подсчитаем сумму выплат
            {
                totalCostEmpls += e.Pay;
            }

            Console.WriteLine($"Total cost: {totalCostEmpls}");
            Console.ReadKey();
        }
    }
}
