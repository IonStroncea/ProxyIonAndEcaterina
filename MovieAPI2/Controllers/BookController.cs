using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common;
using DAL;

namespace MovieAPI2.Controllers
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
            Console.WriteLine("Get by id");
            IList<BookCollection> books = DataBase.GetBooksById(id);

            return Ok(books.First());
        }

        [HttpGet("/count")]
        public ActionResult GetBookByCount([FromQuery] int count)
        {
            Console.WriteLine("Get by count");
            IList<BookCollection> books = DataBase.GetBooksByCount(count);

            return Ok(books);
        }

        [HttpGet("/title")]
        public ActionResult GetBookByTitle([FromQuery] string title)
        {
            Console.WriteLine("Get by title");
            IList<BookCollection> books = DataBase.GetBooksByTitle(title);

            return Ok(books);
        }

        [HttpGet("/author")]
        public ActionResult GetBookByAuthor([FromQuery] string author)
        {
            Console.WriteLine("Get by author");
            IList<BookCollection> books = DataBase.GetBooksByAuthor(author);

            return Ok(books);
        }

        [HttpGet("/genre")]
        public ActionResult GetBookByGenre([FromQuery] string genre)
        {
            Console.WriteLine("Get by genre");
            IList<BookCollection> books = DataBase.GetBooksByGenre(genre);

            return Ok(books);
        }

        [HttpPost]
        public ActionResult CreateNewBook([FromBody] BookCollection newBook)
        {
            Console.WriteLine("Create");
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
            Console.WriteLine("Delete");
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
