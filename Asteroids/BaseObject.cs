using System;
using System.Drawing;



namespace Asteroids
{

    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }

    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        protected BaseObject(int x, int y, int dx, int dy, int width, int height)
        {
            Pos = new Point(x, y);
            Dir = new Point(dx, dy);
            Size = new Size(width, height);
        }

        public abstract void Draw();
        public abstract void Update();

        //public bool Collision(ICollision obj) => obj.Rect.IntersectsWith(this.Rect);
        public virtual bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }

        //public Rectangle Rect => new Rectangle(Pos, Size); одно и то же
        public Rectangle Rect
        {
            get
            {
                return new Rectangle(Pos, Size);
            }
        }
    }


    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override bool Collision(ICollision obj) //на столкновение со звездами не реагируем
        {
            return false;
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
                Pos.Y = Game.rnd.Next(Game.Height);
            }
        }
    }

    class Asteroid : BaseObject
    {
        static Image image = Image.FromFile("Images\\asteroid.png");
        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0)          //ушли влево
                Pos.X = Game.Width;
            if (Pos.X > Game.Width) //ушли вправо
                Pos.X = 0;
            if (Pos.Y < 0)          //ушли вверх
                Pos.Y = Game.Height;
            if (Pos.Y > Game.Height)//ушли вниз
                Pos.Y = 0;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }

    class Ship : BaseObject
    {
        private int _energy = 100;
        public int Energy => _energy;

        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }
        public void Die()
        {
        }
    }

    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X += Dir.X; // устанавливаем скорость полёта выстрела, нелинейное приращение?
            if (Pos.X > Game.Width)
                Pos.X = 0;
                

        }

    }


}

