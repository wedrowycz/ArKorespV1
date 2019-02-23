using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    /// <summary>
    /// User View controller
    /// </summary>
    public class ATUZYTKController : Controller
    {
        /// <summary>
        /// default index action
        /// </summary>
        /// <returns>view</returns>
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

        
        /// <summary>
        /// standard create -prepare action
        /// </summary>
        /// <returns>view</returns>
        // GET: ATUZYTK/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// insert user to database
        /// </summary>
        /// <param name="collection"></param>
        /// <returns>redirect to index<returns>
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

        /// <summary>
        /// prepares data to edit entity
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns>view</returns>
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

        /// <summary>
        /// standard edit action- posts changed data
        /// </summary>
        /// <param name="id">entity id</param>
        /// <param name="collection">entity</param>
        /// <returns>redirects to view</returns>
        // POST: ATUZYTK/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, ATUZYTK collection)
        {
            try
            {                
                ATUZYTKDBSet dbset = new ATUZYTKDBSet();
                dbset.Update(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// controler delet method
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns>view</returns>
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

        /// <summary>
        /// execute delete method
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns>redirects to index</returns>
        // POST: ATUZYTK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {                
                ATUZYTKDBSet dbset = new ATUZYTKDBSet();                
                dbset.Delete(id.Replace("_", "/"));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }           
        }
        /// <summary>
        /// Change user's status 0 - active, 1 inactive
        /// </summary>
        /// <param name="id">documents id</param>
        /// <param name="status"> new status</param>
        /// <returns>redirects to index</returns>
        public ActionResult ChangeState(string id, int? status)
        {
            ATUZYTKDBSet dbset = new ATUZYTKDBSet();
            ATUZYTK datatochange = dbset.GetById(id);

            if (datatochange == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //admin users cannot be blocked
            if(datatochange.UserRole == 2 && status >0 )
            {
                return RedirectToAction("Index");
            }
            datatochange.Status = status ?? 0;
            dbset.Update(datatochange);
            return RedirectToAction("Index");
        }
    }
}
