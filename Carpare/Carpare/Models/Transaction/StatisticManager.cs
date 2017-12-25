using Carpare.Models.Entity;
using Carpare.Models.Persistance;
using Carpare.Models.Repository;
using System.Collections.Generic;

namespace Carpare.Models.Transaction
{
    /// <summary>
    /// Handles the transactions about statistics page in the admin page.
    /// </summary>
    public class StatisticManager
    {
        /// <summary>
        /// Calculates the statistics and puts them into the array.
        /// </summary>
        /// <returns>An integer of length 5 which contains the count of count of the number of users (total, active, and inactive), records,
        ///and comments, in this order.
        ///</returns>
        public static int[] GetStatistics()
        {
            int[] stats = new int[5];
            for (int i = 0; i < 5; i++)
            {
                stats[i] = 0;
            }
            User[] users = UserPersistence.GetAllUsers();
            List<Car> cars = CarPersistence.GetAllCars();

            for (int i = 0; i < users.Length; i++) // Counts for the users that are active, inactive and total.
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

            for (int i = 0; i < cars.Count; i++) // Counts the cars in the database.
            {
                stats[3]++;
            }

            List<Comment> comments = CommentPersistence.GetAllComments();
            for (int i = 0; i < comments.Count; i++) // Counts the comments in the system.
            {
                stats[4]++;
            }
            return stats;
        }
    }
}