using Carpare.Models.Persistance;
using Carpare.Models.Transaction;
using System.Web.Mvc;

namespace Carpare.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// Opens the default admin page.
        /// </summary>
        /// <returns>View that opens Admin Page.</returns>
        [HttpGet]
        public ActionResult AdminPage()
        {
            return View();
        }
        /// <summary>
        /// Lists all users that are registered to the website.
        /// </summary>
        /// <returns>View that contains all users.</returns>
        public ActionResult ListUsers()
        {
            return View(UserPersistence.GetAllUsers());
        }
        /// <summary>
        /// Shows statistics for the website. Contains:
        /// Count of the number of users (total, active, and inactive), records and comments.
        /// </summary>
        /// <returns>View that contains all statistics.</returns>
        public ActionResult ShowStatistics()
        {
            return View(StatisticManager.GetStatistics());
        }
        /// <summary>
        /// Opens the view for changing user status.
        /// </summary>
        /// <returns>View that contains change status view.</returns>
        [HttpGet]
        public ActionResult ChangeUserStatus()
        {
            return View(UserPersistence.GetAllUsers());
        }
        /// <summary>
        /// Changes the status for a user either active or inactive.
        /// </summary>
        /// <param name="Status">Status parameter that we want to change.</param>
        /// <param name="UserId">User that we want to change his/her status.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangeStatus(string Status, string UserId)
        {
            bool result = UserPersistence.ChangeUserStatus(UserId.Replace("'", "&apos;"), Status.Replace("'", "&apos;"));
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
        /// <summary>
        /// Returns the view that we can reset user's passwords.
        /// </summary>
        /// <returns>View for reset password page.</returns>
        [HttpGet]
        public ActionResult ResetUserPassword()
        {
            return View(UserPersistence.GetAllUsers());
        }
        /// <summary>
        /// Resets the password for the selected user and prints the new password to the screen.
        /// </summary>
        /// <param name="UserId">User that we want to reset his/her password.</param>
        /// <returns>View that shows the new password.</returns>
        [HttpPost]
        public ActionResult ResetPassword(string UserId)
        {
            string password = UserPersistence.ResetPassword(UserId.Replace("'", "&apos;"));
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