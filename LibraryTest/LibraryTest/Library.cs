using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Library
    {
        private readonly List<Book> _books = new();

        public void AddBook(string title, string author)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Название и Автор не могут быть пустыми.");

            var book = new Book(title, author);
            _books.Add(book);
        }

        public void RemoveBook(string title)
        {
            var book = _books.FirstOrDefault(b => b.Title == title);
            if (book == null)
                throw new InvalidOperationException("Книга не найдена.");

            _books.Remove(book);
        }

        public Book FindBookByTitle(string title)
        {
            return _books.FirstOrDefault(b => b.Title == title);
        }

        public void MarkBookAsRead(string title)
        {
            var book = FindBookByTitle(title);
            if (book == null)
                throw new InvalidOperationException("Книга не найдена.");

            book.MarkAsRead();
        }

        public int BookCount => _books.Count;
    }
}
