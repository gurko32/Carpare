using Carpare.Models.Entity;
using Carpare.Models.Repository;
using SqliteDemo.Models.Transaction;
using System;
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
            Car[] cars = CarManager.GetUserCars(UserId);
            return View(cars);
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
        public ActionResult ChangeCar(string carId, string Url, string Brand, string Model, string YearOfProduction, string km, string TransmissionType, string TopSpeed, string Acceleration, string UrbanConsumption, string Fuel, string WheelDrive)
        {
            bool result = false;
            if (Url != "")
            {
                result = CarManager.ChangeCar(Url, carId, 1);
            }
            if (Brand != "")
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
            if (km != "")
            {
                result = CarManager.ChangeCar(km, carId, 5);
            }
            if (TransmissionType != "")
            {
                result = CarManager.ChangeCar(TransmissionType, carId, 6);
            }
            if (Fuel != "")
            {
                result = CarManager.ChangeCar(Fuel, carId, 7);
            }
            if (TopSpeed != "")
            {
                result = CarManager.ChangeCar(TopSpeed, carId, 8);
            }
            if (Acceleration != "")
            {
                result = CarManager.ChangeCar(Acceleration, carId, 9);
            }
            if (UrbanConsumption != "")
            {
                result = CarManager.ChangeCar(UrbanConsumption, carId, 10);
            }
            if (WheelDrive != "")
            {
                result = CarManager.ChangeCar(WheelDrive, carId, 11);
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
            return View(CarPersistence.GetUserCar(Session["UserId"].ToString()));
        }
        [HttpPost]
        public ActionResult DeleteCar(string carId)
        {
            bool result = CarManager.DeleteCar(carId);
            if (result)
                ViewBag.message = "Car successfully deleted.";
            else
                ViewBag.message = "Car could not be deleted.";

            return View(CarPersistence.GetUserCar(Session["UserId"].ToString()));
        }
        [HttpGet]
        public ActionResult SearchCar()
        {
            return View();
        }
        public ActionResult FoundCars(string Brand, string Model, string YearOfProduction, string km, string TransmissionType, string Fuel, string WheelDrive)
        {
            Car[] cars = new Car[0];
            if (Brand != null)
            {
                cars = CarManager.SearchCar(Brand.Replace("'", "&apos;"), Session["UserId"].ToString(), 1);
            }
            else if (Model != null)
            {
                cars = CarManager.SearchCar(Model.Replace("'", "&apos;"), Session["UserId"].ToString(), 2);
            }
            else if (YearOfProduction != null)
            {
                cars = CarManager.SearchCar(YearOfProduction.Replace("'", "&apos;"), Session["UserId"].ToString(), 3);
            }
            else if (km != null)
            {
                cars = CarManager.SearchCar(km.Replace("'", "&apos;"), Session["UserId"].ToString(), 4);
            }
            else if (TransmissionType != null)
            {
                cars = CarManager.SearchCar(TransmissionType.Replace("'", "&apos;"), Session["UserId"].ToString(), 5);
            }
            else if (Fuel != null)
            {
                cars = CarManager.SearchCar(Fuel.Replace("'", "&apos;"), Session["UserId"].ToString(), 6);
            }
            else if (WheelDrive != null)
            {
                cars = CarManager.SearchCar(WheelDrive.Replace("'", "&apos;"), Session["UserId"].ToString(), 10);
            }
            if (cars.Length == 0)
            {
                ViewBag.message = "No car has been found. Please try with another keyword.";
                return View("SearchCar");
            }

            return View(cars);
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

        public ActionResult FavouriteCars()
        {
            return View(CarManager.GetFavouriteCars((string)Session["UserId"]));
        }
        public ActionResult AddToFavourites(string carId)
        {
            bool result = CarManager.AddToFavourites(carId, (string)Session["UserId"]);
            if (result)
            {
                TempData["message"] = "Car successfully added to your favourites.";
            }
            else
            {
                TempData["message"] = "There was something wrong about transaction. Probably you have this car already in your favourite list.";
            }
            return RedirectToAction("FavouriteCars");
        }

        public ActionResult CompareCars()
        {
            return View(CarManager.GetFavouriteCars(Session["UserId"].ToString()));
        }
        public ActionResult Compare(string Car1, string Car2)
        {
            int index1 = Car1.IndexOf(':');
            int index2 = Car2.IndexOf(':');
            string car1Id, car2Id;
            car1Id = Car1.Substring(0, index1);
            car2Id = Car2.Substring(0, index2);

            Car car1 = CarPersistence.getCar(Int32.Parse(car1Id));
            Car car2 = CarPersistence.getCar(Int32.Parse(car2Id));

            Car[] cars = { car1, car2 };
            return View(cars);
        }

    }


}