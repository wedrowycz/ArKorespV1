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
    /// controller for PEPROCOBDOKSKRZYNKI views
    /// </summary>
    public class PEPROCOBDOKSKRZYNKIController : Controller
    {
        /// <summary>
        /// prepares data for Index View
        /// </summary>
        /// <param name="pozycjaprocedury"></param>
        /// <param name="procedura"></param>
        /// <returns></returns>
        // GET: PEPROCOBDOKSKRZYNKI
        public ActionResult Index(string pozycjaprocedury, string procedura)
        {
            PEPROCOBDOKPOZDBSet dbproc = new PEPROCOBDOKPOZDBSet();
            var pozycjap = dbproc.GetById(pozycjaprocedury);
            PEPROCOBDOKSKRZYNKIDBSet db = new PEPROCOBDOKSKRZYNKIDBSet();
            var listaskrzynek = db.GetOtherSide<PESKRZPOCZT>(pozycjaprocedury.Replace("_", "/"), Arango.Client.ADirection.Out);
            if (listaskrzynek == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.nazwa = pozycjap.DNAZWA;
            ViewBag.pozycjaprocedury = pozycjaprocedury;
            ViewBag.procedura = procedura;
            return View(listaskrzynek);
        }

        // GET: PEPROCOBDOKSKRZYNKI/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        /// <summary>
        /// prepares data for create view
        /// </summary>
        /// <param name="pozycjaprocedury"></param>
        /// <param name="procedura"></param>
        /// <returns></returns>
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
                string procedura = Request["procedura"].ToString();
                if (collection == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                PEPROCOBDOKSKRZYNKIDBSet db = new PEPROCOBDOKSKRZYNKIDBSet();
                collection.SDATA = DateTime.Now;
                db.CreateEdge(collection);

                return RedirectToAction("Index",
                    new { pozycjaprocedury = collection._from, procedura });
            }
            catch
            {
                return View();
            }
        }

       
        // GET: PEPROCOBDOKSKRZYNKI/Delete/5
        public ActionResult Delete(string id, string pozycjaprocedury, string procedura)
        {
            PEPROCOBDOKSKRZYNKIDBSet db = new PEPROCOBDOKSKRZYNKIDBSet();
            if (db.GetEdges(pozycjaprocedury,Arango.Client.ADirection.Out))
            {
                var toremove = db.Where(lst => lst._to == id.Replace("_","/")).FirstOrDefault();
                if (toremove != null)
                {
                    db.RemoveEdge(toremove._from, toremove._to);
                }
            }

            return RedirectToAction("Index",
                    new { pozycjaprocedury , procedura });
        }

        
        private SelectList UserSelectList()
        {
            PESKRZPOCZTDBSet uzytkownicy = new PESKRZPOCZTDBSet();
            if (uzytkownicy.Get(""))
            {
                var lista = uzytkownicy.Select(iz => new SelectListItem { Value = iz._id, Text = iz.DNAZWA }).AsEnumerable();
                return new SelectList(lista, "Value", "Text");
            }
            return null;
        }
    }
}
