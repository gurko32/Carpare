using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carpare.Models.Transaction
{
    public class CarManager
    {

        static CarRepository repository = new CarRepository();

        /*
         * Get a list of all pets
         */
        public Car[] allCars()
        {
            return repository.allCars();
        }

        /*
         * Add a pet to the repository. Normally, the PetManager would
         * do some validation of the transaction, to ensure that the 
         * fields have correct data.
         */
        public bool addPet(Car car)
        {
            // validate the transaction...
            return repository.addPet(car);
        }

        /*
         * Delete a pet. Also would normally validate the transaction.
         */
        public bool deletePet(Car car)
        {
            // validate the transaction...
            return repository.deletePet(car);
        }
    }
}