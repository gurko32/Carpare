using Carpare.Models.Entity;
using Carpare.Models.Transaction;
using SqliteDemo.Models.Transaction;
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


        CarManager carController = new CarManager();

        /*
         * Generate the Car listing.
         */
        public ActionResult CarLister()
        {
            Car[] cars = CarManager.GetAllCars();
            return View(cars);  // returns /Views/Car/CarLister.cshtml
        }

        /*
         * Display the Update form
         */
        [HttpGet]
        public ActionResult Update()
        {
            return View(new Car());   // returns /Views/Pet/Update.cshtml
        }

        /*
         * Handle the Update form submission
         */
        [HttpPost]
        public ActionResult Update(Car car, string submit)
        {
            bool result = false;

            // add or drop
            switch (submit)
            {
                case "Add Car":
                    result = CarManager.AddNewCar(car);
                    break;
                case "Delete Car":
                    result = CarManager.DeleteCar(car);
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

            Car[] cars = CarManager.GetAllCars();
            return View("Listing", cars);   // returns /Views/Pet/Listing.cshtml
        }
    }

}