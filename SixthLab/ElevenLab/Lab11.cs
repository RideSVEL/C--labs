using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevenLab
{
    class Lab11
    {
        static void Main(string[] args)
        {
            BaseClass[] baseClasses = {new Stroka("privet"), new ComplexNumber("+12i12")};
            IEnumerable<BaseClass> baseClass = baseClasses;
            baseClass.ElementAt(0).Print();
            Console.WriteLine(baseClass.ElementAt(0).GetLength());
            baseClass.ElementAt(1).Print();
            Console.WriteLine(baseClass.ElementAt(1).GetLength());
            Stroka stroka = (Stroka) baseClass.ElementAt(0);
            ComplexNumber complexNumber = (ComplexNumber) baseClass.ElementAt(1);
            Console.WriteLine(stroka.Equals(new Stroka("privet")));
            Console.WriteLine(complexNumber.Equals(new ComplexNumber("+12i12")));
            Console.WriteLine(stroka.Equals(new Stroka("poka")));
            Console.WriteLine(complexNumber.Equals(new ComplexNumber("luna12i12")));
            Console.WriteLine(stroka.Clear());
            Console.WriteLine(complexNumber.Clear());
            (new ComplexNumber("+12i12") + new ComplexNumber("-10i2")).Print();
            (new ComplexNumber("+12i12") * new ComplexNumber("-10i2")).Print();
            Console.WriteLine(new ComplexNumber("+12i12") == new ComplexNumber("-10i2"));
            Console.WriteLine(new ComplexNumber("+12i12") == new ComplexNumber("+12i12"));
        }
    }
}