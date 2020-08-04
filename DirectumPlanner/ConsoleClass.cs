using System;
using System.Collections.Generic;

namespace DirectumPlanner
{
    public class ConsoleClass
    {
        public static DateTime ReadDateTime()
        {
            DateTime resultDateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out resultDateTime))
            {
                Console.WriteLine("Некорректный ввод даты (пример: 25.07.2020 18:00)");
            }
            return resultDateTime;
        }
        public static int ReadInteger()
        {
            int resultInt;
            while (!int.TryParse(Console.ReadLine(), out resultInt))
            {
                Console.WriteLine("Некорректный ввод числа");
            }
            return resultInt;
        }
        public static string ReadNotEmptyString()
        {
            string resultString = Console.ReadLine();
            while (string.IsNullOrEmpty(resultString) || string.IsNullOrWhiteSpace(resultString))
            {
                Console.WriteLine("Строка не должна быть пустой. Повторите ввод!");
                resultString = Console.ReadLine();
            }
            return resultString;
        }
        public static void WriteEvent(Event @event)
        {
            Console.WriteLine(@event.ToString());
        }
        public static void WriteEvents(List<Event> events)
        {
            Console.Clear();
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine($"Встреча № {i + 1}");
                WriteEvent(events[i]);
                Console.WriteLine();
            }
        }
    }
}
