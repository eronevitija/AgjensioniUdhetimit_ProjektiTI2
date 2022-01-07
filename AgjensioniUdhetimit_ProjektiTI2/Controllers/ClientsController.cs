using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AgjensioniUdhetimit_ProjektiTI2.Models;
using AgjensioniUdhetimit_ProjektiTI2.Services;

namespace AgjensioniUdhetimit_ProjektiTI2.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        ClientService clientService = new ClientService();
        Client client = new Client();
        // GET: Clients
        public ActionResult Index()
        {
            return View(ClientService.GetAllClients());
        }

        public ActionResult ChangeLanguage(string lang)
        {
            Session["lang"] = lang;
            return RedirectToAction("Index", "Clients", new { language = lang });
        }

        //[HttpPost]
        //public ActionResult Index(string language)
        //{
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
        //    Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        //    return View();
        //}

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
                if (ModelState.IsValid)
                {
                    clientService.Insert(client);
                    return RedirectToAction("Index");
                }
            
                return View(client);
        }

        public ActionResult Edit(int id)
        {
            return View(clientService.GetClientByID(id));
        }

        //// POST: Clients/Edit/5
        [HttpPost]
        public ActionResult Edit(Client client)
        {
            try
            {
                clientService.Update(client);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET
        public ActionResult Delete(int id)
        {
            return View(clientService.GetClientByID(id));
        }

        // POST: Clients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            try
            {
                clientService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetAll()
        {
            List<Client> client = ClientService.GetAllClients();
            return Json(new { data = client }, JsonRequestBehavior.AllowGet);
        }

       
    }
}


