using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult Create(string procedura, string levelup)
        {
            ViewBag.procedura = procedura;
            ViewBag.levelup = levelup;
            return View();
        }

        // POST: PEPROCOBDOKPOZ/Create
        [HttpPost]
        public ActionResult Create(PEPROCOBDOKPOZ collection)
        {
            try
            {
                string poprzedni = Request["procedura"].ToString();
                string levelup = Request["levelup"].ToString();
                // TODO: Add insert logic here
                PEPROCOBDOKPOZDBSet krok = new PEPROCOBDOKPOZDBSet();
                //data
                var newcollection = krok.Insert(collection);
                //edge
                PEPROCEDURYDBSet connections = new PEPROCEDURYDBSet();
                Dictionary<string, object> extradane = new Dictionary<string, object>
                {
                    { "SDATA", DateTime.Now }
                };
                connections.CreateEdge(levelup, newcollection.ID,extradane);

                return RedirectToAction(actionName:"RouteDiagram",
                        controllerName:"PEPROCOBDOK",
                        routeValues: new { id = poprzedni});
            }
            catch
            {
                return View();
            }
        }

        // GET: PEPROCOBDOKPOZ/Edit/5
        public ActionResult Edit(string id, string procedura)
        {
            PEPROCOBDOKPOZDBSet dbset = new PEPROCOBDOKPOZDBSet();
            var datatoedit = dbset.GetById(id);
            if (datatoedit == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.procedura = procedura;
            return View(datatoedit);
        }

        // POST: PEPROCOBDOKPOZ/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, PEPROCOBDOKPOZ collection)
        {
            try
            {
                string poprzedni = Request["procedura"].ToString();
                PEPROCOBDOKPOZDBSet dbset = new PEPROCOBDOKPOZDBSet();                
                if (collection == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                dbset.Update(collection);

                return RedirectToAction(actionName: "RouteDiagram",
                        controllerName: "PEPROCOBDOK",
                        routeValues: new { id = poprzedni });
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
