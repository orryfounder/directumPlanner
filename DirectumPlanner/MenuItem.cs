using System;
using System.Collections.Generic;
using System.IO;

namespace DirectumPlanner
{
    public abstract class MenuItem
    {
        public string Name;
        public abstract void Click();

        protected static int GetEventNumber(int countEvents)
        {
            int eventNumber;
            do
            {
                Console.Write("Введите номер встречи для редактирования" +
                    "\nили 0, чтобы вернуться в главное меню: ");
                eventNumber = ConsoleClass.ReadInteger();
            }
            while (eventNumber < 0 && eventNumber > countEvents);
            return eventNumber;
        }
    }

    class ShowAllEventsItem : MenuItem
    {
        public override void Click()
        {
            Console.Clear();

            if (Management.Events.Count == 0)
            {
                Console.WriteLine("Список встреч пуст, создать встречу? (Y\\N)");
                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                    Management.AddEvent();
                Console.Clear();
                Program.MainMenu.Start();
            }
            else
            {
                ConsoleClass.WriteEvents(Management.Events);
                int eventNumber = GetEventNumber(Management.Events.Count);
                if (eventNumber == 0)
                {
                    Console.Clear();
                    Program.MainMenu.Start();
                }
                else
                {
                    Console.Clear();
                    new MenuOfEvent(Management.Events[eventNumber - 1]).Start();
                }
            }
        }
        public ShowAllEventsItem(string name) => this.Name = name;
    }

    class ShowEventsForSelectedDateItem : MenuItem
    {
        private List<Event> GetEventsForSelectedDate(DateTime selectedDate)
            => Management.Events.FindAll(x => x.StartDate <= selectedDate.AddDays(1) && selectedDate <= x.EndDate);
        private Event GetSameEvent(Event @event)
            => Management.Events.Find(x => x == @event);

        public override void Click()
        {
            Console.Clear();
            Console.WriteLine("Введите дату, для которой показать встречи");
            var events = GetEventsForSelectedDate(ConsoleClass.ReadDateTime());
            if (events.Count != 0)
            {
                ConsoleClass.WriteEvents(events);
                int eventNumber = GetEventNumber(events.Count);
                if (eventNumber == 0)
                {
                    Console.Clear();
                    Program.MainMenu.Start();
                }
                else
                {
                    Console.Clear();
                    new MenuOfEvent(GetSameEvent(events[eventNumber - 1])).Start();
                }
            }
            else
            {
                Console.WriteLine("Встреч в данный день не найдено!");
                Program.MainMenu.Start();
            }
        }
        public ShowEventsForSelectedDateItem(string name) => this.Name = name;
    }
    class ExportEventsItem : MenuItem
    {
        private List<Event> GetEventsForSelectedDate(DateTime selectedDate)
            => Management.Events.FindAll(x => x.StartDate <= selectedDate.AddDays(1) && selectedDate <= x.EndDate);
        public override void Click()
        {
            Console.Clear();
            Console.WriteLine("Введите дату для экспорта расписания встреч в текстовый файл");
            var events = GetEventsForSelectedDate(ConsoleClass.ReadDateTime());
            if (events.Count != 0)
            {
                Console.Write("Введите название текстового файла: ");
                string fileName = ConsoleClass.ReadNotEmptyString();
                foreach (Event @event in events)
                    File.AppendAllText($"{fileName}.txt", $"{@event}\n");
                Console.WriteLine($"Встречи успешно сохранены в \"{fileName}.txt\"");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Встреч в данный день не найдено!");
            }
            Program.MainMenu.Start();
        }
        public ExportEventsItem(string name)
        {
            this.Name = name;
        }
    }

    class AddEventItem : MenuItem
    {
        public override void Click()
        {
            Console.Clear();
            Management.AddEvent();
            Program.MainMenu.Start();
        }
        public AddEventItem(string name) => this.Name = name;
    }

    class CloseProgramItem : MenuItem
    {
        public override void Click()
        {
            Program.Exit();
            Console.Clear();
            Program.MainMenu.Start();
        }
        public CloseProgramItem(string name) => this.Name = name;
    }

    class ChangeNameEventItem : MenuItem
    {
        Event @event;
        public override void Click()
        {
            Management.EditName(@event);
            new MenuOfEvent(@event).Start();
        }
        public ChangeNameEventItem(string name, Event @event)
        {
            this.Name = name;
            this.@event = @event;
        }
    }

    class ChangeStartDateEventItem : MenuItem
    {
        Event @event;
        public override void Click()
        {
            Management.EditStartDate(@event);
            new MenuOfEvent(@event).Start();
        }
        public ChangeStartDateEventItem(string name, Event @event)
        {
            this.Name = name;
            this.@event = @event;
        }
    }

    class ChangeEndDateEventItem : MenuItem
    {
        Event @event;
        public override void Click()
        {
            Management.EditEndDate(@event);
            new MenuOfEvent(@event).Start();
        }
        public ChangeEndDateEventItem(string name, Event @event)
        {
            this.Name = name;
            this.@event = @event;
        }
    }

    class ChangeReminderEventItem : MenuItem
    {
        Event @event;
        public override void Click()
        {
            Management.EditReminder(@event);
            new MenuOfEvent(@event).Start();
        }
        public ChangeReminderEventItem(string name, Event @event)
        {
            this.Name = name;
            this.@event = @event;
        }
    }

    class DeleteEventItem : MenuItem
    {
        Event @event;
        public override void Click()
        {
            Management.DeleteEvent(@event);
            Console.Clear();
            Program.MainMenu.Start();
        }
        public DeleteEventItem(string name, Event @event)
        {
            this.Name = name;
            this.@event = @event;
        }
    }

    class ReturnToMenuItem : MenuItem
    {
        public override void Click()
        {
            Console.Clear();
            Program.MainMenu.Start();
        }
        public ReturnToMenuItem(string name) => this.Name = name;
    }
}
