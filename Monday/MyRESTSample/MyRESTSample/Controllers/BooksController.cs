using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRESTSample.Models;
using MyRESTSample.Services;

namespace MyRESTSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return Ok(_booksService.GetBooks());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            _booksService.AddBook(value);
        }
    }
}