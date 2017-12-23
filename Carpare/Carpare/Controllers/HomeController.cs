using Carpare.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carpare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
                Session["UserId"] = "";
            bool result = RepositoryManager.Repository.Initialize();
            return View();
        }


    }
}