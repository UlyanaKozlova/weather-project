using KozlovaProject2.Helper;
using KozlovaProject2.Helper.Exceptions;
using KozlovaProject2.WeatherData;

namespace KozlovaProject2.Menu.MenuButtons
{
    /// <summary>
    /// Класс для 5 пункта проекта.
    /// </summary>
    public class SunnyDaysMenuItem : IMenuItem
    {
        public string Name =>"Вывести на экран и записать в файл с именем, выбранным пользователем," +
                             " выборку записей дней, когда солнечная погода держалась хотя бы 4 часа за день.";
        
        public void Execute()
        {
            WeatherRec maxSunshineDay=new();
            double maxSunshine = double.MinValue;
            List<string> results = new();
            foreach (WeatherRec weather in WeatherStorage.Weathers)
            {
                if (weather.Sunshine >= 4)
                {
                    Console.WriteLine(weather);
                    results.Add(weather.ToCsvRepresentation());
                }

                if (weather.Sunshine > maxSunshine)
                {
                    maxSunshine = weather.MaxTemp;
                    maxSunshineDay = weather;
                }
            }
            Console.WriteLine($"Дата: {maxSunshineDay.Date:yyyy-MM-dd}, максимальная температура {maxSunshineDay.MaxTemp}, которая была в день, когда солнце светило дольше всего.");
            
            Console.Write("Введите имя файла: ");
            string outputPath = $"{FileHelper.GetFilesDirectory()}Output{Path.DirectorySeparatorChar}" + Console.ReadLine() + ".csv";
            try
            {
                FileHelper.WriteLines(outputPath, results);
            }
            catch (FileWriteException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}