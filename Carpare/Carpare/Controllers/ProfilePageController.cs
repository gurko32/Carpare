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
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUserId(Credentials cr)
        {

        }
    }
}