using Carpare.Models.Entity;
using Carpare.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carpare.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View(new Credential());
        }
        [HttpPost]
        public ActionResult Signup(Credential credential)
        {
            if (credential == null)
                return View(new Credential());
            if (credential.Password == null || credential.UserId == null||credential.Email == null)
            {
                string err = "Both User ID and Password are required. Please try again.";
                TempData["message"] = err;
                return View(credential);
            }

            if (credential.Password.Length == 0 || credential.UserId.Length == 0||credential.Email.Length == 0)
            {
                string err = "Both User ID and Password are required. Please try again.";
                TempData["message"] = err;
                return View(credential);
            }
            bool res = UserManager.SignUpUser(credential,Session);
            if (!res)
            {
                TempData["message"] = "Invalid credentials";
                return View(credential);
            }
            bool result = UserManager.AuthenticateUser(credential, Session);
            if (result)
            {
                TempData["message"] = "Sign Up Successful";
                ViewBag.message = "Sign Up Successful";
                return RedirectToAction("Login", "Authentication");
            }
            else
            {
                TempData["message"] = "Invalid credentials";
                return View(credential);
            }

        }
    }
}