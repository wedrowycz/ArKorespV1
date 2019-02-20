using ArKorespV1.Helpers;
using ArKorespV1.Models;
using ArKorespV1.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    /// <summary>
    /// Controller class for user documents
    /// </summary>
    public class PEZALACZNIKIController : Controller
    {
        // GET: PEZALACZNIKI
        public ActionResult Index(int ? pagesize, int ? pagenumber)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            int psize = pagesize ?? 5;
            int pnumber = pagenumber ?? 1;

            string uname = Session["UserName"].ToString();
            PEZALACZNIKIDBSet zalaczniki = new PEZALACZNIKIDBSet(uname);

            int ogolem = zalaczniki.GetCount("");

            if (zalaczniki.Get("", pnumber, psize))
            {
                ZalacznikiZOgonemList lista = new ZalacznikiZOgonemList();
                foreach (PEZALACZNIKI elem in zalaczniki)
                {
                    lista.Add(elem);
                }
                ViewBag.uname = uname;
                ViewBag.page = pnumber;
                ViewBag.psize = psize;
                ViewBag.numberofrecords = ogolem;
                return View(lista);
            }
            else
            {
                ViewBag.uname = "";
                ViewBag.page = pnumber;
                ViewBag.psize = psize;
                return View(new ZalacznikiZOgonemList());
            }
        }

        // GET: PEZALACZNIKI/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PEZALACZNIKI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PEZALACZNIKI/Create
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

        // GET: PEZALACZNIKI/Edit/5
        public ActionResult Edit(string id)
        {
            string uname = Session["UserName"].ToString();
            PEZALACZNIKIDBSet zalaczniki = new PEZALACZNIKIDBSet(uname);
            PEZALACZNIKI pEZALACZNIKI = zalaczniki.GetById(id);
            if (pEZALACZNIKI != null)
            {
                return View(pEZALACZNIKI);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: PEZALACZNIKI/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, PEZALACZNIKI collection)
        {
            try
            {
                string uname = Session["UserName"].ToString();
                PEZALACZNIKIDBSet zalaczniki = new PEZALACZNIKIDBSet(uname);
                collection.SDATA = DateTime.Now;
                zalaczniki.Update(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PEZALACZNIKI/Delete/5
        public ActionResult Delete(string id)
        {
            string uname = Session["UserName"].ToString();
            PEZALACZNIKIDBSet zalaczniki = new PEZALACZNIKIDBSet(uname);
            PEZALACZNIKI pEZALACZNIKI = zalaczniki.GetById(id);
            if (pEZALACZNIKI != null)
            {
                return View(pEZALACZNIKI);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        // POST: PEZALACZNIKI/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, PEZALACZNIKI collection)
        {

            try
            {
                string uname = Session["UserName"].ToString();
                PEZALACZNIKIDBSet zalaczniki = new PEZALACZNIKIDBSet(uname);
                zalaczniki.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult AttachementInsert( HttpPostedFileBase file, String comment, int? dokumentid)
        {
            BinaryReader b = new BinaryReader(file.InputStream);
            byte[] binData = new byte[file.ContentLength];            
            file.InputStream.Read(binData, 0, binData.Length);
            String hexencoded = HexHelper.ByteArrayToHexString(binData);
            string uname = Session["UserName"].ToString();
            PEZALACZNIKIDBSet zalaczniki = new PEZALACZNIKIDBSet(uname);
            PEZALACZNIKI pEZALACZNIKI = new PEZALACZNIKI();
            pEZALACZNIKI.DDANE = hexencoded;
            pEZALACZNIKI.DNAZWAPLIKU = file.FileName;
            pEZALACZNIKI.SDATA = DateTime.Now;
            pEZALACZNIKI.DWERSJA = "1";
            pEZALACZNIKI.DDATA = DateTime.Now;
            pEZALACZNIKI.DOPIS = comment;
            pEZALACZNIKI.DROZMIARPLIKU = hexencoded.Length;
            zalaczniki.Insert(pEZALACZNIKI);
            
            return RedirectToAction("Index",
                    routeValues: new {  })
                    ;

        }

        [HttpGet]
        public FileResult DownloadFile(string id)
        {            
            byte[] pdfByte;
            string uname = Session["UserName"].ToString();
            PEZALACZNIKIDBSet zalaczniki = new PEZALACZNIKIDBSet(uname);
            PEZALACZNIKI pEZALACZNIKI = zalaczniki.GetById(id);
            if (pEZALACZNIKI != null)
            {
                pdfByte = HexHelper.HexStringToByteArray(pEZALACZNIKI.DDANE);
                return File(pdfByte, "application/pdf", pEZALACZNIKI.DNAZWAPLIKU);
            }
            else
              return null ;
        }

    }

    
}
