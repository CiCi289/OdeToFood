using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();
        
        public ActionResult Autocomplete(string term)
        {
            var model = _db.Restaurants
                        .Where(r => r.Name.StartsWith(term))
                        .Take(10)
                        .Select(r => new { label = r.Name });
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult Index(string searchTerm = null, int page = 1)
        {

            var model = _db.Restaurants
                        .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                        .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                        .Select(r => new RestaurantListViewModel
                        {
                            Id = r.Id,
                            Name = r.Name,
                            City = r.City,
                            Country = r.Country,
                            CountOfReviews = r.Reviews.Count()
                        }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            return View(model);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        protected override void Dispose(bool disposing) //dispose the connection to database to be properly closed so that others can use the database connection
        {
            if (_db != null) //if _db has been instantialized...
            {
                _db.Dispose(); //release resources held in _db field
            }
            base.Dispose(disposing); //release resources held by base class

        }
    }
}