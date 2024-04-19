using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Mission6_Hull.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Mission6_Hull.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger; // Constructor (ILogger of type home controller)

        private CollectionFormContext _context;

        public HomeController(CollectionFormContext temp) // Constructor
        {
            _context = temp;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //_logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getToKnow()
        {
            return View();
        }

        // Create get and post actions for collection
        [HttpGet]
        public IActionResult collection()
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View("collection", new Form());
        }

        [HttpPost]
        public IActionResult collection(Form response)

        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();

                return View(response);
            }
        }

        // Create action for Enteries
        public IActionResult Enteries ()
        {
            var forms = _context.Movies.Include(x => x.CategoryName).ToList();


            return View(forms);

        }

        // Create get and post actions for Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies.Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.ToList();

            return View("collection", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Form updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();


            return RedirectToAction("Enteries");
        }

        // Create get and post actions for Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
           var recordToDelete = _context.Movies.Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Form form)
        {
            _context.Movies.Remove(form);
            _context.SaveChanges();

            return RedirectToAction("Enteries");
        }

    }
}
