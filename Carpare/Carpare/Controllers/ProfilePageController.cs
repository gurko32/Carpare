using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carpare.Models.Entity;
using Carpare.Models.Transaction;

namespace Carpare.Controllers
{
    public class ProfilePageController : Controller
    {
        // GET: ProfilePage
        [HttpGet]
        public ActionResult ProfilePage()
        {
            User user = (User)TempData["User"];
            if (user.IsAdmin)
            {
                return RedirectToAction("AdminPage", "Admin");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUserId(Credential cr)
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdatePassword(Credential cr)
        {
            return View();

        }
        [HttpPost]
        public ActionResult UpdateEmail(Credential cr)
        {
            return View();

        }

    }
}