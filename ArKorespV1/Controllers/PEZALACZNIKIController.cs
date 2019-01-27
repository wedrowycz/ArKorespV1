using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class PEZALACZNIKIController : Controller
    {
        // GET: PEZALACZNIKI
        public ActionResult Index()
        {
            string uname = Session["UserName"].ToString();
            PEZALACZNIKIDBSet notatki = new PEZALACZNIKIDBSet(uname);
            if (notatki.Get(""))
            {
                ViewBag.uname = uname;
                return View(notatki);
            }
            else
                return View();
        }

        // GET: PEZALACZNIKI/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PEZALACZNIKI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PEZALACZNIKI/Create
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

        // GET: PEZALACZNIKI/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PEZALACZNIKI/Edit/5
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

        // GET: PEZALACZNIKI/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PEZALACZNIKI/Delete/5
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
