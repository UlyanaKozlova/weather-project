using KozlovaProject2.Menu.MenuButtons;

namespace KozlovaProject2.Menu
{
    /// <summary>
    /// Класс для реализации меню.
    /// </summary>
    public class Menu
    {
        private readonly List <IMenuItem> _menuItems;
        /// <summary>
        /// Конструктор для меню.
        /// </summary>
        /// <param name="menuItems">Элементы меню.</param>
        public Menu(List<IMenuItem> menuItems)
        {
            _menuItems = menuItems;
        }
        /// <summary>
        /// Метод для работы с меню.
        /// </summary>
        public void Show()
        {
            int choice;
            do
            {
                Console.Clear();
                Render();
                bool digitOk = false;
                do
                {
                    Console.Write("Введите цифру: ");
                    if (int.TryParse(Console.ReadLine(), out choice) && choice >=1  && choice <= _menuItems.Count )
                    {
                        digitOk = true;
                    }
                    
                } while (!digitOk); 
                
                _menuItems[choice - 1].Execute();
                Console.WriteLine("Нажмите любую кнопку для продолжения.");
                Console.ReadKey(true);

            } while (choice != 6);
        }
        private void Render()
        {
            for (int i = 0; i < _menuItems.Count; i++)
            {
                Console.WriteLine($"{i+1} {_menuItems[i].Name}");
            }
        }
    }
}