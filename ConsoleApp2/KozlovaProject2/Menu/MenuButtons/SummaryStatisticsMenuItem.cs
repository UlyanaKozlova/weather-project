using KozlovaProject2.WeatherData;

namespace KozlovaProject2.Menu.MenuButtons
{
    /// <summary>
    /// Класс для 3 пункта проекта.
    /// </summary>
    public class SummaryStatisticsMenuItem : IMenuItem
    {
        public string Name => "Вывести на экран сводную статистику.";

        public void Execute()
        {
            HashSet<DateTime> fishingDays = new();
            HashSet<DateTime> warmRainyDays = new();
            HashSet<DateTime> okPressureDays = new();
            Dictionary<string, int> locationCount = new();
            foreach (WeatherRec weather in WeatherStorage.Weathers)
            {
                if (weather.WindSpeed3Pm is < 13 and >= 0)
                {
                    fishingDays.Add(weather.Date.Date);
                }
                
                if (!locationCount.TryAdd(weather.Location!, 1))
                {
                    locationCount[weather.Location!]+=1;
                }

                if (weather is { MaxTemp: >= 20, RainToday: "Yes" } && Math.Abs(weather.MaxTemp - WeatherRec.SpecialCaseNaOfMaxTemp) > WeatherRec.ToleranceForCompare)
                {
                    warmRainyDays.Add(weather.Date.Date);
                }
                
                if (weather.Pressure9Am is <= 1007 and >= 1000)
                {
                    okPressureDays.Add(weather.Date.Date);
                }
            }
            Console.WriteLine($"-Количество дней пригодных, для рыбалки: {fishingDays.Count}");
            Console.WriteLine($"-Количество групп записей если группировать их по локации и количество записей в каждой группе.");
            foreach (KeyValuePair<string?, int> entry in locationCount)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
            Console.WriteLine($"-Количество теплых дождливых дней: {warmRainyDays.Count}");
            Console.WriteLine($"-Количество дней с нормальным атмосферным давлением с утра: {okPressureDays.Count}");

        }
    }
}