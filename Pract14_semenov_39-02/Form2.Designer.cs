namespace Pract14_semenov_39_02
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMainForm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonChangeBack = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxRed = new System.Windows.Forms.CheckBox();
            this.checkBoxGreen = new System.Windows.Forms.CheckBox();
            this.checkBoxBlue = new System.Windows.Forms.CheckBox();
            this.numericUpDownRed = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownGreen = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBlue = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMainForm
            // 
            this.buttonMainForm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonMainForm.Location = new System.Drawing.Point(0, 77);
            this.buttonMainForm.Name = "buttonMainForm";
            this.buttonMainForm.Size = new System.Drawing.Size(491, 23);
            this.buttonMainForm.TabIndex = 0;
            this.buttonMainForm.Text = "Главная форма";
            this.buttonMainForm.UseVisualStyleBackColor = true;
            this.buttonMainForm.Click += new System.EventHandler(this.buttonMainForm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonChangeBack);
            this.panel1.Controls.Add(this.buttonMainForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 100);
            this.panel1.TabIndex = 1;
            // 
            // buttonChangeBack
            // 
            this.buttonChangeBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonChangeBack.Location = new System.Drawing.Point(0, 54);
            this.buttonChangeBack.Name = "buttonChangeBack";
            this.buttonChangeBack.Size = new System.Drawing.Size(491, 23);
            this.buttonChangeBack.TabIndex = 1;
            this.buttonChangeBack.Text = "Поменять цвет фона";
            this.buttonChangeBack.UseVisualStyleBackColor = true;
            this.buttonChangeBack.Click += new System.EventHandler(this.buttonChangeBack_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.191781F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.80822F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxRed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxGreen, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxBlue, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownRed, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownGreen, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownBlue, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 91);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // checkBoxRed
            // 
            this.checkBoxRed.AutoSize = true;
            this.checkBoxRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxRed.Location = new System.Drawing.Point(20, 3);
            this.checkBoxRed.Name = "checkBoxRed";
            this.checkBoxRed.Size = new System.Drawing.Size(222, 24);
            this.checkBoxRed.TabIndex = 0;
            this.checkBoxRed.Text = "Красный";
            this.checkBoxRed.UseVisualStyleBackColor = true;
            // 
            // checkBoxGreen
            // 
            this.checkBoxGreen.AutoSize = true;
            this.checkBoxGreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxGreen.Location = new System.Drawing.Point(20, 33);
            this.checkBoxGreen.Name = "checkBoxGreen";
            this.checkBoxGreen.Size = new System.Drawing.Size(222, 25);
            this.checkBoxGreen.TabIndex = 1;
            this.checkBoxGreen.Text = "Зеленый";
            this.checkBoxGreen.UseVisualStyleBackColor = true;
            // 
            // checkBoxBlue
            // 
            this.checkBoxBlue.AutoSize = true;
            this.checkBoxBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxBlue.Location = new System.Drawing.Point(20, 64);
            this.checkBoxBlue.Name = "checkBoxBlue";
            this.checkBoxBlue.Size = new System.Drawing.Size(222, 24);
            this.checkBoxBlue.TabIndex = 2;
            this.checkBoxBlue.Text = "Синий";
            this.checkBoxBlue.UseVisualStyleBackColor = true;
            // 
            // numericUpDownRed
            // 
            this.numericUpDownRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownRed.Location = new System.Drawing.Point(248, 3);
            this.numericUpDownRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownRed.Name = "numericUpDownRed";
            this.numericUpDownRed.Size = new System.Drawing.Size(240, 23);
            this.numericUpDownRed.TabIndex = 3;
            // 
            // numericUpDownGreen
            // 
            this.numericUpDownGreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownGreen.Location = new System.Drawing.Point(248, 33);
            this.numericUpDownGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownGreen.Name = "numericUpDownGreen";
            this.numericUpDownGreen.Size = new System.Drawing.Size(240, 23);
            this.numericUpDownGreen.TabIndex = 4;
            // 
            // numericUpDownBlue
            // 
            this.numericUpDownBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownBlue.Location = new System.Drawing.Point(248, 64);
            this.numericUpDownBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownBlue.Name = "numericUpDownBlue";
            this.numericUpDownBlue.Size = new System.Drawing.Size(240, 23);
            this.numericUpDownBlue.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 265);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonMainForm;
        private Panel panel1;
        private Button buttonChangeBack;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox checkBoxRed;
        private CheckBox checkBoxGreen;
        private CheckBox checkBoxBlue;
        private NumericUpDown numericUpDownRed;
        private NumericUpDown numericUpDownGreen;
        private NumericUpDown numericUpDownBlue;
    }
}