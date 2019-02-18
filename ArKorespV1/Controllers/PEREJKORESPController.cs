using Arango.Client;
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
    /// Weg Controller for PEREJKORESP collection
    /// </summary>
    public class PEREJKORESPController : Controller
    {
        private const string wychodzacaitem = "wychodząca";
        private const string przychodzacaitem = "przychodząca";

        /// <summary>
        /// controller's Index action method
        /// </summary>
        /// <param name="rodzaj">kind of data object</param>
        /// <returns>view data</returns>
        // GET: PEREJKORESP
        public ActionResult Index(int ? rodzaj)
        {
            int rodz = rodzaj ?? 0;

            PEREJKORESPDBSet db = new PEREJKORESPDBSet();
            if (!db.Get(""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lista = db.OrderBy(rk => rk.DSYMBOL).ToList();
            if (rodz > 0)
            {
                lista = lista.Where(lst => lst.DKIERUNEK == rodz).ToList();
            }
            ViewBag.rodzaj = rodz;
            return View( lista );
        }
        /// <summary>
        /// prepares data to view specific user registers
        /// </summary>
        /// <param name="rodzaj"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UserRegisters(int? rodzaj)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            int rodz = rodzaj ?? 0;
            string user = Session["UserId"].ToString();

            PEREJKORESPPRACDBSet listau = new PEREJKORESPPRACDBSet();
            List<PEREJKORESP> lista = listau.GetOtherSide<PEREJKORESP>(user,ADirection.In);
                        
            lista = lista.OrderBy(rk => rk.DSYMBOL).ToList();
            if (rodz > 0)
            {
                lista = lista.Where(lst => lst.DKIERUNEK == rodz).ToList();
            }
            ViewBag.rodzaj = rodz;
            return View(lista);
        }
        
        /// <summary>
        /// prepares static select list for DKIERUNEK field
        /// </summary>
        /// <returns></returns>
        private SelectList KierunkiSelectList()
        {
            Dictionary<int, string> kierunki = new Dictionary<int, string>
            {
                { 1, przychodzacaitem },
                { 2, wychodzacaitem }
            };
            return new SelectList(kierunki.Select(kk => new { id = kk.Key, value = kk.Value }), "id", "value");
        }

        /// <summary>
        /// prepares Create view 
        /// </summary>
        /// <returns></returns>
        // GET: PEREJKORESP/Create
        public ActionResult Create()
        {
            ViewBag.kierunki = KierunkiSelectList();
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection">form data</param>
        /// <returns>redirects to index</returns>
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

                    //now create PEKORESP collection and add to search
                    PEKORESPDBSet korespdbset = new PEKORESPDBSet(collection._id.Replace("/",""));
                    //in case it is missing - create empty view
                    korespdbset.InitializeView("VPEKORESP" );
                    //optionally add link to view
                    korespdbset.ModifyView("VPEKORESP" , collection._id.Replace("/", "").Replace("_", "") + "PEKORESP");

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// prepares edit view
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns>edit view</returns>
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

        /// <summary>
        /// posts edited data do database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"> posted data</param>
        /// <returns>redirects to index</returns>
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

                //now create PEKORESP collection and add to search
                PEKORESPDBSet korespdbset = new PEKORESPDBSet(collection.ID.Replace("/", ""));
                //in case it is missing - create empty view
                korespdbset.InitializeView("VPEKORESP");
                korespdbset.ModifyView("VPEKORESP", collection.ID.Replace("/", "").Replace("_", "") + "PEKORESP");

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        /// <summary>
        /// prepares view to delete entity
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns>view</returns>
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

        /// <summary>
        /// executes entity removal
        /// </summary>
        /// <param name="id">antity id</param>
        /// <param name="collection">some data</param>
        /// <returns></returns>
        // POST: PEREJKORESP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, PEREJKORESP collection)
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
