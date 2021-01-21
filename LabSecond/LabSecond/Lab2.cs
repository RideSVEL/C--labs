using System;
using System.ComponentModel;

namespace LabSecond
{
    class Lab2
    {
        private static double GetNumberFromConsole()
        {
            bool loop = true;
            double number = 0;
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

        static void Main(string[] args)
        {
            {
                Console.WriteLine("X = ");
                double x = GetNumberFromConsole(); // получение х
                Console.WriteLine("R = "); 
                int r = Convert.ToInt32(GetNumberFromConsole()); // получение радиуса целочисленного
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
                Console.WriteLine("y = " + y); //вывод результата
            }
        }
    }
}