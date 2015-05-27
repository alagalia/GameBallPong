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
        }
    }
}