using System;
using System.Drawing;
using System.Windows.Forms;

namespace carrrr
{
    public partial class Form1 : Form
    {
        int score = 0;
        int timeLeft = 30;
        int targetSlot = 1;
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            timer1.Enabled = false;
            timer1.Stop();

            timeLeft = 30;

            label2.Text = score.ToString();
            label4.Text = timeLeft.ToString() + " san";
            label6.Text = "";

            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();

            targetSlot = r.Next(1, 6);

            pictureBox1.Location = new Point(650, 520);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            label4.Text = timeLeft.ToString() + " san";

            if (timeLeft <= 0)
            {
                timer1.Enabled = false;
                timer1.Stop();
                MessageBox.Show("Vaxt bitdi! Oyun başa çatdı.", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = pictureBox1.Top - 20;
            CheckParkingPosition();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Left = pictureBox1.Left - 20;
            CheckParkingPosition();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Left = pictureBox1.Left + 20;
            CheckParkingPosition();
        }

        private void CheckParkingPosition()
        {
            int currentSlot = 0;

            if (pictureBox1.Top <= panel2.Bottom - (panel2.Height / 2) && pictureBox1.Bounds.IntersectsWith(panel2.Bounds))
            {
                currentSlot = 1;
            }
            else if (pictureBox1.Top <= panel3.Bottom - (panel3.Height / 2) && pictureBox1.Bounds.IntersectsWith(panel3.Bounds))
            {
                currentSlot = 2;
            }
            else if (pictureBox1.Top <= panel4.Bottom - (panel4.Height / 2) && pictureBox1.Bounds.IntersectsWith(panel4.Bounds))
            {
                currentSlot = 3;
            }
            else if (pictureBox1.Top <= panel5.Bottom - (panel5.Height / 2) && pictureBox1.Bounds.IntersectsWith(panel5.Bounds))
            {
                currentSlot = 4;
            }
            else if (pictureBox1.Top <= panel6.Bottom - (panel6.Height / 2) && pictureBox1.Bounds.IntersectsWith(panel6.Bounds))
            {
                currentSlot = 5;
            }

            if (currentSlot == 0)
            {
                return;
            }

            if (currentSlot == targetSlot)
            {
                score = score + 1;
                label2.Text = score.ToString();

                label6.Text = "Düzgün park! +1";
                label6.ForeColor = Color.LightGreen;

                timer1.Enabled = false;
                timer1.Stop();
                MessageBox.Show("Təbriklər! Düzgün park etdiniz!", "Qələbə", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (score > 0)
                {
                    score = score - 1;
                }
                else
                {
                    score = 0;
                }

                label2.Text = score.ToString();

                label6.Text = "Səhv park! -1";
                label6.ForeColor = Color.IndianRed;

                MessageBox.Show("Səhv park yeri! Başqa yerə park edin.", "Səhv", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();
            StartNewGame();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}