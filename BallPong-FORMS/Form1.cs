using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Rectangle circle= new Rectangle(200,300,15,15); // позиция - x,y, размери височина и ширина на топката
        private Rectangle wall;
        private bool movingRight = true;
        private bool movingUp = true;
        private int Player1X = 1212;
        private int Player1Y = 203;
        private int Player2X = 12;
        private int Player2Y = 230;
        private int PlayerSpeed = 20;
        private bool scored = false;
        private bool paused = false;
        private int intitialBallX;
        private int initialBallY;
        private int initialPlayer1X = 1212;
        private int initialPlayer1Y = 230;
        private int initialPlayer2X = 12;
        private int initialPlayer2Y = 230;
        private int timer2Counter = 2;
        private bool scorePause = false;
        private int maxScore = 9;
        private bool gameOver = false;
        private bool spawnedWall = false;
        private int wallTurnCounter = 0;
        private int wallTmpX;
        private int wallTmpY;
        private int wallTurns = 150;
        private bool secondPlayer = false;
        private int ballSpeed = Public_Properties.BallSpeed;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // това е метода, който се изпълнява при отварянето на формата
        {
            SetInitialPositions();
            pictureBox1.BackColor = Public_Properties.Player1Color;
            pictureBox2.BackColor = Public_Properties.Player2Color;
            label1.Text = Public_Properties.Player2Name;
            label2.Text = Public_Properties.Player1Name;
            if (Public_Properties.Difficulty == 0) secondPlayer = true;
            timer1.Enabled = true;
            timer1.Start(); //пускам таймера и той започва да влиза в метода долу
            this.DoubleBuffered = true; // има малко лаг, но стената и топката не премигват
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawEllipse(new Pen(Color.Red,2),circle );
            g.FillEllipse(new SolidBrush(Color.Red),circle );
            if (spawnedWall)
            {
                wall = new Rectangle(wallTmpX, wallTmpY, 10, 60);
                g.DrawRectangle(new Pen(Color.White,2),wall);
                g.FillRectangle(new SolidBrush(Color.White),wall );
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (circle.IntersectsWith(pictureBox1.Bounds)) movingRight = false;
            else if (circle.IntersectsWith(pictureBox2.Bounds)) movingRight = true;
            if (circle.IntersectsWith(pictureBox3.Bounds)) movingUp = false;
            else if (circle.IntersectsWith(pictureBox4.Bounds)) movingUp = true;
            if (movingRight) circle.X += ballSpeed;
            else circle.X -= ballSpeed;
            if (movingUp) circle.Y -= ballSpeed;
            else circle.Y += ballSpeed;
            if (circle.IntersectsWith(wall))
            {
                movingRight = !movingRight;
            }
            if (!secondPlayer) Move_AI(Public_Properties.Difficulty);
            SpawnRandomWall();
            CheckForPoint();
            Invalidate();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!paused)
            {
                if (e.KeyCode == Keys.Up)
                {
                    if (!pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds)) Player1Y -= PlayerSpeed;
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (!pictureBox1.Bounds.IntersectsWith(pictureBox4.Bounds)) Player1Y += PlayerSpeed;
                }
                pictureBox1.Location = new Point(Player1X, Player1Y);
                if (secondPlayer)
                {
                    if (e.KeyCode == Keys.W)
                    {
                        if (!pictureBox2.Bounds.IntersectsWith(pictureBox3.Bounds)) Player2Y -= PlayerSpeed;
                    }
                    if (e.KeyCode == Keys.S)
                    {
                        if (!pictureBox2.Bounds.IntersectsWith(pictureBox4.Bounds)) Player2Y += PlayerSpeed;
                    }
                    pictureBox2.Location = new Point(Player2X, Player2Y);
                }
            }
            if (e.KeyCode == Keys.P && !scorePause)
            {
                if (paused)
                {
                    paused = false;
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                    paused = true;
                }
            }
            if (gameOver)
            {
                if (e.KeyCode == Keys.Space)
                {
                    this.Close();
                }
            }
        }

        private void Move_AI(int diffictulty)
        {
            Random rnd = new Random();
            int tmp = rnd.Next(0, 101);
            if (tmp < diffictulty)
            {
                if (movingUp)
                {
                    if (!pictureBox2.Bounds.IntersectsWith(pictureBox3.Bounds))
                    {
                        Player2Y -= ballSpeed;
                        pictureBox2.Location = new Point(Player2X, Player2Y);
                    }
                }
                else
                {
                    if (!pictureBox2.Bounds.IntersectsWith(pictureBox4.Bounds))
                    {
                        Player2Y += ballSpeed;
                        pictureBox2.Location = new Point(Player2X, Player2Y);
                    }
                }
            }
        }

        private void CheckForPoint()
        {
            if (circle.X <= ClientRectangle.Left)
            {
                scored = true;
                Public_Properties.Player1Score++;
            }
            if (circle.X >= ClientRectangle.Width)
            {
                scored = true;
                Public_Properties.Player2Score++;
            }
            if (Public_Properties.Player1Score == maxScore) Winner(Public_Properties.Player1Name);
            else if (Public_Properties.Player2Score==maxScore) Winner(Public_Properties.Player2Name);
            else if (scored)
            {
                UpdateScores();
                timer1.Stop();
                label6.Visible = true;
                SetInitialPositions();
                scored = false;
                scorePause = true;
                timer2.Enabled = true;
                timer2.Start();
            }
        }

        private void Winner(string player)
        {
            label6.Visible = true;
            label6.Text = player+"\n    WINS!";
            timer1.Stop();
            gameOver = true;
        }
        private void UpdateScores()
        {
            label3.Text = Public_Properties.Player2Score.ToString();
            label4.Text = Public_Properties.Player1Score.ToString();
        }

        private void SetInitialPositions()
        {
            intitialBallX = ClientRectangle.Width/2;
            initialBallY = ClientRectangle.Height/2;
            Random rand=new Random();
            if (rand.Next(1, 51) >= 25) movingRight = !movingRight;
            if (rand.Next(1, 51) <= 25) movingUp = !movingUp;
            pictureBox1.Location=new Point(initialPlayer1X,initialPlayer1Y);
            pictureBox2.Location = new Point(initialPlayer2X, initialPlayer2Y);
            Player1X = initialPlayer1X;
            Player1Y = initialPlayer1Y;
            Player2X = initialPlayer2X;
            Player2Y = initialPlayer2Y;
            circle.X = intitialBallX;
            circle.Y = initialBallY;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label7.Visible = true;
            label7.Text = timer2Counter.ToString();
            timer2Counter--;
            if (Public_Properties.HelpEnabled)DirectionsHelp();
            if (timer2Counter == -1)
            {
                label6.Visible = false;
                timer2.Stop();
                label7.Visible = false;
                timer2Counter = 2;
                scorePause = false;
                timer1.Start();
                pictureBox5.Visible = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Public_Properties.Player1Score = 0;
            Public_Properties.Player2Score = 0;
        }

        private void SpawnRandomWall()
        {
            if (!spawnedWall)
            {
                Random rnd = new Random();
                if (rnd.Next(1, 101) <= 20)
                {
                    wallTmpX = rnd.Next(110, 1101);
                    wallTmpY = rnd.Next(0, 700);
                    spawnedWall = true;
                }
            }
            else
            {
                wallTurnCounter++;
                if (wallTurnCounter == wallTurns)
                {
                    wallTurnCounter = 0;
                    spawnedWall = false;
                }
            }
        }

        private void DirectionsHelp()
        {
            if (movingRight)
            {
                if (movingUp) pictureBox5.Location=new Point(1069,43);
                else pictureBox5.Location=new Point(1069,568);
                pictureBox5.Image = Properties.Resources.arrow;
            }
            else
            {
                if (movingUp) pictureBox5.Location=new Point(97,43);
                else pictureBox5.Location=new Point(97,568);
                pictureBox5.Image = Properties.Resources.arrow2;
            }
            pictureBox5.Visible = true;
        }
    }
}
