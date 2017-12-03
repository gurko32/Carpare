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
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }

        public User()
        {
            UserId = "";
            Name = "";
            Salt = "";
            PasswordHash = "";
            IsAdmin = false;
        }
    }
}