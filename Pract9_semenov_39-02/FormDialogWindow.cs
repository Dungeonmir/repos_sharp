using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Pract9_semenov_39_02
{
    public partial class FormDialogWindow : Form
    {
        public FormDialogWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Text format (*.txt)|*.txt|Rich Text (*.rtf)|*.rtf";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                // если выбрали текст
                if (fd.FilterIndex == 1)
                    richTextBox1.LoadFile(fd.FileName, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.LoadFile(fd.FileName, RichTextBoxStreamType.RichText);
            }

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Text format (*.txt)|*.txt|Rich Text (*.rtf)|*.rtf";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                // если выбрали текст
                if (fd.FilterIndex == 1)
                    richTextBox1.SaveFile(fd.FileName, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.SaveFile(fd.FileName, RichTextBoxStreamType.RichText);
            }

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = d.Color;
            }

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog d = new FontDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = d.Font;
            }

        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) !=
            DialogResult.Yes)
            {
                
            }
            else
            {
                this.Close();
            }
        }
    }
}
