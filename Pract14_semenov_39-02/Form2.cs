using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pract14_semenov_39_02
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void buttonMainForm_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void buttonChangeBack_Click(object sender, EventArgs e)
        {
            int red=0, green=0, blue= 0;
            int getColorifChecked(CheckBox box, NumericUpDown updown)
            {
                if (box.Checked)
                {
                    return (int)updown.Value;
                }
                else return 0;
            }
            red = getColorifChecked(checkBoxRed, numericUpDownRed);
            green = getColorifChecked(checkBoxGreen, numericUpDownGreen);
            blue = getColorifChecked(checkBoxBlue, numericUpDownBlue);
            Color clr = Color.FromArgb(red, green, blue);
            BackColor = clr;
        }
    }
}
