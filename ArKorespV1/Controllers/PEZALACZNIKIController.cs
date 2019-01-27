using ArKorespV1.Models;
using ArKorespV1.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    public class PEZALACZNIKIController : Controller
    {
        // GET: PEZALACZNIKI
        public ActionResult Index()
        {
            string uname = Session["UserName"].ToString();
            PEZALACZNIKIDBSet zalaczniki = new PEZALACZNIKIDBSet(uname);
            if (zalaczniki.Get(""))
            {
                ZalacznikiZOgonemList lista = new ZalacznikiZOgonemList()  ;
                foreach (PEZALACZNIKI elem in zalaczniki)
                {
                    lista.Add(elem);
                }
                ViewBag.uname = uname;
                return View(lista);
            }
            else
                return View(new ZalacznikiZOgonemList());
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PEZALACZNIKI/Edit/5
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

        // GET: PEZALACZNIKI/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PEZALACZNIKI/Delete/5
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

        //GET: PEZALACZNIKIs/AttachementInsert/5
        public ActionResult AttachementInsert(int? imgid, HttpPostedFileBase file, String comment, int? dokumentid)
        {
            //string routeto = (string.IsNullOrEmpty(returnaction)) ? "Index" : returnaction;
            string keyword = imgid.ToString();
            BinaryReader b = new BinaryReader(file.InputStream);
            byte[] binData = new byte[file.ContentLength];
            //byte[] binData = b.ReadBytes(file.ContentLength);
            file.InputStream.Read(binData, 0, binData.Length);

            //SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.
            //                                        ConnectionStrings["Zalaczniki"].ConnectionString);
            //conn.Open();
            //SqlCommand zapytanie = new SqlCommand("select top 1 SID from PEZALACZNIKI where not exists(select top 1 1 from PEZALACZNIKI z where z.SID = PEZALACZNIKI.SID +1) and SID > 0", conn);
            //int theId = (int)zapytanie.ExecuteScalar() + 1;

            //zapytanie.CommandText = "INSERT INTO PEZALACZNIKI ( SID ,DNAZWAPLIKU  , DDOKUMENT , DREJESTRID , DKOMENTARZ, SUZYTKOWNIK , SDATA, SSYSTEM , DREJESTR ) " +
            //    "Values (@id , @wartosc, @bloob , @dokumentid ,@komentarz , @uzytk , @dataczas ,'joda' , @rejestr )";
            //zapytanie.Parameters.AddWithValue("id", theId);
            ////zapytanie.Parameters.AddWithValue("komentarz", parametry.theInfo);
            //zapytanie.Parameters.AddWithValue("wartosc", Path.GetFileName(file.FileName));
            //zapytanie.Parameters.Add("bloob", SqlDbType.VarBinary, binData.Length).Value = binData;
            //zapytanie.Parameters.AddWithValue("dokumentid", dokumentid);
            //zapytanie.Parameters.AddWithValue("komentarz", comment);
            //string usrname = Session["UserName"].ToString().Substring(0, (Session["UserName"].ToString().Length > 8) ? 8 : Session["UserName"].ToString().Length);
            //zapytanie.Parameters.AddWithValue("uzytk", usrname);
            //zapytanie.Parameters.AddWithValue("dataczas", DateTime.Now);
            //zapytanie.Parameters.AddWithValue("rejestr", "PWIK_JODA");
            //zapytanie.CommandTimeout = 36000;
            //zapytanie.ExecuteNonQuery();

            //conn.Close();

            return RedirectToAction("Index",
                    routeValues: new { jodaid = dokumentid })
                    ;

        }

    }

    
}
