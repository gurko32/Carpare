using Carpare.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SqliteDemo.Models.Transaction
{
    public class CarManager
    {

        public static Car[] GetAllCars()
        {
            List<Car> books = CarPersistence.GetAllCars();
            if (books != null)
            {
                return CarPersistence.GetAllCars().ToArray();
            }
            else
            {
                return (new Car[0]);
            }
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
        public static bool ChangeCar(Car car)
        {
            if (car == null)
            {
                return false;
            }
            bool result = CarPersistence.UpdateCar(car);


            return result;
        }
    }
}