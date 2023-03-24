using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEAOIB.Models;
using System.Data.SqlClient;


namespace NEAOIB.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.Account.ToList());
            }
        }

        public ActionResult LoggedOut()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Account account)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.Account.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " succesfully registered.";

            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.Account.Single(u => u.Username == user.Username && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is incorrect.");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


    }
}
