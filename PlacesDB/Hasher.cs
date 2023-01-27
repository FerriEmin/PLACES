using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDB
{
    public static class Hasher
    {
        const int KeySize = 64;
        const int Iterations = 350000;

        public static byte[] GenerateSalt(string? input = null)
        {
            if (string.IsNullOrEmpty(input))
                return RandomNumberGenerator.GetBytes(KeySize);

            return Convert.FromHexString(input);
        }

        public static string HashPassword(string password, byte[] salt)
        {
            /* Pbkdf2 is the official standard key-derivation password hashing algorithm in .NET
             * Although BCrypt/SCrypt would have been preferable, no verified IMPLEMENTATION can be found
             */

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                Iterations,
                HashAlgorithmName.SHA512,
                KeySize
            );

            return $"{Convert.ToHexString(hash)}{Convert.ToHexString(salt)}";
        }

        public static bool PasswordVerify(string password, string hash)
        {
            // Salt will always be the half of password column regardless of keysize
            byte[] salt = GenerateSalt(hash.Substring(hash.Length / 2, hash.Length / 2));
            return hash.SequenceEqual(Hasher.HashPassword(password, salt));
        }
    }
}
