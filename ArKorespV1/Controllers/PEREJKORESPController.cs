using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class PEREJKORESPController : Controller
    {
        private const string wychodzacaitem = "wychodząca";
        private const string przychodzacaitem = "przychodząca";

        // GET: PEREJKORESP
        public ActionResult Index()
        {
            PEREJKORESPDBSet db = new PEREJKORESPDBSet();
            if (!db.Get(""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(db.OrderBy(rk => rk.DSYMBOL).ToList());
        }

        // GET: PEREJKORESP/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        private SelectList KierunkiSelectList()
        {
            Dictionary<int, string> kierunki = new Dictionary<int, string>
            {
                { 1, przychodzacaitem },
                { 2, wychodzacaitem }
            };
            return new SelectList(kierunki.Select(kk => new { id = kk.Key, value = kk.Value }), "id", "value");
        }

        // GET: PEREJKORESP/Create
        public ActionResult Create()
        {
            ViewBag.kierunki = KierunkiSelectList();

            return View();
        }

        // POST: PEREJKORESP/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PEREJKORESP collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    PEREJKORESPDBSet wstaw = new PEREJKORESPDBSet();
                    collection.SDATA = DateTime.Now;
                    wstaw.Insert(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PEREJKORESP/Edit/5
        public ActionResult Edit(string id)
        {
            PEREJKORESPDBSet zmien = new PEREJKORESPDBSet();
            PEREJKORESP datatoupdate = zmien.GetById(id);
            if (datatoupdate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.kierunki = KierunkiSelectList();
            return View(datatoupdate);
        }

        // POST: PEREJKORESP/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, PEREJKORESP collection)
        {
            try
            {
                PEREJKORESPDBSet aktualizuj = new PEREJKORESPDBSet();
                collection.SDATA = DateTime.Now;
                aktualizuj.Update(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PEREJKORESP/Delete/5
        public ActionResult Delete(string id)
        {
            PEREJKORESPDBSet zmien = new PEREJKORESPDBSet();
            PEREJKORESP datatodelete = zmien.GetById(id);
            if (datatodelete == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(datatodelete);
        }

        // POST: PEREJKORESP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, FormCollection collection)
        {
            try
            {
                PEREJKORESPDBSet aktualizuj = new PEREJKORESPDBSet();               
                aktualizuj.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
