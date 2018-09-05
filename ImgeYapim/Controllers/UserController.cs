using ImgeYapim.Models;
using ImgeYapim.Models.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ImgeYapim.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DatabaseContext db = new DatabaseContext();

        // GET: User

        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]

        public ActionResult Create([Bind(Include = "Id,UserName,Password,Email,ConfirmPassword")] User user)
        {

            if (ModelState.IsValid)
            {
                user.PasswordHash = Crypto.HashPassword(user.Password);

                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }

            return View("Create");

        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user, string PasswordHash)
        {

            var login = db.User.Where(u => u.UserName == "house").SingleOrDefault();

            var doesPasswordMatch = Crypto.VerifyHashedPassword(login.PasswordHash, PasswordHash);


            if (doesPasswordMatch)
            {
                //HttpCookie cookie = new HttpCookie("Cookie");
                //cookie.Value = "Hello Cookie! CreatedOn: " + DateTime.Now.ToShortTimeString();
                //this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                Response.Cookies["userInfo"]["userName"] = "house";
                Response.Cookies["userInfo"]["lastVisit"] = DateTime.Now.ToString();
                Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(1);
                return RedirectToAction("Index", "Admin");

            }
            else
            {
                ViewBag.Uyari = "Kullanıcı adını veya şifreyi hatalı girdiniz.";
                return View();
            }


        }
    }
}