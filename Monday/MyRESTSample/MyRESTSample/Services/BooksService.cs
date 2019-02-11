using MyRESTSample.Models;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace MyRESTSample.Services
{
    public class BooksService : IBooksService
    {
        private readonly ConcurrentDictionary<int, Book> _books = new ConcurrentDictionary<int, Book>();

        public BooksService()
        {
            _books.TryAdd(3, new Book { BookId = 3, Title = "Professional C# 6", Publisher = "Wrox Press" });
            _books.TryAdd(2, new Book { BookId = 2, Title = "Professional C# 7", Publisher = "Wrox Press" });
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books.Values;
        }

        public Book GetBookById(int id)
        {
            if (_books.TryGetValue(id, out Book book))
            {
                return book;
            }
            else
            {
                return null;
            }
        }

        public void AddBook(Book book)
        {
            _books.TryAdd(book.BookId, book);
        }
    }
}
