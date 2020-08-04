using System;
using System.Timers;

namespace DirectumPlanner
{
    class Program
    {
        public static MainMenu MainMenu;
        private static Timer timer;
        public static void Main(string[] args)
        {
            timer = new Timer
            {
                Interval = 1000,
                Enabled = true
            };
            timer.Elapsed += Timer_Elapsed;
            MainMenu = new MainMenu();
            MainMenu.Start();
        }
        public static void Exit()
        {
            Console.WriteLine("Вы уверены, что хотите выйти?(Y\\N)");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
                Environment.Exit(0);
        }
        private static void Timer_Elapsed(Object sender, EventArgs args)
        {
            foreach (Event @event in Management.Events)
            {
                if (DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") == @event.Reminder.ToString("dd MMM yyyy HH:mm:ss"))
                    Console.WriteLine("\nНапоминание о предстоящей встрече." + @event.ToString());
            }
        }
    }
    
}
