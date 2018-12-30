using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class ATUZYTKController : Controller
    {
        // GET: ATUZYTK
        public ActionResult Index()
        {
            return View();
        }

        // GET: ATUZYTK/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ATUZYTK/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ATUZYTK/Create
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

        // GET: ATUZYTK/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ATUZYTK/Edit/5
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

        // GET: ATUZYTK/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ATUZYTK/Delete/5
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
