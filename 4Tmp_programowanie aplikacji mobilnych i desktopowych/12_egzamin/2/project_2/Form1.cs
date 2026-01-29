using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.Leave += textBox1_Leave;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string numer = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(numer) )
            {
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                return;
            }

            string zdjecie = $"{numer}-zdjecie.jpg";
            string odcisk = $"{numer}-odcisk.jpg";

            if (File.Exists(zdjecie))
            {
                pictureBox1.Load(zdjecie);
            } else
            {
                pictureBox1.Image = null;
            }

            if (File.Exists(odcisk))
            {
                pictureBox2.Load(odcisk);
            }
            else
            {
                pictureBox2.Image = null;
            }
        }

        

        private string PobierzKolorOczu()
        {
            if (radioButton1.Checked)
            {
                return "niebieskie";
            }
            if (radioButton2.Checked)
            {
                return "zielone";
            }
            if (radioButton3.Checked)
            {
                return "piwne";
            }

            return "nieznany";
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imie = textBox2.Text.Trim();
            string nazwisko = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(imie) ||  string.IsNullOrEmpty(nazwisko))
            {
                MessageBox.Show("Wprowadź dane");
                return;
            }

            string kolorOczu = PobierzKolorOczu();

            MessageBox.Show($"{imie} {nazwisko} kolor oczu: {kolorOczu}");
        }
    }
}
