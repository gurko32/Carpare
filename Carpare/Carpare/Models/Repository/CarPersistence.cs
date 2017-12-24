﻿using System;
using System.Collections.Generic;
using Carpare.Models.Entity;
using System.Diagnostics;

namespace Carpare.Models.Repository
{
    public class CarPersistence
    {
        /// <summary>
        /// Gets the car from database
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
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
        /// returns favorite cars
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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
                List<object[]> car = RepositoryManager.Repository.DoQuery(sqlQuery);

                if (car.Count == 0)
                    continue;

                dataRow = car[0];
                Car newCar = new Car(Int32.Parse(dataRow[0].ToString()), (string)dataRow[1], (string)dataRow[2], (string)dataRow[3], Int32.Parse(dataRow[4].ToString()), Int32.Parse(dataRow[5].ToString()), (string)dataRow[6], (string)dataRow[7], (string)dataRow[8], Int32.Parse(dataRow[9].ToString()), dataRow[10].ToString(), dataRow[11].ToString(), (string)dataRow[12]);
                cars[i] = newCar;
            }
            return cars;
        }
        
        /// <summary>
        /// Gets cars with given id from database
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds car to Favourites
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        internal static int AddToFavourites(string carId, string userId)
        {
            string sqlQuery = "insert into favourites (UserId,carId) values('" + userId + "'," + carId + ");";
            int result = RepositoryManager.Repository.DoCommand(sqlQuery);
            return result;
        }

        /// <summary>
        /// Returns favorite cars from databse
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="userId"></param>
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
        /// Gets the users cars
        /// </summary>
        /// <param name="UserId"></param>
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
        /// Searchs for the car with given parameters
        /// </summary>
        /// <param name="value"></param>
        /// <param name="userId"></param>
        /// <param name="option"></param>
        /// <returns></returns>
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
        /// Adds car to database
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletes car from car table and favorites table
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
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
        /// Updates with given value as input
        /// </summary>
        /// <param name="value"></param>
        /// <param name="option"></param>
        /// <param name="carId"></param>
        /// <returns></returns>
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

        //returns every car from database
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