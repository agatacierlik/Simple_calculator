using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            InitializeComponent();
        }

        private string firstNumber = "", secondNumber = "";
        private char operationSign = ' ';

        private void viewCapture(string nr)
        {
            if (operationSign == ' ')
            {
                eraseText();
                firstNumber += nr;
                textBox1.Text = firstNumber;
            }
            else if (operationSign == '=')
            {
                firstNumber = "";
                secondNumber = "";
                eraseText();
                secondNumber += nr;
                textBox1.Text = secondNumber;
            }
            else if (operationSign == 'e')
            {
                firstNumber += nr;
                textBox1.Text = firstNumber;
            }
            else
            {
                eraseText();
                secondNumber += nr;
                textBox1.Text = secondNumber;
            }
        }

        private void eraseText()
        {
            textBox1.Clear();
        }

        private bool twoDotsPrevention(string actualNumber)
        {
            for (int i = 0; i < actualNumber.Length; i++)
            {
                if (actualNumber[i] == '.')
                    return false;
            }
            return true;
        }

        private bool divisionByzero(double denominator)
        {
            if (denominator == 0.0)
                return false;
            return true;
        }

        private bool squareroot(double nonnegative)
        {
            if (nonnegative >= 0.0)
                return true;
            return false;
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (twoDotsPrevention(textBox1.Text) == true)
            {
                viewCapture(".");
            }
        }
        private char copyOfSign(char signCopy)
        {
            signCopy = operationSign;
            return signCopy;
        }

        private bool isOperationSignE(char actualSign)
        {
            if (actualSign != 'e')
                return false;
            return true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CE_Click(object sender, EventArgs e)
        {
            if (operationSign == '=' | operationSign == 'e')
            {
                firstNumber = "";
                secondNumber = "";
                eraseText();
                operationSign = ' ';
            }
            else
            {
                eraseText();
                operationSign = copyOfSign(operationSign);
                secondNumber = "";
            }
        }

        private void C_Click(object sender, EventArgs e)
        {
            firstNumber = "";
            secondNumber = "";
            eraseText();
            operationSign = ' ';
        }

        private void squareRoot_Click(object sender, EventArgs e)
        {
            if (isOperationSignE(operationSign) == false & firstNumber != "")
            {
                operationSign = 'r';
            }
            else
            {
                textBox1.Text = "Input a number first";
                operationSign = ' ';
                firstNumber = "";
                secondNumber = "";
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (isOperationSignE(operationSign) == false & firstNumber != "")
            {
                operationSign = '+';
                eraseText();
            }
            else
            {
                textBox1.Text = "Input a number first";
                operationSign = ' ';
                firstNumber = "";
                secondNumber = "";
            }
        }

        private void nr7_Click(object sender, EventArgs e)
        {
            viewCapture("7");
        }

        private void nr8_Click(object sender, EventArgs e)
        {
            viewCapture("8");
        }

        private void nr9_Click(object sender, EventArgs e)
        {
            viewCapture("9");
        }

        private void substract_Click(object sender, EventArgs e)
        {
            if (isOperationSignE(operationSign) == false & firstNumber != "")
            {
                operationSign = '-';
                eraseText();
            }
            else
            {
                textBox1.Text = "Input a number first";
                operationSign = ' ';
                firstNumber = "";
                secondNumber = "";
            }
        }

        private void nr4_Click(object sender, EventArgs e)
        {
            viewCapture("4");
        }

        private void nr5_Click(object sender, EventArgs e)
        {
            viewCapture("5");
        }

        private void nr6_Click(object sender, EventArgs e)
        {
            viewCapture("6");
        }

        private void divide_Click(object sender, EventArgs e)
        {
            if (isOperationSignE(operationSign) == false & firstNumber != "")
            {
                operationSign = '/';
                eraseText();
            }

            else
            {
                textBox1.Text = "Input a number first";
                operationSign = ' ';
                firstNumber = "";
                secondNumber = "";
            }
        }

        private void nr1_Click(object sender, EventArgs e)
        {
            viewCapture("1");
        }

        private void nr2_Click(object sender, EventArgs e)
        {
            viewCapture("2");
        }

        private void nr3_Click(object sender, EventArgs e)
        {
            viewCapture("3");
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            if (isOperationSignE(operationSign) == false & firstNumber != "")
            {
                operationSign = '*';
                eraseText();
            }
            else
            {
                textBox1.Text = "Input a number first";
                operationSign = ' ';
                firstNumber = "";
                secondNumber = "";
            }
        }

        private void nr0_Click(object sender, EventArgs e)
        {
            viewCapture("0");
        }

        private void power_Click(object sender, EventArgs e)
        {
            if (isOperationSignE(operationSign) == false & firstNumber != "")
            {
                operationSign = 'P';
            }
            else
            {
                textBox1.Text = "Input a number first";
                firstNumber = "";
                secondNumber = "";
                operationSign = ' ';
            }
        }

        private void equals_Click(object sender, EventArgs e)
        {
            switch (operationSign)
            {
                case ('+'):
                    textBox1.Text = (double.Parse(firstNumber) + double.Parse(secondNumber)).ToString();
                    break;
                case ('-'):
                    textBox1.Text = (double.Parse(firstNumber) - double.Parse(secondNumber)).ToString();
                    break;
                case ('/'):
                    if (divisionByzero(double.Parse(secondNumber)) == true)
                        textBox1.Text = (double.Parse(firstNumber) / double.Parse(secondNumber)).ToString();
                    else
                        textBox1.Text = "Undefined";
                    break;
                case ('*'):
                    textBox1.Text = (double.Parse(firstNumber) * double.Parse(secondNumber)).ToString();
                    break;
                case ('r'):
                    if (squareroot(double.Parse(textBox1.Text)) == true)
                        textBox1.Text = (Math.Sqrt(double.Parse(textBox1.Text))).ToString();
                    else
                        textBox1.Text = "Invalid input data";
                    break;
                case ('P'):
                        textBox1.Text = (Math.Pow(double.Parse(textBox1.Text), 2)).ToString();
                    break;
            }
            if (textBox1.Text == "Undefined" | textBox1.Text == "Invalid input data")
            {
                firstNumber = "";
                secondNumber = "";
                operationSign = 'e';
            }
            else
            {
                operationSign = '=';
                firstNumber = textBox1.Text;
                secondNumber = "";
            }
        }
    }
}
