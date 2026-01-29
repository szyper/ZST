namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            groupBox2 = new GroupBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(30, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(219, 109);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rodzaj przesyłki";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(17, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(82, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Pocztówka";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(17, 47);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(43, 19);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "List";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(17, 72);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(61, 19);
            radioButton3.TabIndex = 2;
            radioButton3.Text = "Paczka";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(470, 66);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 236);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dane adresowe";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 34);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 0;
            label1.Text = "Ulica z numerem";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(19, 56);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(211, 23);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 106);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 2;
            label2.Text = "Kod pocztowy";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(19, 124);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(207, 23);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 171);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 4;
            label3.Text = "Miasto";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(18, 189);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(208, 23);
            textBox3.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(47, 393);
            button1.Name = "button1";
            button1.Size = new Size(727, 34);
            button1.TabIndex = 2;
            button1.Text = "Zatwierdź";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(30, 229);
            button2.Name = "button2";
            button2.Size = new Size(219, 23);
            button2.TabIndex = 3;
            button2.Text = "Sprawdź Cenę";
            button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label4.Location = new Point(192, 268);
            label4.Name = "label4";
            label4.Size = new Size(61, 25);
            label4.TabIndex = 4;
            label4.Text = "Cena:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.list;
            pictureBox1.Location = new Point(47, 268);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Nadaj przesyłkę, PESEL: 00000000";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox2;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label label4;
        private PictureBox pictureBox1;
    }
}
