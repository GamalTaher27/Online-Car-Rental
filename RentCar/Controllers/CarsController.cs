using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentCar.Models;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Web.Helpers;
using System.Configuration;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.AspNet.Mvc;
using Twilio.Types;

namespace RentCar.Controllers
{
    public class CarsController : TwilioController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public object upload { get; private set; }

        // GET: Cars
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.category = new SelectList(new[] { "BMW", "Mercides Benz", "Audi", "Chevrolet", "Pejout", "Renault", "Hyundai", "Honda", "Toyota", "Range Rover", "KIA", "Nissan", "Mazda", "Jeep", "FIAT", "Sozuki", "Spranza", "Other" });
            ViewBag.Color = new SelectList(new[] { "White", "Black", "Gray", "Selver", "Red", "Blue", "Brouwn", "Green", "Others" });
            ViewBag.State = new SelectList(new[] { "Available", "UnAvailable" });
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cars cars, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                ViewBag.category = new SelectList(new[] { "BMW", "Mercides Benz", "Audi", "Chevrolet", "Pejout", "Renault", "Hyundai", "Honda", "Toyota", "Range Rover", "KIA", "Nissan", "Mazda", "Jeep", "FIAT", "Sozuki", "Spranza", "Other" });
                ViewBag.Color = new SelectList(new[] { "White", "Black", "Gray", "Selver", "Red", "Blue", "Brouwn", "Green", "Others" });
                ViewBag.State = new SelectList(new[] { "Available", "UnAvailable" });
                string path = Path.Combine(Server.MapPath("~/uploads"), upload.FileName);
                upload.SaveAs(path);
                cars.Image = upload.FileName;
                db.Cars.Add(cars);
                db.SaveChanges();
            
                  foreach(var item in db.Users)
                  
                    if (item.CarType == cars.category)
                    {

                        WebMail.SmtpServer = "smtp.gmail.com";

                        WebMail.SmtpPort = 587;
                        WebMail.SmtpUseDefaultCredentials = true;

                        WebMail.EnableSsl = true;

                        WebMail.UserName = "muhammad.wahed30@gmail.com";
                        WebMail.Password = "01150235008";


                        WebMail.From = "muhammad.wahed30@gmail.com";
                        string ClientEmail = item.Email;
                        string Subject = "New Car";
                        string body = "There is a new car of category ";
                        body += item.CarType + " has been added to Go Car Website you can show it by visit the website ";
                        WebMail.Send(to: ClientEmail, subject: Subject, body: body, isBodyHtml: true);
                    }

              



                return RedirectToAction("Index");
            }

            return View(cars);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.category = new SelectList(new[] { "BMW", "Mercides Benz", "Audi", "Chevrolet", "Pejout", "Renault", "Hyundai", "Honda", "Toyota", "Range Rover", "KIA", "Nissan", "Mazda", "Jeep", "FIAT", "Sozuki", "Spranza", "Other" });
            ViewBag.Color = new SelectList(new[] { "White", "Black", "Gray", "Selver", "Red", "Blue", "Brouwn", "Green", "Others" });
            ViewBag.State = new SelectList(new[] { "Available", "UnAvailable" });

            if (id == null)
            {
                return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
                return View(cars);

        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cars cars, HttpPostedFileBase upload)
        {

            if (ModelState.IsValid)
            {
                ViewBag.category = new SelectList(new[] { "BMW", "Mercides Benz", "Audi", "Chevrolet", "Pejout", "Renault", "Hyundai", "Honda", "Toyota", "Range Rover", "KIA", "Nissan", "Mazda", "Jeep", "FIAT", "Sozuki", "Spranza", "Other" });
                ViewBag.Color = new SelectList(new[] { "White", "Black", "Gray", "Selver", "Red", "Blue", "Brouwn", "Green", "Others" });
                ViewBag.State = new SelectList(new[] { "Available", "UnAvailable" });
                if(upload!=null)
                {
                    string path = Path.Combine(Server.MapPath("~/uploads"), upload.FileName);
                    upload.SaveAs(path);
                    cars.Image = upload.FileName;
                }

              
               
                db.Entry(cars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cars);
        }

        public ActionResult Search()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Search(string SearchId)
        {

            var result = db.Cars.Where(c => c.id.ToString().Contains(SearchId)).ToList();

            return View(result);

        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars cars = db.Cars.Find(id);
            db.Cars.Remove(cars);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult RentCash(string from,string to,string carId)
        {
            try
            {
                int CarId = int.Parse(carId);
                Cars car = db.Cars.Find(CarId);
                int RentByDay = int.Parse(car.Amount);
                TimeSpan difference = Convert.ToDateTime(to) - Convert.ToDateTime(from);
                int Days = Convert.ToInt32(difference.TotalDays);
                int RentAmount = RentByDay * Days;
                string UserId = User.Identity.GetUserId();
                var user = db.Users.Where(u => u.Id ==UserId ).FirstOrDefault() ;
                if (RentAmount <= user.Balance)
                {
                    Rent rent = new Rent();
                    rent.CarId = car.id;
                    rent.From = Convert.ToDateTime(from);
                    rent.To = Convert.ToDateTime(to);
                    rent.UserId = User.Identity.GetUserId();
                    rent.TotalAmount = RentAmount;
                    user.Balance = user.Balance - RentAmount;
                    car.State = "UnAvailable";
                    db.Entry(user).State = EntityState.Modified;
                    db.Entry(car).State = EntityState.Modified;
                    db.Rents.Add(rent);
                    db.SaveChanges();

                    WebMail.SmtpServer = "smtp.gmail.com";

                    WebMail.SmtpPort = 587;
                    WebMail.SmtpUseDefaultCredentials = true;

                    WebMail.EnableSsl = true;

                    WebMail.UserName = "muhammad.wahed30@gmail.com";
                    WebMail.Password = "01150235008";


                    WebMail.From = "muhammad.wahed30@gmail.com";
                    string AdminEmail = "muhammedwahed19@yahoo.com";
                    string Subject = "New Rent";
                    string body = "User: ";
                    body += User.Identity.Name + " has rent the car: ";
                    body += car.Model + "with Car ID: ";
                    body += car.id + "for: ";
                    body += Days.ToString() + " days";
                    WebMail.Send(to: AdminEmail, subject: Subject, body: body, isBodyHtml: true);
                    ViewBag.Status = "Email Sent Successfully.";
                    int rid = rent.Id;

                    var accountSid = "AC8608432847456494ff979ddc7568e534";
                    var authToken = "88b42744c68db78ef3b56da4a266a08a";
                    TwilioClient.Init(accountSid, authToken);

                    var too = new PhoneNumber("+201014322217");
                    var froom = new PhoneNumber("+16013006123");

                    var message = MessageResource.Create(
                        to: too,
                        from: froom,
                        body: " User " + User.Identity.Name + " has rent the car: " + car.Model + " with Car ID: " + car.id + " for: "+Days.ToString() + " days"
                        );

                    

                    return Json("Added");

                }
                else
                {
                    return Json("Balance is Not Enough");
                }


            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }          
        }

        public ActionResult Report()
        {

            return View(db.Cars.ToList());
        }

    }

}
