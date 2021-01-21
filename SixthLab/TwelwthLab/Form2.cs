using System;
using System.Windows.Forms;

namespace TwelwthLab
{
    public partial class Form2 : Form
    {


        public Form2()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Form1.radius = Convert.ToDouble(textBox1.Text);
                Form1.height = Convert.ToDouble(textBox2.Text);
                Form1.density = Convert.ToDouble(textBox3.Text);
                Form1.volume = checkBox1.Checked;
                Form1.mass = checkBox2.Checked;
                Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                Console.WriteLine("Неверный ввод");
            }
        }
    }
}