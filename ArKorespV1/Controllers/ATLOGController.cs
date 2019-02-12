using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArKorespV1.Controllers
{
    /// <summary>
    /// users logins controller
    /// </summary>
    public class ATLOGController : Controller
    {
        /// <summary>
        /// generates data for view - users logins
        /// </summary>
        /// <param name="id">user id filter</param>
        /// <returns>data for view</returns>
        // GET: ATLOG
        public ActionResult Index(string id)
        {
            ATLOGDBSet lista = new ATLOGDBSet();
            if (lista.Get(" item.UserId == '" + id.Replace("_","/") +"'" ))
            {
                //eventually order by
            }

            ATUZYTKDBSet uzytk = new ATUZYTKDBSet();
            var username = uzytk.GetById(id).UserName;

            ViewBag.UserName = username;
            return View(lista);
        }
    }
}