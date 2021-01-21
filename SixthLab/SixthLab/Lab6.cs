using System;

namespace SixthLab
{
    class Lab6
    {
        public static int GetNumberOfZeroElementColumns(int[,] matrix) // подсчет количество нулевых элементов
        {
            int result = 0;
            for (int i = 0; i < matrix.GetLength(1); ++i) // пробежка по столбцам
            {
                for (int j = 0; j < matrix.GetLength(0); ++j) // по строкам 
                {
                    if (matrix[j, i] == 0) // сравнение полученного результата
                    {
                        ++result; // инкрементирование
                        break; // остановка циклы
                    }
                }
            }
            return result; // возврат результата 
        }

        public static void GetMaxSessionWithEqualsElements(int [,] matrix) // фукнция поиска длинной серии
        {
            
            int row = -1, maxEqual = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int tmpEqual = 1, currEqual = 1;
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    //если нашли равные елементы, то считаем
                    if (matrix[i, j] == matrix[i, j + 1])
                        tmpEqual++;
                    //если елементы не равны то считаем новую последовательность
                    else tmpEqual = 1;
                    //если полученная последовательность больше найденой, то сохраняем новый результат
                    if (tmpEqual > currEqual)
                        currEqual = tmpEqual;
                }
                //если в строке найдена новая последовательность и она больше последовательностей в других строках
                //то сохраняем новое значение наибольшей полседовательности и запоминаем строку
                if (currEqual > maxEqual && currEqual > 1)
                {
                    maxEqual = currEqual;
                    row = i + 1;
                }
            }
            if (row > 0)
                Console.WriteLine("Найдена наибольшая серия из {0} элементов в строке № {1}", maxEqual, row);
            else
                Console.WriteLine("Серий одинаковых элементов в строках не найдено");
        }

        static void Main(string[] args)
        {
            int[,] matrix =
            {
                {3, 5, 6},
                {1, 0, 4},
                {7, 8, 6},
                {0, 0, 1},
                {1, 1, 1},
                {3, 6, 9},
                {7, 1, 8}
            };
            Console.WriteLine("Число столбцов содержащик хотя бы один нулевой элемент - " + GetNumberOfZeroElementColumns(matrix));
            GetMaxSessionWithEqualsElements(matrix);
        }
    }
}