using System;
using System.Collections.Generic;
using System.Text;

namespace ElevenLab
{
    public class Stroka : BaseClass // насследование от абстрактного класса
    {
        protected int sizeInBytes; // поле размера
        private string str; // поле для хранение строки

        public Stroka() // конструктор по умолчанию
        {
            str = "";
            sizeInBytes = 0;
        }

        public Stroka(string str) // конструктор инициализирующий строку
        {
            this.str = str; // инициализация
            sizeInBytes = Encoding.UTF8.GetByteCount(str); // высчитывание размера
        }

        public Stroka(char symbol) // инцифиализация строки по символу
        {
            this.str = symbol.ToString(); // инициализация строки
            sizeInBytes = Encoding.UTF8.GetByteCount(str); // расчет размера
        }

        public override void Print() // функция отображения
        {
            Console.WriteLine(str);
        }


        public override int GetLength() // функция поулчения длины
        {
            return sizeInBytes;
        }

        public override bool Clear() // функция очистки 
        {
            str = "";
            sizeInBytes = 0;
            return true;
        }

        public override bool Equals(object obj) // переопределение метода сравнения
        {
            if (obj.GetType() != this.GetType()) return false;
            Stroka stroka = (Stroka) obj;
            if (!stroka.sizeInBytes.Equals(this.sizeInBytes)) return false;
            if (!stroka.str.Equals(this.str)) return false;
            return true;
        }
        
        public override int GetHashCode() // переопределение метода расчета хешкода
        {
            return HashCode.Combine(sizeInBytes, str);
        }
    }
}
