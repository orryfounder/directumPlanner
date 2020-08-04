using System;
using System.Collections.Generic;

namespace DirectumPlanner
{
    public static class Management
    {
        public static List<Event> Events = new List<Event>();
        public static void AddEvent()
        {
            Event addEvent = new Event();
            EditName(addEvent);
            do
            {
                EditStartDate(addEvent);
                EditEndDate(addEvent);
            }
            while (EventIntersect(addEvent));
            EditReminder(addEvent);
            Console.Clear();
            Events.Add(addEvent);
            Console.WriteLine("Встреча успешно добавлена!");
        }
        public static void DeleteEvent(Event removeEvent)
        {
            Console.WriteLine("Вы уверены, что хотите удалить встречу? (Y\\N)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
                Events.Remove(removeEvent);
        }
        public static void EditName(Event editEvent)
        {
            Console.WriteLine("Введите название встречи");
            editEvent.Name = ConsoleClass.ReadNotEmptyString();
        }
        public static void EditStartDate(Event editEvent)
        {
            Console.WriteLine("Введите дату и время начала встречи");
            editEvent.StartDate = ConsoleClass.ReadDateTime();
        }
        public static void EditEndDate(Event editEvent)
        {
            Console.WriteLine("Введите дату и время конца встречи");
            editEvent.EndDate = ConsoleClass.ReadDateTime();
        }
        public static void EditReminder(Event editEvent)
        {
            Console.WriteLine("Введите дату и время напоминания о встрече");
            editEvent.Reminder = ConsoleClass.ReadDateTime();
        }
        public static bool EventIntersect (Event compareEvent)
        {
            if (Events.Exists(@event => compareEvent != @event
                                     && DateTime.Compare(compareEvent.EndDate ,@event.StartDate) >= 0
                                     && DateTime.Compare(compareEvent.StartDate, @event.EndDate) <= 0))
            {
                Console.WriteLine("Встречи пересекаются");
                return true;
            }
            return false;
        }
    }
}
