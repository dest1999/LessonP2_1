using System;
namespace Class_Vector0010
{
    class Vector
    {

        // Теперь поля приватные
        private double _x;
        //private double _y;

        public double Y { get;private set; }




        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void SetX(double value)
        {
            _x = value;
        }

        public double GetX()
        {
            return _x;
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date=new DateTime(2020,15,19);
            //date.Month = 100;

            Vector v1;
            Vector v2;
            v2 = new Vector(-5, -10);
            v2.X = 10;
            v2.Y = 20;
        }
    }
}
