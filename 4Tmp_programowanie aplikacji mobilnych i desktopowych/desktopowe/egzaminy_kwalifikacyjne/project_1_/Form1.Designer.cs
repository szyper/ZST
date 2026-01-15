namespace project_1_
{
    partial class Form1
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
            this.ColorLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.RValue = new System.Windows.Forms.Label();
            this.GBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.GValue = new System.Windows.Forms.Label();
            this.BBar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.BValue = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ColorSave = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ColorLabel
            // 
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.BackColor = System.Drawing.Color.White;
            this.ColorLabel.Location = new System.Drawing.Point(94, 32);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Padding = new System.Windows.Forms.Padding(600, 60, 0, 0);
            this.ColorLabel.Size = new System.Drawing.Size(600, 73);
            this.ColorLabel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dobierz kolor suwakami i zapisz przyciskiem:";
            // 
            // RBar
            // 
            this.RBar.Location = new System.Drawing.Point(115, 192);
            this.RBar.Maximum = 255;
            this.RBar.Name = "RBar";
            this.RBar.Size = new System.Drawing.Size(560, 45);
            this.RBar.TabIndex = 2;
            this.RBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RBar.Value = 255;
            this.RBar.Scroll += new System.EventHandler(this.RBar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "R";
            // 
            // RValue
            // 
            this.RValue.AutoSize = true;
            this.RValue.Location = new System.Drawing.Point(672, 192);
            this.RValue.Name = "RValue";
            this.RValue.Size = new System.Drawing.Size(25, 13);
            this.RValue.TabIndex = 3;
            this.RValue.Text = "255";
            // 
            // GBar
            // 
            this.GBar.Location = new System.Drawing.Point(115, 243);
            this.GBar.Maximum = 255;
            this.GBar.Name = "GBar";
            this.GBar.Size = new System.Drawing.Size(560, 45);
            this.GBar.TabIndex = 2;
            this.GBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GBar.Value = 255;
            this.GBar.Scroll += new System.EventHandler(this.GBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "G";
            // 
            // GValue
            // 
            this.GValue.AutoSize = true;
            this.GValue.Location = new System.Drawing.Point(672, 243);
            this.GValue.Name = "GValue";
            this.GValue.Size = new System.Drawing.Size(25, 13);
            this.GValue.TabIndex = 3;
            this.GValue.Text = "255";
            // 
            // BBar
            // 
            this.BBar.Location = new System.Drawing.Point(115, 294);
            this.BBar.Maximum = 255;
            this.BBar.Name = "BBar";
            this.BBar.Size = new System.Drawing.Size(560, 45);
            this.BBar.TabIndex = 2;
            this.BBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BBar.Value = 255;
            this.BBar.Scroll += new System.EventHandler(this.BBar_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "B";
            // 
            // BValue
            // 
            this.BValue.AutoSize = true;
            this.BValue.Location = new System.Drawing.Point(672, 294);
            this.BValue.Name = "BValue";
            this.BValue.Size = new System.Drawing.Size(25, 13);
            this.BValue.TabIndex = 3;
            this.BValue.Text = "255";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Peru;
            this.button1.Location = new System.Drawing.Point(343, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pobierz";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ColorSave
            // 
            this.ColorSave.AutoSize = true;
            this.ColorSave.BackColor = System.Drawing.Color.White;
            this.ColorSave.Location = new System.Drawing.Point(340, 393);
            this.ColorSave.Name = "ColorSave";
            this.ColorSave.Padding = new System.Windows.Forms.Padding(30, 10, 0, 0);
            this.ColorSave.Size = new System.Drawing.Size(103, 23);
            this.ColorSave.TabIndex = 5;
            this.ColorSave.Text = "255, 255, 255";
            this.ColorSave.Click += new System.EventHandler(this.ColorSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ColorSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BValue);
            this.Controls.Add(this.GValue);
            this.Controls.Add(this.RValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BBar);
            this.Controls.Add(this.GBar);
            this.Controls.Add(this.RBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColorLabel);
            this.Name = "Form1";
            this.Text = "Wykonał” dalej wstawiony numer zdającego 47198471";
            ((System.ComponentModel.ISupportInitialize)(this.RBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ColorLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar RBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RValue;
        private System.Windows.Forms.TrackBar GBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label GValue;
        private System.Windows.Forms.TrackBar BBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label BValue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ColorSave;
    }
}

