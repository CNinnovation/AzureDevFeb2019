using System.Collections.Generic;
using MyRESTSample.Models;

namespace MyRESTSample.Services
{
    public interface IBooksService
    {
        void AddBook(Book book);
        Book GetBookById(int id);
        IEnumerable<Book> GetBooks();
    }
}