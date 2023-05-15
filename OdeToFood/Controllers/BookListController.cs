using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class BookListController : Controller
    {
        private OdeToFoodDb db = new OdeToFoodDb();
        // GET: BookList
        public ActionResult Index()
        {
            var model = db.Books
                .Select(b => new BookListViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorName = b.Author.Name,
                    Description = b.Description,
                    PublishedDate = b.PublishedDate,
                    PublisherName = b.Publisher.Name,
                    ImagePath = b.ImagePath,
                    CountOfBookReviews = b.Reviews.Count
                });

            return View(model);
        }

        protected override void Dispose(bool disposing) 
        {
            if (db != null) 
            {
                db.Dispose(); 
            }
            base.Dispose(disposing); 

        }
    }
}
