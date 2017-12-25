using Carpare.Models.Entity;
using Carpare.Models.Transaction;
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Carpare.Controllers
{
    /// <summary>
    /// Represents the controller for sign up operations.
    /// </summary>
    public class SignupController : Controller
    {
        /// <summary>
        /// Returns the sign up page View.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Signup()
        {
            return View(new Credential());
        }
        /// <summary>
        /// Checks the credentials which is entered by the user. If they are all valid, enters a new entry into database as a new user.
        /// </summary>
        /// <param name="credential">Credentials that user entered.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Signup(Credential credential)
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

            string validUserId = @"^[a-z][a-z0-9]{8,12}$";
            string validPassword = @"^[a-z0-9!@#$*]{4,12}$";
            string validLocation = @"^[A-Za-z]*$";

            
            if (credential.BirthDate == null)
            {
                ViewBag.message = "Please enter a valid birth date.";
                return View(credential);
            }

            if (credential.Location == null)
            {
                ViewBag.message = "Please enter a valid location.";
                return View(credential);
            }

            if (credential.Name == null)
            {
                ViewBag.message = "Please enter a name.";
                return View(credential);
            }
            else if (credential.Name.Length < 2 || credential.Name.Length > 50)
            {
                ViewBag.message = "Your name is too short or too long.Your name can be at length 2 to 50 characters.";
                return View(credential);
            }

            if (credential.Email == null)
            {
                ViewBag.message = "Please enter an E-Mail.";
                return View(credential);
            }
            else if (credential.Email.Length < 5 || credential.Email.Length > 50)
            {
                ViewBag.message = "Your E-Mail is too short or too long.Your E-Mail can be at length 5 to 50 characters.";
                return View(credential);
            }

            try
            {
                MailAddress m = new MailAddress(credential.Email); // This method checks if the E-Mail format is valid.
            }
            catch (FormatException)
            {
                ViewBag.message = "Invalid E-Mail format. Please enter a valid E-Mail";
                return View(credential);
            }
            Match match = Regex.Match(credential.UserId, validUserId);
            if (match.Success)
            {
                Match match2 = Regex.Match(credential.Password, validPassword);
                if (match2.Success)
                {
                    Match match3 = Regex.Match(credential.Location, validLocation);
                    if (match3.Success)
                    {
                        credential.Name = credential.Name.Replace("'", "&apos;"); // Replace the "'" character with the escape character in case of attacks.
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