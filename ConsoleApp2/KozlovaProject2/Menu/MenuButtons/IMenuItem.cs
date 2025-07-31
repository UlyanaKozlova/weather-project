namespace KozlovaProject2.Menu.MenuButtons
{
    /// <summary>
    /// Интерфейс для элементов меню.
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// Название элемента меню.
        /// </summary>
        public string Name { get; }
        
        
        /// <summary>
        /// Задача, выполняемая элементом меню.
        /// </summary>
        public void Execute();
    }
}