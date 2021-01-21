using System;

namespace LabFirst
{
    class Lab1
    {
        private static double FirstFunction(double a)
        {
            double denominator = Math.Sin(2 * a) + Math.Sin(5 * a) - Math.Sin(3 * a); // расчет знаменателя
            if (denominator == 0) // проверка знаменателя на ноль
            {
                throw new ArgumentException("Denominator must be not null"); // в случае правды выбрасывае исключение
            }

            double numerator = Math.Cos(a) + 1 - 2 * Math.Pow(Math.Sin(2 * a), 2); // высчитывание числителя
            return numerator / denominator; // вовзвращение результата
        }

        private static double SecondFunction(double a)
        {
            return 2 * Math.Sin(a); // возвращение результата
        }

        private static double GetNumberFromConsole()
        {
            bool loop = true; // переменная для зацикливания
            double number = 0; // переменная для получения результата
            while (loop) // обьявление бесконечного цикла
            {
                Console.WriteLine("Enter number: "); 
                try
                {
                    number = Convert.ToDouble(Console.ReadLine()); // получение с консполи и попытка переперсить значение
                    loop = false; // выход из цикла
                }
                catch (Exception e) // в случае получения из консоли значения отличного от числа, ловим эксепшен и перезапускам цикл
                {
                    Console.WriteLine("You entered not number!");
                }
            }

            return number; // возвращаем полученное число
        }

        static void Main(string[] args)
        {
            bool loop = true; // переменная для зацикливания
            while (loop) // безконечный цикл
            {
                Console.WriteLine("Enter number of formula from thrid variant (1 or 2, 0 - for exit)");
                string console = Console.ReadLine(); // чтение переменной из консоли
                switch (console) // оператор свитч, для выбора  действия
                {
                    case "1": // первый случай
                        Console.WriteLine(FirstFunction(GetNumberFromConsole())); // вызов функции и вывод результата выражения
                        loop = false; // заврешение цикла
                        break;
                    case "2":
                        Console.WriteLine(SecondFunction(GetNumberFromConsole())); // вызов функции и вывод результата выражения
                        loop = false; // заврешение цикла
                        break;
                    case "0":
                        Console.WriteLine("Good bye!)"); // прощание
                        loop = false; // заврешение цикла
                        break;
                    default: // если результат предыдущих кейсов не был успешен - идем на след итерацию цикла
                        Console.WriteLine("You entered bad number"); 
                        break;
                }
            }
        }
    }
}