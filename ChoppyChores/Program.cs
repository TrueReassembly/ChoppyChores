using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            // Create test data
            
            var chores = "chore1+chore2+chore3".Split('+').ToList();
            var rewards = "reward1+reward2+reward3".Split('+').ToList();
            var child = new Child("test1", "test1", 10, 0, chores, rewards);
            child.Save();
            child = new Child("test2", "test2", 10, 0, chores, rewards);
            child.Save();
            child = new Child("test3", "test3", 10, 0, chores, rewards);
            child.Save();

            DataFileHandler.Instance.RunReader(StorageFiles.Accounts, reader =>
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    Console.WriteLine(line.ToChild());
                }
            });
            
            Application.Run(new LoginPage());
        }
    }
}
