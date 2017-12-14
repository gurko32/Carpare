using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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