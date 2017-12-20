using Carpare.Models.Entity;
using Carpare.Models.Repository;
using Carpare.Models.Transaction;
using SqliteDemo.Models.Transaction;
using System.Diagnostics;
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
        [HttpGet]
        public ActionResult MyCarLister()
        {
            string UserId = (string)Session["UserId"];
            Car [] cars = CarManager.GetUserCars(UserId);
            return View(cars);
        }
        [HttpPost]
        public ActionResult CarLister(string comment,int carId)
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
        [HttpGet]
        public ActionResult ChangeCar()
        {
            return View(CarManager.GetUserCars((string)Session["UserId"]));
        }
        [HttpPost]
        public ActionResult ChangeCar(string carId, string Url, string Brand, string Model, string YearOfProduction,string km)
        {
            bool result = false;
            if(Url != "")
            {
                result = CarManager.ChangeCar(Url, carId, 1);
            }
            if(Brand != "")
            {
                result = CarManager.ChangeCar(Brand, carId, 2);
            }
            if (Model != "")
            {
                result = CarManager.ChangeCar(Model, carId, 3);
            }
            if (YearOfProduction != "")
            {
                result = CarManager.ChangeCar(YearOfProduction, carId, 4);
            }
            if(km != "")
            {
                result = CarManager.ChangeCar(km, carId, 5);
            }
            if (result)
            {
                ViewBag.message = "Car successfully updated.";
            }
            else
                ViewBag.message = "Car couldn't be updated. Try again.";

            return View(CarManager.GetUserCars(Session["UserId"].ToString()));
        }
        public ActionResult DeleteCar()
        {
            return View();
        }
        /*
         * Handle the Update form submission
         */
        [HttpPost]
        public ActionResult Update(Car car, string submit)
        {
            bool result = false;
            car.Owner = (string)Session["UserId"];
            
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
            return View("CarLister", cars);   // returns /Views/Pet/Listing.cshtml
        }
    }

}