using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ChoppyChores.data;
using ChoppyChores.utils;

namespace ChoppyChores.models
{
    public abstract class Account
    {
        private readonly string _id;
        private readonly AccountType _accountType;
        private readonly string _username;
        private string _password;

        public string GetId()
        {
            return _id;
        }

        public string GetUsername()
        {
            return _username;
        }

        public string GetPassword()
        {
            return _password;
        }

        public void ResetPassword(string rawPassword)
        {
            _password = GeneralUtils.ComputeHash(rawPassword);
            // Add Saving
        }
        
        protected Account(AccountType type, string username, string password)
        {
            _accountType = type;
            this._username = username;
            this._password = GeneralUtils.ComputeHash(password);
            _id = DataFileHandler.Instance.FindNewId().ToString();
        }
        
        protected Account(AccountType type, string id, string username, string password)
        {
            _accountType = type;
            _username = username;
            _password = password;
            _id = id;
        }
        
        public abstract void Save();
    }
}
