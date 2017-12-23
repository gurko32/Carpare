using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carpare.Models.Entity;
using Carpare.Models.Transaction;
using Carpare.Models.Persistance;
using System.Diagnostics;

namespace Carpare.Controllers
{
    public class ProfilePageController : Controller
    {
        // GET: ProfilePage
        [HttpGet]
        public ActionResult ProfilePage()
        {
            User user = UserPersistence.GetUser(Session["UserId"].ToString());

            if (user.IsAdmin)
            {
                return RedirectToAction("AdminPage", "Admin");
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUserId(string name)
        {
            bool result = UserPersistence.UpdateUser(name, (string)Session["UserId"], 1);
            if (result)
                ViewBag.message = "Name successfully changed.";
            else
                ViewBag.message = "Name cannot be changed. Try again.";
            User user = UserPersistence.GetUser((string)Session["UserId"]);
            if (user.IsAdmin)
            {
                return RedirectToAction("AdminPage", "Admin");
            }
            return View("ProfilePage", user);
        }
        [HttpPost]
        public ActionResult UpdatePassword(string Password)
        {
            bool result = UserPersistence.UpdateUser(Password, (string)Session["UserId"], 2);

            if (result)
                ViewBag.message = "Password successfully changed.";
            else
                ViewBag.message = "Password cannot be changed. Try Again.";

            User user = UserPersistence.GetUser((string)Session["UserId"]);
            if (user.IsAdmin)
            {
                return RedirectToAction("AdminPage", "Admin");
            }
            return View("ProfilePage", user);

        }
        [HttpPost]
        public ActionResult UpdateEmail(string Email)
        {
            bool result = UserPersistence.UpdateUser(Email, (string)Session["UserId"], 3);

            if (result)
                ViewBag.message = "E-Mail successfully changed.";
            else
                ViewBag.message = "E-Mail cannot be changed. Try Again.";

            User user = UserPersistence.GetUser((string)Session["UserId"]);
            if (user.IsAdmin)
            {
                return RedirectToAction("AdminPage", "Admin");
            }
            return View("ProfilePage", user);

        }
        [HttpPost]
        public ActionResult UpdateGender(string Gender)
        {
            bool result = UserPersistence.UpdateUser(Gender, (string)Session["UserId"], 4);

            if (result)
                ViewBag.message = "Gender successfully changed.";
            else
                ViewBag.message = "Gender cannot be changed. Try Again.";

            User user = UserPersistence.GetUser((string)Session["UserId"]);
            if (user.IsAdmin)
            {
                return RedirectToAction("AdminPage", "Admin");
            }
            return View("ProfilePage", user);

        }
        [HttpPost]
        public ActionResult UpdateBirthDate(string BirthDate)
        {
            bool result = UserPersistence.UpdateUser(BirthDate, (string)Session["UserId"], 5);

            if (result)
                ViewBag.message = "Birth Date successfully changed.";
            else
                ViewBag.message = "Birth Date cannot be changed. Try Again.";

            User user = UserPersistence.GetUser((string)Session["UserId"]);
            if (user.IsAdmin)
            {
                return RedirectToAction("AdminPage", "Admin");
            }
            return View("ProfilePage", user);

        }
        [HttpPost]
        public ActionResult UpdateLocation(string Location)
        {
            bool result = UserPersistence.UpdateUser(Location, (string)Session["UserId"], 6);

            if (result)
                ViewBag.message = "Location successfully changed.";
            else
                ViewBag.message = "Location cannot be changed. Try Again.";

            User user = UserPersistence.GetUser((string)Session["UserId"]);
            if (user.IsAdmin)
            {
                return RedirectToAction("AdminPage", "Admin");
            }
            return View("ProfilePage", user);

        }
    }
}