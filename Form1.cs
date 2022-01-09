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
    }
}
