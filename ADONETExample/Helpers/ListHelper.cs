using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADONETExample.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString List(this HtmlHelper htmlHelper, string[] items)
        {
            /*
             * <ul>
             * <li>
             * 1
             * </li>
             * <li>
             * 2
             * </li>
             * </ul>
             */ 
            TagBuilder ul = new TagBuilder("ul");
            foreach(string item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ul.ToString());
        }
    }
}