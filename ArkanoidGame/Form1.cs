using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArkanoidGame.Classes;
using System.Collections;

namespace ArkanoidGame
{
    public partial class Form1 : Form
    {
        //player platform
        private PlayerPlatform player;
        //list of bricks
        private List<Brick> bricks = new List<Brick>();
        //ball
        private Ball ball;

        List<GameObject> objects = new List<GameObject>();

        List<GameObject> alive = new List<GameObject>();

        public Form1()
        {
            InitializeComponent();

            //add borders around picturebox/main canvas
            gameCanvas.BorderStyle = BorderStyle.FixedSingle;

            //setting picture box size
            gameCanvas.Size = new Size(Constants.CANVAS_WIDTH, Constants.CANVAS_HEIGHT);
            
            //reset the stats
            new Stats();

            //start the game timer. the rate at which the game will refresh
            gameTimer.Interval = 1000 / Constants.SPEED;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //start the game
            //TODO: will start the game on button click
            StartGame();

        }

        private void StartGame()
        {
            //reset the stats
            new Stats();

            //reset the lists
            objects.Clear();
            alive.Clear();
            bricks.Clear();

            //place the platform at the bottom in the middle
            player = new PlayerPlatform(gameCanvas.Size.Width/2 - Constants.PLATFORM_WIDTH/2, gameCanvas.Size.Height - Constants.PLATFORM_HEIGHT,
                Brushes.Blue, Constants.PLATFORM_WIDTH, Constants.BRICK_HEIGHT);

            objects.Add(player);

            int topLineOffset = 30;
            //add lines of bricks
            for (int i = 0; i < Constants.BRICK_ROW_COUNT; i++)
            {
                for (int j = 0; j < Constants.BRICK_COUNT; j++)
                {
                    bricks.Add(new Brick(j * Constants.BRICK_WIDTH, topLineOffset + (i * Constants.BRICK_HEIGHT), Brick.colors[i], 
                        Constants.BRICK_WIDTH, Constants.BRICK_HEIGHT));
                    
                }
            }
            objects.AddRange(bricks);

            // spawn a ball
            ball = new Ball(100, 100, Brushes.Black, 15, 15, 4, 4); // ball speed has to be one for precision as ints are used

            objects.Add(ball);
            

            gameScore.Text = Stats.Score.ToString();

            //update the lives
            livesCount.Text = Stats.Lives.ToString();
        }

        private void ResetGame()
        {
            //update the lives
            livesCount.Text = Stats.Lives.ToString();

            //add new ball to the game
            ball = new Ball(100, 100, Brushes.Black, 15, 15, 4, 4);
            objects.Add(ball);
            Stats.Reset = false;
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            // if game reset
            if (Stats.Reset)
            {
                if (Stats.Lives >= 0)
                {
                    ResetGame();
                }
                
            }

            // if game is not started yet or a player has lost the match
            if (Stats.GameOver)
            {
                GameOverLabel.Visible = true;
                restartLabel.Visible = true;
                //press enter or button to start the match

                if (Input.GetKeyPressed(Keys.Enter))
                {
                    StartGame();
                }    

            } else // the match has started
            {
                GameOverLabel.Visible = false;
                restartLabel.Visible = false;

                if (Input.GetKeyPressed(Keys.D))
                {
                    //MovePlatform(0); // moves the platform right
                    player.direction = Constants.PLATFORM_SPEED;
                } else if (Input.GetKeyPressed(Keys.A))
                {
                    player.direction = -Constants.PLATFORM_SPEED;
                } else
                {
                    player.direction = 0;
                }
            }

            alive = new List<GameObject>();

            //check for ball collisions
            foreach (GameObject obj in objects)
            {
                //only collide once. because of the ints it might collide with more than 1. This fixes some problems
                if (!ball.collided)
                    ball.CollisionHandling(obj);

                if (!obj.dead) //if the objects is alive
                {
                    
                    alive.Add(obj); // add all alive objects
                    obj.Update();
                }
                
            }
            // resetting collision
            ball.collided = false;

            //update the the object list
            objects.Clear();
            objects.AddRange(alive);

            //update the points
            gameScore.Text = Stats.Score.ToString();

            //update the GUI
            gameCanvas.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void gameCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (!Stats.GameOver)
            {                
                foreach (GameObject obj in alive)
                {
                    obj.Draw(g);
                }

            }
        }
    }
}
