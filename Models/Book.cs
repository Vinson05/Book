using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{

    public class Books
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public decimal Price { get; set; }
    }

        public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public decimal Price { get; set; }
        public string PublicationDate { get; set; }
        public string Location { get; set; }
        public string containerTitle { get; set; }
        public string JournalTitle { get; set; }
        public string Issue_No { get; set; }
        public string Volume_No { get; set; }
        public string DOI { get; set; }

    }
}
