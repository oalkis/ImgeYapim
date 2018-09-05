using ImgeYapim.Content;
using ImgeYapim.Models;
using ImgeYapim.Models.DatabaseContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ImgeYapim.Controllers
{
    [UserAuthorize]
    public class AdminController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.GrupSayisi = db.Artists.Count();
            ViewBag.EkipKisiSayisi = db.Crew.Count();
            ViewBag.SliderSayisi = db.Slider.Count();
            DateTime dt = DateTime.Parse(Request.Cookies["userInfo"]["lastVisit"]);
            if ((DateTime.Now - dt).TotalHours > 1)
            {
                Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(-1);
            }
            return View();
        }
        public ActionResult Artist()
        {
            var artists = db.Artists.ToList();
            return View(artists);
        }

        public ActionResult AddArtist()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddArtist([Bind(Include = "ArtistID,ArtistName,ArtistAbout")] Artist artist, HttpPostedFileBase picture)
        {
            try
            {
                if (picture != null)
                {
                    WebImage img = new WebImage(picture.InputStream);
                    FileInfo pictureInfo = new FileInfo(picture.FileName);

                    string newPicuture = Guid.NewGuid().ToString() + pictureInfo.Extension;
                    //img = img.Resize(533, 332, true);
                    img.Save("~/Content/Images/ArtistImages/" + newPicuture);
                    artist.ArtistPicture = "/Content/Images/ArtistImages/" + newPicuture;

                }

                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Artist");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditArtist(int id)
        {
            var artist = db.Artists.Where(a => a.ArtistID == id).SingleOrDefault();
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }
        [HttpPost]
        public ActionResult EditArtist(int id, HttpPostedFileBase picture, Artist artist)
        {
            try
            {
                var artists = db.Artists.Where(a => a.ArtistID == id).SingleOrDefault();
                if (picture != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(artist.ArtistPicture)))
                    {
                        System.IO.File.Delete(Server.MapPath(artist.ArtistPicture));
                    }
                    WebImage img = new WebImage(picture.InputStream);
                    FileInfo pictureInfo = new FileInfo(picture.FileName);

                    string newPicuture = Guid.NewGuid().ToString() + pictureInfo.Extension;

                    img.Save("~/Content/Images/ArtistImages/" + newPicuture);
                    artists.ArtistPicture = "/Content/Images/ArtistImages/" + newPicuture;
                }
                artists.ArtistName = artist.ArtistName;
                artists.ArtistAbout = artist.ArtistAbout;
                db.SaveChanges();
                return RedirectToAction("Artist");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult DeleteArtist(int id)
        {
            var artist = db.Artists.Where(a => a.ArtistID == id).SingleOrDefault();
            if (artist == null)
            {
                return HttpNotFound();
            }

            return View(artist);
        }
        [HttpPost]
        public ActionResult DeleteArtist(int id, FormCollection collection)
        {
            try
            {
                var artist = db.Artists.Where(m => m.ArtistID == id).SingleOrDefault();
                if (artist == null)
                {
                    return HttpNotFound();

                }
                if (System.IO.File.Exists(Server.MapPath(artist.ArtistPicture)))
                {
                    System.IO.File.Delete(Server.MapPath(artist.ArtistPicture));
                }


                db.Artists.Remove(artist);
                db.SaveChanges();
                return RedirectToAction("Artist");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Crew()
        {
            var crews = db.Crew.ToList();
            return View(crews);
        }
        public ActionResult AddCrew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCrew([Bind(Include = "CrewID,CrewName,CrewAbout,CrewPhone,CrewTwitter,CrewMail,CrewJob,CrewInstagram")] Crew crew, HttpPostedFileBase picture)
        {
            try
            {
                if (picture != null)
                {
                    WebImage img = new WebImage(picture.InputStream);
                    FileInfo pictureInfo = new FileInfo(picture.FileName);

                    string newPicuture = Guid.NewGuid().ToString() + pictureInfo.Extension;
                    //img = img.Resize(533, 332, true);
                    img.Save("~/Content/Images/CrewImages/" + newPicuture);
                    crew.CrewPicture = "/Content/Images/CrewImages/" + newPicuture;

                }

                db.Crew.Add(crew);
                db.SaveChanges();
                return RedirectToAction("Crew");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditCrew(int id)
        {
            var crews = db.Crew.Where(a => a.CrewID == id).SingleOrDefault();
            if (crews == null)
            {
                return HttpNotFound();
            }
            return View(crews);
        }
        [HttpPost]
        public ActionResult EditCrew(int id, HttpPostedFileBase picture, Crew crew)
        {
            try
            {
                var crews = db.Crew.Where(a => a.CrewID == id).SingleOrDefault();
                if (picture != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(crew.CrewPicture)))
                    {
                        System.IO.File.Delete(Server.MapPath(crew.CrewPicture));
                    }
                    WebImage img = new WebImage(picture.InputStream);
                    FileInfo pictureInfo = new FileInfo(picture.FileName);

                    string newPicture = Guid.NewGuid().ToString() + pictureInfo.Extension;

                    img.Save("~/Content/Images/CrewImages/" + newPicture);
                    crews.CrewPicture = "/Content/Images/CrewImages/" + newPicture;
                }
                crews.CrewName = crew.CrewName;
                crews.CrewAbout = crew.CrewAbout;
                crews.CrewJob = crew.CrewJob;
                crews.CrewInstagram = crew.CrewInstagram;
                crews.CrewMail = crew.CrewMail;
                crews.CrewPhone = crew.CrewPhone;
                crews.CrewTwitter = crew.CrewTwitter;
                db.SaveChanges();
                return RedirectToAction("Crew");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult DeleteCrew(int id)
        {
            var crews = db.Crew.Where(a => a.CrewID == id).SingleOrDefault();
            if (crews == null)
            {
                return HttpNotFound();
            }

            return View(crews);
        }
        [HttpPost]
        public ActionResult DeleteCrew(int id, FormCollection collection)
        {
            try
            {
                var crews = db.Crew.Where(a => a.CrewID == id).SingleOrDefault();
                if (crews == null)
                {
                    return HttpNotFound();

                }
                if (System.IO.File.Exists(Server.MapPath(crews.CrewPicture)))
                {
                    System.IO.File.Delete(Server.MapPath(crews.CrewPicture));
                }


                db.Crew.Remove(crews);
                db.SaveChanges();
                return RedirectToAction("Crew");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Slider()
        {
            var sliders = db.Slider.ToList();
            return View(sliders);
        }

        public ActionResult AddSlider()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSlider([Bind(Include = "SliderID,SliderName")] Slider slider, HttpPostedFileBase picture)
        {
            try
            {
                if (picture != null)
                {
                    WebImage img = new WebImage(picture.InputStream);
                    FileInfo pictureInfo = new FileInfo(picture.FileName);

                    string newPicuture = Guid.NewGuid().ToString() + pictureInfo.Extension;
                    //img = img.Resize(533, 332, true);
                    img.Save("~/Content/Images/SliderImages/" + newPicuture);
                    slider.SliderPicture = "/Content/Images/SliderImages/" + newPicuture;

                }

                db.Slider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Slider");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditSlider(int id)
        {
            var slider = db.Slider.Where(a => a.SliderID == id).SingleOrDefault();
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }
        [HttpPost]
        public ActionResult EditSlider(int id, HttpPostedFileBase picture, Slider slider)
        {
            try
            {
                var sliders = db.Slider.Where(a => a.SliderID == id).SingleOrDefault();
                if (picture != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(slider.SliderPicture)))
                    {
                        System.IO.File.Delete(Server.MapPath(slider.SliderPicture));
                    }
                    WebImage img = new WebImage(picture.InputStream);
                    FileInfo pictureInfo = new FileInfo(picture.FileName);

                    string newPicuture = Guid.NewGuid().ToString() + pictureInfo.Extension;

                    img.Save("~/Content/Images/SliderImages/" + newPicuture);
                    sliders.SliderPicture = "/Content/Images/SliderImages/" + newPicuture;
                }
                sliders.SliderName = slider.SliderName;
                db.SaveChanges();
                return RedirectToAction("Slider");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult DeleteSlider(int id)
        {
            var slider = db.Slider.Where(a => a.SliderID == id).SingleOrDefault();
            if (slider == null)
            {
                return HttpNotFound();
            }

            return View(slider);
        }
        [HttpPost]
        public ActionResult DeleteSlider(int id, FormCollection collection)
        {
            try
            {
                var slider = db.Slider.Where(m => m.SliderID == id).SingleOrDefault();
                if (slider == null)
                {
                    return HttpNotFound();

                }
                if (System.IO.File.Exists(Server.MapPath(slider.SliderPicture)))
                {
                    System.IO.File.Delete(Server.MapPath(slider.SliderPicture));
                }


                db.Slider.Remove(slider);
                db.SaveChanges();
                return RedirectToAction("Slider");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Product()
        {
            var products = db.Product.ToList();
            return View(products);
        }

        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct([Bind(Include = "ProductID,ProductName,ProductAddress,ProductAbout,ProductPhone,ProductMail,ProductTwitter,ProductInstagram,ProductFacebook")] Product product, HttpPostedFileBase picture)
        {
            try
            {



                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Product");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditProduct(int id)
        {
            var product = db.Product.Where(a => a.ProductID == id).SingleOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(int id, Product product)
        {
            try
            {

                var products = db.Product.Where(a => a.ProductID == id).SingleOrDefault();

                products.ProductName = product.ProductName;
                products.ProductAbout = product.ProductAbout;
                products.ProductAddress = product.ProductAddress;
                products.ProductPhone = product.ProductPhone;
                products.ProductMail = product.ProductMail;
                products.ProductTwitter = product.ProductTwitter;
                products.ProductInstagram = product.ProductInstagram;
                products.ProductFacebook = product.ProductFacebook;
                db.SaveChanges();
                return RedirectToAction("Product");
            }
            catch
            {
                return View();
            }

        }
    }
}