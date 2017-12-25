using System;

namespace Carpare.Models.Entity
{
    /// <summary>
    /// Represents the cars that are entered to system.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// ID of the car.
        /// </summary>
        public int carId { get; set; }
        /// <summary>
        /// Brand of the car.
        /// </summary>
        public String Brand { get; set; }
        /// <summary>
        /// Model of the car.
        /// </summary>
        public String Model { get; set; }
        /// <summary>
        /// Owner of the car.
        /// </summary>
        public String Owner { get; set; }
        /// <summary>
        /// Year of production of the car.
        /// </summary>
        public int YearOfProduction { get; set; }
        /// <summary>
        /// KM of the car.
        /// </summary>
        public int km { get; set; }
        /// <summary>
        /// Photo of the car which is a url of the photo.
        /// </summary>
        public String Url { get; set; }
        /// <summary>
        /// Transmission type of the car.
        /// </summary>
        public String TransmissionType { get; set; }
        /// <summary>
        /// Fuel type of the car.
        /// </summary>
        public String Fuel { get; set; }
        /// <summary>
        /// Top speed of the car.
        /// </summary>
        public int TopSpeed { get; set; }
        /// <summary>
        /// Acceleration of the car.
        /// </summary>
        public string Acceleration { get; set; }
        /// <summary>
        /// Urban consumption of the car.
        /// </summary>
        public string UrbanConsumption { get; set; }
        /// <summary>
        /// Wheel drive type of the car.
        /// </summary>
        public String WheelDrive { get; set; }

        /// <summary>
        /// Initializes a Car object.
        /// </summary>
        /// <param name="carId">ID of the car.</param>
        /// <param name="Brand">Brand of the car.</param>
        /// <param name="Model">Model of the car.</param>
        /// <param name="Owner">Owner of the car which is the User ID.</param>
        /// <param name="YearOfProduction">Year of production of the car.</param>
        /// <param name="km">KM of the car.</param>
        /// <param name="Url">Photo of the car which is a url of the photo.</param>
        /// <param name="tt">Transmission type of the car.</param>
        /// <param name="f">Fuel type of the car.</param>
        /// <param name="ts">Top speed of the car.</param>
        /// <param name="a">Acceleration of the car.</param>
        /// <param name="uc">Urban consumption of the car.</param>
        /// <param name="wd">Wheel drive type of the car.</param>
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
        /// Initializes an empty car object.
        /// </summary>
        public Car()
        {

        }

        /// <summary>
        /// To string method for debug purposes.
        /// </summary>
        /// <returns>String value that contains car's important credentials.</returns>
        public String toString()
        {
            return "Car Id: " + carId + " Car Brand: " + Brand + ", " + "Car Model: " + Model + "Car Owner: " + Owner + ", " + "Year of Production: " + YearOfProduction + "," + "Car's mileage(km): " + km + "," + "Car's URL: " + Url;
        }
    }
}