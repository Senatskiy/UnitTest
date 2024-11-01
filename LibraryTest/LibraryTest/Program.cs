namespace Library
{
    public class Program
    {
        private static readonly Library library = new();

        public static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Система управления библиотекой");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Найти книгу по названию");
                Console.WriteLine("4. Отметить книгу как прочитанную");
                Console.WriteLine("5. Показать количество книг");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите вариант: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        RemoveBook();
                        break;
                    case "3":
                        FindBook();
                        break;
                    case "4":
                        MarkBookAsRead();
                        break;
                    case "5":
                        ShowBookCount();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неверный вариант. Пожалуйста, попробуйте еще раз.");
                        break;
                }
            }
        }

        private static void AddBook()
        {
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();
            Console.Write("Введите автора: ");
            string author = Console.ReadLine();

            try
            {
                library.AddBook(title, author);
                Console.WriteLine($"Книга '{title}' от {author} добавлена в библиотеку.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void RemoveBook()
        {
            Console.Write("Введите название книги, которую нужно удалить: ");
            string title = Console.ReadLine();

            try
            {
                library.RemoveBook(title);
                Console.WriteLine($"Книга '{title}' была удалена из библиотеки.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void FindBook()
        {
            Console.Write("Введите название книги, чтобы найти: ");
            string title = Console.ReadLine();

            var book = library.FindBookByTitle(title);
            if (book != null)
            {
                Console.WriteLine($"Найдена книга: '{book.Title}' автора {book.Author}. Статус прочтения: {(book.IsRead ? "Прочитана" : "Не прочитана")}");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }

        private static void MarkBookAsRead()
        {
            Console.Write("Введите название книги, которую хотите отметить как прочитанную: ");
            string title = Console.ReadLine();

            try
            {
                library.MarkBookAsRead(title);
                Console.WriteLine($"Книга '{title}' помечена как прочитанная.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void ShowBookCount()
        {
            Console.WriteLine($"Всего книг в библиотеке: {library.BookCount}");
        }
    }
}