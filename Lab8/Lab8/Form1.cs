using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form1 : Form
    {
        private void Convolution(Bitmap img, double[,] matrix)
        {
            var w = matrix.GetLength(0);
            var h = matrix.GetLength(1);

            using (var wr = new ImageWrapper(img) { DefaultColor = Color.Silver })
                foreach (var p in wr)
                {
                    double r = 0d, g = 0d, b = 0d;

                    for (int i = 0; i < w; i++)
                        for (int j = 0; j < h; j++)
                        {
                            var pixel = wr[p.X + i - 1, p.Y + j - 1];
                            r += matrix[j, i] * pixel.R;
                            g += matrix[j, i] * pixel.G;
                            b += matrix[j, i] * pixel.B;
                        }
                    wr.SetPixel(p, r, g, b);
                }
        }

        private Point PreviousPoint, point; //Точка до перемещения курсора мыши
                                            //и текущая точка
        private Bitmap bmp;
        private Pen blackPen;
        private Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            blackPen = new Pen(Color.Black, 4); //подготавливаем перо
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //сохранение файла
            SaveFileDialog savedialog = new SaveFileDialog();
            //задаем свойства для savedialog
            savedialog.Title = "Сохранить картинку как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
            "Bitmap File(*.bmp)|*.bmp|" +
            "GIF File(*.gif)|*.gif|" +
            "JPEG File(*.jpg)|*.jpg|" +
            "TIF File(*.tif)|*.tif|" +
            "PNG File(*.png)|*.png";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                // в fileName записываем полный путь к файлу
                string fileName = savedialog.FileName;
                // Убираем из имени три последних символа (расширение файла)
                string strFilExtn =
                fileName.Remove(0, fileName.Length - 3);
                // Сохраняем файл в нужном формате и с нужным расширением
                switch (strFilExtn)
                {
                    case "bmp":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                break;
                }
            }
        }
    


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
 { // обработчик события нажатия кнопки на мыши
 // записываем в предыдущую точку (PreviousPoint) текущие координаты
 PreviousPoint.X = e.X;
 PreviousPoint.Y = e.Y;
 }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {//Обработчик события перемещения мыши по pictuteBox1
        if (e.Button == MouseButtons.Left) //Проверяем нажатие левой кнопка
        { //запоминаем в point текущее положение курсора мыши
            point.X = e.X;
            point.Y = e.Y;
            //соединяем линией предыдущую точку с текущей
            g.DrawLine(blackPen, PreviousPoint, point);
            //текущее положение курсора мыши сохраняем в PreviousPoint
            PreviousPoint.X = point.X;
            PreviousPoint.Y = point.Y;
            pictureBox1.Invalidate();//Принудительно вызываем перерисовку
        }
    }


    private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    int R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    int G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    int B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета
                    int Gray = (R = G + B) / 3; // высчитываем среднее
                    Color p = Color.FromArgb(255, R/3, G/3, B/3); //переводим
                
                bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //задаем расширения файлов
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG," +
                " *.ICO, *.EMF, *.WMF)| *.bmp; *.jpg; *.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
 if (dialog.ShowDialog() == DialogResult.OK)//вызываем диалоговое окно
            {
                Image image = Image.FromFile(dialog.FileName); //Загружаем в image
                                                               //изображение из выбранного файла
                int width = image.Width;
                int height = image.Height;
                pictureBox1.Width = width;
                pictureBox1.Height = height;
                bmp = new Bitmap(image, width, height); //создаем и загружаем из
                                                        //image изображение в формате bmp
                pictureBox1.Image = bmp; //записываем изображение в формате bmp
                                         //в pictureBox1
                g = Graphics.FromImage(pictureBox1.Image); //подготавливаем объект
                                                           //Graphics для рисования в pictureBox1
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var kernel = new double[,]
                {{0.11, 0.11, 0.11},
                  {0.11, 0.11, 0.11},
                  {0.11, 0.11, 0.11}};

            Convolution(bmp, kernel);
        }

       
    }
}
