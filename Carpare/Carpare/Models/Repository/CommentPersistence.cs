using System;
using System.Collections.Generic;
using Carpare.Models.Entity;
using System.Diagnostics;

namespace Carpare.Models.Repository
{
    /// <summary>
    /// Handles the database queries and commands for the comment transactions.
    /// </summary>
    public class CommentPersistence
    {
        /// <summary>
        /// Gets the user comments from the database.
        /// </summary>
        /// <param name="UserId">User which wants his/her comments.</param>
        /// <returns>Array of Comments which is found from the database.</returns>
        public static Comment[] GetUserComment(string UserId)
        {
            string sqlQuery = "select * from comment where UserId='" + UserId + "';";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);

            if (rows.Count == 0)
            {
                return null;
            }

            Comment[] comments = new Comment[rows.Count];
            object[] dataRow;

            for (int i = 0; i < rows.Count; i++)
            {
                dataRow = rows[i];
                Comment comment = new Comment(Int32.Parse(dataRow[0].ToString()), Int32.Parse(dataRow[1].ToString()), (string)dataRow[2], (string)dataRow[3]);
                comments[i] = comment;
            }
            return comments;

        }

        /// <summary>
        /// Returns every comment for chosen car.
        /// </summary>
        /// <param name="CarId">Car that user wants to see its comments.</param>
        /// <returns>Array of comments which is entered for that car.</returns>
        public static Comment[] GetCarComment(int CarId)
        {
            string sqlQuery = "select * from comment where carId='" + CarId + "';";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);

            if (rows.Count == 0)
            {
                return null;
            }

            Comment[] comments = new Comment[rows.Count];
            object[] dataRow;

            for (int i = 0; i < rows.Count; i++)
            {
                dataRow = rows[i];
                Comment comment = new Comment(Int32.Parse(dataRow[0].ToString()), Int32.Parse(dataRow[1].ToString()), (string)dataRow[2], (string)dataRow[3]);
                comments[i] = comment;
            }
            return comments;

        }

        /// <summary>
        /// Adds the comment into database.
        /// </summary>
        /// <param name="comment">Comment which is wanted to be added.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        public static bool AddComment(Comment comment)
        {
            string sql = "select max(CommentId) AS num from comment;";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sql);
            sql = "select * from comment";
            List<object[]> rows2 = RepositoryManager.Repository.DoQuery(sql);

            if (rows2.Count == 0) // If there is no comment found in the database, start the comment ID from 1000.
            {
                comment.commentId = 1000;
            }
            else // Else, find the max value for the CommentId which is in the database, add 1 to it and assign it to the new comment.
            {
                comment.commentId = Int32.Parse(rows[0][0].ToString()) + 1;
            }

            sql = "insert into comment (CommentId, carId, UserId,Text) values ("
                + comment.commentId + ", "
                + comment.carId + ", '"
                + comment.UserId + "', '"
                + comment.comment + "')";
            RepositoryManager.Repository.DoCommand(sql);
            return true;
        }
        /// <summary>
        /// Deletes that comments if the car is deleted.
        /// </summary>
        /// <param name="carId">Car that is deleted from the database.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        internal static bool DeleteCommentFromCarID(string carId)
        {
            string sql = "delete from comment where carId = " + carId + ";";
            int result = RepositoryManager.Repository.DoCommand(sql);
            if (result == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Deletes the comment from the database.
        /// </summary>
        /// <param name="CommentId">Comment ID that is wanted to be deleted.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        internal static bool DeleteComment(string CommentId)
        {
            string sql = "delete from comment where commentId = " + CommentId + ";";
            int result = RepositoryManager.Repository.DoCommand(sql);
            if (result == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Gets all the comments from the database.
        /// </summary>
        /// <returns>List of comments that contains all comments in the database.</returns>
        public static List<Comment> GetAllComments()
        {
            List<Comment> comments = new List<Comment>();

            string sqlQuery = "select * from comment";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);

            foreach (object[] dataRow in rows)
            {
                Comment comment = new Comment(Int32.Parse(dataRow[0].ToString()), Int32.Parse(dataRow[1].ToString()), (string)dataRow[2], (string)dataRow[3]);
                Debug.WriteLine(comment.toString());
                comments.Add(comment);
            }
            return comments;
        }
    }
}