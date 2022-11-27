using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using Common;
using Newtonsoft;
using Newtonsoft.Json;

namespace DAL
{
    public class DataBase
    {
        public static string connString = "";
        public static HttpClient client; 

        public static IList<BookCollection> GetBooksById(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("get_books_by_id", conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader result = cmd.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(result);

                    IList<BookCollection> books = new List<BookCollection>();

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        BookCollection book = new BookCollection();

                        book.Author = table.Rows[i]["author"].ToString();
                        book.Genre = table.Rows[i]["genre"].ToString();
                        book.Title = table.Rows[i]["title"].ToString();
                        book.idBook = Convert.ToInt32(table.Rows[i]["id"]);
                        book.Rating = Convert.ToInt32(table.Rows[i]["rating"]);

                        books.Add(book);
                    }

                    conn.Close();

                    return books;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                return default;
            }
        }

        public static IList<BookCollection> GetBooksByCount(int count)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("get_books_by_count", conn);
                    cmd.Parameters.Add("@count", SqlDbType.Int).Value = count;

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader result = cmd.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(result);

                    IList<BookCollection> books = new List<BookCollection>();

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        BookCollection book = new BookCollection();

                        book.Author = table.Rows[i]["author"].ToString();
                        book.Genre = table.Rows[i]["genre"].ToString();
                        book.Title = table.Rows[i]["title"].ToString();
                        book.idBook = Convert.ToInt32(table.Rows[i]["id"]);
                        book.Rating = Convert.ToInt32(table.Rows[i]["rating"]);

                        books.Add(book);
                    }

                    conn.Close();

                    return books;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                return default;
            }
        }

        public static IList<BookCollection> GetBooksByAuthor(string author)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("get_books_by_author", conn);
                    cmd.Parameters.Add("@author", SqlDbType.NVarChar).Value = author;

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader result = cmd.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(result);

                    IList<BookCollection> books = new List<BookCollection>();

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        BookCollection book = new BookCollection();

                        book.Author = table.Rows[i]["author"].ToString();
                        book.Genre = table.Rows[i]["genre"].ToString();
                        book.Title = table.Rows[i]["title"].ToString();
                        book.idBook = Convert.ToInt32(table.Rows[i]["id"]);
                        book.Rating = Convert.ToInt32(table.Rows[i]["rating"]);

                        books.Add(book);
                    }

                    conn.Close();

                    return books;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                return default;
            }
        }

        public static IList<BookCollection> GetBooksByTitle(string title)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("get_books_by_title", conn);
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader result = cmd.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(result);

                    IList<BookCollection> books = new List<BookCollection>();

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        BookCollection book = new BookCollection();

                        book.Author = table.Rows[i]["author"].ToString();
                        book.Genre = table.Rows[i]["genre"].ToString();
                        book.Title = table.Rows[i]["title"].ToString();
                        book.idBook = Convert.ToInt32(table.Rows[i]["id"]);
                        book.Rating = Convert.ToInt32(table.Rows[i]["rating"]);

                        books.Add(book);
                    }

                    conn.Close();

                    return books;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                return default;
            }
        }
        
        public static IList<BookCollection> GetBooksByGenre(string genre)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("get_books_by_genre", conn);
                    cmd.Parameters.Add("@genre", SqlDbType.NVarChar).Value = genre;

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader result = cmd.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(result);

                    IList<BookCollection> books = new List<BookCollection>();

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        BookCollection book = new BookCollection();

                        book.Author = table.Rows[i]["author"].ToString();
                        book.Genre = table.Rows[i]["genre"].ToString();
                        book.Title = table.Rows[i]["title"].ToString();
                        book.idBook = Convert.ToInt32(table.Rows[i]["id"]);
                        book.Rating = Convert.ToInt32(table.Rows[i]["rating"]);

                        books.Add(book);
                    }

                    conn.Close();

                    return books;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                return default;
            }
        }

        public static BookCollection CreateBook(BookCollection book)
        {
            DBRequest request = new DBRequest();
            request.Procedure = "create_book";
            request.date = DateTime.UtcNow;

            Request param1 = new Request("title", book.Title);
            Request param2 = new Request("author", book.Author);
            Request param3 = new Request("genre",  book.Genre);
            Request param4 = new Request("rating", book.Rating);

            param4.type = (int)SqlDbType.Int;

            request.parameters.Add(param1);
            request.parameters.Add(param2);
            request.parameters.Add(param3);
            request.parameters.Add(param4);

            Console.WriteLine(JsonConvert.SerializeObject(request));

            var task = client.PostAsync("https://localhost:4001/api/DataBase", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            task.Wait();

            var result = task.Result.Content.ReadAsStringAsync();

            result.Wait();

            Console.WriteLine(result.Result);

            if (int.Parse(result.Result) == 1)
            {
                return book;
            }
            else 
            {
                return default;
            }

            
        }

        public static int DeleteBook(int id)
        {
            DBRequest request = new DBRequest();
            request.Procedure = "delete_book";
            request.date = DateTime.UtcNow;

            Request requestParam = new Request();
            requestParam.name = "id";
            requestParam.value = id;
            requestParam.type = (int)SqlDbType.Int;

           request.parameters.Add(requestParam);

            Console.WriteLine(JsonConvert.SerializeObject(request));

            var task = client.PostAsync("https://localhost:4001/api/DataBase", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            task.Wait();

            var result = task.Result.Content.ReadAsStringAsync();

            result.Wait();

            Console.WriteLine(result.Result);
            return int.Parse(result.Result);
        }
    }
}
