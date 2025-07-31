using System.Globalization;

namespace KozlovaProject2.WeatherData
{
    public class WeatherRec
    {
        /// <summary>
        /// Константа, используемая, если MaxTemp равно NA.
        /// </summary>
        public const double SpecialCaseNaOfMaxTemp = -1000000000.0;

        /// <summary>
        /// Константа, используемая, если Rainfall равно NA.
        /// </summary>
        public const double SpecialCaseNaOfRainfall = -1.0;

        /// <summary>
        /// Константа, используемая, если Sunshine равно NA.
        /// </summary>
        public const double SpecialCaseNaOfSunshine = -1.0;

        /// <summary>
        /// Константа, используемая, если Speed3Pm равно NA.
        /// </summary>
        public const int SpecialCaseNaOfWindSpeed3Pm = -1;

        /// <summary>
        /// Константа, используемая, если Pressure9Am равно NA.
        /// </summary>
        public const double SpecialCaseNaOfPressure9Am = -1.0;

        /// <summary>
        /// Константа для сравнения.
        /// </summary>
        public static readonly double ToleranceForCompare = 0.0001;
        
        
        
        

        /// <summary>
        /// Свойство для даты.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Свойство для места.
        /// </summary>
        public string? Location { get; }

        /// <summary>
        /// Свойство для максимальной температуры.
        /// </summary>
        public double MaxTemp { get; }

        /// <summary>
        /// Свойство для осадков.
        /// </summary>
        public double Rainfall { get; }

        /// <summary>
        /// Свойство для солнечности.
        /// </summary>
        public double Sunshine { get; }

        /// <summary>
        /// Свойство для скорости ветра в 3 часа дня.
        /// </summary>
        public int WindSpeed3Pm { get; }

        /// <summary>
        /// Свойство для давления в 9 часов утра.
        /// </summary>
        public double Pressure9Am { get; }

        /// <summary>
        /// Свойство для дожя сегодня.
        /// </summary>
        public string? RainToday { get; }

        private string? WindGustDir { get; }
        private string? Evaporation { get; }
        private string? MinTemp { get; }
        private string? WindGustSpeed { get; }
        private string? WindDir9Am { get; }
        private string? WindDir3Pm { get; }
        private string? WindSpeed9Am { get; }
        private string? RainTomorrow { get; }
        private string? Humidity9Am { get; }
        private string? Humidity3Pm { get; }
        private string? Pressure3Pm { get; }
        private string? Cloud9Am { get; }
        private string? Cloud3Pm { get; }
        private string? Temp9Am { get; }
        private string? Temp3Pm { get; }

        /// <summary>
        /// Основной конструктор. 
        /// </summary>
        /// <param name="date">Дата.</param>
        /// <param name="location">Место.</param>
        /// <param name="minTemp">Минимальная Температура.</param>
        /// <param name="maxTemp">Максимальная температура.</param>
        /// <param name="rainfall">Осадки.</param>
        /// <param name="evaporation">Испарение.</param>
        /// <param name="sunshine">Солнце.</param>
        /// <param name="windGustDir">Направление ветра.</param>
        /// <param name="windGustSpeed">Скорость ветра.</param>
        /// <param name="windDir9Am">Направление ветра в 9 часа утра.</param>
        /// <param name="windDir3Pm">Направление ветра в 3 часа дня.</param>
        /// <param name="windSpeed9Am">Скорость ветра в 9 часа утра.</param>
        /// <param name="windSpeed3Pm">Скорость ветра в 3 часа дня.</param>
        /// <param name="humidity9Am">Влажность в 9 часа утра.</param>
        /// <param name="humidity3Pm">Влажность в 3 часа дня.</param>
        /// <param name="pressure9Am">Давление в 9 часа утра.</param>
        /// <param name="pressure3Pm">Давление в 3 часа дня.</param>
        /// <param name="cloud9Am">Облачность в 9 часа утра.</param>
        /// <param name="cloud3Pm">Облачность в 3 часа дня.</param>
        /// <param name="temp9Am">Температура в 9 часа утра.</param>
        /// <param name="temp3Pm">Температура в 3 часа дня.</param>
        /// <param name="rainToday">Дождь сегодня.</param>
        /// <param name="rainTomorrow">Дождь завтра.</param>
        public WeatherRec(DateTime date, string? location, string? minTemp, double maxTemp, double rainfall,
            string? evaporation, double sunshine,
            string? windGustDir, string? windGustSpeed, string? windDir9Am, string? windDir3Pm, string? windSpeed9Am,
            int windSpeed3Pm, string? humidity9Am,
            string? humidity3Pm, double pressure9Am, string? pressure3Pm, string? cloud9Am, string? cloud3Pm,
            string? temp9Am, string? temp3Pm, string? rainToday,
            string? rainTomorrow)
        {
            Date = date;
            Location = location;
            MinTemp = minTemp;
            MaxTemp = maxTemp;
            Rainfall = rainfall;
            Evaporation = evaporation;
            Sunshine = sunshine;
            WindGustDir = windGustDir;
            WindGustSpeed = windGustSpeed;
            WindDir9Am = windDir9Am;
            WindDir3Pm = windDir3Pm;
            WindSpeed9Am = windSpeed9Am;
            WindSpeed3Pm = windSpeed3Pm;
            Humidity9Am = humidity9Am;
            Humidity3Pm = humidity3Pm;
            Pressure9Am = pressure9Am;
            Pressure3Pm = pressure3Pm;
            Cloud9Am = cloud9Am;
            Cloud3Pm = cloud3Pm;
            Temp9Am = temp9Am;
            Temp3Pm = temp3Pm;
            RainToday = rainToday;
            RainTomorrow = rainTomorrow;
        }

