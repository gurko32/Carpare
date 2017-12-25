using System;
using System.Security.Cryptography;
using System.Text;


namespace Carpare.Models.Transaction
{
    /// <summary>
    /// Handles the encryptions for creating password hash.
    /// </summary>
    public class EncryptionManager
    {
        /// <summary>
        /// Generate a random salt value.
        /// </summary>
        public static string PasswordSalt
        {
            get
            {
                var rng = new RNGCryptoServiceProvider();
                var buff = new byte[32];
                rng.GetBytes(buff);
                return Convert.ToBase64String(buff);
            }
        }

        
        /// <summary>
        /// Hash a password to protect the password in case of database attacks.
        /// </summary>
        /// <param name="password">Password that wanted to be hashed.</param>
        /// <param name="salt">The salt value which will be used to encode.</param>
        /// <returns>The string that is encoded.</returns>
        public static string EncodePassword(string password, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inarray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inarray);
        }
    }
}