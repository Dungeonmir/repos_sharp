using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsPract13_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void Check(TextBox tb)
        {
            DialogResult result;
            try
            {
                Convert.ToInt32(tb.Text);
            }
            catch (FormatException)
            {

                result = MessageBox.Show(this,
                    @"Ошибка преобразования. Требуется ввести цифры. Повторить ввод?", tb.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result==DialogResult.Yes)
                {
                    tb.Focus();
                }
            }
        }

        private void btnCheck1TextBox_Click(object sender, EventArgs e)
        {
            Check(textBox1);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            Check(textBox2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Check(textBox3);
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            Check(textBox4);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex reg = new Regex(@"\d");
            Match match = reg.Match(e.KeyChar.ToString());
            if (!match.Success)
            {
                e.KeyChar = '\0';
            }
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex reg = new Regex(@"\d");
            Match match = reg.Match(e.KeyChar.ToString());
            if (!match.Success)
            {
                e.KeyChar = '\0';
            }
        }

        private void btnCalcForm_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            Hide();
            form.ShowDialog();
        }
    }
}
