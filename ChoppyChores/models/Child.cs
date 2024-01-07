using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ChoppyChores.data;

namespace ChoppyChores.models
{
    public class Child : Account
    {
        private int _age;
        private int _points;
        private List<string> _chores; //Stores Chore ID
        private List<string> _rewards; //Stores Reward IDs
        
        public Child(string username, string password, int age, int points, List<string> chores, List<string> rewards) : base(AccountType.Child, username, password)
        {
            this._age = age;
            this._points = points;
            this._chores = chores;
            this._rewards = rewards;
        }

        public override void Save()
        {
            var lineToEdit = -1;

            DataFileHandler.Instance.RunReader(StorageFiles.Accounts, reader =>
            {
                var iteration = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var split = line.Split(';');

                    if (split[0].Equals(GetId()))
                    {
                        lineToEdit = iteration;
                    }

                    iteration++;
                }
            });
            //
            // string parsedChores = "", parsedRewards = "";
            // var i = 0;
            // foreach (var chore in _chores)
            // {
            //     
            //     if (i == _chores.Count - 1)
            //     {
            //         parsedChores += chore;
            //         break;
            //     }
            //     parsedChores += chore + "+";
            //     i++;
            // }
            //
            // i = 0;
            // foreach (var reward in _rewards)
            // {
            //     if (i == _rewards.Count - 1)
            //     {
            //         parsedRewards += reward;
            //         break;
            //     }
            //     parsedRewards += reward + "+";
            //     i++;
            // }
            
            var lines = new List<string>();

            DataFileHandler.Instance.RunReader(StorageFiles.Accounts, reader =>
            {
                lines = reader.ReadToEnd().Split('\n').ToList();
            });
            
            DataFileHandler.Instance.RunWriter(StorageFiles.Accounts, accountFile =>
            {
                if (lineToEdit == -1)
                {
                    var line = GetId() + ";" + AccountType.Child + ";" + GetUsername() + ";" + GetPassword() + ";" +
                               _age + ";" + _points + ";" + string.Join("+", _chores) + ";" + string.Join("+", _rewards);
                    // Add new line to the end of the file
                    accountFile.WriteLine(line);
                    Console.WriteLine(line);
                }
                else
                {
                    // Ovewrite the iteration line with the new data
                    
                    lines[lineToEdit] = GetId() + ";" + AccountType.Child + ";" + GetUsername() + ";" + GetPassword() + ";" + _age + ";" + _points + ";" + string.Join("+", _chores) + ";" + string.Join("+", _rewards);
                    accountFile.Write(string.Join("\n", lines));
                }
            });
        }
    }
}
