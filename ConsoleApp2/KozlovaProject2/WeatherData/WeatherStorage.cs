namespace KozlovaProject2.WeatherData
{
    /// <summary>
    /// Класс для хранения и обновления погоды.
    /// </summary>
    public static class WeatherStorage
    {
        /// <summary>
        /// Свойство для списка погоды.
        /// </summary>
        public static List<WeatherRec> Weathers { get; private set; } = new();
        /// <summary>
        /// Метод для обновления погоды.
        /// </summary>
        /// <param name="weathers">Обновленный список погоды.</param>
        public static void UpdateWeather(List<WeatherRec> weathers)
        {
            Weathers = weathers;
        } 
   }
}