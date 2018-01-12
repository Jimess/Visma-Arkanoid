using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ArkanoidGame.Classes
{
    class PlayerPlatform : GameObject
    {
        public int direction;

        public PlayerPlatform(int X, int Y, Brush Color, int Width, int Height) : base(X, Y, Color, Width, Height) { }

        public override void Update()
        {
            //clamp position so the platform does not leave the map
            X += direction;
            X = Clamp(X, 0, Constants.CANVAS_WIDTH - Constants.PLATFORM_WIDTH);
           
        }

        // clamps 
        public int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }
    }
}
