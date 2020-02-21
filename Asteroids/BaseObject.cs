using System;
using System.Drawing;

namespace Asteroids
{

    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public BaseObject(int x,int y,int dx,int dy,int width,int height)
        {
            Pos = new Point(x,y);
            Dir = new Point(dx,dy);
            Size = new Size(width,height);
        }


        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }


        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0)//ушли влево
            {
                Pos.X = Game.Width;
            }
            if (Pos.X > Game.Width)//ушли вправо
            {
                Pos.X = 0;// - Size.Width;
            }
            if (Pos.Y < 0)//ушли вверх
            {
                Pos.Y = Game.Height;
            }
            if (Pos.Y > Game.Height)//ушли вниз
            {
                Pos.Y = 0;// - Size.Height;
            }
        }
    }


    class Star: BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
                Random rnd = new Random();
                Pos.Y = rnd.Next(Game.Height);
            }
        }
    }

    class Asteroid:BaseObject
    {
        static Image image = Image.FromFile("Images\\asteroid.png");

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}

