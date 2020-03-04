using System;
namespace inheritance_0020
{
    class Vector: Object
    {
        internal int Z;

        public double X { get; set; }
        public double Y { get; set; }
        // Переопределим конструктор по умолчанию        
        public Vector()
        {
            X = Y = 0;
        }
        // Конструктор, который будет заполнять поля объекта
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Метод для получения данных в строковой форме
        public override string ToString() => $"X = {X}, Y = {Y}";
    }
    class MyObject : Vector
    {
    }

    class Animals <T1, T2, T3> { }

    interface I1 { }



    class Program
    {
        static void Yes(int i)
        {
            Console.WriteLine($"Yes, it number: {i}");
        }

        static void No()
        {
            Console.WriteLine("It is not a number");
        }


        static void Main(string[] args)
        {
            Vector obj1 = new Vector { X = 4, Z = 5 };

            obj1.X = 50;


            Console.WriteLine(obj1);
            int i;


            if (Int32.TryParse(Console.ReadLine(), out i))
                Yes(i);
            else
                No();




            Console.ReadKey();
        }
    }
}