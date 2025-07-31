using KozlovaProject2.Helper.Exceptions;
using System.Security;
using System.Text;

namespace KozlovaProject2.Helper
{
    /// <summary>
    /// Класс для помощи при работе с файлом.
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// Метод для чтения строк из файла.
        /// </summary>
        /// <param name="path"> Путь к файлу.</param>
        /// <returns> Массив строк, считанных из файла.</returns>
        /// <exception cref="FileReadException"> Ошибка чтения данных из файла.</exception>
        public static string[] Readlines(string? path)
        {
            try
            {
                if (File.Exists(path))
                {
                    return File.ReadAllLines(path, Encoding.UTF8);
                }

                throw new FileReadException("Файл не найден.");

            }
            catch (FileLoadException e)
            {
                throw new FileReadException("Проблема с открытием файла.",e);
            }
            catch (Exception e) when (e is IOException or UnauthorizedAccessException or SecurityException)
            {

                throw new FileReadException("Проблема с чтением файла.",e);
            }
        }
        /// <summary>
        /// Метод для записи в файл.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <param name="content">Список данных для записи в файл.</param>
        /// <exception cref="FileWriteException">Ошибка записи в файл.</exception>
        public static void WriteLines(string path, List<string> content)
        {
            content.Insert(0, CsvParser.Header); 
            try
            {
                File.WriteAllLines(path, content, Encoding.UTF8);
            }
            catch (EndOfStreamException ex)
            {
                throw new FileWriteException("Проблема с открытием файла.", ex);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or SecurityException)
            {
                throw new FileWriteException("Проблема с записью в файл.", ex);
            }
        }
        /// <summary>
        /// Метод для получения папки с файлами.
        /// </summary>
        /// <returns>Путь к папке с файлами.</returns>
        public static string GetFilesDirectory()
        {
            
            string[] dirs = Directory.GetCurrentDirectory().Split(Path.DirectorySeparatorChar);
            string workingDirectory = string.Join(Path.DirectorySeparatorChar, dirs, 0, dirs.Length - 3)
                                      + Path.DirectorySeparatorChar;
            return workingDirectory;
        }
    }
}