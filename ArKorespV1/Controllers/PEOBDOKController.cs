using ArKorespV1.Models;
using ArKorespV1.Models.ZADANIA;
using ArKorespV1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class PEOBDOKController : Controller
    {
        // GET: PEOBDOK
        [HttpGet]
        public ActionResult Index(string id,string rejkoresp)
        {
            PEKORESPDBSet korespondencja = new PEKORESPDBSet(rejkoresp);
            var wpiswrejestrze = korespondencja.GetById(id);
            if (wpiswrejestrze == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEOBDOKDBSet obieg = new PEOBDOKDBSet();
            var listazadan = obieg.GetOtherSide<PEZADANIA>(id,Arango.Client.ADirection.Out,10);
            ViewBag.rejestr = rejkoresp;
            ViewBag.korespondencja = id;
            ViewBag.ddotyczy = wpiswrejestrze.DDOTYCZY;
            List<PEZADANIEZOGONEM> rozszerzone = new List<PEZADANIEZOGONEM>();
            foreach (PEZADANIA item in listazadan)
            {
                PEZADANIEZOGONEM pEZADANIEZOGONEM = new PEZADANIEZOGONEM();
                pEZADANIEZOGONEM.pEZADANIA = item;
                PEOBDOKDBSet obiegi = new PEOBDOKDBSet();
                if (obiegi.Get("item._to == '" + item._id + "'"))
                {
                    string skrzynkazad = obiegi.FirstOrDefault().Skrzynka;
                    PESKRZPOCZTDBSet skrzpoczt = new PESKRZPOCZTDBSet();
                    var adresat = skrzpoczt.GetById(skrzynkazad);
                    if (adresat != null)
                        pEZADANIEZOGONEM.pESKRZPOCZT = adresat;
                    else
                        pEZADANIEZOGONEM.pESKRZPOCZT = new PESKRZPOCZT();
                }

                pEZADANIEZOGONEM.extradane = "";
                rozszerzone.Add(pEZADANIEZOGONEM);
            }
            ViewBag.proceduryselectlist = ProcedurySelectList();
            return View(rozszerzone);
        }
        /// <summary>
        /// Post call from grid view that advances task flow
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rejkoresp">context document set</param>
        /// <param name="procedura">task to advance</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string id, string rejkoresp,string procedura)
        {
            PEPROCOBDOKDBSet prc = new PEPROCOBDOKDBSet();
            var naglowek = prc.GetById(procedura);
            if (naglowek != null)
            {
                PEPROCEDURYDBSet kroki = new PEPROCEDURYDBSet();
                var pierwszykrok = kroki.GetOtherSide<PEPROCOBDOKPOZ>(naglowek._id,Arango.Client.ADirection.Out);
                if (pierwszykrok != null)
                {
                    PEOBDOKDBSet obieg = new PEOBDOKDBSet();
                    PEPROCOBDOKSKRZYNKIDBSet skrzynkiobiegu = new PEPROCOBDOKSKRZYNKIDBSet();
                    var skrzynki = skrzynkiobiegu.GetOtherSide<PESKRZPOCZT>(pierwszykrok.FirstOrDefault()._id, Arango.Client.ADirection.Out);
                    if (skrzynki != null)
                    {
                        foreach (PESKRZPOCZT skrznka in skrzynki)
                        {
                            PEZADANIADBSet zadaniadb = new PEZADANIADBSet();
                            PEZADANIA nowezadanie = new PEZADANIA();
                            nowezadanie.SDATA = DateTime.Now;
                            nowezadanie.DPROCEDURAID = pierwszykrok.FirstOrDefault().ID;
                            nowezadanie.DNAZWA = pierwszykrok.FirstOrDefault().DNAZWA;
                            nowezadanie.DSTATUS = 0;
                            var wstawionezad = zadaniadb.Insert(nowezadanie);
                            Dictionary<string, object> extradane = new Dictionary<string, object>
                            {
                                { "SDATA", DateTime.Now },
                                { "Skrzynka", skrznka._id},
                                { "Korespondencja", id }
                            };
                            obieg.CreateEdge(id,wstawionezad._id,extradane);
                        }
                    }

                }
            }

            return RedirectToAction("Index", new { id, rejkoresp });
        }

        private SelectList ProcedurySelectList()
        {
            PEPROCOBDOKDBSet uzytkownicy = new PEPROCOBDOKDBSet();
            if (uzytkownicy.Get(""))
            {
                var lista = uzytkownicy.Select(iz => new SelectListItem { Value = iz._id, Text = iz.DNAZWA }).AsEnumerable();
                return new SelectList(lista, "Value", "Text");
            }
            return null;
        }

        // GET: PEOBDOK/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PEOBDOK/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PEOBDOK/Create
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

        // GET: PEOBDOK/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PEOBDOK/Edit/5
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

        // GET: PEOBDOK/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PEOBDOK/Delete/5
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
