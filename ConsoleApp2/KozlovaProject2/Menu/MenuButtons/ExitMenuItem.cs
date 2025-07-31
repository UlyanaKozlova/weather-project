namespace KozlovaProject2.Menu.MenuButtons
{
    /// <summary>
    /// Класс для 4 пункта проекта.
    /// </summary>
    public class ExitMenuItem:IMenuItem
    {
        public string Name => "Завершение работы программы.";

        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}