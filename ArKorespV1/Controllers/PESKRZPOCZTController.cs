using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class PESKRZPOCZTController : Controller
    {
        // GET: PESKRZPOCZT
        public ActionResult Index()
        {
            PESKRZPOCZTDBSet skrzynki = new PESKRZPOCZTDBSet();
            if (!skrzynki.Get(""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View(skrzynki.OrderBy(sp => sp.DNAZWA).ToList()); 
        }

        // GET: PESKRZPOCZT/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PESKRZPOCZT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PESKRZPOCZT/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PESKRZPOCZT collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PESKRZPOCZTDBSet dbset = new PESKRZPOCZTDBSet();
                    collection.SDATA = DateTime.Now;
                    dbset.Insert(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PESKRZPOCZT/Edit/5
        public ActionResult Edit(string id)
        {
            PESKRZPOCZTDBSet dbset = new PESKRZPOCZTDBSet();
            PESKRZPOCZT datatoupdate = dbset.GetById(id.Replace("_", "/"));
            if (datatoupdate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(datatoupdate);
        }

        // POST: PESKRZPOCZT/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, PESKRZPOCZT collection)
        {
            try
            {
                PESKRZPOCZTDBSet dbset = new PESKRZPOCZTDBSet();
                collection.SDATA = DateTime.Now;
                dbset.Update(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: PESKRZPOCZT/Delete/5
        public ActionResult Delete(string id)
        {
            PESKRZPOCZTDBSet dbset = new PESKRZPOCZTDBSet();
            PESKRZPOCZT datatodelete = dbset.GetById(id.Replace("_", "/"));
            if (datatodelete == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(datatodelete);
        }

        // POST: PESKRZPOCZT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, PESKRZPOCZT collection)
        {
            try
            {
                PESKRZPOCZTDBSet dbset = new PESKRZPOCZTDBSet();
                dbset.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
