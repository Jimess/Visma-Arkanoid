using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame.Classes
{
    class Brick : GameObject
    {
        public static readonly List<Brush> colors = new List<Brush> { Brushes.Red, Brushes.Black, Brushes.Gold, Brushes.Green};

        public Brick(int X, int Y, Brush Color, int Width, int Height) : base(X, Y, Color, Width, Height)
        {
        }

        public override void Update()
        {
        }
    }
}
