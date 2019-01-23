using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult Create(UserNotes collection)
        {
            try
            {
                string uname = Session["UserName"].ToString();
                UserNotesDBSet datactr = new UserNotesDBSet(uname);
                collection.SDATA = DateTime.Now;
                datactr.Insert(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserNotes/Edit/5
        public ActionResult Edit(string id)
        {
            string uname = Session["UserName"].ToString();
            UserNotesDBSet datactr = new UserNotesDBSet(uname);
            UserNotes datatoupdate = datactr.GetById(id);
            if(datatoupdate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View( datatoupdate );
        }

        // POST: UserNotes/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, UserNotes collection)
        {
            try
            {
                string uname = Session["UserName"].ToString();
                UserNotesDBSet datactr = new UserNotesDBSet(uname);
                collection.SDATA = DateTime.Now;
                datactr.Update(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserNotes/Delete/5
        public ActionResult Delete(string id)
        {
            string uname = Session["UserName"].ToString();
            UserNotesDBSet datactr = new UserNotesDBSet(uname);
            UserNotes datatodelete = datactr.GetById(id);
            if (datatodelete == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(datatodelete);
        }

        // POST: UserNotes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, UserNotes collection)
        {
            try
            {
                string uname = Session["UserName"].ToString();
                UserNotesDBSet datactr = new UserNotesDBSet(uname);
                datactr.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
