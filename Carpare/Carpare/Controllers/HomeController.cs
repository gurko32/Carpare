using Carpare.Models.Repository;
using System.Web.Mvc;

namespace Carpare.Controllers
{
    /// <summary>
    /// Controller for showing the home page.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns the home page view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["UserId"] == null) // Create the UserId dictionary value if not created. This will be used for further transactions.
                Session["UserId"] = "";
            bool result = RepositoryManager.Repository.Initialize();
            return View();
        }


    }
}