using System;

namespace NinthLab
{
    class Lab9
    {
        static void Main(string[] args)
        {
            BaseClass[] baseClasses = {new Stroka("privet"), new ComplexNumber("+12i12")}; //выполнение операций
            baseClasses[0].Print(); //выполнение операций
            Console.WriteLine(baseClasses[0].GetLength()); //выполнение операций
            baseClasses[1].Print(); //выполнение операций
            Console.WriteLine(baseClasses[1].GetLength()); //выполнение операций
            Stroka stroka = (Stroka) baseClasses[0]; //выполнение операций
            ComplexNumber complexNumber = (ComplexNumber) baseClasses[1]; //выполнение операций
            Console.WriteLine(stroka.Equals(new Stroka("privet"))); //выполнение операций
            Console.WriteLine(complexNumber.Equals(new ComplexNumber("+12i12"))); //выполнение операций
            Console.WriteLine(stroka.Equals(new Stroka("poka"))); //выполнение операций 
            Console.WriteLine(complexNumber.Equals(new ComplexNumber("luna12i12"))); //выполнение операций
            Console.WriteLine(stroka.Clear()); //выполнение операций
            Console.WriteLine(complexNumber.Clear()); //выполнение операций
            (new ComplexNumber("+12i12") + new ComplexNumber("-10i2")).Print();  //выполнение операций
            (new ComplexNumber("+12i12") * new ComplexNumber("-10i2")).Print(); //выполнение операций
            Console.WriteLine(new ComplexNumber("+12i12") == new ComplexNumber("-10i2"));  //выполнение операций
            Console.WriteLine(new ComplexNumber("+12i12") == new ComplexNumber("+12i12"));//выполнение операций
        }
    }
}