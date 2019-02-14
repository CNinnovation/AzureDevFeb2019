using CosmosWithEFCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosWithEFCore.Services
{
    public class BooksSampleService
    {
        private readonly BooksContext _booksContext;
        public BooksSampleService(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public async Task CreateDatabaseAsync()
        {
            bool created = await _booksContext.Database.EnsureCreatedAsync();
            Console.WriteLine($"database created? {created}");
        }

        public async Task CreateSampleBookAsync()
        {
            var book = new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Professional C# 8",
                Publisher = "Wrox Press"
            };
            _booksContext.Books.Add(book);
            int changed = await _booksContext.SaveChangesAsync();
            Console.WriteLine($"inserted {changed} entity");

        }
    }
}
