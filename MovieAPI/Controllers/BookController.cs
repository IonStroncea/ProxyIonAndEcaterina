using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet]
        public ActionResult GetBook([FromQuery] int count)
        {
            BookCollection[] books =
            {
                new BookCollection() { Title = "Verity"},
                new BookCollection() { Title = "Turnul"},
                new BookCollection() { Title = "Pianistul"}
            };
            return Ok(books.Take(count));
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
