using System;
using System.Collections.Generic;
using Carpare.Models.Entity;
using Carpare.Models.Transaction;
using Carpare.Models.Repository;
using System.Diagnostics;

namespace Carpare.Models.Persistance
{
    /// <summary>
    /// Handles the database queries and commands for the user transactions.
    /// </summary>
    public class UserPersistence
    {
        /// <summary>
        /// Adds user over credential to the database.
        /// </summary>
        /// <param name="cr">New user's information is kept in credential object.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        public static bool AddUser(Credential cr)
        {
            string salt = User.CreateSalt();
            string hashedPassword = EncryptionManager.EncodePassword(cr.Password, salt);
            string sql = "insert into user (UserId, Name,Salt, HashedPassword,Email,IsAdmin,Status,Gender,BirthDate,Location) values ('"
               + cr.UserId + "', '"
               + cr.Name + "', '"
               + salt + "', '"
               + hashedPassword + "', '"
               + cr.Email + "',"
               + "0" + ", '"
               + "A" + "','"
               + cr.gender + "', '"
               + cr.BirthDate + "', '"
               + cr.Location + "'); ";
            RepositoryManager.Repository.DoCommand(sql);
            PrintAllUsers();
            return true;
        }
        
        /// <summary>
        /// Returns user with userId from database.
        /// </summary>
        /// <param name="userId">User that is looking for.</param>
        /// <returns>An User object which contains the desired user.</returns>
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
            User user = new User((string)dataRow[0], (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], (string)dataRow[4], (bool)dataRow[5], (string)dataRow[6], (string)dataRow[7], (string)dataRow[8], (string)dataRow[9]);
            return user;
        }

        /// <summary>
        /// Updates user information over options and userId and alters the database.
        /// </summary>
        /// <param name="update">New value which is wanted to change.</param>
        /// <param name="userId">User that wants to make the change.</param>
        /// <param name="option">The value (Ranged from 1 to 6) to determine which field will be changed.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        public static bool UpdateUser(string update, string userId, int option)
        {
            string sql = "";
            int result = 0;
            if (option == 1)
            {
                sql = "update user set Name ='" + update + "' where UserId = '" + userId + "';";
                result = RepositoryManager.Repository.DoCommand(sql);
            }

            else if (option == 2)
            {
                sql = "select Salt from user where UserId='" + userId + "';";
                List<object[]> rows = RepositoryManager.Repository.DoQuery(sql);
                if (rows.Count == 0)
                {
                    return false;
                }
                string salt = (string)rows[0][0];
                string hashedPassword = EncryptionManager.EncodePassword(update, salt);
                sql = "update user set HashedPassword='" + hashedPassword + "' where UserId = '" + userId + "';";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 3)
            {
                sql = "update user set Email='" + update + "' where UserId = '" + userId + "';";
                result = RepositoryManager.Repository.DoCommand(sql);
            }

            else if (option == 4)
            {
                sql = "update user set Gender='" + update + "' where UserId = '" + userId + "';";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 5)
            {
                sql = "update user set BirthDate='" + update + "' where UserId = '" + userId + "';";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 6)
            {
                sql = "update user set Location='" + update + "' where UserId = '" + userId + "';";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            if (result == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns all users from the database.
        /// </summary>
        /// <returns>Array of users which contains all users in the database.</returns>
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
                User user = new User((string)a[0], (string)a[1], (string)a[2], (string)a[3], (string)a[4], (bool)a[5], (string)a[6], (string)a[7], (string)a[8], (string)a[9]);
                users[i] = user;
                i++;
            }
            return users;
        }

        /// <summary>
        /// Changes the status of User by updating the database table.
        /// </summary>
        /// <param name="userId">The user which will be active or inactive.</param>
        /// <param name="stat">New value which is wanted to change.("A" or "I")</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
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

        /// <summary>
        /// Resets the password,creates a string with the length of 8, encodes the new password and writes back into database.
        /// </summary>
        /// <param name="userId">User that password will be resetted.</param>
        /// <returns>string value which contains the new password.</returns>
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

        /// <summary>
        /// Returns a random string to use on ResetPassword method.
        /// </summary>
        /// <param name="length">Length of the password.</param>
        /// <returns>The string which contains a random password.</returns>
        public static string CreateRandomString(int length)
        {
            Random randomGenerator = new Random();
            string result = "";
            string characters = "ABCDEFGHIJKLMNOPRSTUVWXYZabcdefghijklmnoprstuwxyz0123456789.,!?";
            for (int i = 0; i < length; i++)
            {
                result += characters[randomGenerator.Next(characters.Length)]; // Get a random character from the characters string and add it to the new password.
            }

            return result;
        }

        /// <summary>
        /// Prints all of the users in the database.
        /// </summary>
        public static void PrintAllUsers()
        {
            string sql = "select * from user";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sql);

            if (rows.Count == 0)
                return;

            foreach (object[] a in rows)
            {
                User user = new User((string)a[0], (string)a[1], (string)a[2], (string)a[3], (string)a[4], (bool)a[5], (string)a[6], (string)a[7], (string)a[8], (string)a[9]);
                Debug.WriteLine(user.toString());
            }

        }
    }
}