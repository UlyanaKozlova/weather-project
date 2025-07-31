// Козлова Ульяна Андреевна, БПИ-249-2, вариант 17.

using KozlovaProject2.Menu.MenuButtons;
using System.Globalization;

namespace KozlovaProject2
{
    /// <summary>
    /// Основной класс программы.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            new GetFileAddressMenuItem().Execute();
            List<IMenuItem> menuItems =
            [
                new GetFileAddressMenuItem(), new WeatherSydneyMenuItem(), new SummaryStatisticsMenuItem(), new SunnyDaysMenuItem(), new SortedByLocationAndRainfallMenuItem(), new ExitMenuItem()
            ];
            KozlovaProject2.Menu.Menu menu = new(menuItems);
            menu.Show();
        }
    }
}