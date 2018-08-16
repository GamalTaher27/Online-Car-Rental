using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.category = new SelectList(new[] { "BMW", "Mercides Benz", "Audi", "Chevrolet", "Pejout", "Renault", "Hyundai", "Honda", "Toyota", "Range Rover", "KIA", "Nissan", "Mazda", "Jeep", "FIAT", "Sozuki", "Spranza", "Other" });
            ViewBag.Color = new SelectList(new[] { "White", "Black", "Gray", "Selver", "Red", "Blue", "Brouwn", "Green", "Others" });

            return View(db.Cars.ToList());
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

        public ActionResult Visitor()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search()
        {
            ViewBag.category = new SelectList(new[] { "BMW", "Mercides Benz", "Audi", "Chevrolet", "Pejout", "Renault", "Hyundai", "Honda", "Toyota", "Range Rover", "KIA", "Nissan", "Mazda", "Jeep", "FIAT", "Sozuki", "Spranza", "Other" });
            ViewBag.Color = new SelectList(new[] { "White", "Black", "Gray", "Selver", "Red", "Blue", "Brouwn", "Green", "Others" });

            return View();
        }

        [HttpPost]
        public ActionResult Search(string category , string Color)
        {
            ViewBag.category = new SelectList(new[] { "BMW", "Mercides Benz", "Audi", "Chevrolet", "Pejout", "Renault", "Hyundai", "Honda", "Toyota", "Range Rover", "KIA", "Nissan", "Mazda", "Jeep", "FIAT", "Sozuki", "Spranza", "Other" });
            ViewBag.Color = new SelectList(new[] { "White", "Black", "Gray", "Selver", "Red", "Blue", "Brouwn", "Green", "Others" });
            var result = db.Cars.Where(a => a.category.Contains(category) && a.Color.Contains(Color)).ToList();

            return View(result);
    
        }
    }
}