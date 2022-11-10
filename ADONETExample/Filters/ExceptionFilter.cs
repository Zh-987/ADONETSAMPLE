using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ADONETExample.Filters
{
   /* public interface IExceptionFilter
    {
        void OnException(ExceptionContext exceptionContext);
    }*/
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if(!exceptionContext.ExceptionHandled && exceptionContext.Exception is IndexOutOfRangeException)
            {
                exceptionContext.Result = new RedirectResult("");
                   
                exceptionContext.ExceptionHandled = true;
            }
        }

    }
}