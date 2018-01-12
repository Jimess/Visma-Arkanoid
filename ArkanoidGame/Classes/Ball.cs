using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame.Classes
{
    class Ball : GameObject
    {
        int velocityX;
        int velocityY;
        public bool collided = false;

        public Ball(int X, int Y, Brush Color, int Width, int Height, int VelocityX, int VelocityY) : base(X, Y, Color, Width, Height)
        {
            this.velocityX = VelocityX;
            this.velocityY = VelocityY;
        }

        public override void Update()
        {
            X += velocityX;
            Y += velocityY;

            //checks only for game bounds
            if (X >= Constants.CANVAS_WIDTH - Width || X <= 0)
            {
                velocityX = -velocityX;
            } else if (Y <= 0)
            {
                velocityY = -velocityY;
            } else if (Y >= Constants.CANVAS_HEIGHT - Height) //ball has reached the bottom
            {
                Stats.TakeLife();
                dead = true;
            }
        }

        // checks if tho objects have collided
        public bool Overlap (GameObject other)
        {
            //a way to detect collision. This method is not perfect as it will only count the collision
            //when one object is already inside another. This can raise some collision problems as INTS are used and not doubles
            Rectangle gameObject = new Rectangle(X, Y, Width, Height);
            Rectangle otherObject = new Rectangle(other.X, other.Y, other.Width, other.Height);

            if (gameObject.IntersectsWith(otherObject))
            {
                collided = true;
                return true;
            }

            return false;
        }
        

        public void CollisionHandling (GameObject other)
        {
            if (other.GetType() != GetType() && Overlap(other))
            {
                this.velocityY = -velocityY;
                if (other.GetType() != typeof(PlayerPlatform)) //brick is hit
                {
                    other.dead = true; //destroy brick\
                    Stats.AddPoints(); // adding points for brick
                }
                    
                Console.WriteLine("Handling collision");
            }
        }
    }
}
