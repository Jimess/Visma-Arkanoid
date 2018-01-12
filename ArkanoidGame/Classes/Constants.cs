using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame.Classes
{
    //Constants that will never change
    public class Constants
    {
        //player platform size
        public static readonly int PLATFORM_HEIGHT = 20;
        public static readonly int PLATFORM_WIDTH = 80;
        public static readonly int PLATFORM_SPEED = 5;

        //upper platform size
        public static readonly int BRICK_HEIGHT = 20;
        public static readonly int BRICK_WIDTH = 65;

        //main canvas size
        public static readonly int CANVAS_WIDTH = 650;
        public static readonly int CANVAS_HEIGHT = 650;


        //count of how many bricks fit into on row
        public static readonly int BRICK_COUNT = CANVAS_WIDTH / BRICK_WIDTH;
        public static readonly int BRICK_ROW_COUNT = 3;

        public static readonly int SPEED = 36;
    }
}
