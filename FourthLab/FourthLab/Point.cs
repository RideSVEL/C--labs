namespace FourthLab
{
    public class Point // класс точки
    {
        private double x; // точка х
        private double y; // точка у

        public Point(double x, double y) // конструктор инициализации
        {
            this.x = x;
            this.y = y;
            
        }

        public double getX() //геттер
        {
            return x;
        }

        public double getY() //геттер
        {
            return y;
        }

        public void move(double x, double y) // перемещение точки
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString() // вывод точки на экран
        {
            return "{ " + $"{x}" + " ; " + $"{y}" + " }";
        }
    }
}