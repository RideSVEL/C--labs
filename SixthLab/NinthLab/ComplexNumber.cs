using System;
using System.Text;
using System.Text.RegularExpressions;

namespace NinthLab
{
    public class ComplexNumber : Stroka // наследование от строки 
    {
        
        private int real; // целая
        private int imaginary; //мнимая

        public ComplexNumber() // комплексные числа
        {
            real = 0;
            imaginary = 0;
            sizeInBytes = Encoding.UTF8.GetByteCount(real + "i" + imaginary);
        }

        public ComplexNumber(int real, int imaginary) // конструктор инициализации
        {
            this.real = real;
            this.imaginary = imaginary;
            sizeInBytes = Encoding.UTF8.GetByteCount(real + "i" + imaginary);
        }

        public ComplexNumber(string str) // инициализация по строке
        {
            Regex regex = new Regex("^[+-]?\\d+i\\d+$"); // регулярное выражение 
            if (regex.IsMatch(str))
            {
                string[] number = str.Split("i"); //рабитие по разделителю
                real = Convert.ToInt32(number[0]);
                imaginary = Convert.ToInt32(number[1]);
            }
            else // иначе инициализация нулямми
            {
                real = 0;
                imaginary = 0;
            }

            sizeInBytes = Encoding.UTF8.GetByteCount(real + "i" + imaginary);
        }

        public override void Print() // вывод на экран
        {
            if (real == 0 && imaginary == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(real + "i" + imaginary);
            }
        }

        public static bool operator ==(ComplexNumber first, ComplexNumber second) // перегрузка оператора
        {
            return first.Equals(second);
        }

        public static bool operator !=(ComplexNumber first, ComplexNumber second) // перегрузка оператора 
        {
            return !(first == second);
        }

        public static ComplexNumber operator +(ComplexNumber first, ComplexNumber second) // перегрузка оператора 
        {
            return new ComplexNumber(first.real + second.real, 
                first.imaginary + second.imaginary);
        }
        
        public static ComplexNumber operator *(ComplexNumber first, ComplexNumber second) // перегрузка оператора 
        {
            return new ComplexNumber(first.real * second.real, 
                first.imaginary * second.imaginary);
        }

        public override bool Equals(object obj) // перегрузка метода
        {
            if (obj.GetType() != this.GetType()) return false;
            ComplexNumber complexNumber = (ComplexNumber) obj;
            if (!complexNumber.real.Equals(this.real)) return false;
            if (!complexNumber.imaginary.Equals(this.imaginary)) return false;
            return true;
        }
        
        public override int GetHashCode() // перегрузка метода 
        {
            return HashCode.Combine(real, imaginary);
        }

        public override bool Clear() // очистка
        {
            real = 0;
            imaginary = 0;
            return true;
        }
    }
}