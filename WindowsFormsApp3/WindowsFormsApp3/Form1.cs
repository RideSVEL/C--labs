using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        float UgolWrascheniaZemli = 0;
        float UgolWrascheniaLuny = 0;

        // прирост изменения положения Земли и Луны
        float PrirostUglaWrascheniaZemli = 0.05f;
        float PrirostUglaWrascheniaLuny = 0.1f;
        float Zx;
        bool ToRight = true;

        //private int x1, y1, x2, y2;
        //private double a, t, fi;
        //private Pen pen = new Pen(Color.DarkRed, 2);
        public Form1()
        {
            InitializeComponent();

            this.Left = 10;
            this.Top = 10;
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.7f);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.85f);

            this.BackColor = Color.DarkBlue;

        }


    private void Form1_Paint(object sender, PaintEventArgs e)
    {
            // рисовка Солнца
            e.Graphics.FillEllipse(Brushes.Yellow, this.Width / 2 - 80, this.Height / 2 - 80, 160, 160);

            // вычисления положения Земли
            if (ToRight)
            {
                Zx += 4;
                if ((int)Zx > this.Size.Width)
                    ToRight = false;
            }
            else
            {
                Zx -= 4;
                if ((int)Zx < 0)
                    ToRight = true;
            }
            float Zy = 200 + (float)(this.Height / 2 - this.Width / 4 * Math.Cos(UgolWrascheniaZemli) / 5D);

            // рисовка Земли
            e.Graphics.FillEllipse(Brushes.LimeGreen, Zx - 25, Zy - 25, 50, 50);

            // вычисления положения Луны
            float Kx = (float)(Zx + this.Width / 12 * Math.Sin(UgolWrascheniaLuny));
            float Ky = (float)(Zy - this.Width / 12 * Math.Cos(UgolWrascheniaLuny));

            // рисовка Луны
            e.Graphics.FillEllipse(Brushes.LightYellow, Kx - 5, Ky - 5, 10, 10);
        }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
            UgolWrascheniaZemli = UgolWrascheniaZemli + PrirostUglaWrascheniaZemli;
            if (UgolWrascheniaZemli >= 360)
                UgolWrascheniaZemli = 0;

            UgolWrascheniaLuny = UgolWrascheniaLuny + PrirostUglaWrascheniaZemli;
            if (UgolWrascheniaLuny >= 360)
                UgolWrascheniaLuny = 0;
            this.Refresh();
        }
    private void button1_Click(object sender, EventArgs e)
    {
    }
}
}

