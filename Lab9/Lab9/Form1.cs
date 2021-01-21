using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using MathNet.Numerics.LinearAlgebra.Double; 


namespace GMiMG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label1.Enabled = true;
                label2.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                numericUpDown1.Enabled = true;
            }
            else
            {
                label1.Enabled = false;
                label2.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                numericUpDown1.Enabled = false;
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
            }
            else
            {
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
            }
        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                label3.Enabled = true;
                label4.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                label3.Enabled = false;
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void checkBox4_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                label7.Enabled = true;
                label8.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
            }
            else
            {
                label7.Enabled = false;
                label8.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen penLightGrey = new Pen(Color.LightGray);
            Pen penBlack = new Pen(Color.Black);
            Pen penRed = new Pen(Color.Red);

            int h = pictureBox1.Height;
            int w = pictureBox1.Width;

            // очищаем область
            g.Clear(Color.White);

            // строим ось х
            g.DrawLine(penLightGrey, 0, h / 2, w, h / 2);
            g.DrawLine(penLightGrey, w - 10, (h / 2) - 2, w, h / 2);
            g.DrawLine(penLightGrey, w - 10, (h / 2) + 2, w, h / 2);

            // строим ось у
            g.DrawLine(penLightGrey, w / 2, 0, w / 2, h);
            g.DrawLine(penLightGrey, (w / 2) - 2, 10, w / 2, 0);
            g.DrawLine(penLightGrey, (w / 2) + 2, 10, w / 2, 0);

            // матрица начальной фигуры (в логических координатах -- как на математике); каждая строка матрицы -- линия соединяющая две точки (x, y)
            var initialFigure = new DenseMatrix(new[,] { { -100.0, 50.0, 0, 100.0 }, { 0, 100.0, 100.0, 50.0 }, { 100.0, 50.0, 100.0, -50.0 }, { 100.0, -50.0, -100.0, -50.0 }, { -100.0, -50.0, -50.0, 0 }, { -50.0, 0, -100.0, 50.0 }, { -50.0, 0, 100.0, 0 }, { 0, 100.0, 0, -50.0 } });
            // матрица преобразования из логической системы координат (как на уроке математики) к машинной
            var toMachineCoordsionMatrix = new DenseMatrix(new[,] { { 1.0, 0, 0 }, { 0, -1.0, 0 }, { w / 2, h / 2, 1.0 } });
            // разбиваем матрицу фигуры на две матрицы начальных и конечных точек отрезков, из которых она состоит;
            // кроме того добавляем третий единичный столбец для матричных вычислений аффинных преобразований
            var firstFiguresPoints = new DenseMatrix(initialFigure.RowCount, 3);
            var secondFiguresPoints = new DenseMatrix(initialFigure.RowCount, 3);
            // заполняем эти две матрицы вручную
            for (var i = 0; i < initialFigure.RowCount; i++)
            {
                firstFiguresPoints[i, 0] = initialFigure[i, 0];
                firstFiguresPoints[i, 1] = initialFigure[i, 1];
                firstFiguresPoints[i, 2] = 1.0;
                secondFiguresPoints[i, 0] = initialFigure[i, 2];
                secondFiguresPoints[i, 1] = initialFigure[i, 3];
                secondFiguresPoints[i, 2] = 1.0;
            }


            // разбираем нажаты ли галочки, введены ли параметры преобразования
            // и в соответствие с этим умножаем на нужные матрицы преобразований

            // поворот
            if (checkBox1.Checked == true)
            {
                double a = System.Convert.ToDouble(textBox1.Text);
                double b = System.Convert.ToDouble(textBox2.Text);
                var transferalToABMatrix = new DenseMatrix(new[,] { { 1.0, 0, 0 }, { 0, 1.0, 0 }, { -a, -b, 1.0 } });
                var rotationMatrix = new DenseMatrix(new[,] { { Math.Cos(System.Convert.ToDouble(numericUpDown1.Value) * Math.PI / 180), Math.Sin(System.Convert.ToDouble(numericUpDown1.Value) * Math.PI / 180), 0 }, { -(Math.Sin(System.Convert.ToDouble(numericUpDown1.Value) * Math.PI / 180)), Math.Cos(System.Convert.ToDouble(numericUpDown1.Value) * Math.PI / 180), 0 }, { 0, 0, 1.0 } });
                var transferalFromABMatrix = new DenseMatrix(new[,] { { 1.0, 0, 0 }, { 0, 1.0, 0 }, { a, b, 1.0 } });

                firstFiguresPoints.Multiply(transferalToABMatrix, firstFiguresPoints);
                secondFiguresPoints.Multiply(transferalToABMatrix, secondFiguresPoints);
                firstFiguresPoints.Multiply(rotationMatrix, firstFiguresPoints);
                secondFiguresPoints.Multiply(rotationMatrix, secondFiguresPoints);
                firstFiguresPoints.Multiply(transferalFromABMatrix, firstFiguresPoints);
                secondFiguresPoints.Multiply(transferalFromABMatrix, secondFiguresPoints);
            }

            // отражение
            if (checkBox2.Checked == true)
            {
                var reflectionXMatrix = new DenseMatrix(new[,] { { -1.0, 0, 0 }, { 0, 1.0, 0 }, { 0, 0, 1.0 } });
                var reflectionYMatrix = new DenseMatrix(new[,] { { 1.0, 0, 0 }, { 0, -1.0, 0 }, { 0, 0, 1.0 } });

                if (checkBox5.Checked == true)
                {
                    firstFiguresPoints.Multiply(reflectionXMatrix, firstFiguresPoints);
                    secondFiguresPoints.Multiply(reflectionXMatrix, secondFiguresPoints);
                }

                if (checkBox6.Checked == true)
                {
                    firstFiguresPoints.Multiply(reflectionYMatrix, firstFiguresPoints);
                    secondFiguresPoints.Multiply(reflectionYMatrix, secondFiguresPoints);
                }
            }

            // растяжение
            if (checkBox3.Checked == true)
            {
                var scaleMatrix = new DenseMatrix(new[,] { { Convert.ToDouble(textBox3.Text), 0, 0 }, { 0, Convert.ToDouble(textBox4.Text), 0 }, { 0, 0, 1.0 } });

                firstFiguresPoints.Multiply(scaleMatrix, firstFiguresPoints);
                secondFiguresPoints.Multiply(scaleMatrix, secondFiguresPoints);
            }

            // перенос
            if (checkBox4.Checked == true)
            {
                double tX = System.Convert.ToDouble(textBox5.Text);
                double tY = System.Convert.ToDouble(textBox6.Text);
                var transferalMatrix = new DenseMatrix(new[,] { { 1.0, 0, 0 }, { 0, 1.0, 0 }, { tX, tY, 1.0 } });

                firstFiguresPoints.Multiply(transferalMatrix, firstFiguresPoints);
                secondFiguresPoints.Multiply(transferalMatrix, secondFiguresPoints);
            }

            // чтобы всё отображалось как надо переводим полученный рисунок из логической системы координат в машинную
            firstFiguresPoints.Multiply(toMachineCoordsionMatrix, firstFiguresPoints);
            secondFiguresPoints.Multiply(toMachineCoordsionMatrix, secondFiguresPoints);

            // рисуем получившуюся фигуру
            for (var i = 0; i < initialFigure.RowCount; i++)
            {
                g.DrawLine(penBlack, (float)firstFiguresPoints[i, 0], (float)firstFiguresPoints[i, 1], (float)secondFiguresPoints[i, 0], (float)secondFiguresPoints[i, 1]);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

    }
}
