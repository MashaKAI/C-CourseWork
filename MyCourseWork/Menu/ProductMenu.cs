using BLL.Dependency;
using BLL.Exceptions;
using BLL.Interfaces;
using BLL.Models;
using System.Text;

namespace PL.Menu
{
    public class ProductMenu
    {
        private readonly IProductService _service = ServiceFactory.CreateProductService();

        public void ShowMenu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n--- Товари ---");
            Console.WriteLine("1. Додати");
            Console.WriteLine("2. Переглянути всі");
            Console.WriteLine("3. Видалити");
            Console.WriteLine("4. Оновити");
            Console.WriteLine("5. Сортувати за назвою");
            Console.WriteLine("6. Сортувати за брендом");
            Console.WriteLine("7. Сортувати за ціною");
            Console.WriteLine("8. Пошук по ключовому слову");
            Console.Write("Виберіть: ");

            try
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Назва: "); string name = Console.ReadLine();
                        Console.Write("Бренд: "); string brand = Console.ReadLine();
                        Console.Write("Ціна: "); decimal price = decimal.Parse(Console.ReadLine());
                        Console.Write("Кількість: "); int qty = int.Parse(Console.ReadLine());
                        Console.Write("Id категорії: "); Guid catId = Guid.Parse(Console.ReadLine());
                        Console.Write("Id постачальника: "); Guid supId = Guid.Parse(Console.ReadLine());

                        _service.Add(new Product { Name = name, Brand = brand, Price = price, Quantity = qty, CategoryId = catId, SupplierId = supId });
                        Console.WriteLine("Товар додано!");
                        break;

                    case "2":
                        _service.GetAll().ToList().ForEach(p =>
                            Console.WriteLine($"{p.Id} | {p.Name} | {p.Brand} | {p.Price} | {p.Quantity}"));
                        break;

                    case "3":
                        Console.Write("Id для видалення: "); Guid idDel = Guid.Parse(Console.ReadLine());
                        _service.Delete(idDel);
                        Console.WriteLine("Видалено!");
                        break;

                    case "4":
                        Console.Write("Id для оновлення: "); Guid idUpd = Guid.Parse(Console.ReadLine());
                        Console.Write("Нова назва: "); string nName = Console.ReadLine();
                        Console.Write("Новий бренд: "); string nBrand = Console.ReadLine();
                        Console.Write("Нова ціна: "); decimal nPrice = decimal.Parse(Console.ReadLine());
                        Console.Write("Нова кількість: "); int nQty = int.Parse(Console.ReadLine());
                        _service.Update(new Product { Id = idUpd, Name = nName, Brand = nBrand, Price = nPrice, Quantity = nQty });
                        Console.WriteLine("Оновлено!");
                        break;

                    case "5":
                        _service.SortByName().ToList().ForEach(p => Console.WriteLine($"{p.Name} | {p.Brand} | {p.Price}"));
                        break;
                    case "6":
                        _service.SortByBrand().ToList().ForEach(p => Console.WriteLine($"{p.Name} | {p.Brand} | {p.Price}"));
                        break;
                    case "7":
                        _service.SortByPrice().ToList().ForEach(p => Console.WriteLine($"{p.Name} | {p.Brand} | {p.Price}"));
                        break;
                    case "8":
                        Console.Write("Ключове слово: "); string kw = Console.ReadLine();
                        _service.SearchByKeyword(kw).ToList().ForEach(p => Console.WriteLine($"{p.Name} | {p.Brand} | {p.Price}"));
                        break;
                    default: Console.WriteLine("Невірний вибір"); break;
                }
            }
            catch (ValidationException ex) { Console.WriteLine($"Помилка валідації: {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"Помилка: {ex.Message}"); }
        }
    }
}
