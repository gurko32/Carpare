using System.Web;
using Carpare.Models.Entity;
using Carpare.Models.Persistance;

namespace Carpare.Models.Transaction
{
    /// <summary>
    /// Handles the transactions about users.
    /// </summary>
    public class UserManager
    {
        /// <summary>
        /// Authenticates the user if the credentials are true and verified.
        /// </summary>
        /// <param name="cr"></param>
        /// <param name="baseState"></param>
        /// <returns>Boolean value whether the entered credentials are valid or not.</returns>
        public static bool AuthenticateUser(Credential cr, HttpSessionStateBase baseState)
        {
            baseState["LoggedIn"] = false;
            baseState["IsAdmin"] = false;

            User user = UserPersistence.GetUser(cr.UserId);
            if (user == null) // If user is not found, that means there is no user with that UserId.
            {
                return false;
            }
            string passwordHash = EncryptionManager.EncodePassword(cr.Password, user.Salt);

            if (passwordHash != user.PasswordHash) // Check the hashed password with the database hashed password. 
            {
                return false;                      // If they are not matched , that means user entered a wrong password.
            }
            else
            {
                baseState["LoggedIn"] = true;
                baseState["IsAdmin"] = user.IsAdmin;
                return true;
            }
        }
        /// <summary>
        /// Logs out the user from the system.
        /// </summary>
        /// <param name="baseState"></param>
        public static void LogoutUser(HttpSessionStateBase baseState)
        {
            baseState["LoggedIn"] = false;
            baseState["IsAdmin"] = false;
        }
        /// <summary>
        /// Adds the new user into the database.
        /// </summary>
        /// <param name="cr">Credentials for the new user.</param>
        /// <param name="baseState"></param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        public static bool SignUpUser(Credential cr, HttpSessionStateBase baseState)
        {
            baseState["LoggedIn"] = false;
            baseState["IsAdmin"] = false;


            return UserPersistence.AddUser(cr);

        }
    }
}