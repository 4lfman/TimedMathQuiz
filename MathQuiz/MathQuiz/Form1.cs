using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //Create a Random object called randomizer
        //to generate random numbers
        Random randomizer = new Random();

        //Declare the variables that will store the values for the term in the addition 
        int addend1;
        int addend2;

        //The integers for the subraction problem
        int minuend;
        int subtrahend;

        //Same for multiplication and division
        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        //Keeps track of the remaining time
        int timeLeft;

        SoundPlayer correctAnswer = new SoundPlayer(@"c:\Windows\Media\tada.wav");

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

            //Fill in the subtraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, 101);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //Fill in the subtraction problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //Fill in the division problem
            divisor = randomizer.Next(2, 11);
            int temproraryQuotiont = randomizer.Next(2, 11);
            dividend = divisor * temproraryQuotiont;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            //Start the timer
            timeLabel.BackColor = Color.Empty;
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
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
            if (CheckTheAnswer())
            {
                //If CheckTheAnswer true, stop the clock
                //and send a congratilation message
                //Also enables startButton
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Concratulations");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //Updates the time left by updating timeLabel
                timeLeft -= 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in the time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
            if(timeLeft == 5)
            {
                timeLabel.BackColor = Color.Red;
            }
        }


        //Checks if the answer is correct
        //<returns>True if the answer is correct, flase otherwise</returns>
        private bool CheckTheAnswer()
        {
            //The parentheses are (I think) unnessesary but they make it easier to understand
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
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
            //Select the whole answer in the NumericUpDown control
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            if (sum.Value == addend1 + addend2)
            {
                sum.BackColor = Color.Green;
                correctAnswer.Play();
            }
        }

        private void differance_ValueChanged(object sender, EventArgs e)
        {
            if (difference.Value == minuend-subtrahend)
            {
                difference.BackColor = Color.Green;
                correctAnswer.Play();
            }
        }
        private void product_ValueChanged(object sender, EventArgs e)
        {
            if (product.Value == multiplicand*multiplier)
            {
                product.BackColor = Color.Green;
                correctAnswer.Play();
            }
        }
        private void quotient_ValueChanged(object sender, EventArgs e)
        {
            if (quotient.Value == dividend/divisor)
            {
                quotient.BackColor = Color.Green;
                correctAnswer.Play();
            }
        }
    }
}
