using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 1024;
            form.Height = 768;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }

}
