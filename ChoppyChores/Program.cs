using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ChoppyChores.data;
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
            if (!File.Exists("./storage/Accounts.txt"))
            {
                Directory.CreateDirectory("./storage");
                File.Create("./storage/Accounts.txt").Close();
                File.Create("./storage/Chores.txt").Close();
                File.Create("./storage/Rewards.txt").Close();
            }

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

            new Child("child1", "child1", 15, 10, chores, rewards).Save();
            new Child("child2", "child2", 10, 20, chores, rewards).Save();
            new Child("child3", "child3", 5, 30, chores, rewards).Save();
            foreach (var child in DataFileHandler.Instance.GetAllChildren())
            {
                Console.WriteLine(child.ToString());              
            }

            Console.WriteLine("-----------------------");
            Application.Run(new LoginPage());

        }
    }
}
