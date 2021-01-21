using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        float[] xTriangel = { 100.78F, 50.12F, 200.99F };  // Массив х-кординат треугольника
        float[] yTriangel = { 100.45F, 200.77F, 300.18F }; // Массив y-кординат треугольника

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Задаем размер нашей формы
            this.Height = 700;
            this.Width = 900;

            // Задаем положение pictureBox1, координаты левого верхнего угла относительно формы
            this.pictureBox1.Location = new System.Drawing.Point(40, 40);

            // Задаем размер pictureBox1
            this.pictureBox1.Width = 764;
            this.pictureBox1.Height = 371;

            // Помещаем кнопку button1 в нижний правый угол формы
            this.button1.Left = this.Width - this.button1.Width - 30;
            this.button1.Top = this.Height - this.button1.Height - 60;
            this.button1.Text = "Построить";
        }

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            PointF point = new PointF(10, 20);
            PointF[] pointFs = {new PointF(15,20), new PointF(95, 100), new PointF(80, 75), new PointF(89, 39), new PointF(25, 140)};
            // Создаем локальную версию графического объекта для PictureBox
            Graphics g = e.Graphics;

            // Прорисовка отрезков сторон треугольника
            g.DrawLine(Pens.Red, xTriangel[0], yTriangel[0], xTriangel[1], yTriangel[1]);
            g.DrawLine(Pens.Red, xTriangel[1], yTriangel[1], xTriangel[2], yTriangel[2]);
            g.DrawLine(Pens.Red, xTriangel[0], yTriangel[0], xTriangel[2], yTriangel[2]);
            // Линия
            g.DrawLine(Pens.Black, 200.78F, 120.45F, xTriangel[2] - 70, yTriangel[2]);
            g.DrawRectangle(Pens.Blue, 300, 100, 100, 100);
            g.DrawEllipse(Pens.Green, 400, 150, 200, 150);
     
            g.DrawPolygon(Pens.Red, pointFs);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
            pictureBox1.Visible = true;

            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
        }
    }

    }
