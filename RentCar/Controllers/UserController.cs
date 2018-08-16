using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCar.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(int? id)
        {
            return View();
        }
    }
}