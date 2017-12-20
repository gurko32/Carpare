using Carpare.Models.Persistance;
using Carpare.Models.Transaction;
using System.Web.Mvc;

namespace Carpare.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult AdminPage()
        {
            return View();
        }
        public ActionResult ListUsers()
        {
            return View(UserPersistence.GetAllUsers());
        }
        public ActionResult ShowStatistics()
        {
            return View(StatisticManager.GetStatistics());
        }
        [HttpGet]
        public ActionResult ChangeUserStatus()
        {
            return View(UserPersistence.GetAllUsers());
        }
        [HttpPost]
        public ActionResult ChangeStatus(string Status, string UserId)
        {
            bool result = UserPersistence.ChangeUserStatus(UserId, Status);
            if (result)
            {
                ViewBag.message = "Transaction Completed.";
            }
            else
            {
                ViewBag.message = "Transaction Failed. Try Again.";
            }
            return View("ChangeUserStatus", UserPersistence.GetAllUsers());

        }
        [HttpGet]
        public ActionResult ResetUserPassword()
        {
            return View(UserPersistence.GetAllUsers());
        }
        [HttpPost]
        public ActionResult ResetPassword(string UserId)
        {
            string password = UserPersistence.ResetPassword(UserId);
            if (password != null)
                ViewBag.message = UserId + "'s password has changed. New password is: " + password;
            else
            {
                ViewBag.message = "There was a problem with transaction. Please try again.";
            }
            return View("ResetUserPassword", UserPersistence.GetAllUsers());
        }
    }
}