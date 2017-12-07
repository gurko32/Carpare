using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carpare.Models.Entity
{
    public class Car
    {
        public String Brand { get; set; }
        public String Model { get; set; }
        public String Owner { get; set; }
        public int YearOfProduction { get; set; }
        public int km { get; set; }
        /*
         * Return a string representation of the Pet object.
         */
        public Car(String Brand,String Model,String Owner,int YearOfProduction)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.Owner = Owner;
            this.YearOfProduction = YearOfProduction;
        }
        public String toString()
        {
            return "Car Brand: " + Brand + ", " + "Car Model: " + Model + "Car Owner: " + Owner + ", " + "Year of Production: " + YearOfProduction + "," + "Car's mileage(km): " + km;
        }

        /*
         * Compare two Car objects.
         * Car match on the Name field and Year of Production.
         */
        public bool Equals(Car other)
        {
            return (this.Brand == other.Brand) && (this.Model == other.Model) && (this.YearOfProduction == other.YearOfProduction);
        }
    }
}