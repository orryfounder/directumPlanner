using System;

namespace DirectumPlanner
{
    public abstract class Menu
    {
        public string Name;
        public MenuItem[] MenuItems;
        public abstract void Start();

        protected static int GetActionNumber(int countMenuItems)
        {
            int actionNumber;
            do
            {
                Console.Write("Выберите действие: ");
                actionNumber = ConsoleClass.ReadInteger();
            }
            while (actionNumber < 0 && actionNumber >= countMenuItems);
            return actionNumber;
        }
    }
    public class MainMenu : Menu
    {
        public MainMenu()
        {
            Name = "Главное меню.";
            MenuItems = new MenuItem[]
            {
                new ShowAllEventsItem("Просмотреть все встречи"),
                new ShowEventsForSelectedDateItem("Просмотреть встречи за выбранную дату"),
                new ExportEventsItem("Экспортировать встречи за выбранную дату"),
                new AddEventItem("Создать встречу"),
                new CloseProgramItem("Закрыть программу")
            };
        }
        public override void Start()
        {
            Console.WriteLine(Name);

            for (int i = 0; i < MenuItems.Length; i++)
                Console.WriteLine($"{i} - {MenuItems[i].Name}");

            MenuItems[GetActionNumber(MenuItems.Length)].Click();
        }
    }
    public class MenuOfEvent : Menu
    {
        public MenuOfEvent(Event @event)
        {
            Name = $"Меню управления встречей {@event.Name}";
            MenuItems = new MenuItem[]
            {
                new ReturnToMenuItem("Вернуться в главное меню"),
                new ChangeNameEventItem("Изменить имя", @event),
                new ChangeStartDateEventItem("Изменить начало встречи", @event),
                new ChangeEndDateEventItem("Изменить конец встречи", @event),
                new ChangeReminderEventItem("Изменить напоминание", @event),
                new DeleteEventItem("Удалить встречу", @event)
            };
        }
        public override void Start()
        {
            Console.WriteLine(Name);

            for (int i = 0; i < MenuItems.Length; i++)
                Console.WriteLine($"{i} - {MenuItems[i].Name}");

            MenuItems[GetActionNumber(MenuItems.Length)].Click();
        }
    }
}
