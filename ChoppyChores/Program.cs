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
            if (!File.Exists("./storage/Accounts.txt"))
            {
                Directory.CreateDirectory("./storage");
                File.Create("./storage/Accounts.txt").Close();
                File.Create("./storage/Chores.txt").Close();
                File.Create("./storage/Rewards.txt").Close();
            }

            
            
            Application.Run(new LoginPage());
        }
    }
}
