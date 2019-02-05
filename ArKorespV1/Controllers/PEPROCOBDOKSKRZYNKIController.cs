using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class PEPROCOBDOKSKRZYNKIController : Controller
    {
        // GET: PEPROCOBDOKSKRZYNKI
        public ActionResult Index(string pozycjaprocedury, string procedura)
        {
            PEPROCOBDOKPOZDBSet dbproc = new PEPROCOBDOKPOZDBSet();
            var pozycjap = dbproc.GetById(pozycjaprocedury);
            PEPROCOBDOKSKRZYNKIDBSet db = new PEPROCOBDOKSKRZYNKIDBSet();
            if (!db.Get("item == " + pozycjaprocedury.Replace("_","/")))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.nazwa = pozycjap.DNAZWA;
            ViewBag.pozycjaprocedury = pozycjaprocedury;
            ViewBag.procedura = procedura;
            return View(db);
        }

        // GET: PEPROCOBDOKSKRZYNKI/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PEPROCOBDOKSKRZYNKI/Create
        public ActionResult Create(string pozycjaprocedury, string procedura)
        {
            PEPROCOBDOKPOZDBSet dbproc = new PEPROCOBDOKPOZDBSet();
            var pozycjap = dbproc.GetById(pozycjaprocedury);

            ViewBag.nazwa = pozycjap.DNAZWA;
            ViewBag.pozycjaprocedury = pozycjaprocedury;
            ViewBag.procedura = procedura;
            ViewBag.ListaU = UserSelectList();

            return View();
        }

        // POST: PEPROCOBDOKSKRZYNKI/Create
        [HttpPost]
        public ActionResult Create(PEPROCOBDOKSKRZYNKI collection)
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

        // GET: PEPROCOBDOKSKRZYNKI/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PEPROCOBDOKSKRZYNKI/Edit/5
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

        // GET: PEPROCOBDOKSKRZYNKI/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PEPROCOBDOKSKRZYNKI/Delete/5
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

        private SelectList UserSelectList()
        {
            ATUZYTKDBSet uzytkownicy = new ATUZYTKDBSet();
            if (uzytkownicy.Get(""))
            {
                var lista = uzytkownicy.Select(iz => new SelectListItem { Value = iz._id, Text = iz.UserName }).AsEnumerable();
                return new SelectList(lista, "Value", "Text");
            }
            return null;
        }
    }
}
