using Carpare.Models.Entity;
using Carpare.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            Car oldCar = CarPersistence.getCar(newCar);
            // oldBook should be null, if this is a new book
            if (oldCar != null)
            {
                return false;
            }

            return CarPersistence.AddCar(newCar);
        }

        /*
         * Transaction: Delete a book from the database
         * Returns true iff the book exists in the database and
         * it was successfully deleted.
         */
        public static bool DeleteCar(Car delCar)
        {
            Car car = CarPersistence.getCar(delCar);
            if (car == null)
            {
                return false;
            }
            bool result = CarPersistence.DeleteCar(delCar);

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
    }
}