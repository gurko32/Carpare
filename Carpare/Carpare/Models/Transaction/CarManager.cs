using Carpare.Models.Entity;
using Carpare.Models.Repository;
using System.Collections.Generic;

namespace SqliteDemo.Models.Transaction
{
    public class CarManager
    {

        public static Car[] GetAllCars()
        {
            List<Car> cars = CarPersistence.GetAllCars();
            if (cars != null)
            {
                return CarPersistence.GetAllCars().ToArray();
            }
            else
            {
                return (new Car[0]);
            }
        }
        public static Car GetUserCars(int carId)
        {
            Car[] cars = CarPersistence.GetCar(carId);
            return cars[0];
        }
        public static Car[] GetFavouriteCars(string userId)
        {
            Car[] cars = CarPersistence.GetFavCars(userId);
            return cars;
        }
        public static Car[] GetUserCars(string UserId)
        {
            Car[] cars = CarPersistence.GetUserCar(UserId);

            return cars;
        }

        /*
         * Transaction: Add a new book to the database
         * Returns true iff the new book has a unique ISBN
         * and it was successfully added.
         */
        public static bool AddNewCar(Car newCar)
        {
            // Verify that the book doesn't already exist
            return CarPersistence.AddCar(newCar);
        }

        /*
         * Transaction: Delete a book from the database
         * Returns true iff the book exists in the database and
         * it was successfully deleted.
         */
        public static bool DeleteCar(string carId)
        {

            bool result = CarPersistence.DeleteCar(carId);

            return result;
        }


        /*
         * Transaction: Update a book in the database
         * Returns true iff the book exists in the database and
         * it was successfully changed.
         */
        public static bool ChangeCar(string value, string carId, int option)
        {
            bool result = CarPersistence.UpdateCar(value, option, carId);
            return result;
        }

        public static Car[] SearchCar(string value, string userId, int option)
        {
            Car[] cars = CarPersistence.SearchCar(value, userId, option);
            return cars;
        }

        internal static bool AddToFavourites(string carId, string userId)
        {
            bool result = CarPersistence.CheckFavCar(carId, userId);
            if (result)
            {
                int res = CarPersistence.AddToFavourites(carId, userId);
                if (res == 1)
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }

        }
    }
}