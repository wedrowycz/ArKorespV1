using ArKorespV1.Models;
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
        public ActionResult Create(string procedura)
        {
            ViewBag.procedura = procedura;
            return View();
        }

        // POST: PEPROCOBDOKPOZ/Create
        [HttpPost]
        public ActionResult Create(PEPROCOBDOKPOZ collection)
        {
            try
            {
                string poprzedni = Request["procedura"].ToString();
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
                connections.CreateEdge(poprzedni, newcollection.ID,extradane);

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
