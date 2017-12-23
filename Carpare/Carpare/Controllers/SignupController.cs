using Carpare.Models.Entity;
using Carpare.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
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

            /*
            bool res = UserManager.SignUpUser(credential,Session);
            if (!res)
            {
                TempData["message"] = "Invalid credentials";
                return View(credential);
            }
            else
            {
                TempData["message"] = "Sign Up Successful";
                ViewBag.message = "Sign Up Successful";
                return RedirectToAction("Login", "Authentication");
            }
            */


            //these are for checking the validity of inputs

            string validUserId = @"^[a-z][a-z0-9]*$";
            string validPassword = @"^[a-z0-9!@#$*]{4,12}$";
            string validLocation = @"^[A-Za-z]*$";

            Match match = Regex.Match(credential.UserId, validUserId);

            try
            {
                MailAddress m = new MailAddress(credential.Email);
            }
            catch (FormatException)
            {
                ViewBag.message = "Invalid E-Mail format. Please enter a valid E-Mail";
                return View(credential);
            }
            if (match.Success)
            {
                Match match2 = Regex.Match(credential.Password, validPassword);
                if (match2.Success)
                {
                    Match match3 = Regex.Match(credential.Location, validLocation);
                    if (match3.Success)
                    {
                        credential.Name = credential.Name.Replace("'", "&apos;");
                        credential.Email = credential.Email.Replace("'", "&apos;");
                        credential.Location = credential.Location.Replace("'", "&apos;");
                        UserManager.SignUpUser(credential, Session);
                        TempData["message"] = "Sign Up Successful";
                        ViewBag.message = "Sign Up Successful";
                        return RedirectToAction("Login", "Authentication");
                    }
                    ViewBag.message = "Invalid Location";
                    TempData["message"] = "Invalid Location";
                    return View(credential);
                }
                ViewBag.message = "Invalid Password";
                TempData["message"] = "Invalid Password";
                return View(credential);
            }
            ViewBag.message = "Invalid UserId";
            TempData["message"] = "Invalid UserId";
            return View(credential);
        }
    }
}