        /// <summary>
        /// Пустой конструктор для неудавшегося парсинга.
        /// </summary>
        public WeatherRec() { }

        /// <summary>
        /// Метод для представления объекта в виде, подходящем для записи в Csv файл.
        /// </summary>
        /// <returns>Представление объекта в виде, подходящем для записи в Csv файл.</returns>
        public string ToCsvRepresentation()
        {
            (string maxTemp, string rainFall, string sunshine, string windSpeed3Pm, string pressure9Am) =
                GetStringNaValues();
            return
                $"{Date:yyyy-MM-dd},{Location},{MinTemp},{maxTemp},{rainFall},{Evaporation},{sunshine},{WindGustDir},{WindGustSpeed},{WindDir9Am}," +
                $"{WindDir3Pm},{WindSpeed9Am},{windSpeed3Pm},{Humidity9Am},{Humidity3Pm},{pressure9Am},{Pressure3Pm},{Cloud9Am}," +
                $"{Cloud3Pm},{Temp9Am},{Temp3Pm},{RainToday},{RainTomorrow}";
        }

        /// <summary>
        /// Переопределение метода ToString.
        /// </summary>
        /// <returns>Строковое представление объекта.</returns>
        public override string ToString()
        {
            (string maxTemp, string rainFall, string sunshine, string windSpeed3Pm, string pressure9Am) =
                GetStringNaValues();
            return
                $"Date: {Date:yyyy-MM-dd}, Location: {Location}, MinTemp: {MinTemp}, MaxTemp: {maxTemp}, RainFall: {rainFall}, Evaporation: {Evaporation}, " +
                $"Sunshine: {sunshine}, WindGustDir: {WindGustDir}, WindGustSpeed: {WindGustSpeed}, WindDir9Am: {WindDir9Am}, WindDir3Pm: {WindDir3Pm}, " +
                $"WindSpeed9Am: {WindSpeed9Am}, WindSpeed3Pm: {windSpeed3Pm}, Humidity9Am: {Humidity9Am}, Humidity3Pm: {Humidity3Pm}, Pressure9Am:{pressure9Am}, " +
                $"Pressure3Pm: {Pressure3Pm}, Cloud9Am: {Cloud9Am}, Cloud3Pm: {Cloud3Pm}, Temp9Am: {Temp9Am}, Temp3Pm: {Temp3Pm}, RainToday: {RainToday}, RainTomorrow: {RainTomorrow}";
        }


        private (string, string, string, string, string) GetStringNaValues()
        {
            string maxTemp = Math.Abs(MaxTemp - SpecialCaseNaOfMaxTemp) < ToleranceForCompare
                ? "NA"
                : MaxTemp.ToString(CultureInfo.InvariantCulture);
            string rainFall = Math.Abs(Rainfall - SpecialCaseNaOfRainfall) < ToleranceForCompare
                ? "NA"
                : Rainfall.ToString(CultureInfo.InvariantCulture);
            string sunshine = Math.Abs(Sunshine - SpecialCaseNaOfSunshine) < ToleranceForCompare
                ? "NA"
                : Sunshine.ToString(CultureInfo.InvariantCulture);
            string windSpeed3Pm = WindSpeed3Pm == SpecialCaseNaOfWindSpeed3Pm ? "NA" : WindSpeed3Pm.ToString();
            string pressure9Am = Math.Abs(Pressure9Am - SpecialCaseNaOfPressure9Am) < ToleranceForCompare
                ? "NA"
                : Pressure9Am.ToString(CultureInfo.InvariantCulture);
            return (maxTemp, rainFall, sunshine, windSpeed3Pm, pressure9Am);
        }
    }
}