using System;
using System.IO;
using ChoppyChores.models;

namespace ChoppyChores.data
{
    class DataFileHandler
    {


        private readonly StreamReader AccountFile = File.OpenText("Accounts.txt");
        private readonly StreamReader ChoreFile = File.OpenText("Chores.txt");
        private readonly StreamReader RewardsFile = File.OpenText("Rewards.txt");

        
        public Child GetChildByID(String id)
        {

            return null;

            while (!AccountFile.EndOfStream)
            {

            }
        }

        public bool IdExists(String id)
        {
            while (!AccountFile.EndOfStream)
            {
                string line = AccountFile.ReadLine();
                string[] split = line.Split(';');

                if (split[0].Equals(id)) return true;
            }

            return false;
        }
    }
}
