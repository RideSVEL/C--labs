using System.Globalization;

namespace TenthLab
{
    public struct Student // структура студент
    {
        private string lastnameAndInitials; // поле фамилии и инциалов
        private long numberGroup; // поле номера группы
        private int[] perfomance; // поля оценок

        public Student(string lastnameAndInitials, long numberGroup, int[] perfomance) // конкструктор инициализации
        {
            this.lastnameAndInitials = lastnameAndInitials;
            this.numberGroup = numberGroup;
            this.perfomance = perfomance;
        }

        public string LastnameAndInitials // свойства
        {
            get => lastnameAndInitials;
            set => lastnameAndInitials = value;
        }

        public long NumberGroup // свойства
        {
            get => numberGroup;
            set => numberGroup = value;
        }

        public int[] Perfomance // свойства
        {
            get => perfomance;
            set => perfomance = value;
        }
    }
}