using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class PEPROCOBDOKPOZController : Controller
    {
        // GET: PEPROCOBDOKPOZ
        public ActionResult Index()
        {
            return View();
        }

        // GET: PEPROCOBDOKPOZ/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PEPROCOBDOKPOZ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PEPROCOBDOKPOZ/Create
        [HttpPost]
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

        // GET: PEPROCOBDOKPOZ/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PEPROCOBDOKPOZ/Edit/5
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

        // GET: PEPROCOBDOKPOZ/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PEPROCOBDOKPOZ/Delete/5
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
