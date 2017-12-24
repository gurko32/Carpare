﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carpare.Models.Entity;
using System.Diagnostics;
using System.Globalization;

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
            Car car = new Car(Int32.Parse(dataRow[0].ToString()), (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], Int32.Parse(dataRow[4].ToString()), Int32.Parse(dataRow[5].ToString()), (string)dataRow[6], (string)dataRow[7], (string)dataRow[8], Int32.Parse(dataRow[9].ToString()), dataRow[10].ToString(), dataRow[11].ToString(), (string)dataRow[12]);
            return car;
        }

        internal static Car[] GetFavCars(string userId)
        {
            Car[] cars;
            string sqlQuery = "select * from favourites where UserId='" + userId + "';";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);

            if (rows.Count == 0)
            {
                return null;
            }
            string carId = "";
            object[] dataRow;
            cars = new Car[rows.Count];
            for (int i = 0; i < rows.Count; i++)
            {
                carId = rows[i][1].ToString();
                sqlQuery = "select * from car where carId='" + carId + "';";
                List <object[]> car = RepositoryManager.Repository.DoQuery(sqlQuery);
                dataRow = car[0];
                Car newCar = new Car(Int32.Parse(dataRow[0].ToString()), (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], Int32.Parse(dataRow[4].ToString()), Int32.Parse(dataRow[5].ToString()), (string)dataRow[6], (string)dataRow[7], (string)dataRow[8], Int32.Parse(dataRow[9].ToString()), dataRow[10].ToString(), dataRow[11].ToString(), (string)dataRow[12]);
                cars[i] = newCar;
            }
            return cars;

        }

        public static Car[] GetCar(int carId)
        {
            string sqlQuery = "select * from car where carId='" + carId + "';";
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

        internal static int AddToFavourites(string carId, string userId)
        {
            string sqlQuery = "insert into favourites (UserId,carId) values('" + userId + "'," + carId + ");";
            int result = RepositoryManager.Repository.DoCommand(sqlQuery);
            return result;
        }

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


        /*
* Add a Book to the database.
* Return true iff the add succeeds.
*/
        public static bool AddCar(Car car)
        {
            string sql = "select max(carId) AS num from car;";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sql);
            sql = "select * from car";
            List<object[]> rows2 = RepositoryManager.Repository.DoQuery(sql);

            if (rows2.Count == 0)
            {
                car.carId = 1000;
            }
            else
            {
                car.carId = Int32.Parse(rows[0][0].ToString()) + 1;
            }

            sql = "insert into car (carId, brand, model,owner, yearOfProduction, km, url,TransmissionType,Fuel,TopSpeed,Acceleration,UrbanConsumption,WheelDrive) values ('"
                + car.carId + "', '"
                + car.Brand + "', '"
                + car.Model + "', '"
                + car.Owner + "', "
                + car.YearOfProduction + ", "
                + car.km + ",'"
                + car.Url + "','"
                + car.TransmissionType + "', '"
                + car.Fuel + "', "
                + car.TopSpeed + ", "
                + car.Acceleration + ","
                + car.UrbanConsumption + ",'"
                + car.WheelDrive + "')";
            RepositoryManager.Repository.DoCommand(sql);
            return true;
        }


        internal static bool DeleteCar(string CarId)
        {
            string sql = "delete from car where carId = " + CarId + ";";
            int result = RepositoryManager.Repository.DoCommand(sql);

            if (result == 0)
                return false;
            else
                return true;
        }

        /*
         * Update a Car that is in the database, replacing all field values except
         * the key field.
         */
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
                Car car = new Car(Int32.Parse(dataRow[0].ToString()), (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], Int32.Parse(dataRow[4].ToString()), Int32.Parse(dataRow[5].ToString()), (string)dataRow[6], (string)dataRow[7], (string)dataRow[8], Int32.Parse(dataRow[9].ToString()), dataRow[10].ToString(), dataRow[11].ToString(), (string)dataRow[12]);
                Debug.WriteLine(car.toString());
                cars.Add(car);
            }

            return cars;
        }
    }
}