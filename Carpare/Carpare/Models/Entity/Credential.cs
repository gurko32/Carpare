namespace Carpare.Models.Entity
{
    /// <summary>
    /// This class is used for login or signup credentials.
    /// </summary>
    public class Credential
    {
        /// <summary>
        /// User ID for the new user.
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Password for the new user.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// E-Mail for the new user.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Name for the new user.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gender for the new user.
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// Birth date for the new user.
        /// </summary>
        public string BirthDate { get; set; }
        /// <summary>
        /// Location for the new user.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Initializes an empty credential.
        /// </summary>
        public Credential()
        {
            UserId = "";
            Password = "";
            Email = "";
            Name = "";
        }
    }
}