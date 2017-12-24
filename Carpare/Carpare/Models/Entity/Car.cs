using System;

namespace Carpare.Models.Entity
{
    public class Car
    {
        public int carId { get; set; }
        public String Brand { get; set; }
        public String Model { get; set; }
        public String Owner { get; set; }
        public int YearOfProduction { get; set; }
        public int km { get; set; }
        public String Url { get; set; }
        public String TransmissionType { get; set; }
        public String Fuel { get; set; }
        public int TopSpeed { get; set; }
        public string Acceleration { get; set; }
        public string UrbanConsumption { get; set; }
        public String WheelDrive { get; set; }
        
        /// <summary>
        /// Creates a Car object
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="Brand"></param>
        /// <param name="Model"></param>
        /// <param name="Owner"></param>
        /// <param name="YearOfProduction"></param>
        /// <param name="km"></param>
        /// <param name="Url"></param>
        /// <param name="tt"></param>
        /// <param name="f"></param>
        /// <param name="ts"></param>
        /// <param name="a"></param>
        /// <param name="uc"></param>
        /// <param name="wd"></param>
        public Car(int carId, String Brand, String Model, String Owner, int YearOfProduction, int km, String Url, string tt, string f, int ts, string a, string uc, string wd)
        {
            this.carId = carId;
            this.Brand = Brand;
            this.Model = Model;
            this.Owner = Owner;
            this.YearOfProduction = YearOfProduction;
            this.km = km;
            this.Url = Url;
            TransmissionType = tt;
            Fuel = f;
            TopSpeed = ts;
            Acceleration = a;
            UrbanConsumption = uc;
            WheelDrive = wd;
        }

        /// <summary>
        /// Empty constructor for view objects
        /// </summary>
        public Car()
        {

        }

        /// <summary>
        /// To string 
        /// </summary>
        /// <returns></returns>
        public String toString()
        {
            return "Car Id: " + carId + " Car Brand: " + Brand + ", " + "Car Model: " + Model + "Car Owner: " + Owner + ", " + "Year of Production: " + YearOfProduction + "," + "Car's mileage(km): " + km + "," + "Car's URL: " + Url;
        }
    }
}