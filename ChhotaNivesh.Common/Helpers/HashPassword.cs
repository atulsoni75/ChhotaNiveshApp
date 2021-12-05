using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace ChhotaNivesh.Common.Helpers
{
    public static class HashPassword
    {
        /// <summary>
        /// Use into Register when new password hash generating using salt
        /// </summary>
        public static (string,string) GenerateNewPassword(string password)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            
            string passwordSalt = Convert.ToBase64String(salt);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string passwordHashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return (passwordSalt, passwordHashed);
        }

        /// <summary>
        /// Use for login to compare hash password with stored salt
        /// </summary>
        public static string GenerateHashPasswordToCompare(string password, string passwordSalt)
        {
            var salt = Convert.FromBase64String(passwordSalt);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string passwordHashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return passwordHashed;
        }
    }
}
