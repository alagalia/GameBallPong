using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private int Player1X = 1212;
        private int Player1Y = 203;
        private int Player2X = 12;
        private int Player2Y = 230;
        private int PlayerSpeed = 20;
        private int initialPlayer1X = 1212;
        private int initialPlayer1Y = 230;
        private int initialPlayer2X = 12;
        private int initialPlayer2Y = 230;
        private bool secondPlayer = true;
        private int difficulty = 90;
        private bool movingRight = true;
        private bool movingUp = true;
        private int ballSpeed = 20;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!secondPlayer) Move_AI(difficulty);
            Invalidate();

        }
    }
}
