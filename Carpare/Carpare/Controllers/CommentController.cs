using Carpare.Models.Entity;
using Carpare.Models.Repository;
using SqliteDemo.Models.Transaction;
using System;
using System.Web.Mvc;

namespace Carpare.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult CommentPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CommentAdder(string comment, int carId)
        {
            Comment com = new Comment(10, carId, (String)Session["UserId"], comment);
            CommentManager.AddNewComment(com);
            TempData["CommentMessage"] = "Comment successfully added.";
            return RedirectToAction("CarLister", "Car");  // returns /Views/Car/CarLister.cshtml
        }


        [HttpGet]
        public ActionResult CommentShower(Comment[] comments)
        {
            if (comments == null)
            {
                ViewBag.message = "There are no comments for this car.";
            }
            return View(comments);

        }
        [HttpPost]
        public ActionResult CommentShower(int carId)
        {
            Car car = CarManager.GetUserCars(carId);
            TempData["carId"] = car.carId;
            TempData["Brand"] = car.Brand;
            TempData["Model"] = car.Model;
            TempData["Owner"] = car.Owner;
            TempData["YearOfProduction"] = car.YearOfProduction;
            TempData["km"] = car.km;
            TempData["Url"] = car.Url;
            TempData["TransmissionType"] = car.TransmissionType;
            TempData["Fuel"] = car.Fuel;
            TempData["TopSpeed"] = car.TopSpeed;
            TempData["Acceleration"] = car.Acceleration;
            TempData["UrbanConsumption"] = car.UrbanConsumption;
            TempData["WheelDrive"] = car.WheelDrive;

            Comment[] comments = CommentManager.GetCarComments(carId);
            if (comments == null)
            {
                ViewBag.message = "There are no comments for this car.";
            }
            return View(comments);
        }
        [HttpGet]
        public ActionResult DeleteComment()
        {
            return View(CommentPersistence.GetUserComment(Session["UserId"].ToString()));
        }
        [HttpPost]
        public ActionResult DeleteComment(string CommentId)
        {
            bool result = CommentManager.DeleteComment(CommentId);
            if (result)
                ViewBag.message = "Comment successfully deleted.";
            else
                ViewBag.message = "Comment could not be deleted.";

            return View(CommentPersistence.GetUserComment(Session["UserId"].ToString()));
        }



    }
}