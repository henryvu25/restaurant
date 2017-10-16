using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using restaurant_project.Models;
using System.Linq;

namespace restaurant_project.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantContext _context;
        public HomeController(RestaurantContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = ModelState.Values;
            return View();
        }
        [HttpPost]
        [Route("reviews")]
        public IActionResult AddReview(Review model)
        {
            if(ModelState.IsValid)
            {
                _context.Reviews.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Display");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }
        }
        [HttpGet]
        [Route("reviews")]
        public IActionResult Display()
        {
            List<Review> ReturnedValues = _context.Reviews.OrderByDescending(review => review.visited).ToList();
            ViewBag.everything = ReturnedValues;
            return View();
        }
    }
}
