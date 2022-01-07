using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgjensioniUdhetimit_ProjektiTI2.Models;
using AgjensioniUdhetimit_ProjektiTI2.Services;

namespace AgjensioniUdhetimit_ProjektiTI2.Controllers
{
    //[Authorize]
    public class BookingController : Controller
    {
        BookingService bookingService = new BookingService();

        // GET: Booking
        public ActionResult Index()
        {
            return View(BookingService.GetAllBookings());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                  bookingService.Insert(booking);
                  return RedirectToAction("Index");
            }
             return View(booking);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View(bookingService.GetBookingById(id));
        }

        // POST: Booking/Edit/5
        [HttpPost]
        public ActionResult Edit(Booking booking)
        {
            try
            {
                bookingService.Update(booking);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View(bookingService.GetBookingById(id));
        }

        // POST: Booking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bookingService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
