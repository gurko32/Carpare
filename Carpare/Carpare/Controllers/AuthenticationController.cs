using System.Web.Mvc;
using Carpare.Models.Entity;
using Carpare.Models.Transaction;
using Carpare.Models.Persistance;

namespace Carpare.Controllers
{
    /// <summary>
    /// Represents the controller for Login and Logout.
    /// </summary>
    public class AuthenticationController : Controller
    {
        /// <summary>
        /// Returns the login page View.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View(new Credential());
        }
        /// <summary>
        /// Applies the login procedure with checking the parameters whether they are correct or not.
        /// </summary>
        /// <param name="credential">Username and password to check the database, then login.</param>
        /// <returns>View for proper response.</returns>
        [HttpPost]
        public ActionResult Login(Credential credential)
        {
            if (credential == null)
                return View(new Credential());

            if (credential.Password == null || credential.UserId == null)
            {
                string err = "Both User ID and Password are required. Please try again.";
                TempData["message"] = err;
                return View(credential);
            }

            if (credential.Password.Length == 0 || credential.UserId.Length == 0)
            {
                string err = "Both User ID and Password are required. Please try again.";
                TempData["message"] = err;
                return View(credential);
            }

            User user = UserPersistence.GetUser(credential.UserId); // Get the user
            if (user.status != "I") // If user is active, Authenticate the user.
            {
                bool result = UserManager.AuthenticateUser(credential, Session);
                if (result) //If username or password is matched with the database value, login the user.
                {
                    TempData["message"] = "";
                    Session["UserId"] = user.UserId;
                    Session["LoggedIn"] = true;
                    if (user.IsAdmin)
                        return RedirectToAction("AdminPage", "Admin");
                    else
                        return RedirectToAction("ProfilePage", "ProfilePage");
                }
                else
                {
                    TempData["message"] = "Invalid login credentials";
                    return View(credential);
                }
            }
            else // If user is inactive, do not login the user.
            {
                TempData["invalid"] = "Your account has been banned";
                return RedirectToAction("Index", "Home");
            }


        }
        /// <summary>
        /// Starts the logout procedure and redirects to the home page.
        /// </summary>
        /// <returns>View for home page.</returns>
        public ActionResult Logout()
        {
            UserManager.LogoutUser(Session);
            TempData["message"] = "";
            Session["UserId"] = "";
            return RedirectToAction("Index", "Home");
        }
    }
}