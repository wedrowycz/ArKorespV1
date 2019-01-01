using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class ATUZYTKController : Controller
    {

        // GET: ATUZYTK
        public ActionResult Index()
        {
            ATUZYTKDBSet lista = new ATUZYTKDBSet();
            if (!lista.Get(""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var lista2 = lista.OrderBy(kl => kl.UserName);

            return View(lista);
        }

        // GET: ATUZYTK/Details/5
        public ActionResult Details(string id)
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(ATUZYTK collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ATUZYTKDBSet dbset = new ATUZYTKDBSet();
                    dbset.Insert(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ATUZYTK/Edit/5
        public ActionResult Edit(string id)
        {
            ATUZYTKDBSet dbset = new ATUZYTKDBSet();
            ATUZYTK datatoupdate = dbset.GetById(id.Replace("_", "/"));
            if (datatoupdate == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(datatoupdate);
        }

        // POST: ATUZYTK/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, ATUZYTK collection)
        {
            try
            {
                // TODO: Add update logic here
                ATUZYTKDBSet dbset = new ATUZYTKDBSet();
                dbset.Update(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ATUZYTK/Delete/5
        public ActionResult Delete(string id)
        {
            if( id == null || id == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ATUZYTKDBSet dbset = new ATUZYTKDBSet();
            ATUZYTK datatodelete = dbset.GetById(id.Replace("_","/"));
            if(datatodelete == null || datatodelete.UserRole == 2)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(datatodelete);
        }

        // POST: ATUZYTK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                // TODO: Add delete logic here
                ATUZYTKDBSet dbset = new ATUZYTKDBSet();                
                dbset.Delete(id.Replace("_", "/"));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
