using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carpare.Models.Entity;
using System.Diagnostics;

namespace Carpare.Models.Repository
{
    public class CarPersistence
    {
        /*
         * Retrieve from the database the book matching the ISBN field of
         * the parameter.
         * Return null if the book can't be found.
         */
        public static Car getCar(Car keyCar)
        {
            string sqlQuery = "select * from car where carId=" + keyCar.carId;
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            //System.Console.WriteLine("$$rows: " + rows.Count);
            if (rows.Count == 0)
            {
                return null;
            }

            // Use the data from the first returned row (should be the only one) to create a Book.
            object[] dataRow = rows[0];
            //DateTime dateAdded = DateTime.Parse(dataRow[2].ToString());
            Car car = new Car(Int32.Parse(dataRow[0].ToString()), (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], Int32.Parse(dataRow[4].ToString()), Int32.Parse(dataRow[5].ToString()),(string)dataRow[6]);
            return car;
        }

        /*
         * Add a Book to the database.
         * Return true iff the add succeeds.
         */
        public static bool AddCar(Car car)
        {

            string sql = "insert into car (carId, brand, model,owner, yearOfProduction, km, url  ) values ('"
                + car.carId + "', '"
                + car.Brand + "', '"
                + car.Model + "', '"
                + car.Owner + "', "
                + car.YearOfProduction + ", "
                + car.km+",'"
                + car.Url+"')";
            RepositoryManager.Repository.DoCommand(sql);
            return true;
        }

        internal static bool DeleteCar(Car delCar)
        {
            throw new NotImplementedException();
        }

        /*
         * Update a book that is in the database, replacing all field values except
         * the key field.
         * Return false if the book is not found, based on key field match.
         */
        public static bool UpdateCar(Car car)
        {
            return true;
        }

        /*
         * Get all Book data from the database and return an array of Books.
         */
        public static List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            string sqlQuery = "select * from car";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);

            foreach (object[] dataRow in rows)
            {
                Car car = new Car(Int32.Parse(dataRow[0].ToString()), (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], Int32.Parse(dataRow[4].ToString()), Int32.Parse(dataRow[5].ToString()), (string)dataRow[6]);
                Debug.WriteLine(car.toString());
                cars.Add(car);
            }

            return cars;
        }
    }
}