using Carpare.Models.Entity;
using Carpare.Models.Repository;
using System.Collections.Generic;

namespace SqliteDemo.Models.Transaction
{
    public class CommentManager
    {
        /// <summary>
        /// Returns every comment
        /// </summary>
        /// <returns></returns>
        public static Comment[] GetAllComments()
        {
            List<Comment> comments = CommentPersistence.GetAllComments();
            if (comments != null)
            {
                return CommentPersistence.GetAllComments().ToArray();
            }
            else
            {
                return (new Comment[0]);
            }
        }

        /// <summary>
        /// Gets users comments
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static Comment[] GetUserComments(string UserId)
        {
            Comment[] comments = CommentPersistence.GetUserComment(UserId);

            return comments;
        }

        /// <summary>
        /// Gets car's comments
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        public static Comment[] GetCarComments(int CarId)
        {
            Comment[] comments = CommentPersistence.GetCarComment(CarId);

            return comments;
        }


        /// <summary>
        /// Adds the comment
        /// </summary>
        /// <param name="newComment"></param>
        /// <returns></returns>
        public static bool AddNewComment(Comment newComment)
        {
            Comment oldComment = CommentPersistence.getComment(newComment);
            if (oldComment != null)
            {
                return false;
            }

            return CommentPersistence.AddComment(newComment);
        }

        /// <summary>
        /// Deletes the comment with given commentId
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public static bool DeleteComment(string commentId)
        {
            bool result = CommentPersistence.DeleteComment(commentId);
            return result;
        }
    }
}