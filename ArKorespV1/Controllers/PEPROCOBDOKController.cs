using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class PEPROCOBDOKController : Controller
    {
        // GET: PEPROCOBDOK
        public ActionResult Index()
        {
            PEPROCOBDOKDBSet db = new PEPROCOBDOKDBSet();
            if (!db.Get(""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(db);
        }

        // GET: PEPROCOBDOK/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PEPROCOBDOK/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PEPROCOBDOK/Create
        [HttpPost]
        public ActionResult Create(PEPROCOBDOK collection)
        {
            try
            {
                PEPROCOBDOKDBSet db = new PEPROCOBDOKDBSet();
                collection.SDATA = DateTime.Now;
                db.Insert(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PEPROCOBDOK/Edit/5
        public ActionResult Edit(string id)
        {
            PEPROCOBDOKDBSet db = new PEPROCOBDOKDBSet();
            PEPROCOBDOK datatoupdate = db.GetById(id);
            if (datatoupdate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(datatoupdate);
        }

        // POST: PEPROCOBDOK/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, PEPROCOBDOK collection)
        {
            try
            {
                PEPROCOBDOKDBSet db = new PEPROCOBDOKDBSet();
                collection.SDATA = DateTime.Now;
                db.Update(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PEPROCOBDOK/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: PEPROCOBDOK/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
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
