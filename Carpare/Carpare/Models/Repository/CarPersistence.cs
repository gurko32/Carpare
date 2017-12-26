using System;
using System.Collections.Generic;
using Carpare.Models.Entity;
using System.Diagnostics;

namespace Carpare.Models.Repository
{
    /// <summary>
    /// Handles the database queries and commands for the car transactions.
    /// </summary>
    public class CarPersistence
    {
        /// <summary>
        /// Gets the car from database.
        /// </summary>
        /// <param name="carId">Car that wanted to find.</param>
        /// <returns>Car that is wanted by the user.</returns>
        public static Car getCar(int carId)
        {
            string sqlQuery = "select * from car where carId=" + carId;
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            if (rows.Count == 0)
            {
                return null;
            }
            object[] dataRow = rows[0];
            Car car = new Car(Int32.Parse(dataRow[0].ToString()), (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], Int32.Parse(dataRow[4].ToString()), Int32.Parse(dataRow[5].ToString()), (string)dataRow[6], (string)dataRow[7], (string)dataRow[8], Int32.Parse(dataRow[9].ToString()), dataRow[10].ToString(), dataRow[11].ToString(), (string)dataRow[12]);
            return car;
        }

        /// <summary>
        /// Returns the favorite cars of the user.
        /// </summary>
        /// <param name="userId">User ID for gather favourite cars.</param>
        /// <returns>An array which contains favourite cars of the user.</returns>
        internal static Car[] GetFavCars(string userId)
        {
            Car[] cars;
            string sqlQuery = "select * from favourites where UserId='" + userId + "';"; // Check the database if there are cars in the user which are favourite.
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);

            if (rows.Count == 0) // If not, return null.
            {
                return null;
            }
            string carId = "";
            object[] dataRow;
            cars = new Car[rows.Count];
            for (int i = 0; i < rows.Count; i++) // This loop gets the cars and puts into an array.
            {
                carId = rows[i][1].ToString();  // Get the car ID.
                sqlQuery = "select * from car where carId='" + carId + "';";
                List<object[]> car = RepositoryManager.Repository.DoQuery(sqlQuery);

                if (car.Count == 0)
                    continue;

                dataRow = car[0];
                Car newCar = new Car(Int32.Parse(dataRow[0].ToString()), (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], Int32.Parse(dataRow[4].ToString()), Int32.Parse(dataRow[5].ToString()), (string)dataRow[6], (string)dataRow[7], (string)dataRow[8], Int32.Parse(dataRow[9].ToString()), dataRow[10].ToString(), dataRow[11].ToString(), (string)dataRow[12]);
                cars[i] = newCar; // Add the car to the array.
            }
            return cars;
        }
        
        /// <summary>
        /// Gets the car with given ID from database.
        /// </summary>
        /// <param name="carId">Car that user wants.</param>
        /// <returns>A Car object which is desired.</returns>
        public static Car GetCar(int carId)
        {
            string sqlQuery = "select * from car where carId='" + carId + "';";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);

            if (rows.Count == 0)
            {
                return null;
            }

