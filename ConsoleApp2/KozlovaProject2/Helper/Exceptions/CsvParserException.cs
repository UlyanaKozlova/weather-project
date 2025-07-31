namespace KozlovaProject2.Helper.Exceptions
{
    /// <summary>
    /// Общая ошибка парсинга.
    /// </summary>
    public class CsvParserException: Exception
    {
        /// <summary>
        /// Конструктор класса с параметрами сообщения.
        /// </summary>
        /// <param name="message">Конкретное сообщение об ошибке.</param>
        public CsvParserException(string message) : base(message) { }
        /// <summary>
        /// Конструктор класса с параметром сообщения и предыдущей ошибкой.
        /// </summary>
        /// <param name="message">Конкретное сообщение об ошибке.</param>
        /// <param name="inner">Предыдущая ошибка.</param>
        public CsvParserException(string message, Exception inner) : base(message, inner) { }
    }
}