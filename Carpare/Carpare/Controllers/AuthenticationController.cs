using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carpare.Models.Entity;
using Carpare.Models.Transaction;
using Carpare.Models.Persistance;

namespace Carpare.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new Credential());
        }
        [HttpPost]
        public ActionResult Login(Credential credential)
        {
            if (credential == null)
                return View(new Credential());
            if (credential.Password == null || credential.UserId == null)
            {
                string err = "Both User ID and Password are required. Please try again.";
                TempData["message"] = err;
                return View(credential);
            }

            if (credential.Password.Length == 0 || credential.UserId.Length == 0)
            {
                string err = "Both User ID and Password are required. Please try again.";
                TempData["message"] = err;
                return View(credential);
            }

            bool result = UserManager.AuthenticateUser(credential, Session);
            if (result)
            {


                User user = UserPersistence.GetUser(credential.UserId);
                TempData["message"] = "";
                Session["UserId"] = user.UserId;
                Session["LoggedIn"] = true;
                if (user.IsAdmin)
                    return RedirectToAction("AdminPage", "Admin");
                else
                    return RedirectToAction("ProfilePage", "ProfilePage");
            }
            else
            {
                TempData["message"] = "Invalid login credentials";
                return View(credential);
            }

        }
        public ActionResult Logout()
        {
            UserManager.LogoutUser(Session);
            TempData["message"] = "";
            Session["UserId"] = "";
            return RedirectToAction("Index", "Home");
        }
    }
}