using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class PEKORESPController : Controller
    {
        // GET: PEKORESP
        public ActionResult Index(string rejkoresp)
        {
            PEKORESPDBSet koresp = new PEKORESPDBSet(rejkoresp);
            if (koresp.Get(""))
            {
                PEREJKORESPDBSet deff = new PEREJKORESPDBSet();
                PEREJKORESP rk = deff.GetById(rejkoresp.Replace("_", "/"));

                ViewBag.nazwa = rk.DNAZWA;
                ViewBag.rejkoresp = rejkoresp;
                return View(koresp);
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


        }

        // GET: PEKORESP/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PEKORESP/Create
        public ActionResult Create(string rejkoresp)
        {
            PEREJKORESPDBSet deff = new PEREJKORESPDBSet();
            PEREJKORESP rk = deff.GetById(rejkoresp.Replace("_", "/"));

            ViewBag.nazwa = rk.DNAZWA;
            ViewBag.rejkoresp = rejkoresp;
            return View();
        }

        // POST: PEKORESP/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PEKORESP collection, string rejkoresp)
        {
            try
            {
                // TODO: Add insert logic here
                PEKORESPDBSet datatoinsert = new PEKORESPDBSet(rejkoresp);
                collection.SDATA = DateTime.Now;
                datatoinsert.Insert(collection);

                return RedirectToAction("Index",new { rejkoresp = rejkoresp});
                
            }
            catch
            {
                return View();
            }
        }

        // GET: PEKORESP/Edit/5
        public ActionResult Edit(string id, string rejkoresp)
        {
            PEKORESPDBSet datatoinsert = new PEKORESPDBSet(rejkoresp);
            PEKORESP pEKORESP = datatoinsert.GetById(id);
            if (pEKORESP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.rejkoresp = rejkoresp;
            return View(pEKORESP);
        }

        // POST: PEKORESP/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, PEKORESP collection, string rejkoresp)
        {
            try
            {
                PEKORESPDBSet datatoupdate = new PEKORESPDBSet(rejkoresp);
                collection.SDATA = DateTime.Now;
                datatoupdate.Update(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PEKORESP/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PEKORESP/Delete/5
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
