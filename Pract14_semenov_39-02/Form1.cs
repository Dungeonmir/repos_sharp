namespace Pract14_semenov_39_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Mass kg = new Mass(20, "кг");
            Mass gr = new Mass(100, "гр");
            Mass tonn = new Mass(2, "т");
            listBox.Items.Add(kg);
            listBox.Items.Add(gr);
            listBox.Items.Add(tonn);
            comboBox1.Items.Add(kg);
            comboBox1.Items.Add(gr);
            comboBox1.Items.Add(tonn);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            string text = textBoxAddData.Text;
            
            if (radioButtonComboBox.Checked)
            {   
                comboBox1.SelectedItem = comboBox1.Items.Add(text);
            }
            else if (radioButtonListBox.Checked)
            {
                listBox.Items.Add(text);
            }
            else
            {
                MessageBox.Show("Выберите место добавления записи");
            }
            textBoxAddData.Text = "";
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (checkBoxListBox.Checked)
            {
                listBox.Sorted = true;
            }
            else
            {
                listBox.Sorted = false;
            }
            if (checkBoxComboBox.Checked)
            {
                comboBox1.Sorted = true;
            }
            else
            {
                comboBox1.Sorted = false;
            }
        }

        private void btnaddItems_Click(object sender, EventArgs e)
        {
            foreach (var item in comboBox1.Items)
            {
                listBox.Items.Add(item);
            }
        }

        private void btnaddItem_Click(object sender, EventArgs e)
        {
            string str = comboBox1.SelectedItem?.ToString();
            if (str !=null)
            {
                listBox.Items.Add(str);
            }
            
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            listBox.Items.Remove(listBox.SelectedItem);
        }

        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            
                for (int i = 0; i < listBox.Items.Count; i++)
                {

                    listBox.Items.RemoveAt(i);
                }
           
            
            
        }


        private void buttonColorForm_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
            
            
        }

        private void buttonShowInfoComboBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show( comboBox1.SelectedItem?.ToString());
        }
    }
}