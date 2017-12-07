using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carpare.Models.Entity;

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
        

    Car lassie = new Car
        {
            Brand,
            Owner = "Timmie",
            Sex = "F",
            Species = "Dog",
            Birthdate = new DateTime(1998, 04, 30)
        };
        Cars.Add(lassie);
    }

    /*
     * Add a pet to the database.
     */
    public bool addPet(Car car)
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