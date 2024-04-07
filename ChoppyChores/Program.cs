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

            // Create list of template chores and rewards
            List<string> chores = new List<string>
            {
                "Take out the trash",
                "Wash the dishes",
                "Clean your room"
            };

            List<string> rewards = new List<string>
            {
                "Ice cream",
                "Movie night",
                "Trip to the park"
            };

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

            List<Account> accounts = DataFileHandler.Instance.GetAllAccounts();
            if (accounts.Count == 0)
            {
                Application.Run(new FirstAccountPage());
                return;
            }

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
