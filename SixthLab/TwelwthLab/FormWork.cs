using System;
using System.Windows.Forms;

namespace TwelwthLab
{
    public partial class FormWork : Form
    {
        public FormWork()
        {
            InitializeComponent();
            label3.Text = "Не расчитывался";
            label4.Text = "Не расчитывался";
        }

        public void setVolume(string str)
        {
            label3.Text = str;
        }
        
        public void setMass(string str)
        {
            label4.Text = str;
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}