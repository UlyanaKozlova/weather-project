namespace KozlovaProject2.Helper.Exceptions
{
    /// <summary>
    /// Общая ошибка чтения файла.
    /// </summary>
    public class FileReadException:Exception
    {
        /// <summary>
        /// Конструктор класса с параметрами сообщения.
        /// </summary>
        /// <param name="message">Конкретное сообщение об ошибке.</param>
        public FileReadException(string message):base(message){}
        /// <summary>
        /// Конструктор класса с параметром сообщения и предыдущей ошибкой.
        /// </summary>
        /// <param name="message">Конкретное сообщение об ошибке.</param>
        /// <param name="inner">Предыдущая ошибка.</param>
        public FileReadException(string message, Exception inner): base(message,inner){}
    }
}