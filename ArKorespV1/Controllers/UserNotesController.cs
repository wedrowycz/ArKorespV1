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
    /// user notes asp controller
    /// </summary>
    public class UserNotesController : Controller
    {
        /// <summary>
        /// controllers index method
        /// </summary>
        /// <returns>data for Index view</returns>
        // GET: UserNotes
        public ActionResult Index()
        {
            string filtr_notatka = Request["tx_notatka"];
            string filtr_ddata = Request["tx_data"];
            string filtr_przypomnienie = Request["tx_remind"];
            string uname = Session["UserName"].ToString();
            UserNotesDBSet notatki = new UserNotesDBSet(uname);
            ViewBag.tx_notatka = filtr_notatka;
            ViewBag.tx_data = filtr_ddata;
            ViewBag.tx_remind = filtr_przypomnienie;
            String aqlcondition = "";
            if (filtr_notatka != null && filtr_notatka != "")
            {
                aqlcondition += "Contains(item.DNOTATKA,'" + filtr_notatka + "' )";
            }

            try
            {
                if (filtr_ddata != null && filtr_ddata != "")
                {
                    if (filtr_ddata.Length == 10)
                    {
                        if (aqlcondition != "")
                        {
                            aqlcondition += " && ";
                        }
                        aqlcondition += " item.DDATA == '" + DateTime.Parse(filtr_ddata).ToUniversalTime().ToString().Replace(" ", "T") + "Z"
                            //+ "T23:00:00Z" 
                            + "'";
                    }

                }
            }
            catch (Exception e)
            {
                aqlcondition = "";
            }
            try
            {
                if (filtr_przypomnienie != null && filtr_przypomnienie != "")
                {
                    if (filtr_przypomnienie.Length == 10)
                    {
                        if (aqlcondition != "")
                        {
                            aqlcondition += " && ";
                        }
                        aqlcondition += " item.DPRZYPOMNIENIE == '" + DateTime.Parse(filtr_przypomnienie).ToUniversalTime().ToString().Replace(" ", "T") + "Z"
                            //+ "T23:00:00Z" 
                            + "'";
                    }

                }
            }
            catch (Exception e)
            {
                aqlcondition = "";
            }

            if (notatki.Get(aqlcondition))
            {
                ViewBag.uname = uname;
                return View(notatki);
            }
            else
            return View();
        }

        /// <summary>
        /// clear filter request controller method
        /// </summary>
        /// <returns>redirests to index</returns>
        [HttpGet]
        public ActionResult ClearFilters()
        {
            return RedirectToAction("Index");
        }

        /// <summary>
        /// standard controllers method - GET
        /// </summary>
        /// <param name="id">records id</param>
        /// <returns></returns>
        // GET: UserNotes/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: UserNotes/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// standard post create method process data from form
        /// </summary>
        /// <param name="collection">data to write to db</param>
        /// <returns></returns>
        // POST: UserNotes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserNotes collection)
        {
            try
            {
                string uname = Session["UserName"].ToString();
                UserNotesDBSet datactr = new UserNotesDBSet(uname);
                collection.SDATA = DateTime.Now;
                datactr.Insert(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Standard controller Edit get method
        /// </summary>
        /// <param name="id"></param>
        /// <returns>data for edit view</returns>
        // GET: UserNotes/Edit/5
        public ActionResult Edit(string id)
        {
            string uname = Session["UserName"].ToString();
            UserNotesDBSet datactr = new UserNotesDBSet(uname);
            UserNotes datatoupdate = datactr.GetById(id);
            if(datatoupdate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View( datatoupdate );
        }

        // POST: UserNotes/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, UserNotes collection)
        {
            try
            {
                string uname = Session["UserName"].ToString();
                UserNotesDBSet datactr = new UserNotesDBSet(uname);
                collection.SDATA = DateTime.Now;
                datactr.Update(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserNotes/Delete/5
        public ActionResult Delete(string id)
        {
            string uname = Session["UserName"].ToString();
            UserNotesDBSet datactr = new UserNotesDBSet(uname);
            UserNotes datatodelete = datactr.GetById(id);
            if (datatodelete == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(datatodelete);
        }

        // POST: UserNotes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, UserNotes collection)
        {
            try
            {
                string uname = Session["UserName"].ToString();
                UserNotesDBSet datactr = new UserNotesDBSet(uname);
                datactr.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
