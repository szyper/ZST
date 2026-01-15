using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RBar_Scroll(object sender, EventArgs e)
        {
            ColorLabel.BackColor = Color.FromArgb(RBar.Value, GBar.Value, BBar.Value);
            RValue.Text = RBar.Value.ToString();
        }

        private void GBar_Scroll(object sender, EventArgs e)
        {
            ColorLabel.BackColor = Color.FromArgb(RBar.Value, GBar.Value, BBar.Value);
            GValue.Text = GBar.Value.ToString();
        }

        private void BBar_Scroll(object sender, EventArgs e)
        {
            ColorLabel.BackColor = Color.FromArgb(RBar.Value, GBar.Value, BBar.Value);
            BValue.Text = BBar.Value.ToString();
        }

        private void ColorSave_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorSave.BackColor = Color.FromArgb(RBar.Value, GBar.Value, BBar.Value);
            ColorSave.Text = $"{RBar.Value}, {GBar.Value}, {BBar.Value}";
        }
    }
}
