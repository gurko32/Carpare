using System.Web;
using Carpare.Models.Entity;
using Carpare.Models.Persistance;

namespace Carpare.Models.Transaction
{
    public class UserManager
    {
        public static bool AuthenticateUser(Credential cr, HttpSessionStateBase baseState)
        {
            baseState["LoggedIn"] = false;
            baseState["IsAdmin"] = false;

            User user = UserPersistence.GetUser(cr.UserId);
            if (user == null)
            {
                return false;
            }
            string passwordHash = EncryptionManager.EncodePassword(cr.Password, user.Salt);

            if (passwordHash != user.PasswordHash)
            {
                return false;
            }
            else
            {
                baseState["LoggedIn"] = true;
                baseState["IsAdmin"] = user.IsAdmin;
                return true;
            }
        }

        public static void LogoutUser(HttpSessionStateBase baseState)
        {
            baseState["LoggedIn"] = false;
            baseState["IsAdmin"] = false;
        }
        public static bool SignUpUser(Credential cr, HttpSessionStateBase baseState)
        {
            baseState["LoggedIn"] = false;
            baseState["IsAdmin"] = false;


            return UserPersistence.AddUser(cr);

        }
    }
}