using System;

namespace EightsLab
{
    class Lab8
    {
        static void Main(string[] args)
        {
            Mnogochlen p1 = new Mnogochlen(1, 2);
            Mnogochlen p2 = new Mnogochlen(10, 20, 30, 40);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p1 + p2);
            Console.WriteLine(p1 - p2);
            Console.WriteLine(p1 * p2);
            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1.Calculate(1.2d));
        }

        internal class Mnogochlen
        {
            private readonly double[] _coefficients;

            ///<summary>
            ///  Создание*многочлена*на*основе*коэффициентов.
            ///</summary>
            ///<param name = "coefficients">Коэффициенты*полинома.</param>
            public Mnogochlen(params double[] coefficients)
            {
                _coefficients = coefficients;
            }

            ///<summary>
            ///  Получение*или*установка*значения*коэффициента*многочлена.
            ///</summary>
            ///<param name = "n">Номер*коэффициента.</param>
            ///<returns>Значение*коэффициента.</returns>
            public double this[int n]
            {
                get { return _coefficients[n]; }
                set { _coefficients[n] = value; }
            }

            ///<summary>
            ///  Степень*многочлена.
            ///</summary>
            public int Order
            {
                get { return _coefficients.Length; }
            }

            public override string ToString()
            {
                return string.Format("Coefficients:*" + string.Join(";*", _coefficients));
            }

            ///<summary>
            ///  Быстрый*расчет*значения*полинома*по*схеме*Горнера.
            ///</summary>
            ///<param name = "x">Аргумент*полинома.</param>
            ///<returns>Значение*полинома.</returns>
            public double Calculate(double x)
            {
                int n = _coefficients.Length - 1;
                double result = _coefficients[n];
                for (int i = n - 1; i >= 0; i--)
                {
                    result = x * result + _coefficients[i];
                }

                return result;
            }

            ///<summary>
            ///  Сложение*полиномов.
            ///</summary>
            public static Mnogochlen operator +(Mnogochlen pFirst, Mnogochlen pSecond)
            {
                int itemsCount = Math.Max(pFirst._coefficients.Length, pSecond._coefficients.Length);
                var result = new double[itemsCount];
                for (int i = 0; i < itemsCount; i++)
                {
                    double a = 0;
                    double b = 0;
                    if (i < pFirst._coefficients.Length)
                    {
                        a = pFirst[i];
                    }

                    if (i < pSecond._coefficients.Length)
                    {
                        b = pSecond[i];
                    }

                    result[i] = a + b;
                }

                return new Mnogochlen(result);
            }

            ///<summary>
            ///  Вычитание*многочлена.
            ///</summary>
            public static Mnogochlen operator -(Mnogochlen pFirst, Mnogochlen pSecond)
            {
                int itemsCount = Math.Max(pFirst._coefficients.Length, pSecond._coefficients.Length);
                var result = new double[itemsCount];
                for (int i = 0; i < itemsCount; i++)
                {
                    double a = 0;
                    double b = 0;
                    if (i < pFirst._coefficients.Length)
                    {
                        a = pFirst[i];
                    }

                    if (i < pSecond._coefficients.Length)
                    {
                        b = pSecond[i];
                    }

                    result[i] = a - b;
                }

                return new Mnogochlen(result);
            }

            ///<summary>
            ///  Умножение*полиномов.
            ///</summary>
            public static Mnogochlen operator *(Mnogochlen pFirst, Mnogochlen pSecond)
            {
                int itemsCount = pFirst._coefficients.Length + pSecond._coefficients.Length - 1;
                var result = new double[itemsCount];
                for (int i = 0; i < pFirst._coefficients.Length; i++)
                {
                    for (int j = 0; j < pSecond._coefficients.Length; j++)
                    {
                        result[i + j] += pFirst[i] * pSecond[j];
                    }
                }

                return new Mnogochlen(result);
            }

            ///<summary>
            ///  Равенство*полиномов.
            ///</summary>
            public static bool operator ==(Mnogochlen pFirst, Mnogochlen pSecond)
            {
                if (pFirst._coefficients.Length != pSecond._coefficients.Length)
                {
                    return false;
                }

                for (int i = 0; i < pFirst._coefficients.Length; i++)
                {
                    if (pFirst[i] != pSecond[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            public static bool operator !=(Mnogochlen pFirst, Mnogochlen pSecond)
            {
                return !(pFirst == pSecond);
            }
        }
    }
}