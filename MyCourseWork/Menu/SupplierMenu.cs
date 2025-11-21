using BLL.Dependency;
using BLL.Exceptions;
using BLL.Interfaces;
using BLL.Models;
using System.Text;

namespace PL.Menu
{
    public class SupplierMenu
    {
        private readonly ISupplierService _service = ServiceFactory.CreateSupplierService();

        public void ShowMenu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n--- Постачальники ---");
            Console.WriteLine("1. Додати");
            Console.WriteLine("2. Переглянути всі");
            Console.WriteLine("3. Видалити");
            Console.WriteLine("4. Оновити");
            Console.WriteLine("5. Сортувати за ім’ям");
            Console.WriteLine("6. Сортувати за прізвищем");
            Console.Write("Виберіть: ");

            try
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Ім’я: "); string fn = Console.ReadLine();
                        Console.Write("Прізвище: "); string ln = Console.ReadLine();
                        _service.Add(new Supplier { FirstName = fn, LastName = ln });
                        Console.WriteLine("Додано!");
                        break;

                    case "2":
                        _service.GetAll().ToList().ForEach(s => Console.WriteLine($"{s.Id} | {s.FirstName} | {s.LastName}"));
                        break;

                    case "3":
                        Console.Write("Id для видалення: "); Guid idDel = Guid.Parse(Console.ReadLine());
                        _service.Delete(idDel);
                        Console.WriteLine("Видалено!");
                        break;

                    case "4":
                        Console.Write("Id для оновлення: "); Guid idUpd = Guid.Parse(Console.ReadLine());
                        Console.Write("Нове ім’я: "); string nFn = Console.ReadLine();
                        Console.Write("Нове прізвище: "); string nLn = Console.ReadLine();
                        _service.Update(new Supplier { Id = idUpd, FirstName = nFn, LastName = nLn });
                        Console.WriteLine("Оновлено!");
                        break;

                    case "5":
                        _service.SortByFirstName().ToList().ForEach(s => Console.WriteLine($"{s.FirstName} | {s.LastName}"));
                        break;
                    case "6":
                        _service.SortByLastName().ToList().ForEach(s => Console.WriteLine($"{s.FirstName} | {s.LastName}"));
                        break;

                    default: Console.WriteLine("Невірний вибір"); break;
                }
            }
            catch (ValidationException ex) { Console.WriteLine($"Помилка валідації: {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"Помилка: {ex.Message}"); }
        }
    }
}
