using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ArKorespV1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
                var userdata = user.IsValid(user.UserName, user.Password);
                if (userdata != null)
                {
                    FormsAuthentication.SetAuthCookie(userName: user.UserName, createPersistentCookie: true);
                    Session["UserName"] = user.UserName;
                    Session["UserId"] = userdata.ID;
                    Session["Role"] = userdata.UserRole.ToString();
                    ATLOGDBSet atlog = new ATLOGDBSet();
                    ATLOG logininfo = new ATLOG();
                    logininfo.UserId = userdata.ID;
                    logininfo.LoginDateTime = DateTime.Now.ToLongDateString();
                    logininfo.LoginUrl = Request.Headers.GetValues("Origin").FirstOrDefault();
                    atlog.Insert(logininfo);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("password", "Nazwa użytkownika lub hasło są niepoprawne");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login", "User");
        }
    }
}