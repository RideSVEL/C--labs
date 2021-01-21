using System;

namespace FourthLab
{
    class Triangle //класс треугольника
    {
        private double perimeter; // переменная периметра

        private Point pointA; // первая точка
        private Point pointB; // вторая точка
        private Point pointC;// третья точка 

        public Triangle(Point pointA, Point pointB, Point pointC) //конструктор инициализации
        {
            this.pointA = pointA;
            this.pointB = pointB;
            this.pointC = pointC;
            perimeter = CountPerimeter(); // расчет пермиетра
        }

        private double countSideTriangle(Point first, Point second) // функция расчета сторон треугольньки
        {
            return Math.Abs(Math.Sqrt(Math.Pow(second.getX() - first.getX(), 2)
                                      + Math.Pow(second.getY() - first.getY(), 2)));
        }

        private double CountPerimeter() // ффункция расчета периметра
        {
            //работает на осснове функции расчета стороны по точкам
            return countSideTriangle(pointA, pointB) + countSideTriangle(pointB, pointC) +
                   countSideTriangle(pointC, pointA);
        }

        public void Print() // функция вывода на экран
        {
            Console.WriteLine("P = " + perimeter);
            Console.WriteLine(
                "Coordinates : " + pointA.ToString() + ", " + pointB.ToString() + ", " + pointC.ToString());
        }

        public void Scale(double coefficient) // функция масштабирования по коэфициенту
        {
            if (coefficient <= 0) // коэфициент не может быть нулевым
            {
                throw new ArgumentException("Coefficient must be more than 0");
            }

            pointA.move(pointA.getX() * coefficient, pointA.getY() * coefficient); // перемещение точки
            pointB.move(pointB.getX() * coefficient, pointB.getY() * coefficient); // перемещение точки
            pointC.move(pointC.getX() * coefficient, pointC.getY() * coefficient); // перемещение точки
            perimeter = CountPerimeter(); // пересчет периметра
        }

        public void Move(Point pointA, Point pointB, Point pointC) // перемещение функция
        {
            this.pointA.move(pointA.getX(), pointA.getY()); // перемещение точки
            this.pointB.move(pointB.getX(), pointB.getY()); // перемещение точки
            this.pointC.move(pointC.getX(), pointC.getY()); // перемещение точки
            perimeter = CountPerimeter(); // пересчет периметра
        }

        static void Main(string[] args) // главная функция
        {
            Triangle triangle = new Triangle(new Point(2, 3), new Point(6, 2), new Point(7, 1)); // инициализая треугольника
            triangle.Print(); // вывод треугольника
            triangle.Scale(3); // масштабирование треугольника
            triangle.Print(); // вывод треугольника 
            triangle.Move(new Point(2, 3), new Point(8, 9), new Point(6, 7)); // сдвиг точек треугольника
            triangle.Print(); // вывод треугольника
        }
    }
}