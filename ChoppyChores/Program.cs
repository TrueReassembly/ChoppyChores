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

            Application.Run(new LoginPage());

            // Create list of template chores and rewards
            List<string> chores = new List<string>();
            chores.Add("Take out the trash");
            chores.Add("Wash the dishes");
            chores.Add("Clean your room");
    
            List<string> rewards = new List<string>();
            rewards.Add("Ice cream");
            rewards.Add("Movie night");
            rewards.Add("Trip to the park");
            
            new Child("child1", "child1", 15, 10, chores, rewards).Save();
            new Child("child2", "child2", 10, 20, chores, rewards).Save();
            new Child("child3", "child3", 5, 30, chores, rewards).Save();
            foreach (var child in DataFileHandler.Instance.GetAllChildren())
            {
                Console.WriteLine(child.ToString());              
            }

            Console.WriteLine("-----------------------");
            
        }
    }
}
