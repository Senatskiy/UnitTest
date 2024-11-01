using Xunit;
using Library;

namespace LibraryTests
{
    public class UnitTest1
    {
        private readonly Library.Library _library = new();

        [Fact]
        public void AddBook_ShouldIncreaseBookCount()
        {
            _library.AddBook("Евгений Онегин", "А.С. Пушкин");
            Assert.Equal(1, _library.BookCount);
        }

        [Fact]
        public void AddBook_WithEmptyTitle_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _library.AddBook("", "Лев Толстой"));
        }

        [Fact]
        public void RemoveBook_ShouldDecreaseBookCount()
        {
            _library.AddBook("Мастер и Маргарита", "Михаил Булгаков");
            _library.RemoveBook("Мастер и Маргарита");
            Assert.Equal(0, _library.BookCount);
        }

        [Fact]
        public void RemoveBook_NotExistingBook_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _library.RemoveBook("Несуществующая книга"));
        }

        [Fact]
        public void MarkBookAsRead_ShouldSetIsReadToTrue()
        {
            _library.AddBook("1984", "Джордж Оруэлл");
            _library.MarkBookAsRead("1984");
            var book = _library.FindBookByTitle("1984");
            Assert.True(book.IsRead);
        }

        [Fact]
        public void FindBookByTitle_ShouldReturnCorrectBook()
        {
            _library.AddBook("Анна Каренина", "Лев Толстой");
            var book = _library.FindBookByTitle("Анна Каренина");
            Assert.NotNull(book);
            Assert.Equal("Анна Каренина", book.Title);
        }
    }
}