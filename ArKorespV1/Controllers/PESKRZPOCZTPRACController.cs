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
    /// object's PESKRZPOCZT users
    /// </summary>
    public class PESKRZPOCZTPRACController : Controller
    {
        /// <summary>
        ///  object users controller
        /// </summary>
        /// <param name="skrzynka"></param>
        /// <returns> view with users collection</returns>
        // GET: PESKRZPOCZTPRAC
        public ActionResult Index(string skrzynka)
        {
            PESKRZPOCZTPRACDBSet powiazania = new PESKRZPOCZTPRACDBSet();
            var lista = powiazania.GetOtherSide<ATUZYTK>(skrzynka, ADirection.Out);
            if (lista == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PESKRZPOCZTDBSet info = new PESKRZPOCZTDBSet();
            var infooskrz = info.GetById(skrzynka);
            ViewBag.skrzynka = skrzynka;
            ViewBag.nazwaskrzynki = infooskrz.DNAZWA;

            return View(lista);
        }

        // GET: PESKRZPOCZTPRAC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        private SelectList UserSelectList()
        {
            ATUZYTKDBSet uzytkownicy = new ATUZYTKDBSet();
            if (uzytkownicy.Get(""))
            {
                var lista = uzytkownicy.Select(iz => new SelectListItem { Value = iz._id, Text = iz.UserName }).AsEnumerable();
                return new SelectList(lista,"Value","Text");
            }
            return null;
        }

        // GET: PESKRZPOCZTPRAC/Create
        public ActionResult Create(string skrzynka)
        {
            ViewBag.skrzynka = skrzynka;
            ViewBag.ListaU = UserSelectList();
            return View();
        }

        // POST: PESKRZPOCZTPRAC/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PESKRZPOCZTPRAC collection)
        {
            try
            {
                PESKRZPOCZTPRACDBSet pracs = new PESKRZPOCZTPRACDBSet();
                Dictionary<string, object> extradane = new Dictionary<string, object>
                {
                    { "SDATA", DateTime.Now }
                };
                pracs.CreateEdge(collection._from, collection._to, extradane);

                return RedirectToAction("Index",new { skrzynka = collection._from });
            }
            catch
            {
                return View();
            }
        }

        // GET: PESKRZPOCZTPRAC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PESKRZPOCZTPRAC/Edit/5
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

        // GET: PESKRZPOCZTPRAC/Delete/5
        public ActionResult Delete(string _from, string _to)
        {
            PESKRZPOCZTPRACDBSet powiazania = new PESKRZPOCZTPRACDBSet();

            if (powiazania.GetEdges(_from, ADirection.Out))
            {
                var edge = powiazania.Where(konc => konc._to == _to).FirstOrDefault();
                ViewBag.skrzynka = _from;
                return View(edge);
            }   
            
            return View();
        }

        // POST: PESKRZPOCZTPRAC/Delete/5
        [HttpPost]
        public ActionResult Delete(string _from,string _to, PESKRZPOCZTPRAC collection)
        {
            try
            {
                if (_from == "" || _to == "")
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PESKRZPOCZTPRACDBSet powiazania = new PESKRZPOCZTPRACDBSet();
                powiazania.RemoveEdge(_from,_to);
                
                return RedirectToAction("Index", new { rejestr = _from});
            }
            catch
            {
                return View();
            }
        }
    }
}
