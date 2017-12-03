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

        public Credential()
        {
            UserId = "";
            Password = "";
        }
    }
}