using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public bool IsRead { get; private set; }

        public Book(string title, string author)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Название и Автор не могут быть пустыми.");

            Title = title;
            Author = author;
            IsRead = false;
        }

        public void MarkAsRead()
        {
            IsRead = true;
        }
    }
}
