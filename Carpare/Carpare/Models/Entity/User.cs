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
        public User(string UserId,string Name,string password,string email)
        {
            this.UserId = UserId;
            this.Name = Name;
            Salt = EncryptionManager.PasswordSalt;
            PasswordHash = EncryptionManager.EncodePassword(password,Salt);
            this.email = email;
        }
    }
}