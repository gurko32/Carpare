using System;
using System.Collections.Generic;
using Carpare.Models.Entity;
using System.Diagnostics;

namespace Carpare.Models.Repository
{
    public class CommentPersistence
    {
        /*
         * Retrieve from the database the book matching the ISBN field of
         * the parameter.
         * Return null if the book can't be found.
         */
        public static Comment getComment(Comment keyComment)
        {
            string sqlQuery = "select * from comment where commentId=" + keyComment.commentId;
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            //System.Console.WriteLine("$$rows: " + rows.Count);
            if (rows.Count == 0)
            {
                return null;
            }

            // Use the data from the first returned row (should be the only one) to create a Book.
            object[] dataRow = rows[0];
            //DateTime dateAdded = DateTime.Parse(dataRow[2].ToString());
            Comment comment = new Comment(Int32.Parse(dataRow[0].ToString()), Int32.Parse(dataRow[1].ToString()), (string)dataRow[2], (string)dataRow[3]);
            return comment;
        }
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
        /*
         * Add a Book to the database.
         * Return true iff the add succeeds.
         */
        public static bool AddComment(Comment comment)
        {
            string sql = "select max(CommentId) AS num from comment;";
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sql);
            sql = "select * from comment";
            List<object[]> rows2 = RepositoryManager.Repository.DoQuery(sql);

            if (rows2.Count == 0)
            {
                comment.commentId = 1000;
            }
            else
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

        internal static bool DeleteComment(Comment delComment)
        {
            throw new NotImplementedException();
        }

        /*
         * Update a book that is in the database, replacing all field values except
         * the key field.
         * Return false if the book is not found, based on key field match.
         */
        public static bool UpdateComment(Comment comment)
        {
            return true;
        }

        /*
         * Get all Book data from the database and return an array of Books.
         */
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