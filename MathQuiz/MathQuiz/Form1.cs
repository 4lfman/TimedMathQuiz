using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //Create a Random object called randomizer
        //to generate random numbers.
        Random randomizer = new Random();

        //Declare the variables that will store the values for the term in the addition 
        int addend1;
        int addend2;

        //Keeps track of the remaining time
        int timeLeft;

        private void StartTheQuiz()
        {
            //Generates random terms for the addition
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //Displays the numbers in the form
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //Makes sure the box for entering the 
            //answer is set to zero at beginning
            sum.Value = 0;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(timeLeft > 0)
            {
                timeLeft -= 1;
                timeLabel.Text = timeLeft + " seconds";
            }
        }
    }
}
