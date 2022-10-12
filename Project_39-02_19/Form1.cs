using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_39_02_19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            if (button.BackColor == Color.Red)
            {
                changeColor(button, button1);
            }
            else
            {
                changeColor(button1, button);
            }
        }
        private void changeColor(Button btn, Button btn2)
        {
            btn.BackColor=Color.Blue;
            btn2.BackColor=Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button.BackColor == Color.Red)
            {
                changeColor(button, button1);
            }
            else
            {
                changeColor(button1, button);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x = 6.37;
            double y = 0;
            double a = 2.56;
            double b = 7.18;

            y = (Math.Pow((a ), (0.333333)) + 0.25 * Math.Tan(x))/x-4.87;
            string str = y.ToString();
            MessageBox.Show("Ответ = "+str);

            
        }
    }
}
