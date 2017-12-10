using SqliteTest.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carpare.Models.Repository;
namespace Carpare.Models.Repository
{
    public class RepositoryManager
    {
        public static IRepository Repository { get; set; }

        /*
         * Create an instance of a concrete Repository and open it. 
         * The Repository should close itself on shutdown.
         */
        static RepositoryManager()
        {
            Repository = new SqliteRepository();
            Repository.Open();
        }
    }
}