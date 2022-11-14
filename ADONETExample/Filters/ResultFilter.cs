using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ADONETExample.Filters
{
    public interface IResultFilter
    {
        void OnResultExecuted(ResultExecutedContext filterContext);
        void OnResultExecuting(ResultExecutingContext filterContext);
    }

    public class ResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("время HTTP запроса: " + filterContext.HttpContext.Timestamp);
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("Пользователь: " + filterContext.HttpContext.User.Identity.Name);
        }
    }
}