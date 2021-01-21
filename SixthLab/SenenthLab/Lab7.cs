using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SenenthLab
{
    class Lab7
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex("\\d{2}"); // регулрное выражение для поиска совпадений
            using (StreamReader f = new StreamReader("D:\\C#\\SixthLab\\SenenthLab\\text.txt")) // чтение файла
                while (!f.EndOfStream) // пока не дойдем до конца потока
                {
                    string str = f.ReadLine(); // читаем строку файла в стринг
                    if (regex.IsMatch(str)) // совпадение по регулярке
                        Console.WriteLine(str); // выводим строку
                }
            Console.ReadLine();
        }
    }
}