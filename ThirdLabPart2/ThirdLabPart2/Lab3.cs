using System;

namespace ThirdLabPart2
{
    class Lab3
    {
        private static bool Shoot(double x, double y)
        {
            const int radius = 3; // хардкод радиуса
            return ((x >= -2) && (x <= 2)) && ((y >= -2) && (y <= 2)) || // возврат булевого значения попадания в точку по формуле
                   (Math.Abs(x) <= radius && Math.Abs(y) <= radius &&
                    (x + radius) * (x + radius) + (y - radius) * (y - radius) >= radius * radius);
        }

        private static double GetNumberFromConsole()
        {
            bool loop = true; // переменная для зацикливания
            double number = 0D; // число для считывания
            while (loop) // запуск цикла
            {
                Console.WriteLine("Enter number: ");
                try
                {
                    number = Convert.ToDouble(Console.ReadLine()); // получение числа с консли
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
            int counter = 0; // счетчик попаданий
            int shots = 10; // общее число выстрелов
            for (int i = 0; i < shots; i++) // запуск цикла выстрелов
            {
                Console.WriteLine("Осталось - " + (i - 10) * -1 + " выстрелов");
                Console.WriteLine("Введите X"); // чтение из консоли первого значения
                double x = GetNumberFromConsole();
                Console.WriteLine("Введите Y"); // чтение из консоли второго значения
                double y = GetNumberFromConsole();
                if (Shoot(x, y))
                {
                    Console.WriteLine("Попал!");
                    counter++;
                }
                else
                {
                    Console.WriteLine("Мимо:(");
                }
            }

            Console.WriteLine("Твой результат: " + counter + " попаданий из " + shots + " выстрелов"); // вывод результата
        }
    }
}