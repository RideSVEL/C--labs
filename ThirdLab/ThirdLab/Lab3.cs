using System;

namespace ThirdLab
{
    class Lab3
    {
        private static double GetNumberFromConsole()
        {
            bool loop = true;
            double number = 0D;
            while (loop)
            {
                Console.WriteLine("Enter number: ");
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
                    loop = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("You entered not number!");
                }
            }

            return number;
        }

        private static double getY(double x, double r)
        {
            double y = 0; //переменная для записи результата
            if (x <= -5 && x > -9) // при данном условии
            {
                y = Math.Sqrt(r * r - x * x); //выполнение действия
            }

            if (x > -4 && x < -5) // при данном условии
            {
                y = x + 2; //выполнение действия
            }

            if (x <= 0 && x > -4) // при данном условии
            {
                y = (2 - x / 2); //выполнение действия
            }

            if (x >= 0 && x < Math.PI) // при данном условии
            {
                y = Math.Sqrt(1 * 1 - x * x); //выполнение действия
            }

            if (x >= Math.PI && x < 5) // при данном условии
            {
                y = x - Math.PI; //выполнение действия
            }

            if (x < -9 | x > 5) // при данном условии
            {
                Console.WriteLine("Неприпустиме значення х");
                Console.ReadKey();
            }

            return y;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("=======================Numbers============================\n");
            const double xStart = -9D;
            const double xStop = 5D;
            double now = xStart;
            double dx = 0.2D;
            Console.WriteLine("\t x " + " \tresult Y"); // шапка таблицы
            while (now < xStop) // запуск цикла 
            {
                Console.WriteLine("\t" + now + "\t" + getY(now, 3)); // вывод результатов
                now += dx; // добавление шага
            }
        }
    }
}