using System;
using System.Security.Cryptography;
using System.Text;
namespace ChoppyChores.models
{
    public class Account
    {
        private String id;
        private AccountType accountType;
        private String username;
        private String password;

        public String GetID()
        {
            return id;
        }

        public String GetUsername()
        {
            return username;
        }

        public String GetPassword()
        {
            return password;
        }

        public void ResetPassword(String rawPassword)
        {
            password = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(rawPassword)).ToString();
            // Add Saving
        }

        public Account(AccountType type, String username, String password)
        {
            accountType = type;
            this.username = username;
            this.password = password;
            // Add ID
        }

        public Object fromString(String toParse)
        {
            return null;
        }
    }
}
