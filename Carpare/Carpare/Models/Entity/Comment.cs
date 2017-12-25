using System;

namespace Carpare.Models.Entity
{
    /// <summary>
    /// Represents the comments which is entered by users.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// ID of the comment.
        /// </summary>
        public int commentId { get; set; }
        /// <summary>
        ///Car that is commented.
        /// </summary>
        public int carId { get; set; }
        /// <summary>
        /// User that entered the comment.
        /// </summary>
        public String UserId { get; set; }
        /// <summary>
        /// Comment itself.
        /// </summary>
        public String comment { get; set; }
        
        /// <summary>
        /// Initializes an empty comment.
        /// </summary>
        public Comment()
        {

        }

        /// <summary>
        /// Initializes a comment.
        /// </summary>
        /// <param name="commentId">ID of the comment.</param>
        /// <param name="carId">Car ID to determine which car is commented.</param>
        /// <param name="UserId">User that entered the comment.</param>
        /// <param name="comment">Comment itself.</param>
        public Comment(int commentId, int carId, String UserId, String comment)
        {
            this.commentId = commentId;
            this.carId = carId;
            this.UserId = UserId;
            this.comment = comment;
        }

        /// <summary>
        /// Returns a string which contains the important information about the comment for debug purposes.
        /// </summary>
        /// <returns>The string for printing the information on output.</returns>
        public String toString()
        {
            return "Comment Id: " + commentId + ", carId: " + carId + ", UserId: " + UserId + ",Comment: " + comment;
        }
    }
}