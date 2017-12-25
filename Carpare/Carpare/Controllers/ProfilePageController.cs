using System.Web.Mvc;
using Carpare.Models.Entity;
using Carpare.Models.Persistance;

namespace Carpare.Controllers
{
    /// <summary>
    /// Represents the controller for the profile page operations.
    /// </summary>
    public class ProfilePageController : Controller
    {
        /// <summary>
        /// Returns the profile page View where user can modify their profile informations.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProfilePage()
        {
            User user = UserPersistence.GetUser(Session["UserId"].ToString());

            if (user != null && user.IsAdmin)
            {
                return RedirectToAction("AdminPage", "Admin");
            }

            return View(user);
        }
        /// <summary>
        /// Updates the name with the new name.
        /// </summary>
        /// <param name="name">New name that wanted to be changed.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateName(string name)
        {
            bool result = UserPersistence.UpdateUser(name.Replace("'", "&apos;"), (string)Session["UserId"], 1);
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

        /// <summary>
        /// Changes the password which is entered by the user.
        /// </summary>
        /// <param name="Password">New password that user wants to change.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdatePassword(string Password)
        {
            bool result = UserPersistence.UpdateUser(Password.Replace("'", "&apos;"), (string)Session["UserId"], 2);

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
        /// <summary>
        /// Change the E-Mail which is entered by the user.
        /// </summary>
        /// <param name="Email">New E-Mail that user wants to change.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateEmail(string Email)
        {
            bool result = UserPersistence.UpdateUser(Email.Replace("'", "&apos;"), (string)Session["UserId"], 3);

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
        /// <summary>
        /// Change the gender which is entered by the user.
        /// </summary>
        /// <param name="Gender">New gender that user wants to change.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateGender(string Gender)
        {
            bool result = UserPersistence.UpdateUser(Gender.Replace("'", "&apos;"), (string)Session["UserId"], 4);

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
        /// <summary>
        /// Change the birth date which is entered by the user.
        /// </summary>
        /// <param name="BirthDate">New birth date that user wants to change.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateBirthDate(string BirthDate)
        {
            bool result = UserPersistence.UpdateUser(BirthDate.Replace("'", "&apos;"), (string)Session["UserId"], 5);

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
        /// <summary>
        /// Change the location which is entered by the user.
        /// </summary>
        /// <param name="Location">New location that user wants to change.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateLocation(string Location)
        {
            bool result = UserPersistence.UpdateUser(Location.Replace("'", "&apos;"), (string)Session["UserId"], 6);

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