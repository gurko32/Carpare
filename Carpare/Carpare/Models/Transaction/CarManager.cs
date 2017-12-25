using Carpare.Models.Entity;
using Carpare.Models.Repository;
using System.Collections.Generic;

namespace SqliteDemo.Models.Transaction
{
    /// <summary>
    /// Handles the transactions about cars.
    /// </summary>
    public class CarManager
    {
        /// <summary>
        /// Returns all the cars in the database.
        /// </summary>
        /// <returns>All cars that are in the database.</returns>
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
        /// <summary>
        /// Return the car that is desired.
        /// </summary>
        /// <param name="carId">The car ID which we will return the car.</param>
        /// <returns>Car that is desired by user.</returns>
        public static Car GetCar(int carId)
        {
            Car car = CarPersistence.GetCar(carId);
            return car;
        }
        /// <summary>
        /// Returns the cars that are in the favourite list on the user.
        /// </summary>
        /// <param name="userId">User that we will look for his/her favourite cars.</param>
        /// <returns>Cars that are added to favourite by the user.</returns>
        public static Car[] GetFavouriteCars(string userId)
        {
            Car[] cars = CarPersistence.GetFavCars(userId);
            return cars;
        }
        /// <summary>
        /// Returns the user's cars.
        /// </summary>
        /// <param name="UserId">ID that we will use to find it in the database.</param>
        /// <returns>All cars that belongs to the user.</returns>
        public static Car[] GetUserCars(string UserId)
        {
            Car[] cars = CarPersistence.GetUserCar(UserId);

            return cars;
        }

        /// <summary>
        /// Adds the car into the database. 
        /// </summary>
        /// <param name="newCar">Car that wanted to be added.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        public static bool AddNewCar(Car newCar)
        {
            return CarPersistence.AddCar(newCar);
        }

        /// <summary>
        /// Deletes the car from the database.
        /// </summary>
        /// <param name="carId">The car which is wanted to delete from database.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        public static bool DeleteCar(string carId)
        {

            bool result = CarPersistence.DeleteCar(carId);

            return result;
        }


        /// <summary>
        /// Updates the desired car value with the new one.
        /// </summary>
        /// <param name="value">New value which is wanted to change.</param>
        /// <param name="carId">Car that is wanted to update.</param>
        /// <param name="option">The value (Ranged from 1 to 11) to determine which field will be changed.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        public static bool ChangeCar(string value, string carId, int option)
        {
            bool result = CarPersistence.UpdateCar(value, option, carId);
            return result;
        }
        /// <summary>
        /// Makes a search in the car database with the keyword that is entered by the user.
        /// </summary>
        /// <param name="value">Value that user entered to search.</param>
        /// <param name="userId">User that makes the search.</param>
        /// <param name="option">The value (Ranged from 1 to 10) to determine which field will be searched.</param>
        /// <returns>Cars that matches to the query.</returns>
        public static Car[] SearchCar(string value, string userId, int option)
        {
            Car[] cars = CarPersistence.SearchCar(value, userId, option);
            return cars;
        }
        /// <summary>
        /// Adds the desired car into the favourites list.
        /// </summary>
        /// <param name="carId">Car that wanted to add to favourites.</param>
        /// <param name="userId">User that we will add user's car into favourites table.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        internal static bool AddToFavourites(string carId, string userId)
        {
            bool result = CarPersistence.CheckFavCar(carId, userId); // Check if the car is already in the favourites list.
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