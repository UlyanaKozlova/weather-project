using KozlovaProject2.Helper;
using KozlovaProject2.WeatherData;

namespace KozlovaProject2.Menu.MenuButtons
{
    /// <summary>
    /// Класс для 2 пункта проекта.
    /// </summary>
    public class WeatherSydneyMenuItem:IMenuItem
    {
        public string Name => "Вывести на экран и сохранить в файл из набора исходных данных информацию о погоде, собранной в Сиднее  за 2009 и 2010 год.";
        private readonly string _outputPath = $"{FileHelper.GetFilesDirectory()}Output{Path.DirectorySeparatorChar}Sydney_2009_2010_weatherAUS.csv"; 
        public void Execute()
        {
            List<string> results = new();
            foreach (WeatherRec weather in WeatherStorage.Weathers)
            {
                if (weather is { Location: "Sydney", Date.Year: 2009 or 2010 })
                {
                    Console.WriteLine(weather);
                    results.Add(weather.ToCsvRepresentation());
                }
            }
            FileHelper.WriteLines(_outputPath, results);
        }
    }
}