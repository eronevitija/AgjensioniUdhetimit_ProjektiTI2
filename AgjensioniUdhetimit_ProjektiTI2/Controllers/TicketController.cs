using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgjensioniUdhetimit_ProjektiTI2.Models;
using AgjensioniUdhetimit_ProjektiTI2.Services;

namespace AgjensioniUdhetimit_ProjektiTI2.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        TicketService ticketService = new TicketService();
        // GET: Ticket
        public ActionResult Index()
        {
            return View(ticketService.GetAllTickets());
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticketService.InsertTicket(ticket);
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ticketService.GetTicketByID(id));
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        public ActionResult Edit(Ticket ticket)
        {
            try
            {
                ticketService.Update(ticket);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ticketService.GetTicketByID(id));
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ticketService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetAllTickets()
        {
            List<Ticket> ticket = ticketService.GetAllTickets();
            return Json(new { data = ticket }, JsonRequestBehavior.AllowGet);
        }
    }
}
