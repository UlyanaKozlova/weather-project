using KozlovaProject2.Helper;
using KozlovaProject2.WeatherData;

namespace KozlovaProject2.Menu.MenuButtons
{
    /// <summary>
    /// Класс для 6 пункта проекта.
    /// </summary>
    public class SortedByLocationAndRainfallMenuItem:IMenuItem
    {
        public string Name =>
            "Вывести на экран переупорядоченный набор исходных данных о записях,в котором выделены группы по месту расположения станции сбора метеоданных, " +
            "при этом в каждой группе записи упорядочены по убыванию осадков.";

        public void Execute()
        {
            List<string> results = new();
            Dictionary<string, List<WeatherRec>> locationGroups = new();
            foreach (WeatherRec weather in WeatherStorage.Weathers)
            {
                if (!locationGroups.ContainsKey(weather.Location ?? ""))
                {
                    locationGroups[weather.Location ?? ""] = new List<WeatherRec>();
                }
                locationGroups[weather.Location ?? ""].Add(weather);
            }

            foreach (KeyValuePair<string, List<WeatherRec>> locationGroup in locationGroups)
            {
                string location = locationGroup.Key;
                List<WeatherRec> weatherList =locationGroup.Value;
                double totalRainfall = 0;
                foreach (WeatherRec weather in weatherList)
                {
                    totalRainfall += weather.Rainfall; 
                }
                double averageRainfall = totalRainfall / weatherList.Count;
                weatherList.Sort((x, y) => y.Rainfall.CompareTo(x.Rainfall)); 
                Console.WriteLine($"Среднее арифметическое показателей осадков в данной {location}: {averageRainfall}");
                foreach (WeatherRec weather in weatherList)
                {
                    Console.WriteLine(weather.ToString());
                    results.Add(weather.ToCsvRepresentation());
                }
                string outputPath = $"{FileHelper.GetFilesDirectory()}Output{Path.DirectorySeparatorChar}" + "average_rain_weatherAUS.csv";
                FileHelper.WriteLines(outputPath, results);

            }
        }
    }
}