using ADONETExample.Models;
using ADONETExample.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Castle.Windsor;
using ADONETExample.Filters;

namespace ADONETExample.Controllers
{
   
    public class HomeController : Controller
    {

        /*
        * 
        * Tight coupling (Жесткая связь) к Репозиторию
        * 
        * ChatRepository repo;

       public ChatController()
       {
           repo = new ChatRepository();
       }
        
         */

        /* 
         Soft coupling (Мягкая/слабая связь) к репозиторию
         */

        private IHomeRepository repo;

        public HomeController(IHomeRepository r) //
        {
            /*
             * Ninject
             * IKernel kernel = new StandardKernel();
             kernel.Bind<IHomeRepository>().To<HomeRepository>();
             repo = kernel.Get<IHomeRepository>();*/
            repo = r;
        }
        /* public HomeController() : this(*//*new HomeRepository()*//*)
         {

         }*/

      
        [ActionName("MainPage")]
        public ActionResult Index()
        {
            return View();
        }

        [ExceptionFilter]
        public ActionResult One()
        {
            /*int[] arr = new int[2];
            arr[8] = 10;*/
            return View();
        }

        public ActionResult SeacrhCustomer()
        {
            repo.SearchCustomer();
            return View();
        }
        [Authorize(Roles = "admin", Users = "Kanaffin, Aidar")]
        public ActionResult SeacrhItem()
        {
            repo.SeacrhItem();
            return PartialView();
        }

        [HttpPost]
        public ActionResult Results(string fName)
        {
            /*db.Customers.Where(x => x.FirstName.Contains(fName)).ToList();*/
            var searching = repo.Results(fName);

            return PartialView(searching);
        }

         [AllowAnonymous]
         public ActionResult Login()
        {
            return View();
        }

        public ActionResult LinkResults()
         {
            /*var searching = db.Customers.Where(x => x.Company == ).First();*/

            ViewBag.Countries = repo.LinkResults();

            return PartialView();
        }

        public JsonResult SendAsJson(string name)
        {
            var searching = repo.SendAsJson(name);

            return Json(searching,JsonRequestBehavior.AllowGet); 
        }


        [HttpGet]
        public ActionResult GetTable()
        {
            return View(repo.GetTable());
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

        public string Context()
        {
            HttpContext.Response.Write("<h1>HELLO IT STEP</h1>"); // Response
            string browser = HttpContext.Request.Browser.Browser; //Request
            string ip = HttpContext.Request.UserHostAddress;

            HttpContext.Request.Cookies["Name"].Value = "Miras";

            string cookies = HttpContext.Request.Cookies["Name"].Value;

            return "<p> Browser: " + browser + "<br> IP:" + ip+ "Cookie:"+ cookies + "</p>";
        }

        [ActionName("Time")]
        public string VyvodVremeni()
        {
            return TimeStamp();
        } 

        [NonAction]
        public string TimeStamp()
        {
            return "Время :" + DateTime.Now.ToString();
        }

    }
}