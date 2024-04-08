using ChoppyChores.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoppyChores.models
{
    
    // The Parent class, we do not need any extra information for the parent because the account class already has the necessary information
    public class Parent : Account
    {

        /**
         * Constructor for the Parent class
         * @param username The username of the parent
         * @param password The password of the parent
         */
        public Parent(string username, string password) : base(AccountType.Parent, username, password) { }
        
        /**
         * Constructor for the Parent class
         * @param id The id of the parent
         * @param username The username of the parent
         * @param password The password of the parent
         */
        public Parent(string id, string username, string password) : base(AccountType.Parent, id, username, password) { }
        
        // Save the parent to the file
        public override void Save()
        {
            var lineToEdit = -1;

            // Find the line to edit
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

            // Get all the lines from the file separated by new line and add them to the list "lines"
            DataFileHandler.Instance.RunReader(StorageFiles.Accounts, reader =>
            {
                lines = reader.ReadToEnd().Split('\n').ToList();
            });

            // If the line to edit is -1, add a new line to the end of the file with the new data, otherwise overwrite the iteration line with the new data
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
