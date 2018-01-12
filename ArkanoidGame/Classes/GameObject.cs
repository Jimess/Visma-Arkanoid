using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ArkanoidGame.Classes
{
    public abstract class GameObject
    {
        //positions vars
        public int X { get; set; }
        public int Y { get; set; }
        Brush Color; // set up different colour for different GameObjects
        public int Width { get; set; }
        public int Height { get; set; }
        public bool dead = false;


        public GameObject(int X, int Y, Brush Color, int Width, int Height)
        {
            this.X = X;
            this.Y = Y;
            this.Color = Color;
            this.Width = Width;
            this.Height = Height;
        }


        //draw for player platform and game bricks is the same as both objects are rectangles
        // color, width and height is different. When creating objects they will have to be included in constructor
        // if there were more different objects the draw method would've been public abstract void
        public void Draw(Graphics g)
        {
            g.FillRectangle(Color, new Rectangle(X, Y, Width, Height));
        }

        // update methods is responsible for moving objects. in this case it will be abstract even though the bricks will not be moving;
        public abstract void Update();
    }
}
