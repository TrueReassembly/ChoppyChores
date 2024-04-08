using System;
using System.Security.Cryptography;
using System.Text;

namespace ChoppyChores.utils
{
    public class GeneralUtils
    {
        /**
         * Hashes a string using SHA-256
         * @param str The string to hash
         * @return The hashed string
         */
        public static string ComputeHash(string str)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "").ToLower();
        }
    }
}