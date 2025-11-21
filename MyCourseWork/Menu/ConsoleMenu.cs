using BLL.Dependency;
using System.Text;

namespace PL.Menu
{
    public static class ConsoleMenu
    {
        public static void ShowMainMenu()
        {
            var categoryMenu = new CategoryMenu();
            var productMenu = new ProductMenu();
            var supplierMenu = new SupplierMenu();

            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("\n=== Електронний облік товарів ===");
                Console.WriteLine("1. Категорії");
                Console.WriteLine("2. Товари");
                Console.WriteLine("3. Постачальники");
                Console.WriteLine("0. Вихід");
                Console.Write("Виберіть пункт: ");

                switch (Console.ReadLine())
                {
                    case "1": categoryMenu.ShowMenu(); break;
                    case "2": productMenu.ShowMenu(); break;
                    case "3": supplierMenu.ShowMenu(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір"); break;
                }
            }
        }
    }
}
