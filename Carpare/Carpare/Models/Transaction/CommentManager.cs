using Carpare.Models.Entity;
using Carpare.Models.Repository;
using System.Collections.Generic;

namespace SqliteDemo.Models.Transaction
{
    public class CommentManager
    {

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
        public static Comment[] GetUserComments(string UserId)
        {
            Comment[] comments = CommentPersistence.GetUserComment(UserId);

            return comments;
        }

        public static Comment[] GetCarComments(int CarId)
        {
            Comment[] comments = CommentPersistence.GetCarComment(CarId);

            return comments;
        }


        /*
         * Transaction: Add a new book to the database
         * Returns true iff the new book has a unique ISBN
         * and it was successfully added.
         */
        public static bool AddNewComment(Comment newComment)
        {
            // Verify that the book doesn't already exist
            Comment oldComment = CommentPersistence.getComment(newComment);
            // oldBook should be null, if this is a new book
            if (oldComment != null)
            {
                return false;
            }

            return CommentPersistence.AddComment(newComment);
        }

        public static bool DeleteComment(string commentId)
        {
            bool result = CommentPersistence.DeleteComment(commentId);
            return result;
        }

        /*
         * Transaction: Update a book in the database
         * Returns true iff the book exists in the database and
         * it was successfully changed.
         */
        public static bool ChangeComment(Comment comment)
        {
            if (comment == null)
            {
                return false;
            }
            bool result = CommentPersistence.UpdateComment(comment);


            return result;
        }
    }
}