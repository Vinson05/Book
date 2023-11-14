using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Interface
{
    public interface IBook
    {

        public List<Books> GetAllBooks();
        public List<Books> GetSortedListofBooks();

        public List<Books> GetSortedList();

        public List<Books> GetBooksByParameter(string publisher, string AuthorFirstName, string AuthorLastName, string Title);

        public string GetTotalPrice();

        public string GenerateMLACitation(int BookId);
        public string GenerateChicagoStyle(int BookId);



    }
}
