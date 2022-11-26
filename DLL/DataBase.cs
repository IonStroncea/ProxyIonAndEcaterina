using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class DataBase
    {
        public static string connString = "";

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
    }
}
