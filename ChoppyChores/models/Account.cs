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

        public void ResetPassword(string rawPassword)
        {
            _password = GeneralUtils.ComputeHash(rawPassword);
        }
        
        protected Account(AccountType type, string username, string password)
        {
            _accountType = type;
            _username = username;
            _password = GeneralUtils.ComputeHash(password);
            _id = DataFileHandler.Instance.FindNewId(StorageFiles.Accounts).ToString();
        }
        
        protected Account(AccountType type, string id, string username, string password)
        {
            _accountType = type;
            _username = username;
            _password = password;
            _id = id;
        }
        
        public AccountType GetAccountType()
        {
            return _accountType;
        }

        public abstract void Save();
    }
}
