using KozlovaProject2.Helper;
using KozlovaProject2.Helper.Exceptions;
using KozlovaProject2.WeatherData;

namespace KozlovaProject2.Menu.MenuButtons
{
    /// <summary>
    /// Класс для 1 пункта проекта.
    /// </summary>
    public class GetFileAddressMenuItem:IMenuItem
    {
        public string Name => "Изменить адрес файла, из которого загружаются данные о погодных условиях в Австралии.";
        private string?  _input;
        private readonly string?  _currentPath = FileHelper.GetFilesDirectory() + "weatherAUS.csv";

        public void Execute()
        {
            Console.WriteLine("Введите путь к файлу или введите 1, если хотите взять данные из исходного файла.");
            bool isOk = false;
            do
            {
                try
                {
                    _input = Console.ReadLine();
                    if (_input == "1")
                    {
                        _input = _currentPath;
                    }

                    List<WeatherRec> newWeatherData = CsvParser.Parse(_input);
                    WeatherStorage.UpdateWeather(newWeatherData);

                    isOk = true;
                }
                catch (Exception e) when (e is IOException or FileReadException or CsvParserException)
                {
                    Console.WriteLine($"Ошибка с файлом: {e.Message}" +
                                      "\nВведите путь к файлу или введите 1, если хотите взять данные из исходного файла, ещё раз.");
                }
                
            } while (!isOk);
        }
    }
}