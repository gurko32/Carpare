using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carpare.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }
        /*
     * This class handles all HTTP requests related to Pets.
     */


        CarController carController = new CarController();

        /*
         * Generate the Pet listing.
         */
        public ActionResult Listing()
        {
            Car[] pets = carController.allPets();
            return View(pets);  // returns /Views/Pet/Listing.cshtml
        }

        /*
         * Display the Update form
         */
        [HttpGet]
        public ActionResult Update()
        {
            return View();   // returns /Views/Pet/Update.cshtml
        }

        /*
         * Handle the Update form submission
         */
        [HttpPost]
        public ActionResult Update(Pet pet, string submit)
        {
            bool result = false;

            // add or drop
            switch (submit)
            {
                case "Add Pet":
                    result = petManager.addPet(pet);
                    break;
                case "Delete Pet":
                    result = petManager.deletePet(pet);
                    break;
            }

            // ViewBag is a general purpose data dictionary for passing data
            // between Controller & View
            if (result)
            {
                ViewBag.message = "Transaction Completed";
            }
            else
            {
                ViewBag.message = "Transaction Failed";
            }

            Pet[] pets = petManager.allPets();
            return View("Listing", pets);   // returns /Views/Pet/Listing.cshtml
        }
    }

}