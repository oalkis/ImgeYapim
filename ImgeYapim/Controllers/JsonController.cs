using ImgeYapim.Models.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImgeYapim.Controllers
{

    public class JsonController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCustomers(string word, int page, int rows, string searchString)
        {
            //#1 Create Instance of DatabaseContext class for Accessing Database. 
             DatabaseContext db = new DatabaseContext();
            {
                //#2 Setting Paging  
                int pageIndex = Convert.ToInt32(page) - 1;
                int pageSize = rows;

                //#3 Linq Query to Get Customer   
                var Results = db.Artists.Select(
                    a => new
                    {
                        a.ArtistID,
                        a.ArtistOrder,
                        a.ArtistName,
                        a.ArtistPicture,
                    });
                
                //#4 Get Total Row Count  
                int totalRecords = Results.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

                //#5 Setting Sorting  
                //if (word.ToUpper() == "DESC")
                //{
                //    Results = Results.OrderByDescending(s => s.ArtistID);
                //    Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
                //}
                //else
                //{
                    Results = Results.OrderBy(s => s.ArtistID);
                    Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
                
                //}
                //#6 Setting Search  
                if (!string.IsNullOrEmpty(searchString))
                {
                    Results = Results.Where(m => m.ArtistName == searchString);
                }
                //#7 Sending Json Object to View.  
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = Results
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }
    }
}