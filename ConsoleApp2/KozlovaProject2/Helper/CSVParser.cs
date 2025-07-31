using KozlovaProject2.Helper.Exceptions;
using KozlovaProject2.WeatherData;

namespace KozlovaProject2.Helper
{
    /// <summary>
    /// Класс для парсинга.
    /// </summary>
    public class CsvParser
    {
        private const int CorrectAmountColumns = 23;

        public static readonly string Header =
            "Date,Location,MinTemp,MaxTemp,Rainfall,Evaporation,Sunshine,WindGustDir,WindGustSpeed,WindDir9am,WindDir3pm,WindSpeed9am," +
            "WindSpeed3pm,Humidity9am,Humidity3pm,Pressure9am,Pressure3pm,Cloud9am,Cloud3pm,Temp9am,Temp3pm,RainToday,RainTomorrow";
        /// <summary>
        /// Метод для парсинга.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        /// <returns> Результат, спарсился ли файл.</returns>
        /// <exception cref="CsvParserException"> Ошибка парсинга.</exception>
        public static List<WeatherRec> Parse(string? path)
        {
            List<WeatherRec> weathers = new();
            string[] data = FileHelper.Readlines(path);
            
            if (data.Length == 0 || data[0] != Header)
            {
                throw new CsvParserException("Ошибка обработки CSV: некорректная структура файла");
            }

            foreach (string line in data[1..])
            {
                if (TryParseLine(line, out WeatherRec weather))
                {
                    weathers.Add(weather);
                }
            }
            return weathers;
        }
        /// <summary>
        /// Метод для проверки, парсится ли строка.
        /// </summary>
        /// <param name="line">Строка для парсинга.</param>
        /// <param name="weatherRec">Результат парсинга, если он возможен.</param>
        /// <returns> Возможен ли парсинг строки.</returns>

        private static bool TryParseLine(string line,out WeatherRec weatherRec)
        {
            
            string?[] data = line.Split(',');
            if (data.Length == CorrectAmountColumns)
            {
                if (DateTime.TryParse(data[1-1], out DateTime date))
                {
                    double maxTemp = 0;
                    if (data[3] == "NA")
                    {
                        maxTemp = WeatherRec.SpecialCaseNaOfMaxTemp;
                    }

                    double rainfall = 0;
                    if (data[4] == "NA")
                    {
                        rainfall = WeatherRec.SpecialCaseNaOfRainfall;
                    }

                    double sunshine=0;
                    if (data[6] == "NA")
                    {
                        sunshine = WeatherRec.SpecialCaseNaOfSunshine;
                    }

                    int windSpeed3Pm = 0;
                    if (data[12] == "NA")
                    {
                        windSpeed3Pm = WeatherRec.SpecialCaseNaOfWindSpeed3Pm;
                    }

                    double pressure9Am = 0;
                    if (data[15] == "NA")
                    {
                        pressure9Am = WeatherRec.SpecialCaseNaOfPressure9Am;
                    }

                    if
                        ((Math.Abs(maxTemp - WeatherRec.SpecialCaseNaOfMaxTemp) < WeatherRec.ToleranceForCompare || double.TryParse(data[3], out maxTemp)) && 
                         (Math.Abs(rainfall - WeatherRec.SpecialCaseNaOfRainfall) < WeatherRec.ToleranceForCompare || double.TryParse(data[4], out rainfall)) &&
                         (Math.Abs(sunshine - WeatherRec.SpecialCaseNaOfSunshine) < WeatherRec.ToleranceForCompare || double.TryParse(data[6], out sunshine)) &&
                         (windSpeed3Pm == WeatherRec.SpecialCaseNaOfWindSpeed3Pm || int.TryParse(data[12], out windSpeed3Pm)) && 
                         (Math.Abs(pressure9Am - WeatherRec.SpecialCaseNaOfPressure9Am) < WeatherRec.ToleranceForCompare || double.TryParse(data[15], out pressure9Am)))
                    {
                        string? location = data[1];
                        string? minTemp = data[2];
                        string? evaporation = data[5];
                        string? windGustDir = data[7];
                        string? windGustSpeed = data[8];
                        string? windDir9Am = data[9];
                        string? windDir3Pm = data[10];
                        string? windSpeed9Am = data[11];
                        string? humidity9Am = data[13];
                        string? humidity3Pm = data[14];
                        string? pressure3Pm = data[16];
                        string? cloud9Am = data[17];
                        string? cloud3Pm = data[18];
                        string? temp9Am = data[19];
                        string? temp3Pm = data[20];
                        string? rainToday = data[21];
                        string? rainTomorrow = data[22];
                        weatherRec = new WeatherRec(date, location, minTemp, maxTemp, rainfall, evaporation, sunshine, windGustDir, 
                            windGustSpeed, windDir9Am, windDir3Pm, windSpeed9Am, windSpeed3Pm, humidity9Am, humidity3Pm,
                            pressure9Am, pressure3Pm, cloud9Am, cloud3Pm, temp9Am, temp3Pm, rainToday, rainTomorrow);
                        return true;
                    }
                }
            }

            weatherRec = new WeatherRec();
            return false;
        }
        
        
    }
}