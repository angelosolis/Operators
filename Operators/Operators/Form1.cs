using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operators
{
    public partial class Form1 : Form
    {
        private double accumulator = 0.0;
        private char currentOperator;
        private double currentOperand;
        private List<string> previousOutputs = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void ScanData(out char operatorChar, out double operand)
        {
            operatorChar = currentOperator;
            operand = currentOperand;
        }

        private void DoNextOperation(char operatorChar, double operand, ref double accumulator)
        {
            switch (operatorChar)
            {
                case '+':
                    accumulator += operand;
                    break;
                case '-':
                    accumulator -= operand;
                    break;
                case '*':
                    accumulator *= operand;
                    break;
                case '/':
                    accumulator /= operand;
                    break;
                case '^':
                    accumulator = Math.Pow(accumulator, operand);
                    break;
                case 'q':
                    label1.Text = $"Final result is {accumulator}";
                    break;
                default:
                    break;
            }
            if (operatorChar != 'q')
            {
                string output = $"Result so far is {accumulator}";
                previousOutputs.Add(output);
                label1.Text = output;
                
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string[] inputParts = textBox1.Text.Split(' ');
                currentOperator = inputParts[0][0];
                currentOperand = double.Parse(inputParts[1]);
                ScanData(out char operatorChar, out double operand);
                DoNextOperation(operatorChar, operand, ref accumulator);
                textBox1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string summary = string.Join(Environment.NewLine, previousOutputs);
            MessageBox.Show(summary);
        }
    }
}
