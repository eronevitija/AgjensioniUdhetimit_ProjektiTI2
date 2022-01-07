using AgjensioniUdhetimit_ProjektiTI2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgjensioniUdhetimit_ProjektiTI2.Models;

namespace AgjensioniUdhetimit_ProjektiTI2.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        StaffService staffService = new StaffService();
        //RoleService roleService = new RoleService();
        // GET: Staff
        public ActionResult Index()
        {
            return View(staffService.GetAllStaff());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                staffService.Insert(staff);
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            return View(staffService.GetStaffById(id));
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            try
            {
                staffService.EditStaff(staff);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            return View(staffService.GetStaffById(id));
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                staffService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CheckLogin(string username,string password)
        {
            if (ModelState.IsValid)
            {
                StaffService.CheckLogInConfig(username, password);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult GetAllStaff()
        {
            List<Staff> staff = staffService.GetAllStaff();
            return Json(new { data = staff }, JsonRequestBehavior.AllowGet);
        }

    }
}
