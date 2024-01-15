using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChoppyChores.models;
using ChoppyChores.utils;

namespace ChoppyChores.data
{
    internal class DataFileHandler
    {
        private static DataFileHandler _instance = null;
        private const string AccountsFile = "./storage/Accounts.txt";
        private const string ChoresFile = "./storage/Chores.txt";
        private const string RewardsFile = "./storage/Rewards.txt";

        public enum ChoreSort
        {
            Name,
            Cost,
            Age
        }
        
        public static DataFileHandler Instance => _instance ?? (_instance = new DataFileHandler());

        public Child GetChildById(String id)
        {
            
            Child child = null;
            
            RunReader(StorageFiles.Accounts, accountFile =>
            {
                while (!accountFile.EndOfStream)
                {
                    string line = accountFile.ReadLine();
                    string[] split = line.Split(';');

                    if (split[0].Equals(id))
                    {
                        child = line.ToChild();
                        // child = new Child(split[1], split[2],  int.Parse(split[3]), int.Parse(split[4]),   split[5].Split('+').ToList(), split[6].Split('+').ToList());
                    }
                }
            });
            return child;
        }

        public int FindNewId()
        {
            Int32 id = 0;
            string[] lines = null;
            var random = new Random();
            RunReader(StorageFiles.Accounts, accountFile =>
            {
                lines = accountFile.ReadToEnd().Split('\n');
            });
            bool idExists = true;
            while (idExists)
            {
                id = random.Next(100, 999);
                idExists = lines.Any(line => line.Split(';')[0].Equals(id.ToString()));
            }
            return id;
        }

        /**
         * Runs a reader on the specified file
         * @param file The file to read from
         * @param callback The code to run on the reader
         */
        public void RunReader(StorageFiles file, Action<StreamReader> callback)
        {
            switch (file)
            {
                case StorageFiles.Accounts:
                    var accountReader = File.OpenText(AccountsFile);
                    callback(accountReader);
                    accountReader.Close();
                    break;
                case StorageFiles.Chores:
                    var choreReader = File.OpenText(ChoresFile);
                    callback(choreReader);
                    choreReader.Close();
                    break;
                case StorageFiles.Rewards:
                    var rewardReader = File.OpenText(RewardsFile);
                    callback(rewardReader);
                    rewardReader.Close();
                    break;
                default:
                    callback(null);
                    break;
            }
        }

        /**
         * Runs a writer on the specified file
         * @param file The file to write to
         * @param callback The code to run on the writer
         */
        public void RunWriter(StorageFiles file, Action<StreamWriter> callback)
        {
            switch (file)
            {
                case StorageFiles.Accounts:
                    var accountWriter = File.AppendText(AccountsFile);
                    callback(accountWriter);
                    accountWriter.Close();
                    break;
                case StorageFiles.Chores:
                    var choreWriter = File.AppendText(ChoresFile);
                    callback(choreWriter);
                    choreWriter.Close();
                    break;
                case StorageFiles.Rewards:
                    var rewardWriter = File.AppendText(RewardsFile);
                    callback(rewardWriter);
                    rewardWriter.Close();
                    break;
                default:
                    callback(null);
                    break;
            }
        }
        
        public void sort
    }
}
