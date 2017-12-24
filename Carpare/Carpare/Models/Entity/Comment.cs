using System;

namespace Carpare.Models.Entity
{
    public class Comment
    {
        public int commentId { get; set; }
        public int carId { get; set; }
        public String UserId { get; set; }
        public String comment { get; set; }

        public Comment()
        {

        }

        public Comment(int commentId, int carId, String UserId, String comment)
        {
            this.commentId = commentId;
            this.carId = carId;
            this.UserId = UserId;
            this.comment = comment;
        }

        public String toString()
        {
            return "Comment Id: " + commentId + ", carId: " + carId + ", UserId: " + UserId + ",Comment: " + comment;
        }

        public bool Equals(Comment other)
        {
            return (this.commentId == other.commentId);
        }
    }
}