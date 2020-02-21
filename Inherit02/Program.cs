using System;
namespace inheritance_0020
{
    class Vector: Object
    {
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
        public override string ToString() => $"X={X} Y={Y}";
    }
    class MyObject : Vector
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyObject obj1 = new MyObject
            {
                X = 10,
                Y = 20
            };
            Console.WriteLine(obj1);
            Console.ReadKey();
        }
    }
}