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
        private static readonly string[] Genres = new[]
        {
            "Poezie", "Istorie", "Biografie", "Autobiografie", "Thriller", "Science Fiction", "Romantic", "Detective", "Fictiune"
        };

        private readonly ILogger<BookCollection> _logger;

        public BookController(ILogger<BookCollection> logger)
        {
            _logger = logger;
        }

        [HttpGet("/count")]
        public ActionResult GetBook([FromQuery] int count)
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

        [HttpGet("/gnere")]
        public ActionResult GetBookByGenre([FromQuery] string genre)
        {
            IList<BookCollection> books = DataBase.GetBooksByGenre(genre);

            return Ok(books);
        }

        [HttpPost]
        public ActionResult CreateNewBook([FromBody] BookCollection newBook)
        {
            return Created("", newBook);
        }

        [HttpDelete("{idBook}")]
        public ActionResult DeleteBook(int id)
        {
            return NoContent();
        }

        //[HttpPatch("{idBook}")]
        //public ActionResult UpdateBook()

    }
}
