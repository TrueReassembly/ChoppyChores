using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ChoppyChores.data;
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
            if (!File.Exists("./storage/Accounts.txt"))
            {
                Directory.CreateDirectory("./storage");
                File.Create("./storage/Accounts.txt").Close();
                File.Create("./storage/Chores.txt").Close();
                File.Create("./storage/Rewards.txt").Close();

                new Chore(DataFileHandler.Instance.FindNewId(StorageFiles.Chores), chores[0], 5, true, 5).Save();
                new Chore(DataFileHandler.Instance.FindNewId(StorageFiles.Chores), chores[1], 10, true, 10).Save();
                new Chore(DataFileHandler.Instance.FindNewId(StorageFiles.Chores), chores[2], 15, true, 15).Save();

                new Child("Jim", "Jim123", 10).Save();
                new Child("Bob", "Bob123", 12).Save();
                new Child("Sue", "Sue123", 14).Save();
            }

            

            
            foreach (var child in DataFileHandler.Instance.GetAllChildren())
            {
                Console.WriteLine(child.ToString());              
            }

            Console.WriteLine("-----------------------");
            Application.Run(new ChildViewChoresPage());

        }
    }
}
