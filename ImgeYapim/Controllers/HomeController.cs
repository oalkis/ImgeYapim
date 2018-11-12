using ImgeYapim.Models;
using ImgeYapim.Models.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImgeYapim.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Artist = db.Artists.OrderBy(a => a.ArtistOrder).ToList();
            ViewBag.Crew = db.Crew.OrderBy(a=>a.CrewOrder).ToList();
            ViewBag.Slider = db.Slider.OrderBy(a=>a.SliderOrder).ToList();
            ViewBag.Product = db.Product.ToList();
            return View();
        }
        public ActionResult Home()
        {
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            return RedirectToAction("Index");
        }
        public ActionResult EventCalendar()
        {
            return RedirectToAction("Index");
        }
        public ActionResult Team()
        {
            return RedirectToAction("Index");
        }
        public ActionResult Artist()
        {
            return RedirectToAction("Index");
        }
    
        public ActionResult Contact()
        {
            return RedirectToAction("Index");
        }
    }


}
