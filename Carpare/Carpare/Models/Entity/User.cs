using Carpare.Models.Transaction;

namespace Carpare.Models.Entity
{
    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Salt { get; set; }
        public string email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public string status { get; set; }
        public string gender { get; set; }
        public string BirthDate { get; set; }
        public string Location { get; set; }

        /// <summary>
        /// Empty constructor for User
        /// </summary>
        public User()
        {
            UserId = "";
            Name = "";
            Salt = "";
            PasswordHash = "";
            email = "";
            IsAdmin = false;
        }

        /// <summary>
        /// Constructor for User
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Name"></param>
        /// <param name="Salt"></param>
        /// <param name="HashedPassword"></param>
        /// <param name="email"></param>
        /// <param name="IsAdmin"></param>
        /// <param name="stat"></param>
        /// <param name="gender"></param>
        /// <param name="date"></param>
        /// <param name="loc"></param>
        public User(string UserId, string Name, string Salt, string HashedPassword, string email, bool IsAdmin, string stat, string gender, string date, string loc)
        {
            this.UserId = UserId;
            this.Name = Name;
            this.Salt = Salt;
            PasswordHash = HashedPassword;
            this.email = email;
            this.IsAdmin = IsAdmin;
            status = stat;
            this.gender = gender;
            BirthDate = date;
            Location = loc;
        }

        /// <summary>
        /// Salt for encryption
        /// </summary>
        /// <returns></returns>
        public static string CreateSalt()
        {
            return EncryptionManager.PasswordSalt;
        }

        /// <summary>
        /// To String method
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            string returnString = "Username: " + UserId + " Name: " + Name + " E-mail: " + email + " IsAdmin: " + IsAdmin + " Status: " + status + " Gender: " + gender
                + " Date: " + BirthDate + " Location: " + Location;
            return returnString;
        }
    }
}