using System;
using System.Collections.Generic;
using System.Linq;

namespace TenthLab
{
    class Lab10
    {
        static void Main(string[] args)
        {
            int size = 10;
            Student[] students = new Student[size]; // масив на 10 сутдентов
            for (int i = 0; i < students.Length; i++) // запуск цикла для инициализации всех студентов
            {
                Student student = new Student();
                Console.WriteLine("Введите фамилию и инициалы студента:");
                student.LastnameAndInitials = Console.ReadLine();
                Console.WriteLine("Введите номер группы:");
                student.NumberGroup = Convert.ToInt64(Console.ReadLine());
                int[] perfomance = new int[5];
                for (int j = 0; j < perfomance.Length; j++)
                {
                    Console.WriteLine("Введите " + (j + 1) + " оценку");
                    perfomance[j] = Convert.ToInt32(Console.ReadLine());
                }

                student.Perfomance = perfomance;
                students[i] = student;
            }

            IEnumerable<Student> studentsSort =
                from student1 in students orderby student1.LastnameAndInitials select student1; // сортировка 
            bool confirm = false;
            foreach (Student st in studentsSort) // перебор и подсчет
            {
                bool two = false;
                foreach (var t in st.Perfomance)
                {
                    if (t == 2)
                    {
                        two = true;
                        break;
                    }
                }

                if (two)
                {
                    Console.WriteLine("Студент с двойкой - " + st.LastnameAndInitials + " из группы - " + st.NumberGroup);
                    confirm = true;
                }
            }

            if (!confirm)
            {
                Console.WriteLine("Студенты с хотя бы одной оценкой двойкой - отсутствуют");
            }
        }
    }
}