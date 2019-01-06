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
    public class PESKRZPOCZTPRACController : Controller
    {
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

        // GET: PESKRZPOCZTPRAC/Create
        public ActionResult Create(string skrzynka)
        {
            return View();
        }

        // POST: PESKRZPOCZTPRAC/Create
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PESKRZPOCZTPRAC/Delete/5
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
