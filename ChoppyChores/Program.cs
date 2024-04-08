using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ChoppyChores.data;
using ChoppyChores.forms.loginpage;
using ChoppyChores.forms.parent.chores;
using ChoppyChores.models;
using ChoppyChores.utils;


namespace ChoppyChores
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // If Data files do not exist, create them
            if (!File.Exists("./storage/Accounts.txt") || !File.Exists("./storage/Chores.txt") || !File.Exists("./storage/Rewards.txt") || !File.Exists("./storage/PendingRewards.txt"))
            {
                Directory.CreateDirectory("./storage");
                File.Create("./storage/Accounts.txt").Close();
                File.Create("./storage/Chores.txt").Close();
                File.Create("./storage/Rewards.txt").Close();
                File.Create("./storage/PendingRewards.txt").Close();
            }

            // If there are no accounts, open the form to create the first account
            List<Account> accounts = DataFileHandler.Instance.GetAllAccounts();
            if (accounts.Count == 0)
            {
                Application.Run(new FirstAccountPage());
                return;
            }

            // If there is a parent account, open the login page, otherwise open the first account page
            foreach(var account in accounts)
            {
                if (account.GetAccountType() == AccountType.Parent)
                {
                    Application.Run(new LoginPage());
                    return;
                }
            }
            

            Application.Run(new FirstAccountPage());

        }
    }
}
