using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Interface;
using BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public class BookRepository : IBook
    {
        public List<Books> GetAllBooks()
        {
            List<Books> booklist = new List<Books>();

            try
            {
                SqlConnection MyCon = new SqlConnection(DBConnection.GetConnectionString());
                SqlDataAdapter da = new SqlDataAdapter("Book_Proc", MyCon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Books book = new Books();
                        book.BookId = Convert.ToInt32(dt.Rows[i]["BookId"]);
                        book.Title = Convert.ToString(dt.Rows[i]["Title"]);
                        book.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                        book.AuthorFirstName = Convert.ToString(dt.Rows[i]["AuthorFirstName"]);
                        book.AuthorLastName = Convert.ToString(dt.Rows[i]["AuthorLastName"]);
                        book.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);

                        booklist.Add(book);
                    }
                }
                return booklist;

            }
            catch (Exception ex)
            {
                return booklist = null;

            }

        }

        public List<Books> GetSortedListofBooks()
        {
            List<Books> booklist = new List<Books>();

            try
            {
                SqlConnection MyCon = new SqlConnection(DBConnection.GetConnectionString());
                SqlDataAdapter da = new SqlDataAdapter("BookSort", MyCon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Books book = new Books();
                        book.BookId = Convert.ToInt32(dt.Rows[i]["BookId"]);
                        book.Title = Convert.ToString(dt.Rows[i]["Title"]);
                        book.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                        book.AuthorFirstName = Convert.ToString(dt.Rows[i]["AuthorFirstName"]);
                        book.AuthorLastName = Convert.ToString(dt.Rows[i]["AuthorLastName"]);
                        book.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                        booklist.Add(book);
                    }
                }
                return booklist;

            }
            catch
            {
                return booklist = null;
            }
        }

        public List<Books> GetSortedList()
        {
            List<Books> booklist = new List<Books>();

            try
            {


                SqlConnection MyCon = new SqlConnection(DBConnection.GetConnectionString());
                SqlDataAdapter da = new SqlDataAdapter("Book_Sort", MyCon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Books book = new Books();
                        book.BookId = Convert.ToInt32(dt.Rows[i]["BookId"]);
                        book.Title = Convert.ToString(dt.Rows[i]["Title"]);
                        book.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                        book.AuthorFirstName = Convert.ToString(dt.Rows[i]["AuthorFirstName"]);
                        book.AuthorLastName = Convert.ToString(dt.Rows[i]["AuthorLastName"]);
                        book.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                        booklist.Add(book);
                    }
                }
                return booklist;
            }
            catch
            {
                return booklist = null;

            }
        }

        public List<Books> GetBooksByParameter(string publisher, string AuthorFirstName, string AuthorLastName, string Title)
        {
            List<Books> booklist = new List<Books>();

            try
            {
                if (publisher == null)
                {
                    publisher = "";
                }
                if (AuthorFirstName == null)
                {
                    AuthorFirstName = "";
                }
                if (AuthorLastName == null)
                {
                    AuthorLastName = "";
                }
                if (Title == null)
                {
                    Title = "";
                }
                SqlConnection MyCon = new SqlConnection(DBConnection.GetConnectionString());
                SqlDataAdapter da = new SqlDataAdapter("BookList", MyCon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@publisher", publisher);
                da.SelectCommand.Parameters.AddWithValue("@AuthorFirstName", AuthorFirstName);
                da.SelectCommand.Parameters.AddWithValue("@AuthorLastName", AuthorLastName);
                da.SelectCommand.Parameters.AddWithValue("@Title", Title);
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Books book = new Books();
                        book.BookId = Convert.ToInt32(dt.Rows[i]["BookId"]);
                        book.Title = Convert.ToString(dt.Rows[i]["Title"]);
                        book.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                        book.AuthorFirstName = Convert.ToString(dt.Rows[i]["AuthorFirstName"]);
                        book.AuthorLastName = Convert.ToString(dt.Rows[i]["AuthorLastName"]);
                        book.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);

                        booklist.Add(book);
                    }
                }
                return booklist;
            }
            catch
            {
                return booklist = null;
            }

        }
        public string GetTotalPrice()
        {
            string TotalPrice = string.Empty;

            try
            {

                SqlConnection MyCon = new SqlConnection(DBConnection.GetConnectionString());
                SqlDataAdapter da = new SqlDataAdapter("TotalBookPrice", MyCon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<Book> booklist = new List<Book>();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Book book = new Book();
                        book.Price = Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);


                        TotalPrice = "Total Price of all Books = '" + book.Price.ToString() + "'";
                    }
                }
                return TotalPrice;
            }
            catch
            {
                return TotalPrice = null;

            }
        }

        public string  GenerateMLACitation(int BookId)
        {

            string MLACitation = string.Empty;
            try
            {

                string page = "pp.";
                string BookTitle = string.Empty;

                SqlConnection MyCon = new SqlConnection(DBConnection.GetConnectionString());
                SqlDataAdapter da = new SqlDataAdapter("MLACitation_Proc", MyCon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@bookid", BookId);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Book booklist = new Book();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Book book = new Book();
                        book.BookId = Convert.ToInt32(dt.Rows[i]["BookId"]);
                        book.Title = Convert.ToString(dt.Rows[i]["Title"]);
                        book.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                        book.AuthorFirstName = Convert.ToString(dt.Rows[i]["AuthorFirstName"]);
                        book.AuthorLastName = Convert.ToString(dt.Rows[i]["AuthorLastName"]);
                        book.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                        book.PublicationDate = Convert.ToString(dt.Rows[i]["PublicationDate"]);
                        book.Location = Convert.ToString(dt.Rows[i]["Location"]);
                        book.containerTitle = Convert.ToString(dt.Rows[i]["containerTitle"]);

                        BookTitle = "\"" + book.Title + "\"";




                        MLACitation = "" + book.AuthorLastName + "," + book.AuthorFirstName + "," + BookTitle + "," + book.containerTitle + "," + book.Publisher + "," + book.PublicationDate + "," + page + "" + book.Location + "";
                    }
                }
                return MLACitation;
            }
            catch
            {
                return MLACitation = null;

            }

        }


        public string GenerateChicagoStyle(int BookId)
        {

            string ChicagoCitation = string.Empty;
            try
            {
                string page = "pp.";
                string BookTitle = string.Empty;

                SqlConnection MyCon = new SqlConnection(DBConnection.GetConnectionString());
                SqlDataAdapter da = new SqlDataAdapter("Chicago_Proc", MyCon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@BookId", BookId);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Book booklist = new Book();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Book book = new Book();
                        book.Title = Convert.ToString(dt.Rows[i]["Title"]);
                        book.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                        book.AuthorFirstName = Convert.ToString(dt.Rows[i]["AuthorFirstName"]);
                        book.AuthorLastName = Convert.ToString(dt.Rows[i]["AuthorLastName"]);
                        book.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                        book.PublicationDate = Convert.ToString(dt.Rows[i]["PublicationDate"]);
                        book.Location = Convert.ToString(dt.Rows[i]["Location"]);
                        book.JournalTitle = Convert.ToString(dt.Rows[i]["JournalTitle"]);
                        book.Issue_No = Convert.ToString(dt.Rows[i]["Issue_No"]);
                        book.Volume_No = Convert.ToString(dt.Rows[i]["Volume_No"]);
                        book.DOI = Convert.ToString(dt.Rows[i]["DOI"]);

                        BookTitle = "\"" + book.Title + "\"";




                        ChicagoCitation = "" + book.AuthorLastName + "," + book.AuthorFirstName + "," + book.PublicationDate + "," + BookTitle + "," + book.JournalTitle + "," + book.Volume_No + "," + book.Issue_No + "," + book.Location + "," + book.DOI + "";
                    }
                }
                return ChicagoCitation;
            }
            catch
            {
                return ChicagoCitation = null;

            }

        }

    }


}  

