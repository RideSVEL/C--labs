using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwelwthLab
{
    public partial class Form1 : Form
    {
        public static double radius;
        public static double height;
        public static double density;
        public static bool volume;
        public static bool mass;
        public static double volumeNumber;
        public static double massNumber;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowMyDialogBox()
        {
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 testDialog = new Form2();
            testDialog.ShowDialog(this);
            testDialog.Dispose();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void workToolStripMenuItem_Click(object sender, EventArgs e)
        {
            volumeNumber = (Math.PI * Math.Pow(radius, 2) * height) / 3;
            massNumber = volumeNumber * density;
            FormWork formWork = new FormWork();
            if (volume)
            {
                formWork.setVolume(volumeNumber.ToString());
            }
            if (mass)
            {
                formWork.setMass(massNumber.ToString());
            }

            formWork.ShowDialog(this);
        }
    }
}