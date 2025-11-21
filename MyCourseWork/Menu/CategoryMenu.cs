using BLL.Dependency;
using BLL.Exceptions;
using BLL.Interfaces;
using BLL.Models;
using System.Text;

namespace PL.Menu
{
    public class CategoryMenu
    {
        private readonly ICategoryService _service = ServiceFactory.CreateCategoryService();

        public void ShowMenu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n--- Категорії ---");
            Console.WriteLine("1. Додати");
            Console.WriteLine("2. Переглянути всі");
            Console.WriteLine("3. Видалити");
            Console.WriteLine("4. Оновити");
            Console.Write("Виберіть: ");

            try
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Назва: ");
                        string name = Console.ReadLine();
                        _service.Add(new Category { Name = name });
                        Console.WriteLine("Категорію додано!");
                        break;
                    case "2":
                        
                        _service.GetAll().ToList().ForEach(cat =>
                            Console.WriteLine($"{cat.Id} | {cat.Name}"));
                        break;
                    case "3":
                        Console.Write("Id для видалення: ");
                        Guid idDel = Guid.Parse(Console.ReadLine());
                        _service.Delete(idDel);
                        Console.WriteLine("Видалено!");
                        break;
                    case "4":
                        Console.Write("Id для оновлення: ");
                        Guid idUpd = Guid.Parse(Console.ReadLine());
                        Console.Write("Нова назва: ");
                        string newName = Console.ReadLine();
                        _service.Update(new Category { Id = idUpd, Name = newName });
                        Console.WriteLine("Оновлено!");
                        break;
                    default: Console.WriteLine("Невірний вибір"); break;
                }
            }
            catch (ValidationException ex) { Console.WriteLine($"Помилка валідації: {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"Помилка: {ex.Message}"); }
        }
    }
}
