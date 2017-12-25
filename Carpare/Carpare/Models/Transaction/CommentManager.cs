using Carpare.Models.Entity;
using Carpare.Models.Repository;
using System.Collections.Generic;

namespace SqliteDemo.Models.Transaction
{
    /// <summary>
    /// Handles the transactions about comments.
    /// </summary>
    public class CommentManager
    {

        /// <summary>
        /// Gets users comments.
        /// </summary>
        /// <param name="UserId">User that wants to see his/her comments.</param>
        /// <returns>Comments that user enters to cars.</returns>
        public static Comment[] GetUserComments(string UserId)
        {
            Comment[] comments = CommentPersistence.GetUserComment(UserId);

            return comments;
        }

        /// <summary>
        /// Gets car's comments which is selected by user.
        /// </summary>
        /// <param name="CarId">Car which user wants to look at its comments.</param>
        /// <returns>Comments that entered to this car.</returns>
        public static Comment[] GetCarComments(int CarId)
        {
            Comment[] comments = CommentPersistence.GetCarComment(CarId);

            return comments;
        }


        /// <summary>
        /// Adds the comment into the database.
        /// </summary>
        /// <param name="newComment">Comment that wanted to be added.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        public static bool AddNewComment(Comment newComment)
        {
           return CommentPersistence.AddComment(newComment);
        }

        /// <summary>
        /// Deletes the comment with given commentId.
        /// </summary>
        /// <param name="commentId">Comment that is wanted to be deleted.</param>
        /// <returns>Boolean value whether the transaction is happened or not.</returns>
        public static bool DeleteComment(string commentId)
        {
            bool result = CommentPersistence.DeleteComment(commentId);
            return result;
        }
    }
}