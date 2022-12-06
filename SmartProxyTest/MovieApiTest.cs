using Common;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieAPI.Controllers;
using System.Collections.Generic;

namespace SmartProxyTest
{
    [TestClass]
    public class MovieApiTest
    {
        private readonly ILogger<BookCollection> _logger = new Logger<BookCollection>();

        [TestMethod]
        public void GetBookByIdTest_1_BookWithId1()
        {
            //Arrage
            DataBase.connString = "Server=DESKTOP-3NTRSR2;Initial Catalog=Books1;User ID=sa;Password=sa";

            BookController controller = new BookController(_logger);
            BookCollection expectedBook = new BookCollection();
            expectedBook.idBook = 1;
            expectedBook.Title = "Smart proxy";
            expectedBook.Author = "Ion Stroncea";
            expectedBook.Genre = "Fantasticul in prezent";
            expectedBook.Rating = 10;

            //Act
            ActionResult result = controller.GetBookById(1);
            BookCollection book = (result as OkObjectResult).Value as BookCollection;


            //Assert
            Assert.AreEqual(expectedBook.idBook, book.idBook);
            Assert.AreEqual(expectedBook.Title, book.Title);
            Assert.AreEqual(expectedBook.Author, book.Author);
            Assert.AreEqual(expectedBook.Genre, book.Genre);
            Assert.AreEqual(expectedBook.Rating, book.Rating);
        }

        [TestMethod]
        public void GetBookByTitle_Smartproxy_BookWithTitlesmartProxy()
        {
            //Arrage
            DataBase.connString = "Server=DESKTOP-3NTRSR2;Initial Catalog=Books1;User ID=sa;Password=sa";

            BookController controller = new BookController(_logger);
            BookCollection expectedBook = new BookCollection();
            expectedBook.idBook = 1;
            expectedBook.Title = "Smart proxy";
            expectedBook.Author = "Ion Stroncea";
            expectedBook.Genre = "Fantasticul in prezent";
            expectedBook.Rating = 10;

            IList<BookCollection> bookListExpected = new List<BookCollection>();
            bookListExpected.Add(expectedBook);

            //Act
            ActionResult result = controller.GetBookByTitle("Smart proxy");
            IList<BookCollection> bookList = (result as OkObjectResult).Value as IList<BookCollection>;


            //Assert
            Assert.AreEqual(bookListExpected.Count, bookList.Count);

            BookCollection book = bookList[0];

            Assert.AreEqual(expectedBook.idBook, book.idBook);
            Assert.AreEqual(expectedBook.Title, book.Title);
            Assert.AreEqual(expectedBook.Author, book.Author);
            Assert.AreEqual(expectedBook.Genre, book.Genre);
            Assert.AreEqual(expectedBook.Rating, book.Rating);
        }

        [TestMethod]
        public void GetBookByAuthor_IonStroncea_BookWithAuthorIonStroncea()
        {
            //Arrage
            DataBase.connString = "Server=DESKTOP-3NTRSR2;Initial Catalog=Books1;User ID=sa;Password=sa";

            BookController controller = new BookController(_logger);
            BookCollection expectedBook = new BookCollection();
            expectedBook.idBook = 1;
            expectedBook.Title = "Smart proxy";
            expectedBook.Author = "Ion Stroncea";
            expectedBook.Genre = "Fantasticul in prezent";
            expectedBook.Rating = 10;

            IList<BookCollection> bookListExpected = new List<BookCollection>();
            bookListExpected.Add(expectedBook);

            //Act
            ActionResult result = controller.GetBookByAuthor("Ion Stroncea");
            IList<BookCollection> bookList = (result as OkObjectResult).Value as IList<BookCollection>;


            //Assert
            Assert.AreEqual(bookListExpected.Count, bookList.Count);

            BookCollection book = bookList[0];

            Assert.AreEqual(expectedBook.idBook, book.idBook);
            Assert.AreEqual(expectedBook.Title, book.Title);
            Assert.AreEqual(expectedBook.Author, book.Author);
            Assert.AreEqual(expectedBook.Genre, book.Genre);
            Assert.AreEqual(expectedBook.Rating, book.Rating);
        }

        public void GetBookByGenre_Fantasticulinprezent_BookWithGenreFantasticulinprezent()
        {
            //Arrage
            DataBase.connString = "Server=DESKTOP-3NTRSR2;Initial Catalog=Books1;User ID=sa;Password=sa";

            BookController controller = new BookController(_logger);
            BookCollection expectedBook = new BookCollection();
            expectedBook.idBook = 1;
            expectedBook.Title = "Smart proxy";
            expectedBook.Author = "Ion Stroncea";
            expectedBook.Genre = "Fantasticul in prezent";
            expectedBook.Rating = 10;

            IList<BookCollection> bookListExpected = new List<BookCollection>();
            bookListExpected.Add(expectedBook);

            //Act
            ActionResult result = controller.GetBookByGenre("Fantasticul in prezent");
            IList<BookCollection> bookList = (result as OkObjectResult).Value as IList<BookCollection>;


            //Assert
            Assert.AreEqual(bookListExpected.Count, bookList.Count);

            BookCollection book = bookList[0];

            Assert.AreEqual(expectedBook.idBook, book.idBook);
            Assert.AreEqual(expectedBook.Title, book.Title);
            Assert.AreEqual(expectedBook.Author, book.Author);
            Assert.AreEqual(expectedBook.Genre, book.Genre);
            Assert.AreEqual(expectedBook.Rating, book.Rating);
        }
    }
}
