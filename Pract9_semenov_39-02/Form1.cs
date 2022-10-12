using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pract9_semenov_39_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void messageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, hello");
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void cutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void cutToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBoxChoice.Items.Add(textBox2.Text);
            textBox2.Text = "";
            
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Мое сообщение!";
        }

        private void buttonaddItem_Click(object sender, EventArgs e)
        {
             listBoxItems.Items.Add(comboBoxChoice.SelectedItem.ToString());
        }

        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            listBoxItems.Items.Remove(comboBoxChoice.SelectedItem.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormDialogWindow fr = new FormDialogWindow();
            fr.ShowDialog();
        }
    }
}
