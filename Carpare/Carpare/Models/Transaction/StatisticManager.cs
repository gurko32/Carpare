using Carpare.Models.Entity;
using Carpare.Models.Persistance;
using Carpare.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carpare.Models.Transaction
{
    public class StatisticManager
    {
        public static int [] GetStatistics()
        {
            int[] stats = new int[5];
            for(int i = 0; i < 5; i++)
            {
                stats[i] = 0;
            }
            User[] users = UserPersistence.GetAllUsers();
            List<Car> cars = CarPersistence.GetAllCars();
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].status == "A")
                {
                    stats[1]++;
                }
                else
                {
                    stats[2]++;
                }
                stats[0]++;
            }
            for(int i = 0; i < cars.Count; i++)
            {
                stats[3]++;
            }
            return stats;
        }
    }
}