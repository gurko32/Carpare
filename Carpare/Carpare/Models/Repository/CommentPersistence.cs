using System;
using System.Collections.Generic;
using Carpare.Models.Entity;
using System.Diagnostics;

namespace Carpare.Models.Repository
{
    public class CommentPersistence
    {
        /// <summary>
        /// Returns the comment from database
        /// </summary>
        /// <param name="keyComment"></param>
        /// <returns></returns>
        public static Comment getComment(Comment keyComment)
        {
            string sqlQuery = "select * from comment where commentId=" + keyComment.commentId;
            List<object[]> rows = RepositoryManager.Repository.DoQuery(sqlQuery);
            if (rows.Count == 0)
            {
                return null;
            }
            object[] dataRow = rows[0];
            Comment comment = new Comment(Int32.Parse(dataRow[0].ToString()), Int32.Parse(dataRow[1].ToString()), (string)dataRow[2], (string)dataRow[3]);
            return comment;
        }

        /// <summary>
        /// Gets the user comment from the database
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
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
        /// Returns every comment for choosen car 
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
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
        /// Adds the comment to database
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletes the comment from database
        /// </summary>
        /// <param name="CommentId"></param>
        /// <returns></returns>
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
        /// Gets every comment
        /// </summary>
        /// <returns></returns>
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