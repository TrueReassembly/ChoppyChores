using ChoppyChores.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoppyChores.models
{
    class Parent : Account
    {

        public Parent(string username, string password) : base(AccountType.Parent, username, password) { }
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

            var lines = new List<string>();

            DataFileHandler.Instance.RunReader(StorageFiles.Accounts, reader =>
            {
                lines = reader.ReadToEnd().Split('\n').ToList();
            });

            DataFileHandler.Instance.RunWriter(StorageFiles.Accounts, accountFile =>
            {
                if (lineToEdit == -1)
                {
                    var line = GetId() + ";" + AccountType.Parent + ";" + GetUsername() + ";" + GetPassword();
                    // Add new line to the end of the file
                    accountFile.WriteLine(line);
                    Console.WriteLine(line);
                }
                else
                {
                    // Ovewrite the iteration line with the new data

                    lines[lineToEdit] = GetId() + ";" + AccountType.Child + ";" + GetUsername() + ";" + GetPassword();
                    accountFile.Write(string.Join("\n", lines));
                }
            });
        }
    }
}
