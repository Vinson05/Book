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

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IBook book;
        
        public BookController(IBook objIAuthenticate)
        {
            book = objIAuthenticate;

        }


        [HttpGet]
        [Route("GetAllBooks")]
        public IActionResult GetAllBooks()
        {

            ResultSet _objResultSet = new ResultSet();
            try
            {
                var books = book.GetAllBooks();


                if (books == null)
                {

                    _objResultSet = Message.Messages(false, CommonMessage.NoRecordsFound, null);
                    return Ok(_objResultSet);
                }
                else
                {
                    _objResultSet = Message.Messages(true, CommonMessage.Success, books);
                    return Ok(_objResultSet);

                }
            }
            catch (Exception ex)
            {
                _objResultSet = Message.Messages(true, ex.Message, null);
                return Ok(_objResultSet);
            }

        }

        /*SortedList of Books by Publisher,Author(last,first),title*/
        [HttpGet]
        [Route("GetSortedListofBooks")]
        public IActionResult GetSortedListofBooks()
        {

            ResultSet _objResultSet = new ResultSet();
            try
            {
                var books = book.GetSortedListofBooks();


                if (books == null)
                {

                    _objResultSet = Message.Messages(false, CommonMessage.NoRecordsFound, null);
                    return Ok(_objResultSet);
                }
                else
                {
                    _objResultSet = Message.Messages(true, CommonMessage.Success, books);
                    return Ok(_objResultSet);

                }
            }
            catch (Exception ex)
            {
                _objResultSet = Message.Messages(true, ex.Message, null);
                return Ok(_objResultSet);
            }

        }


        /*SortedList of Books by Author(last,first),title*/
        [HttpGet]
        [Route("GetSortedList")]
        public IActionResult GetSortedList()
        {

            ResultSet _objResultSet = new ResultSet();
            try
            {
                var books = book.GetSortedList();


                if (books == null)
                {

                    _objResultSet = Message.Messages(false, CommonMessage.NoRecordsFound, null);
                    return Ok(_objResultSet);
                }
                else
                {
                    _objResultSet = Message.Messages(true, CommonMessage.Success, books);
                    return Ok(_objResultSet);

                }
            }
            catch (Exception ex)
            {
                _objResultSet = Message.Messages(true, ex.Message, null);
                return Ok(_objResultSet);
            }

        }

        /*For Reference */
        [HttpGet]
        [Route("GetBooksByParameter")]
        public IActionResult GetBooksByParameter(string publisher,string AuthorFirstName,string AuthorLastName, string Title)
        {

            ResultSet _objResultSet = new ResultSet();
            try
            {
                var books = book.GetBooksByParameter(publisher, AuthorFirstName, AuthorLastName, Title);


                if (books == null)
                {

                    _objResultSet = Message.Messages(false, CommonMessage.NoRecordsFound, null);
                    return Ok(_objResultSet);
                }
                else
                {
                    _objResultSet = Message.Messages(true, CommonMessage.Success, books);
                    return Ok(_objResultSet);

                }
            }
            catch (Exception ex)
            {
                _objResultSet = Message.Messages(true, ex.Message, null);
                return Ok(_objResultSet);
            }

        }

        [HttpGet]
        [Route("GetTotalPrice")]
        public IActionResult GetTotalPrice()
        {

            ResultSet _objResultSet = new ResultSet();
            try
            {
                var TotalPrice = book.GetTotalPrice();


                if (TotalPrice == null)
                {

                    _objResultSet = Message.Messages(false, CommonMessage.NoRecordsFound, null);
                    return Ok(_objResultSet);
                }
                else
                {
                    _objResultSet = Message.Messages(true, CommonMessage.Success, TotalPrice);
                    return Ok(_objResultSet);

                }
            }
            catch (Exception ex)
            {
                _objResultSet = Message.Messages(true, ex.Message, null);
                return Ok(_objResultSet);
            }

        }

        [HttpGet]
        [Route("GenerateMLACitation")]
        public IActionResult GenerateMLACitation(int BookId)
        {

            ResultSet _objResultSet = new ResultSet();
            try
            {
                var MLACitation = book.GenerateMLACitation(BookId);


                if (MLACitation == null)
                {

                    _objResultSet = Message.Messages(false, CommonMessage.NoRecordsFound, null);
                    return Ok(_objResultSet);
                }
                else
                {
                    _objResultSet = Message.Messages(true, CommonMessage.Success, MLACitation);
                    return Ok(_objResultSet);

                }
            }
            catch (Exception ex)
            {
                _objResultSet = Message.Messages(true, ex.Message, null);
                return Ok(_objResultSet);
            }

        }

        [HttpGet]
        [Route("GenerateChicagoStyle")]
        public IActionResult GenerateChicagoStyle(int BookId)
        {

            ResultSet _objResultSet = new ResultSet();
            try
            {
                var ChicagoStyle = book.GenerateChicagoStyle(BookId);

                if (ChicagoStyle == null)
                {

                    _objResultSet = Message.Messages(false, CommonMessage.NoRecordsFound, null);
                    return Ok(_objResultSet);
                }
                else
                {
                    _objResultSet = Message.Messages(true, CommonMessage.Success, ChicagoStyle);
                    return Ok(_objResultSet);

                }
            }
            catch (Exception ex)
            {
                _objResultSet = Message.Messages(true, ex.Message, null);
                return Ok(_objResultSet);
            }

        }
    } 
}
