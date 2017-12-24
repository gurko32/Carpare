using System;

namespace Carpare.Models.Entity
{
    public class Comment
    {
        public int commentId { get; set; }
        public int carId { get; set; }
        public String UserId { get; set; }
        public String comment { get; set; }
        
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Comment()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="carId"></param>
        /// <param name="UserId"></param>
        /// <param name="comment"></param>
        public Comment(int commentId, int carId, String UserId, String comment)
        {
            this.commentId = commentId;
            this.carId = carId;
            this.UserId = UserId;
            this.comment = comment;
        }

        /// <summary>
        /// To String
        /// </summary>
        /// <returns></returns>
        public String toString()
        {
            return "Comment Id: " + commentId + ", carId: " + carId + ", UserId: " + UserId + ",Comment: " + comment;
        }
    }
}