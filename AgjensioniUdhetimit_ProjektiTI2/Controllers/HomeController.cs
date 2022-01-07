using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AgjensioniUdhetimit_ProjektiTI2.Models;

namespace AgjensioniUdhetimit_ProjektiTI2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index(string language)
        {
            return View();
        }
        
        [Authorize]
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