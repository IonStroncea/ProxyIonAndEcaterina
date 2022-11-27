using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common;
using DAL;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookController : ControllerBase
    {
        private readonly ILogger<BookCollection> _logger;

        public BookController(ILogger<BookCollection> logger)
        {
            _logger = logger;
        }

        [HttpGet("/id")]
        public ActionResult GetBookById([FromQuery] int id)
        {
            IList<BookCollection> books = DataBase.GetBooksById(id);

            return Ok(books.First());
        }

        [HttpGet("/count")]
        public ActionResult GetBookByCount([FromQuery] int count)
        {
            IList<BookCollection> books = DataBase.GetBooksByCount(count);

            return Ok(books);
        }

        [HttpGet("/title")]
        public ActionResult GetBookByTitle([FromQuery] string title)
        {
            IList<BookCollection> books = DataBase.GetBooksByTitle(title);

            return Ok(books);
        }

        [HttpGet("/author")]
        public ActionResult GetBookByAuthor([FromQuery] string author)
        {
            IList<BookCollection> books = DataBase.GetBooksByAuthor(author);

            return Ok(books);
        }

        [HttpGet("/genre")]
        public ActionResult GetBookByGenre([FromQuery] string genre)
        {
            IList<BookCollection> books = DataBase.GetBooksByGenre(genre);

            return Ok(books);
        }

        [HttpPost]
        public ActionResult CreateNewBook([FromBody] BookCollection newBook)
        {
            BookCollection book = DataBase.CreateBook(newBook);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Created("", book);
            }
            
        }

        [HttpDelete()]
        public ActionResult DeleteBook(int id)
        {
            int result = DataBase.DeleteBook(id);

            if (result == 1)
            {
                return NoContent();
            }
            else 
            {
                return NotFound();
            }
        }

        //[HttpPatch("{idBook}")]
        //public ActionResult UpdateBook()

    }
}
