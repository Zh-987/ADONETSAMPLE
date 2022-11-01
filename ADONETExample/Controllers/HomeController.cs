using ADONETExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ADONETExample.Controllers
{
    public class HomeController : Controller
    {
        /*   private MyMusicDBEntities _dbContext;*/

        MyMusicDBEntities db = new MyMusicDBEntities();

        /* public HomeController(MyMusicDBEntities musicdb)
         {
             _dbContext = musicdb;
         }

         public HomeController()
         {

         }*/

        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult SeacrhCustomer()
        {
            ViewBag.Countries = db.Customers.Select(x => x.Country).Distinct();
            return View();
        }

        public ActionResult SeacrhItem()
        {
            ViewBag.Countries = db.Customers.Select(x => x.Country).Distinct();
            return PartialView();
        }

        [HttpPost]
        public ActionResult Results(string fName)
        {
            var searching = db.Customers.Where(x => x.FirstName.Contains(fName)).ToList();

            return PartialView(searching);
        }

        public ActionResult LinkResults()
        {
            /*var searching = db.Customers.Where(x => x.Company == ).First();*/

            ViewBag.Countries = db.Customers.Select(x => x.Country).Distinct();

            return PartialView();
        }

        public JsonResult SendAsJson(string name)
        {
            var searching = db.Customers.Where(x => x.FirstName.Contains(name)).ToList();

            return Json(searching,JsonRequestBehavior.AllowGet); 
        }


        [HttpGet]
        public async Task<ActionResult> GetTable()
        {
            return View(await db.Customers.ToListAsync());
        }

        public ActionResult Sample()
        {
            return View();
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
    }
}