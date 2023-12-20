using System;
using System.IO;
using System.Windows.Forms;

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
            if (File.Exists("Accounts.txt")) File.CreateText("Accounts.txt").Close();
            if (File.Exists("Chores.txt")) File.CreateText("Chores.txt").Close();
            if (File.Exists("Rewards.txt")) File.CreateText("Rewards.txt").Close();
            Application.Run(new LoginPage());
        }
    }
}
