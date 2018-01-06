using Carpare.Models.Entity;
using Carpare.Models.Repository;
using SqliteDemo.Models.Transaction;
using System;
using System.Web.Mvc;

namespace Carpare.Controllers
{
    /// <summary>
    /// Represents the controller for the operations of the cars.
    /// </summary>
    public class CarController : Controller
    {
        /// <summary>
        /// Returns the View that contains all cars in the database.
        /// </summary>
        /// <returns></returns>
        public ActionResult CarLister()
        {
            Car[] cars = CarManager.GetAllCars();
            return View(cars);  // returns /Views/Car/CarLister.cshtml
        }

        /// <summary>
        /// Returns the View that contains only the user's cars.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MyCarLister()
        {
            string UserId = (string)Session["UserId"];
            Car[] cars = CarManager.GetUserCars(UserId);
            return View(cars);
        }

        /// <summary>
        /// Returns the View where you can add your new car.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Update()
        {
            return View(new Car());
        }
        /// <summary>
        /// Returns the View where you can change your cars' specifications.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeCar()
        {
            return View(CarManager.GetUserCars((string)Session["UserId"]));
        }
        /// <summary>
        /// Changes the car's specifications which is entered by the user.
        /// </summary>
        /// <param name="carId">Car that we want to change.</param>
        /// <param name="Url">Url of the photo of the car.</param>
        /// <param name="Brand">Brand of the car.</param>
        /// <param name="Model">Model of the car.</param>
        /// <param name="YearOfProduction">Year of production of the car.</param>
        /// <param name="km">Car's mileage (km).</param>
        /// <param name="TransmissionType">Transmission type of the car.</param>
        /// <param name="TopSpeed">Top speed of the car.</param>
        /// <param name="Acceleration">Acceleration of the car.</param>
        /// <param name="UrbanConsumption">Urban consumption of the car.</param>
        /// <param name="Fuel">Fuel of the car.</param>
        /// <param name="WheelDrive">Wheel drive of the car.</param>
        /// <returns>View for changing car page.</returns>
        [HttpPost]
        public ActionResult ChangeCar(string carId, string Url, string Brand, string Model, string YearOfProduction, string km, string TransmissionType, string TopSpeed, string Acceleration, string UrbanConsumption, string Fuel, string WheelDrive)
        {
            bool result = false;
            if (Url != "")
            {
                result = CarManager.ChangeCar(Url.Replace("'", "&apos;"), carId, 1);
            }
            if (Brand != "")
            {
                result = CarManager.ChangeCar(Brand.Replace("'", "&apos;"), carId, 2);
            }
            if (Model != "")
            {
                result = CarManager.ChangeCar(Model.Replace("'", "&apos;"), carId, 3);
            }
            if (YearOfProduction != "")
            {
                result = CarManager.ChangeCar(YearOfProduction.Replace("'", "&apos;"), carId, 4);
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
        /// <summary>
        /// Returns the car list that you can delete the cars.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteCar()
        {
            return View(CarPersistence.GetUserCar(Session["UserId"].ToString()));
        }
        /// <summary>
        /// Deletes the selected car.
        /// </summary>
        /// <param name="carId">Car that user wants to delete.</param>
        /// <returns>View that contains delete page.</returns>
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
        /// <summary>
        /// Returns the view where you can search the car with the keywords.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SearchCar()
        {
            return View();
        }
        /// <summary>
        /// Looks for the cars that user entered to the search tab in the web page.
        /// </summary>
        /// <param name="Brand">Brand that user looks.</param>
        /// <param name="Model">Model that user looks.</param>
        /// <param name="YearOfProduction">Year of Production that user looks.</param>
        /// <param name="km">Car's km that user looks.</param>
        /// <param name="TransmissionType">Transmission type that user looks.</param>
        /// <param name="Fuel">Fuel type that user looks.</param>
        /// <param name="WheelDrive">Wheel drive type that user looks.</param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Adds the new car into the database.
        /// </summary>
        /// <param name="car">Car that needs to be added.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Car car)
        {
            bool result = false;
            car.Owner = (string)Session["UserId"];
            result = CarManager.AddNewCar(car);
            
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
        /// <summary>
        /// Returns the view where you can see your cars that you added them into your favourites tab.
        /// </summary>
        /// <returns></returns>
        public ActionResult FavouriteCars()
        {
            return View(CarManager.GetFavouriteCars((string)Session["UserId"]));
        }
        /// <summary>
        /// Adds the car into your favourite database.
        /// </summary>
        /// <param name="carId">Car that wants to be added to favourites.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Returns the view where you can compare two cars.
        /// </summary>
        /// <returns></returns>
        public ActionResult CompareCars()
        {
            return View(CarManager.GetFavouriteCars(Session["UserId"].ToString()));
        }
        /// <summary>
        /// Gathers the two cars from the database and and returns the view where you can see these two cars.
        /// </summary>
        /// <param name="Car1">First car.</param>
        /// <param name="Car2">Second car.</param>
        /// <returns></returns>
        public ActionResult Compare(string Car1, string Car2)
        {
            int index1 = Car1.IndexOf(':'); // We are doing this because the string has the form: "carId: Brand Model" and we want only the carId.
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