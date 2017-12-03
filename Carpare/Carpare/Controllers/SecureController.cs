using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carpare.Controllers
{
    public class SecureController : Controller
    {
        // GET: Secure
        public ActionResult Index()
        {
            if (Session["IsAdmin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            bool isAdmin = (bool)Session["IsAdmin"];
            if (!isAdmin)
            {
                TempData["message"] = "Unauthorized access request";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}