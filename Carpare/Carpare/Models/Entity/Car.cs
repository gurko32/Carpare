using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        /*
         * Return a string representation of the Pet object.
         */
        public Car(int carId,String Brand,String Model,String Owner,int YearOfProduction,int km,String Url,string tt,string f,int ts, string a, string uc, string wd)
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
        public Car()
        {

        }
        public String toString()
        {
            return "Car Id: "+ carId + " Car Brand: " + Brand + ", " + "Car Model: " + Model + "Car Owner: " + Owner + ", " + "Year of Production: " + YearOfProduction + "," + "Car's mileage(km): " + km+","+"Car's URL: "+Url;
        }

        /*
         * Compare two Car objects.
         * Car match on the Name field and Year of Production.
         */
        public bool Equals(Car other)
        {
            return (this.carId== other.carId);
        }
    }
}