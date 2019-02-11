using MyRESTSample.Models;
using MyRESTSample.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyRESTSample.Tests.Services
{
    public class BooksServiceTest
    {
        [Fact]
        public void GetBookByIdExpectNull()
        {
            // AAA

            // arrange
            var service = new BooksService();
            Book expectedBook = null;

            // act
            var actualBook = service.GetBookById(42);

            // assert
            Assert.Equal(expectedBook, actualBook);
        }

        [Fact]
        public void GetBookByIdExpectBook()
        {
            // arrange
            var service = new BooksService();
            string expectedTitle = "Professional C# 6";

            // act
            var actualBook = service.GetBookById(1);

            // assert
            Assert.Equal(expectedTitle, actualBook.Title);
        }
    }
}
