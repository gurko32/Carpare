﻿using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;
using Carpare.Models.Repository;
using Carpare.Models.Entity;
using Carpare.Models.Persistance;
using Carpare.Models.Transaction;

namespace SqliteTest.Models.Repository
{
    /*
     * This class creates and accesses an SQLite database.
     */
    public class SqliteRepository : IRepository
    {
        // Location of the database file 
        private string databaseFile = "C:\\Users\\kcaglar.guler\\MyDatabase.sqlite";

        private SQLiteConnection dbConnection;

        public bool IsOpen { get { return isOpen; } }
        private bool isOpen = false;

        /*
         * When the Repository shuts down, it should close the DB if it's open.
         */
        ~SqliteRepository()
        {
            if (IsOpen)
            {
                Close();
            }
        }

        /*
         * Open the database. Return true iff the open succeeds, or it was
         * already open.
         */
        public bool Open()
        {
            if (IsOpen)
            {
                return true;
            }
            dbConnection =
                new SQLiteConnection("Data Source=" + databaseFile + ";Version=3;");
            if (dbConnection == null) { return false; }
            dbConnection.Open();
            isOpen = true;
            return true;
        }

        /*
         * Close the database, if it's open.
         */
        public void Close()
        {
            if (!IsOpen)
            {
                return;
            }
            isOpen = false;
            dbConnection.Close();
        }

        /*
         * Execute an SQL command. 
         * The return value is the number of rows affected by the command.
         */
        public int DoCommand(string sqlCommand)
        {
            if (!IsOpen)
            {
                return -1;
            }
            SQLiteCommand command = new SQLiteCommand(sqlCommand, dbConnection);
            int result = command.ExecuteNonQuery();
            return result;
        }

        /*
         * Execute an SQL query. 
         * The return value is a List of object arrays, in which each array 
         * represents one row of data returned.
         */
        public List<object[]> DoQuery(string sqlQuery)
        {
            if (!IsOpen)
            {
                return null;
            }
            List<object[]> rows = new List<object[]>();
            SQLiteCommand command = new SQLiteCommand(sqlQuery, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                object[] row = new object[reader.FieldCount];
                reader.GetValues(row);
                rows.Add(row);
            }
            return rows;
        }

        /*
         * Recreate and reinitialize the database.
         * The return value is true iff the initialization succeeds.
         */
        public bool Initialize()
        {
            bool openResult;

            if (File.Exists(databaseFile) && new FileInfo(databaseFile).Length > 10)
            {
                openResult = Open();
                return openResult;
            }

            bool success = true;
            Close();

            try
            {
                SQLiteConnection.CreateFile(databaseFile);
            }
            catch (IOException e)
            {
                success = false;
            }

            openResult = Open();
            if (success & openResult)
            {
                string salt;
                string sql = "CREATE TABLE user (UserId VARCHAR(50), Name VARCHAR(50),Salt VARCHAR(50), HashedPassword VARCHAR(50),Email VARCHAR(50),IsAdmin BIT,Status VARCHAR(1),Gender VARCHAR(6),BirthDate VARCHAR(10), Location VARCHAR(30), PRIMARY KEY(UserId));";
                DoCommand(sql);
                sql = "CREATE TABLE car (carId INTEGER, Brand VARCHAR(50), Model VARCHAR(50),Owner VARCHAR(50),YearOfProduction INTEGER,KM INT,Url VARCHAR(200),TransmissionType VARCHAR(15), Fuel VARCHAR(15),TopSpeed INT, Acceleration Float,UrbanConsumption Float, WheelDrive VARCHAR(20), PRIMARY KEY(carId),FOREIGN KEY (Owner) references user(UserId));";
                DoCommand(sql);
                sql = "CREATE TABLE comment (CommentId INTEGER, carId INTEGER,UserId VARCHAR(50), Text VARCHAR(300),FOREIGN KEY (carId) references car(carId),PRIMARY KEY(CommentId),FOREIGN KEY (UserId) references user(UserId));";
                DoCommand(sql);
                sql = "CREATE TABLE favourites (UserId VARCHAR(12), carId INTEGER,FOREIGN KEY (carId) references car(carId),FOREIGN KEY (UserId) references user(UserId));";
                DoCommand(sql);

                salt = User.CreateSalt();
                sql = "insert into user (UserId, Name,Salt, HashedPassword,Email,IsAdmin,Status,Gender,BirthDate,Location) values ('"
               + "crysispeed" + "', '"
               + "Caglar" + "', '"
               + salt + "', '"
               + EncryptionManager.EncodePassword("123456", salt) + "', '"
               + "abc@gmail.com" + "',"
               + "1" + ", '"
               + "A" + "','"
               + "Male" + "', '"
               + "1995-08-26" + "', '"
               + "Ankara" + "');";
                DoCommand(sql);
                salt = User.CreateSalt();
                sql = "insert into user (UserId, Name,Salt, HashedPassword,Email,IsAdmin,Status,Gender,BirthDate,Location) values ('"
               + "gurko32" + "', '"
               + "Gurkan" + "', '"
               + salt + "', '"
               + EncryptionManager.EncodePassword("123456", salt) + "', '"
               + "def@gmail.com" + "',"
               + "1" + ", '"
               + "A" + "', '"
               + "Male" + "', '"
               + "1996-10-16" + "', '"
               + "Ankara" + "');";
                DoCommand(sql);
                UserPersistence.PrintAllUsers();

            }

            return success;
        }
    }
}
