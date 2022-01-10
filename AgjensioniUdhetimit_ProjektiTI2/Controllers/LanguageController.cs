using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AgjensioniUdhetimit_ProjektiTI2.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        

        public ActionResult ChangeLanguage(string lang)
        {
            if (lang != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sq-AL");
                    //CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }

            // update user language
            HttpCookie httpCookie = new HttpCookie("language");
            httpCookie.Value = lang;
            Response.Cookies.Add(httpCookie);
            return Redirect(Request.UrlReferrer.ToString());
        }

       
    }
}

