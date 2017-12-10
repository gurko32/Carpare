using Carpare.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SqliteDemo.Models.Transaction
{
    public class CarManager
    {

        public static Car[] GetAllBooks()
        {
            List<Car> books = CarPersistence.GetAllBooks();
            if (books != null)
            {
                return CarPersistence.GetAllBooks().ToArray();
            }
            else
            {
                return (new Car[0]);
            }
        }

        /*
         * Transaction: Add a new book to the database
         * Returns true iff the new book has a unique ISBN
         * and it was successfully added.
         */
        public static bool AddNewBook(Car newBook)
        {
            // Verify that the book doesn't already exist
            Car oldBook = CarPersistence.getBook(newBook);
            // oldBook should be null, if this is a new book
            if (oldBook != null)
            {
                return false;
            }

            return CarPersistence.AddBook(newBook);
        }

        /*
         * Transaction: Delete a book from the database
         * Returns true iff the book exists in the database and
         * it was successfully deleted.
         */
        public static bool DeleteBook(Car delBook)
        {
            Car book = CarPersistence.getBook(delBook);
            if (book == null)
            {
                return false;
            }
            bool result = CarPersistence.DeleteBook(delBook);

            return result;
        }


        /*
         * Transaction: Update a book in the database
         * Returns true iff the book exists in the database and
         * it was successfully changed.
         */
        public static bool ChangeBook(Car Book)
        {
            if (Book == null)
            {
                return false;
            }
            bool result = CarPersistence.UpdateBook(Book);


            return result;
        }
    }
}