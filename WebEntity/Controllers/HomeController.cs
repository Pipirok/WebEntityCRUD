using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEntity.Models.EntityFrameWork;

namespace WebEntity.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        NorthwindEntities1 db = new NorthwindEntities1();
        Random r = new Random();
        public ActionResult Index()
        {
            List<WebUser> webUsers = db.WebUsers.ToList();
            return View(webUsers);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            WebUser randomUser = db.WebUsers.ToList()[r.Next(db.WebUsers.Count() - 1)];
            return View(randomUser);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(string first_name, string last_name, string password)
        {
            WebUser userToAdd = new WebUser
            {
                username = (first_name + r.Next(100).ToString()).ToLower(),
                first_name = first_name,
                last_name = last_name,
                password = password,
                register_date = DateTime.Now
            };
            db.WebUsers.Add(userToAdd);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }

        [Route("/Home/Delete/{ID}")]
        public ActionResult Delete(int ID)
        {
            WebUser userToDelete = db.WebUsers.Find(ID);
            if (userToDelete == null)
            {
                return HttpNotFound();
            }
            db.WebUsers.Remove(userToDelete);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }

        [HttpGet]
        [Route("/Home/Update/{ID}")]
        public ActionResult Update(int ID)
        {
            WebUser userToUpdate = db.WebUsers.Find(ID);
            if (userToUpdate == null)
            {
                return HttpNotFound();
            }
            return View(userToUpdate);
        }

        [HttpPost]
        public ActionResult Update(int ID, string first_name, string last_name)
        {
            WebUser userToUpdate = db.WebUsers.Find(ID);
            if (userToUpdate == null)
            {
                return HttpNotFound();
            }

            userToUpdate.first_name = first_name;
            userToUpdate.last_name = last_name;
            //db.WebUsers.AddOrUpdate(userToUpdate);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }
    }
}