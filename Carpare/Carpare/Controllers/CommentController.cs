using Carpare.Models.Entity;
using SqliteDemo.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            //Debug.WriteLine("asdasdasdasdasdasdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"+ comment);
            //Debug.WriteLine(Session["UserId"]);
            //Car[] cars = CarManager.GetAllCars();

            Comment com = new Comment(10, carId, (String)Session["UserId"], comment);
            CommentManager.AddNewComment(com);
            return RedirectToAction("CarLister","Car");  // returns /Views/Car/CarLister.cshtml
        }
        

        [HttpGet]
        public ActionResult CommentShower(Comment[] comments)
        {
            return View(comments);

        }
        [HttpPost]
        public ActionResult CommentShower(int carId)
        {

            Comment[] comments = CommentManager.GetCarComments(carId);
            return View(comments);

        }
        

    }
}