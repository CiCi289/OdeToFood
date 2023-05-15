using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Author Author { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public virtual Publisher Publisher { get; set; }
        public string PublisherName{ get; set; }
        public virtual string ImagePath { get; set; }
        public int CountOfBookReviews { get; set; }
    }
}