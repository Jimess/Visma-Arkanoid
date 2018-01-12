using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame.Classes
{
    public class Stats
    {
        public static int Score { get; set; }
        public static bool GameOver { get; set; }
        public static int Lives { get; set; }
        public static bool Reset { get; set; }

        //default constructor
        //will only be called when the static variables need resetting
        public Stats()
        {
            Score = 0;
            GameOver = false;
            Lives = 3;
        }

        public static void AddPoints()
        {
            Score += 100;
        }

        public static void TakeLife() // resets the game ball if gameover is reached but player has more lives
        {
            if (Lives > 0)
            {
                Lives -= 1;
                Reset = true;
            } else
            {
                GameOver = true;
            }
        }
    }
}
