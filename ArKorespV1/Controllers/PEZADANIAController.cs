using ArKorespV1.Models;
using ArKorespV1.Models.ZADANIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class PEZADANIAController : Controller
    {
        // GET: PEZADANIA
        public ActionResult Index(int ? status)
        {
            PEZADANIADBSet pEZADANIA = new PEZADANIADBSet();
            int statuszad = status ?? 0;
            string userid = Session["UserId"].ToString();
            PESKRZPOCZTPRACDBSet skrzynka = new PESKRZPOCZTPRACDBSet();
            List<PESKRZPOCZT> listaskrzynek = skrzynka.GetOtherSide<PESKRZPOCZT>(userid, Arango.Client.ADirection.In);

            var lista = pEZADANIA.GetPEZADANIAList(listaskrzynek.FirstOrDefault()._id, statuszad, 100, 1);
            ViewBag.status = statuszad;
            return View(lista);
        }

        // GET: PEZADANIA/Details/5
        public ActionResult Details(string korespondencja)
        {
            PEKORESPDBSet koresp = new PEKORESPDBSet("");
            PEKORESP pEKORESP = koresp.GetById(korespondencja);
            return View(pEKORESP);
        }
        [HttpPost]
        public ActionResult Details()
        {
            return View("Close");
        }

        // GET: PEZADANIA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PEZADANIA/Create
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

        // GET: PEZADANIA/Edit/5
        public ActionResult Edit(string id, string korespondencja)
        {
            PEZADANIADBSet dbedit = new PEZADANIADBSet();
            PEZADANIA pEZADANIA = dbedit.GetById(id);
            if (pEZADANIA == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEPROCEDURYDBSet proc = new PEPROCEDURYDBSet();
            List<PEPROCOBDOKPOZ> nastepne = proc.GetOtherSide<PEPROCOBDOKPOZ>(pEZADANIA.DPROCEDURAID, Arango.Client.ADirection.Out);

            SelectList slZadan = new SelectList(nastepne, "ID", "DNAZWA");

            PEPROCOBDOKPOZDBSet pEPROCOBDOKPOZdb = new PEPROCOBDOKPOZDBSet();
            PEPROCOBDOKPOZ pEPROCOBDOKPOZ = pEPROCOBDOKPOZdb.GetById(pEZADANIA.DPROCEDURAID);

            PEKORESPDBSet koresp = new PEKORESPDBSet("");
            PEKORESP pEKORESP = koresp.GetById(korespondencja);
            ViewBag.dotyczy = pEKORESP.DDOTYCZY;
            ViewBag.nazwazadania = pEPROCOBDOKPOZ.DNAZWA;
            ViewBag.opiszadania = pEPROCOBDOKPOZ.DOPIS;
            ViewBag.nastepne = slZadan;
            ViewBag.korespondencja = korespondencja;
            return View(pEZADANIA);
        }

        // POST: PEZADANIA/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, PEZADANIA collection, string korespondencja)
        {
            try
            {
                string nastepne = Request["Nastepne"] == null?"":Request["Nastepne"].ToString();

                PEZADANIADBSet dbzadania = new PEZADANIADBSet();
                collection.SDATA = DateTime.Now;
                collection.DSTATUS = 1;
                dbzadania.Update(collection);

                if (nastepne != "")
                {
                    PEPROCOBDOKPOZDBSet nastzad = new PEPROCOBDOKPOZDBSet();
                    var nastepnezadanie = nastzad.GetById(nastepne);

                    PEOBDOKDBSet obieg = new PEOBDOKDBSet();
                    PEPROCOBDOKSKRZYNKIDBSet skrzynkiobiegu = new PEPROCOBDOKSKRZYNKIDBSet();
                    var skrzynki = skrzynkiobiegu.GetOtherSide<PESKRZPOCZT>(nastepnezadanie._id, Arango.Client.ADirection.Out);
                    if (skrzynki != null)
                    {
                        foreach (PESKRZPOCZT skrznka in skrzynki)
                        {
                            PEZADANIADBSet zadaniadb = new PEZADANIADBSet();
                            PEZADANIA nowezadanie = new PEZADANIA();
                            nowezadanie.SDATA = DateTime.Now;
                            nowezadanie.DPROCEDURAID = nastepnezadanie.ID;
                            nowezadanie.DNAZWA = nastepnezadanie.DNAZWA;
                            nowezadanie.DSTATUS = 0;
                            var wstawionezad = zadaniadb.Insert(nowezadanie);
                            Dictionary<string, object> extradane = new Dictionary<string, object>
                            {
                                { "SDATA", DateTime.Now },
                                { "Skrzynka", skrznka._id},
                                { "Korespondencja", korespondencja }
                            };
                            obieg.CreateEdge(id, wstawionezad._id, extradane);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PEZADANIA/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PEZADANIA/Delete/5
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
