using ChoppyChores.data;
using ChoppyChores.utils;

namespace ChoppyChores.models
{
    public abstract class Account
    {
        private string _id;
        private readonly AccountType _accountType;
        private string _username;
        private string _password;

        // Getters and Setters for the Account class
        public string GetId()
        {
            return _id;
        }

        public void SetId(string id)
        {
            _id = id;
        }

        public string GetUsername()
        {
            return _username;
        }

        public void SetUsername(string name)
        {
            _username = name;
        }

        public string GetPassword()
        {
            return _password;
        }

        public void SetPassword(string password)
        {
            _password = password;
        }

        /**
         * Reset the password for the account and hashes it
         * @param rawPassword The new password
         */
        public void ResetPassword(string rawPassword)
        {
            _password = GeneralUtils.ComputeHash(rawPassword);
        }
        
        /**
         * Constructor for the Account class
         * @param type The type of account
         * @param username The username for the account
         * @param password The password for the account
         */
        protected Account(AccountType type, string username, string password)
        {
            _accountType = type;
            _username = username;
            _password = GeneralUtils.ComputeHash(password);
            _id = DataFileHandler.Instance.FindNewId(StorageFiles.Accounts).ToString();
        }
        
        /**
         * Constructor for the Account class
         * @param type The type of account
         * @param id The ID of the account
         * @param username The username for the account
         * @param password The password for the account
         */
        protected Account(AccountType type, string id, string username, string password)
        {
            _accountType = type;
            _username = username;
            _password = password;
            _id = id;
        }
        
        /**
         * Get the type of account
         * @return The type of account
         */
        public AccountType GetAccountType()
        {
            return _accountType;
        }

        /**
         * Save the account to the data file
         */
        public abstract void Save();
    }
}
