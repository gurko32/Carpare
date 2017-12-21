using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carpare.Models.Entity
{
    public class Credential
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string gender { get; set; }
        public string BirthDate { get; set; }
        public string Location { get; set; }

        public Credential()
        {
            UserId = "";
            Password = "";
            Email = "";
            Name = "";
        }
    }
}