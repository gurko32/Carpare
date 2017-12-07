using Carpare.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carpare.Models.Persistence
{
    /* This is the working respository. */

    public class CarRepository
    {

        /* This is the working respository. */
        private List<Car> Cars = new List<Car>();

        /*
         * Initialize the repository with a default pet.
         */
        /*
         * Initialize the repository with a default pet.
         */
        public CarRepository()
        {
            Car newCar = new Car("Ford", "Mustang", "Çağlar Güler", 1965);

        }

        /*
         * Add a pet to the database.
         */
        public bool addCar(Car car)
        {
            Cars.Add(car);
            return true;
        }

        /* 
         * Delete a pet from the database
         */
        public bool deleteCar(Car car)
        {
            return Cars.Remove(car);
        }

        /*
         * Return an array containing all pets.
         */
        public Car[] allCars()
        {
            return Cars.ToArray();
        }
    }
}