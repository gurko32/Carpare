using Carpare.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carpare.Models.Entity
{
    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Salt { get; set; }
        public string email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public string status { get; set; }
        public string gender { get; set; }
        public string BirthDate { get; set; }
        public string Location { get; set; }

        public User()
        {
            UserId = "";
            Name = "";
            Salt = "";
            PasswordHash = "";
            email = "";
            IsAdmin = false;
        }

        public User(string UserId, string Name, string Salt, string HashedPassword, string email, bool IsAdmin, string stat, string gender, string date, string loc)
        {
            this.UserId = UserId;
            this.Name = Name;
            this.Salt = Salt;
            PasswordHash = HashedPassword;
            this.email = email;
            this.IsAdmin = IsAdmin;
            status = stat;
            this.gender = gender;
            BirthDate = date;
            Location = loc;
        }
        public static string CreateSalt()
        {
            return EncryptionManager.PasswordSalt;
        }
        public string toString()
        {
            string returnString = "Username: " + UserId + " Name: " + Name + " E-mail: " + email + " IsAdmin: " + IsAdmin + " Status: " + status + " Gender: " + gender
                + " Date: " + BirthDate + " Location: " + Location;
            return returnString;
        }
    }
}