            Car[] cars = new Car[rows.Count];
            object[] dataRow = rows[0];
            Car car = new Car(Int32.Parse(dataRow[0].ToString()), (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], Int32.Parse(dataRow[4].ToString()), Int32.Parse(dataRow[5].ToString()), (string)dataRow[6], (string)dataRow[7], (string)dataRow[8], Int32.Parse(dataRow[9].ToString()), dataRow[10].ToString(), dataRow[11].ToString(), (string)dataRow[12]);

            
            return car;
        }

        /// <summary>
        /// Adds car to favourites table.
        /// </summary>
        /// <param name="carId">Car that wanted to add.</param>
        /// <param name="userId">User that adds the car into favourites.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        internal static int AddToFavourites(string carId, string userId)
        {
            string sqlQuery = "insert into favourites (UserId,carId) values('" + userId + "'," + carId + ");";
            int result = RepositoryManager.Repository.DoCommand(sqlQuery);
            return result;
        }

        /// <summary>
        /// Checks the car if it is in the favourite table or not.
        /// </summary>
        /// <param name="carId">Car that wanted to be searched.</param>
        /// <param name="userId">User that wants to search.</param>
        /// <returns></returns>
        internal static bool CheckFavCar(string carId, string userId)
        {
            string sqlQuery = "select * from favourites where carId=" + carId + " and UserId = '" + userId + "';";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);

            if (rows.Count == 0)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Gets the user's cars.
        /// </summary>
        /// <param name="UserId">User that wants his/her cars.</param>
        /// <returns></returns>
        public static Car[] GetUserCar(string UserId)
        {
            string sqlQuery = "select * from car where Owner='" + UserId + "';";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);

            if (rows.Count == 0)
            {
                return null;
            }

            Car[] cars = new Car[rows.Count];
            object[] dataRow;

            for (int i = 0; i < rows.Count; i++)
            {
                dataRow = rows[i];
                Car car = new Car(Int32.Parse(dataRow[0].ToString()), (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], Int32.Parse(dataRow[4].ToString()), Int32.Parse(dataRow[5].ToString()), (string)dataRow[6], (string)dataRow[7], (string)dataRow[8], Int32.Parse(dataRow[9].ToString()), dataRow[10].ToString(), dataRow[11].ToString(), (string)dataRow[12]);
                cars[i] = car;
            }
            return cars;

        }

        /// <summary>
        /// Searchs for the car with given parameters.
        /// </summary>
        /// <param name="value">Value that user entered to search.</param>
        /// <param name="userId">User that makes the search.</param>
        /// <param name="option">The value (Ranged from 1 to 10) to determine which field will be searched.</param>
        /// <returns>Cars that matches to the query.</returns>
        internal static Car[] SearchCar(string value, string userId, int option)
        {
            List<object[]> rows = new List<object[]>();
            if (option == 1)
            {
                string sqlQuery = "select * from car where Owner='" + userId + "' and Brand = '" + value + "';";
                rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            }
            else if (option == 2)
            {
                string sqlQuery = "select * from car where Owner='" + userId + "' and Model = '" + value + "';";
                rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            }
            else if (option == 3)
            {
                string sqlQuery = "select * from car where Owner='" + userId + "' and YearOfProduction = " + value + ";";
                rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            }
            else if (option == 4)
            {
                string sqlQuery = "select * from car where Owner='" + userId + "' and KM = " + value + ";";
                rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            }
            else if (option == 5)
            {
                string sqlQuery = "select * from car where Owner='" + userId + "' and TransmissionType = '" + value + "';";
                rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            }
            else if (option == 6)
            {
                string sqlQuery = "select * from car where Owner='" + userId + "' and Fuel = '" + value + "';";
                rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            }
            else if (option == 7)
            {
                string sqlQuery = "select * from car where Owner='" + userId + "' and TopSpeed = " + value + ";";
                rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            }
            else if (option == 8)
            {
                string sqlQuery = "select * from car where Owner='" + userId + "' and Acceleration = " + value + ";";
                rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            }
            else if (option == 9)
            {
                string sqlQuery = "select * from car where Owner='" + userId + "' and UrbanConsumption = " + value + ";";
                rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            }
            else if (option == 10)
            {
                string sqlQuery = "select * from car where Owner='" + userId + "' and WheelDrive ='" + value + "';";
                rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            }
            Car[] cars = new Car[rows.Count];
            object[] dataRow;

            for (int i = 0; i < rows.Count; i++)
            {
                dataRow = rows[i];
                Car car = new Car(Int32.Parse(dataRow[0].ToString()), (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], Int32.Parse(dataRow[4].ToString()), Int32.Parse(dataRow[5].ToString()), (string)dataRow[6], (string)dataRow[7], (string)dataRow[8], Int32.Parse(dataRow[9].ToString()), dataRow[10].ToString(), dataRow[11].ToString(), (string)dataRow[12]);
                cars[i] = car;
            }
            return cars;
        }

        /// <summary>
        /// Adds the car into the database.
        /// </summary>
        /// <param name="car">Car that is wanted to add into database.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        public static bool AddCar(Car car)
        {
            string sql = "select max(carId) AS num from car;";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sql);
            sql = "select * from car";
            List<object[]> rows2 = RepositoryManager.Repository.DoQuery(sql);

            if (rows2.Count == 0) // If there is no car found in the database, start the Car ID from 1000.
            {
                car.carId = 1000;
            }
            else // Else, find the max value for the CarID which is in the database, add 1 to it and assign it to the new car.
            {
                car.carId = Int32.Parse(rows[0][0].ToString()) + 1;
            }

            sql = "insert into car (carId, brand, model,owner, yearOfProduction, km, url,TransmissionType,Fuel,TopSpeed,Acceleration,UrbanConsumption,WheelDrive) values ('"
                + car.carId + "', '"
                + car.Brand.Replace("'", "&apos;") + "', '"
                + car.Model.Replace("'", "&apos;") + "', '"
                + car.Owner.Replace("'", "&apos;") + "', "
                + car.YearOfProduction + ", "
                + car.km + ",'"
                + car.Url.Replace("'", "&apos;") + "','"
                + car.TransmissionType + "', '"
                + car.Fuel + "', "
                + car.TopSpeed + ", "
                + car.Acceleration + ","
                + car.UrbanConsumption + ",'"
                + car.WheelDrive.Replace("'", "&apos;") + "')";
            RepositoryManager.Repository.DoCommand(sql);
            return true;
        }

        /// <summary>
        /// Deletes car from car table and favorites table.
        /// </summary>
        /// <param name="CarId">Car that is wanted to be deleted.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        internal static bool DeleteCar(string CarId)
        {
            string sql = "delete from car where carId = " + CarId + ";";
            int result = RepositoryManager.Repository.DoCommand(sql);
            sql = "delete from favourites where carId = " + CarId + ";";
            result = RepositoryManager.Repository.DoCommand(sql);
            if (result == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Updates the car with given value as input.
        /// </summary>
        /// <param name="value">New value which is wanted to change.</param>
        /// <param name="option">Car that is wanted to update.</param>
        /// <param name="carId">The value (Ranged from 1 to 11) to determine which field will be changed.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        public static bool UpdateCar(string value, int option, string carId)
        {
            int result = 0;
            string sql = "";

            if (option == 1)
            {
                sql = "update car set Url ='" + value + "' where carId = " + carId + ";";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 2)
            {
                sql = "update car set Brand ='" + value + "' where carId = " + carId + ";";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 3)
            {
                sql = "update car set Model ='" + value + "' where carId = " + carId + ";";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 4)
            {
                sql = "update car set YearOfProduction ='" + value + "' where carId = " + carId + ";";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 5)
            {
                sql = "update car set KM =" + value + " where carId = " + carId + ";";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 6)
            {
                sql = "update car set TransmissionType ='" + value + "' where carId = " + carId + ";";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 7)
            {
                sql = "update car set Fuel ='" + value + "' where carId = " + carId + ";";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 8)
            {
                sql = "update car set TopSpeed =" + value + " where carId = " + carId + ";";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 9)
            {
                sql = "update car set Acceleration =" + value + " where carId = " + carId + ";";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 10)
            {
                sql = "update car set UrbanConsumption =" + value + " where carId = " + carId + ";";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            else if (option == 11)
            {
                sql = "update car set WheelDrive ='" + value + "' where carId = " + carId + ";";
                result = RepositoryManager.Repository.DoCommand(sql);
            }
            if (result == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns every car from the database.
        /// </summary>
        /// <returns>List of Cars which contains every car in the database.</returns>
        public static List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            string sqlQuery = "select * from car";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);

            foreach (object[] dataRow in rows)
            {
                Car car = new Car(Int32.Parse(dataRow[0].ToString()), (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], Int32.Parse(dataRow[4].ToString()), Int32.Parse(dataRow[5].ToString()), (string)dataRow[6], (string)dataRow[7], (string)dataRow[8], Int32.Parse(dataRow[9].ToString()), dataRow[10].ToString(), dataRow[11].ToString(), (string)dataRow[12]);
                Debug.WriteLine(car.toString());
                cars.Add(car);
            }

            return cars;
        }
    }
}