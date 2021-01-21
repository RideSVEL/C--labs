using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        private Particle ball;

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            var img = (Bitmap)Image.FromStream(new WebClient().OpenRead(@"http://i273.photobucket.com/albums/jj225/t00ny45/FIFA-Stars/ball.png"));
            img.SetResolution(92, 92);
            ball = new Particle { Image = img, Position = new PointF(200, 200), Velocity = new PointF(-10, 0) };

            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            ball.Update(0.01f);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(ball.Image, new PointF(ball.Position.X - ball.Size.Width / 2, ClientSize.Height - (ball.Position.Y + ball.Size.Height / 2)));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            ball.Position = new PointF(200, 200);
            ball.Velocity = new PointF(-10, 0);
        }
    }

    public class Particle
    {
        public Image Image;
        public PointF Velocity;
        public PointF Position;

        public Size Size { get { return Image.Size; } }

        public const float g = 9.8f;
        public const float groundFriction = 0.9f;
        public const float airFriction = 0.999f;


        public void Update(float dt)
        {
            //сила тяжести
            var a = new PointF(0, -g);
            Velocity = Velocity.Add(a, dt);

            //трение об воздух
            Velocity = Velocity.Mult(airFriction);

            //отскок от земли
            if (Position.Y - Size.Height / 2 < 0)
            {
                Velocity = Velocity.Mult(-groundFriction);
                Position = new PointF(Position.X, Image.Height / 2);
            }
            else
                //движение
                Position = Position.Add(Velocity, dt);
        }
    }

    static class Helper
    {
        public static PointF Mult(this PointF p, float koeff)
        {
            return new PointF(p.X * koeff, p.Y * koeff);
        }

        public static PointF Add(this PointF p1, PointF p2, float koeff = 1f)
        {
            return new PointF(p1.X + p2.X * koeff, p1.Y + p2.Y * koeff);
        }
    }
}
