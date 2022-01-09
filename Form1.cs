using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimedMathQuiz
{
    public partial class Form1 : Form
    {

        Random randomizer = new Random();

        int adden1;
        int adden2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        void StartTheQuiz()
        {
            adden1 = randomizer.Next(51);
            adden2 = randomizer.Next(51);

            plusLeftLabel.Text = adden1.ToString();
            plusRightLabel.Text = adden2.ToString();

            sum.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int tempQuot = randomizer.Next(2, 11);
            dividend = divisor * tempQuot;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 Seconds";
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congradulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " Seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's Up!";
                MessageBox.Show("You didn't finish in time.", "Sorry");
                sum.Value = adden1 + adden2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private bool CheckTheAnswer()
        {
            if ((adden1 + adden2 == sum.Value) && 
                (minuend - subtrahend == difference.Value) && 
                (multiplicand * multiplier == product.Value) && 
                (dividend / divisor == quotient.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown anserbox = sender as NumericUpDown;

            if (anserbox != null)
            {
                int lenghtOfAnswer = anserbox.Value.ToString().Length;
                anserbox.Select(0, lenghtOfAnswer);
            }
        }
    }
}
