using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class UserNotesController : Controller
    {
        // GET: UserNotes
        public ActionResult Index()
        {
            string uname = Session["UserName"].ToString();
            UserNotesDBSet notatki = new UserNotesDBSet(uname);
            if (notatki.Get(""))
            {
                ViewBag.uname = uname;
                return View(notatki);
            }
            else
            return View();
        }

        // GET: UserNotes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserNotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserNotes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserNotes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserNotes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserNotes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserNotes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
