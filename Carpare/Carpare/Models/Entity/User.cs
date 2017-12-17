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

        public User()
        {
            UserId = "";
            Name = "";
            Salt = "";
            PasswordHash = "";
            email = "";
            IsAdmin = false;
        }
        public User(string UserId,string Name,string email)
        {
            this.UserId = UserId;
            this.Name = Name;
            Salt = EncryptionManager.PasswordSalt;           
            this.email = email;
        }
        public User(string UserId, string Name,string Salt, string email)
        {
            this.UserId = UserId;
            this.Name = Name;
            this.Salt = Salt;           
            this.email = email;
        }
        public User(string UserId, string Name, string Salt, string HashedPassword,  string email,bool IsAdmin)
        {
            this.UserId = UserId;
            this.Name = Name;
            this.Salt = Salt;
            this.PasswordHash = HashedPassword;
            this.email = email;
            this.IsAdmin = IsAdmin;
        }
        public static string CreateSalt()
        {
            return EncryptionManager.PasswordSalt;
        }
        public string toString()
        {
            string returnString = "Username: " + UserId + " Name: " + Name + " E-mail: " + email + " IsAdmin: " + IsAdmin;
            return returnString;
        }
    }
}