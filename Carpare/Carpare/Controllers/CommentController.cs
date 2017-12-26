using Carpare.Models.Entity;
using Carpare.Models.Repository;
using SqliteDemo.Models.Transaction;
using System;
using System.Web.Mvc;

namespace Carpare.Controllers
{
    /// <summary>
    /// Represents the controller which handles the comment operations.
    /// </summary>
    public class CommentController : Controller
    {
        /// <summary>
        /// Adds the comment into the comment database.
        /// </summary>
        /// <param name="comment">Comment that will be added.</param>
        /// <param name="carId">Car that is commented.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CommentAdder(string comment, int carId)
        {
            Comment com = new Comment(10, carId, (String)Session["UserId"], comment.Replace("'", "&apos;"));
            CommentManager.AddNewComment(com);
            TempData["CommentMessage"] = "Comment successfully added.";
            return RedirectToAction("CarLister", "Car");  // returns /Views/Car/CarLister.cshtml
        }

        /// <summary>
        /// Returns the view that contains the comments for the car.
        /// </summary>
        /// <param name="comments">Comments for the car.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CommentShower(Comment[] comments)
        {
            if (comments == null)
            {
                ViewBag.message = "There are no comments for this car.";
            }
            return View(comments);

        }
        /// <summary>
        /// Gathers the comments for the car and returns the view that contains them.
        /// </summary>
        /// <param name="carId">Car that user wants to see it's comments.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CommentShower(int carId)
        {
            Car car = CarManager.GetCar(carId); //Gather the car and assign them to the TempData since we can't use two Models in the View.
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
        /// <summary>
        /// Returns the View that you can see the comments to delete. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteComment()
        {
            return View(CommentPersistence.GetUserComment(Session["UserId"].ToString()));
        }
        /// <summary>
        /// Deletes the comment that is chosen.
        /// </summary>
        /// <param name="CommentId">Comment that wants to be deleted.</param>
        /// <returns></returns>
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