namespace KozlovaProject2.Helper.Exceptions
{
    /// <summary>
    /// Общая ошибка записи в файл.
    /// </summary>
    public class FileWriteException:Exception
    {
        /// <summary>
        /// Конструктор класса с параметрами сообщения.
        /// </summary>
        /// <param name="message">Конкретное сообщение об ошибке.</param>
        public FileWriteException(string message):base(message){}
        /// <summary>
        /// Конструктор класса с параметром сообщения и предыдущей ошибкой.
        /// </summary>
        /// <param name="message">Конкретное сообщение об ошибке.</param>
        /// <param name="inner">Предыдущая ошибка.</param>
        public FileWriteException(string message, Exception inner): base(message,inner){}

    }
}