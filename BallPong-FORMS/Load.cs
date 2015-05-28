using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Load : Form
    {
        private bool oneLeft = false;
        private bool pickedBothColors = false;
        private bool errorBreak = false;
        public int aiDifficulty = 0;
        public int ballSpeed;
        public Load()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            textBox1.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false; 
            textBox1.Enabled = true;
        }

        private void Load_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void PlayersColorSelected(Button color)
        {
            if (oneLeft)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                Public_Properties.Player2Color = color.BackColor;
                label6.Text = "Цветовете са запаметени!";
                pickedBothColors = true;
            }
            else
            {
                label6.Text = "Изберете цвят за играч 2:";
                oneLeft = true;
                Public_Properties.Player1Color = color.BackColor;
            }
            color.FlatAppearance.BorderSize = 4;
            color.FlatAppearance.BorderColor = Color.DarkOrchid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayersColorSelected(button1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PlayersColorSelected(button6);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PlayersColorSelected(button5);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PlayersColorSelected(button4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlayersColorSelected(button3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayersColorSelected(button2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PlayersColorSelected(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && radioButton2.Checked) Error("Напишете име за играч 2!");
            if (textBox2.Text == "") Error("Напишете име за играч 1!");
            if (comboBox1.SelectedItem==null && radioButton1.Checked) Error("Изберете трудност!");
            if (!pickedBothColors) Error("Изберете цветове!");
            if (comboBox2.SelectedItem==null) Error("Изберете бързината на топката!");
            if (!errorBreak)
            {
                Public_Properties.Player1Name = textBox2.Text;
                if (radioButton2.Checked) Public_Properties.Player2Name = textBox1.Text;
                else Public_Properties.Player2Name = "AI: " + comboBox1.SelectedItem;
                if (radioButton1.Checked)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            aiDifficulty = 10;
                            break;
                        case 1:
                            aiDifficulty = 30;
                            break;
                        case 2:
                            aiDifficulty = 50;
                            break;
                        case 3:
                            aiDifficulty = 70;
                            break;
                        case 4:
                            aiDifficulty = 90;
                            break;
                    }
                    Public_Properties.Difficulty = aiDifficulty;
                }
                else Public_Properties.Difficulty = 0;
                switch (comboBox2.SelectedIndex)
                {
                    case 0:
                        ballSpeed = 10;
                        break;
                    case 1:
                        ballSpeed = 15;
                        break;
                    case 2:
                        ballSpeed = 20;
                        break;
                }
                Public_Properties.BallSpeed = ballSpeed;
                if (checkBox1.Checked) Public_Properties.HelpEnabled = true;
                Form1 play = new Form1();
                this.Hide();
                DialogResult closed=play.ShowDialog();
                if (closed == DialogResult.Cancel)
                {
                    this.Show();
                    this.Focus();
                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.SelectedItem = null;
                    radioButton1.Checked = true;
                    ResetColors(button1);
                    ResetColors(button2);
                    ResetColors(button3);
                    ResetColors(button4);
                    ResetColors(button5);
                    ResetColors(button6);
                    oneLeft = false;
                    pickedBothColors = false;
                    errorBreak = false;
                    aiDifficulty = 0;

                    label6.Text = "Изберете цвят за играч 1:";
                }
            }
            errorBreak = false;
        }

        private void ResetColors(Button button)
        {
            button.Enabled = true;
            button.FlatAppearance.BorderSize = 0;
        }

        private void Error(string error)
        {
            MessageBox.Show(error);
            errorBreak = true;
        }
    }
}
