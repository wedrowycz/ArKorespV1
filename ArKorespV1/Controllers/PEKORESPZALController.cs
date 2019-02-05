using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class PEKORESPZALController : Controller
    {
        // GET: PEKORESPZAL
        public ActionResult Index()
        {
            return View();
        }

        // GET: PEKORESPZAL/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PEKORESPZAL/Create
        public ActionResult Create(string id, string rejkoresp)
        {
            string uname = Session["UserName"].ToString();

            PEZALACZNIKIBDDBSet zaldb = new PEZALACZNIKIBDDBSet(uname);
            if (!zaldb.Get(""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            SelectList listazal = new SelectList(zaldb.ToList(),  "_id", "DNAZWAPLIKU");

            ViewBag.id = id;
            ViewBag.rejkoresp = rejkoresp;
            ViewBag.listazal = listazal;
            return View();
        }

        // POST: PEKORESPZAL/Create
        [HttpPost]
        public ActionResult Create(PEKORESPZAL collection)
        {
            try
            {
                string koresp = Request["id"].ToString();
                string rejkoresp = Request["rejkoresp"].ToString();
                PEKORESPZALDBSet zadb = new PEKORESPZALDBSet();
                Dictionary<string, object> extra = new Dictionary<string, object>
                {
                    { "SDATA", DateTime.Now }
                };
                zadb.CreateEdge(koresp,collection._to, extra);
                return RedirectToAction(actionName:"Zalaczniki", 
                        controllerName:"PEKORESP",routeValues: new { id = koresp, rejkoresp});
            }
            catch
            {
                return View();
            }
        }

        // GET: PEKORESPZAL/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PEKORESPZAL/Edit/5
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

        // GET: PEKORESPZAL/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PEKORESPZAL/Delete/5
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
