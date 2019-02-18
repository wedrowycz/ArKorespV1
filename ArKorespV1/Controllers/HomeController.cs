using ArKorespV1.Models;
using ArKorespV1.Models.ZADANIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    /// <summary>
    /// home view controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// home view  index 
        /// </summary>
        /// <returns>home index view</returns>
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            ViewBag.Title = "Strona domowa";
            //initialize collections
            InitializeCollections();
            return View();
        }
        /// <summary>
        /// initialize static collections
        /// </summary>
        public void InitializeCollections()
        {
            PEREJKORESPDBSet db = new PEREJKORESPDBSet();
            PEZADANIADBSet pEZADANIA = new PEZADANIADBSet();
            PEOBDOKDBSet pEOBDOK = new PEOBDOKDBSet();
            PEPROCOBDOKDBSet pEPROCOBDOK = new PEPROCOBDOKDBSet();
            PEPROCOBDOKPOZDBSet pEPROCOBDOKPOZ = new PEPROCOBDOKPOZDBSet();
            PEPROCEDURYDBSet pEPROCEDURies = new PEPROCEDURYDBSet();
            PEKORESPZALDBSet pEKORESPZALs = new PEKORESPZALDBSet();
        }
    }
}
