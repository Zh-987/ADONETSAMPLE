using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADONETExample.Filters
{

    public interface IActionFilter
    {
        void OnActionExecuting(ActionExecutingContext filterContext);
        void OnActionExecuted(ActionExecutingContext filterContext);
    }
    public class ActionFilter :FilterAttribute, IActionFilter
    {
       
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Browser.Browser == "Mozila")
            {
                filterContext.Result = new HttpNotFoundResult(); //404 Not found
            }
        }

        public void OnActionExecuted(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("Действие совершено правильно !");
        }
    }
}