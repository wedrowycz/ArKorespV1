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
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Strona domowa";
            //initialize collections
            return View();
        }
    }
}
