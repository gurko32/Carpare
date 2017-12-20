using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carpare.Models.Entity;
using Carpare.Models.Transaction;
using Carpare.Models.Repository;
using System.Diagnostics;

namespace Carpare.Models.Persistance
{
    public class UserPersistence
    {
        /*
         * Get one user from the repository, identified by userId
         */
        public static bool AddUser(Credential cr)
        {
            string salt = User.CreateSalt();
            string hashedPassword = EncryptionManager.EncodePassword(cr.Password, salt);
            string sql = "insert into user (UserId, Name,Salt, HashedPassword,Email,IsAdmin,Status) values ('"
               + cr.UserId + "', '"
               + cr.Name + "', '"
               + salt + "', '"
               + hashedPassword + "', '"
               + cr.Email + "',"
               + "0" + ", '"
               + "A" + "');";
            RepositoryManager.Repository.DoCommand(sql);
            PrintAllUsers();
            return true;

        }
        public static User GetUser(string userId)
        {
            string sql = "select * from user where UserId='" + userId + "';";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sql);
            if (rows.Count == 0)
            {
                return null;
            }

            // Use the data from the first returned row (should be the only one) to create a User.
            object[] dataRow = rows[0];
            User user = new User((string)dataRow[0], (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], (string)dataRow[4], (bool)dataRow[5]);
            return user;
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
        public static User[] GetAllUsers()
        {
            User[] users;
            int i = 0;
            string sql = "select * from user";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sql);
            if (rows.Count == 0)
                return null;
            users = new User[rows.Count];

            foreach (object[] a in rows)
            {
                User user = new User((string)a[0], (string)a[1], (string)a[2], (string)a[3], (string)a[4], (bool)a[5], (string)a[6]);
                users[i] = user;
                i++;
            }
            return users;
        }
        public static bool ChangeUserStatus(string userId, string stat)
        {
            int result = 0;
            string sql = "update user set Status = '" + stat + "' where UserId = '" + userId + "';";
            result = RepositoryManager.Repository.DoCommand(sql);

            if (result == 0)
            {
                return false;
            }
            else
                return true;
        }
        public static string ResetPassword(string userId)
        {
        
            int result = 0;
            string newPassword = CreateRandomString(8);
            string sql = "select Salt from user where UserId='" + userId + "';";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sql);

            if (rows.Count == 0)
                return null;

            string salt = (string)rows[0][0];
            string newHashedPassword = EncryptionManager.EncodePassword(newPassword, salt);

            sql = "update user set HashedPassword = '" + newHashedPassword + "' where UserId = '" + userId + "';";
            result = RepositoryManager.Repository.DoCommand(sql);
            if (result == 1)
            {
                return newPassword;
            }
            else
            {
                return null;
            }

        }
        public static string CreateRandomString(int length)
        {
            Random randomGenerator = new Random();
            string result = "";
            string characters = "ABCDEFGHIJKLMNOPRSTUVWXYZabcdefghijklmnoprstuwxyz0123456789.,!?";
            for (int i = 0; i < length; i++)
            {
                result += characters[randomGenerator.Next(characters.Length)];
            }

            return result;
        }
        public static void PrintAllUsers()
        {
            string sql = "select * from user";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sql);
            if (rows.Count == 0)
                return;
            foreach (object[] a in rows)
            {
                User user = new User((string)a[0], (string)a[1], (string)a[2], (string)a[3], (string)a[4], (bool)a[5]);
                Debug.WriteLine(user.toString());
            }

        }
    }
}