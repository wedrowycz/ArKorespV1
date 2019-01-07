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
    public class PEREJKORESPPRACController : Controller
    {
        // GET: PEREJKORESPPRAC
        public ActionResult Index(string rejestr)
        {
            PEREJKORESPPRACDBSet powiazania = new PEREJKORESPPRACDBSet();
            var lista = powiazania.GetOtherSide<ATUZYTK>(rejestr, ADirection.Out);
            if (lista == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEREJKORESPDBSet info = new PEREJKORESPDBSet();
            var infooskrz = info.GetById(rejestr);
            ViewBag.rejestr = rejestr;
            ViewBag.nazwarejestru = infooskrz.DNAZWA;

            return View(lista);
        }

        // GET: PEREJKORESPPRAC/Details/5
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

                //return new SelectList(uzytkownicy
                //            .Select(ul => new { id = ul._id , value = ul.UserName })
                //                    ,"id","value");
                return new SelectList(lista, "Value", "Text");
            }
            return null;
        }

        // GET: PEREJKORESPPRAC/Create
        public ActionResult Create(string rejestr)
        {
            ViewBag.rejestr = rejestr;
            ViewBag.ListaU = UserSelectList();
            return View();
        }

        // POST: PEREJKORESPPRAC/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PEREJKORESPPRAC collection)
        {
            try
            {
                PEREJKORESPPRACDBSet pracs = new PEREJKORESPPRACDBSet();
                Dictionary<string, object> extradane = new Dictionary<string, object>();
                extradane.Add("SDATA", DateTime.Now);
                pracs.CreateEdge(collection._from, collection._to, extradane);

                return RedirectToAction("Index", new { rejestr = collection._from });
            }
            catch
            {
                return View();
            }
        }

        // GET: PEREJKORESPPRAC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PEREJKORESPPRAC/Edit/5
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

        // GET: PEREJKORESPPRAC/Delete/5
        public ActionResult Delete(string _from, string _to)
        {
            PEREJKORESPPRACDBSet powiazania = new PEREJKORESPPRACDBSet();

            if (powiazania.GetEdges(_from, ADirection.Out))
            {
                var edge = powiazania.Where(konc => konc._to == _to).FirstOrDefault();
                ViewBag.rejestr = _from;
                return View(edge);
            }

            return View();
        }

        // POST: PEREJKORESPPRAC/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string _from, string _to, PEREJKORESPPRAC collection)
        {
            try
            {
                if (_from == "" || _to == "")
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PEREJKORESPPRACDBSet powiazania = new PEREJKORESPPRACDBSet();
                powiazania.RemoveEdge(_from, _to);

                return RedirectToAction("Index", new { rejestr = _from });
            }
            catch
            {
                return View();
            }
        }
    }
}
