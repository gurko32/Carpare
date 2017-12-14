using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carpare.Models.Entity;
using Carpare.Models.Transaction;
using Carpare.Models.Repository;

namespace Carpare.Models.Persistance
{
    public class UserPersistence
    {
        private static List<User> users;

        static UserPersistence()
        {


        }
        /*
         * Get one user from the repository, identified by userId
         */
        public static bool AddUser(Credential cr)
        {
            string sql = "insert into user (UserId, Name, HashedPassword,Email) values ('"
               + cr.UserId + "', '"
               + cr.Name + "', '"
               + cr.Password + "', '"
               + cr.Email + "');";
            RepositoryManager.Repository.DoCommand(sql);
            return true;

        }
        public static User GetUser(string userId)
        {
            string sql = "select * from user where UserId='" + userId+"';";
            string s1=RepositoryManager.Repository.DoQuery(sql);
            return rUser;
        }

        // Not Implemented
        public static bool UpdateUser(User user)
        {
            return false;
        }
        public static bool DeleteUser(User user)
        {
            return false;
        }
        //public static List<User> GetAllUsers()
        //{
        //    return null;
        //}
    }
}