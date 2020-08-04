using System;
namespace DirectumPlanner
{
    public class Event
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                while (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Название встречи не может быть пустым." +
                        "\nПовторите ввод.");
                    value = Console.ReadLine();
                }
                name = value;
            }
        }
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                while (DateTime.Compare(value, DateTime.Now) < 0)
                {
                    Console.WriteLine("Начало встречи должно быть не раньше текущего времени." +
                        "\nПовторите ввод");
                    value = ConsoleClass.ReadDateTime();
                }
                startDate = value;
            }
        }
        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                while (DateTime.Compare(value, StartDate) < 0)
                {
                    Console.WriteLine("Конец встречи должен быть не раньше начала." +
                        "\nПовторите ввод");
                    value = ConsoleClass.ReadDateTime();
                }
                endDate = value;
            }
        }
        private DateTime reminder;
        public DateTime Reminder
        {
            get { return reminder; }
            set
            {
                while (value.CompareTo(DateTime.Now) < 0 || value.CompareTo(StartDate) > 0)
                {
                    Console.WriteLine("Время напоминания должно быть не раньше текущего времени и не позже начала встречи." +
                        "\nПовторите ввод");
                    value = ConsoleClass.ReadDateTime();
                }
                reminder = value;
            }
        }
        public override string ToString()
        {
            return $"\nНазвание {Name}" +
                   $"\nНачало встречи: {StartDate:dd MMM yyyy HH:mm}" +
                   $"\nКонец встречи: {EndDate:dd MMM yyyy HH:mm}" +
                   $"\nВремя напоминания: {Reminder:dd MMM yyyy HH:mm}";
        }
    }
}
