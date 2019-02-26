using ArKorespV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ArKorespV1.Controllers
{
    /// <summary>
    /// controller for user operations such as login/logout
    /// </summary>
    public class UserController : Controller
    {
        
        /// <summary>
        /// standard action to display login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Action called to check login
        /// </summary>
        /// <param name="user">form data</param>
        /// <returns> redirects to main application form</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
                var userdata = user.IsValid2(user.UserName, user.Password);
                if (userdata != null)
                {
                    if (userdata.Status != 0)
                    {
                        ModelState.AddModelError("password", "Uzytkownik został zablokowany");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(userName: user.UserName, createPersistentCookie: true);
                        Session["UserName"] = user.UserName;
                        Session["UserId"] = userdata.ID;
                        Session["Role"] = userdata.UserRole.ToString();
                        ATLOGDBSet atlog = new ATLOGDBSet();
                        ATLOG logininfo = new ATLOG
                        {
                            UserId = userdata.ID,
                            LoginDateTime = DateTime.Now.ToString(),
                            LoginUrl = Request.UserHostAddress
                        };
                        atlog.Insert(logininfo);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("password", "Nazwa użytkownika lub hasło są niepoprawne");
                }
            }
            return View(user);
        }
        /// <summary>
        /// standard action for logout
        /// </summary>
        /// <returns>redirects to login screen</returns>
        public ActionResult Logout()
        {            
            Session.Remove("UserName");
            Session.Remove("UserId");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}