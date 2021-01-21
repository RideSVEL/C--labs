using System;
using System.Collections.Generic;
using System.Linq;

namespace FifthLab
{
    class Lab5
    {
        public double Multiplication(double[] array) // функкция умножения
        {
            double multi = array[0]; // берем первый элемент
            for (int i = 2; i < array.Length; i += 2) // цикл каждого второго
            {
                multi += array[i]; // умножение
            }

            return multi; // вовзрат результата
        }

        public double Sum(double[] array) // функция суммирования
        {
            double sum = 0; // переменная суммы 
            int first = FindIndexOfNullableElement(array, false); // индекс первого нулевого элемента
            int last = FindIndexOfNullableElement(array, true); // индекс последнего нулевого элемента
            for (int i = first; i < last; i++) // запуск цикла
            {
                sum += array[i]; // суммирование значений
            }

            return sum; // вовзрат значения
        }

        private int FindIndexOfNullableElement(double[] array, bool reverse) // функция поиска нулевого элемента
        {
            List<double> codl = new List<double>(array); // коллекция переменных добл
            if (reverse)
            {
                codl.Reverse(); // реверсируем
            }

            for (int i = 0; i < codl.Count; i++) // запуск цикла
            {
                if (codl.ElementAt(i) == 0) // если равняется нулю выходим и возвращаем индекс
                {
                    return i;
                }
            }

            return -1; // если ничего не нашлось возвращаем -1
        }

        public static double[] Sort(double[] array) // соритрова
        {
            double temp; // временная переменная 
            for (int i = 0; i < array.Length; i++) // запуск цикла перебора
            {
                for (int j = i + 1; j < array.Length; j++) // второй цикл
                {
                    if (array[i] > array[j]) // сравнение значений
                    {
                        temp = array[i]; // изменение местами
                        array[i] = array[j]; // изменение местами
                        array[j] = temp; // изменение местами
                    }                   
                }            
            }
            return array; // возврат отсортированого массива
        }

        static void Main(string[] args) // главная функция
        {
            Lab5 lab5 = new Lab5(); // создание обьекта
            double[] array =
            {
                5, 1, 2, 0, 4, -5, 8, 9, -11, 24, 1, -4, 74, 5, -1, 512, 1, 0, -54, 5, 4, -541, 2, 4, 0, -512, 15, 487, -114,
                111
            }; // обьявление массива
            Console.WriteLine(lab5.Multiplication(array)); // вывод результатов
            Console.WriteLine(lab5.Sum(array)); // вывод результатов
            array = Sort(array); // вывод результатов
            foreach (var t in array) // вывод результатов
            {
                Console.Write(t + " "); 
            }
        }
    }
}