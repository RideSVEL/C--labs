using System;

namespace SecondLAbPart2
{
    class LAb2Part2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите X"); // чтение из консоли первого значения
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите Y");  // чтение из консоли первого значения
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите R"); // чтение из консоли радиуса
            double r = Convert.ToDouble(Console.ReadLine());
            if (((x >= -2) && (x <= 2)) && ((y >= -2) && (y <= 2)) || (Math.Abs(x) <= r && Math.Abs(y) <= r &&
                                                                       (x + r) * (x + r) + (y - r) * (y - r) >= r * r))
            {
                Console.WriteLine("Заданая точка находится в  заштрихованой областе"); // вывод успешного результата
            }
            else
            {
                Console.WriteLine("Задана точка не знаходиться у заштрихованой областе"); // вывод отрицательного результата
            }
        }
    }
}