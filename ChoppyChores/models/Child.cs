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
        
        /**
         * Constructor for the Child class
         * @param username The username of the child
         * @param password The password of the child
         * @param age The age of the child
         * @param points The points the child has
         */
        public Child(string username, string password, int age, int points) : base(AccountType.Child, username, password)
        {
            _age = age;
            _points = points;
        }

        /**
         * Constructor for the Child class
         * @param username The username of the child
         * @param password The password of the child
         * @param age The age of the child
         */
        public Child(string username, string password, int age) : base(AccountType.Child, username, password)
        {
            _age = age;
            _points = 0;
        }

        /**
         * Constructor for the Child class
         * @param id The id of the child
         * @param username The username of the child
         * @param password The password of the child
         * @param age The age of the child
         * @param points The points the child has
         */
        public Child(string id, string username, string password, int age, int points) : base(AccountType.Child, id, username, password)
        {
            _age = age;
            _points = points;
        }

        // Save the child to the file
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

            // Read all the lines from the file, splitting them by new line and adding them to the list "lines"
            DataFileHandler.Instance.RunReader(StorageFiles.Accounts, reader =>
            {
                lines = reader.ReadToEnd().Split('\n').ToList();
            });
            
            // Write the new data to the file
            DataFileHandler.Instance.RunWriter(StorageFiles.Accounts, accountFile =>
            {
                if (lineToEdit == -1)
                {
                    // Create a new line with the child data
                    var line = GetId() + ";" + AccountType.Child + ";" + GetUsername() + ";" + GetPassword() + ";" +
                               _age + ";" + _points;
                    Console.WriteLine(line);
                }
                else
                {
                    // Ovewrite the iteration line with the new data
                    
                    lines[lineToEdit] = GetId() + ";" + AccountType.Child + ";" + GetUsername() + ";" + GetPassword() + ";" + _age + ";" + _points;
                    
                }
            });

            lines.RemoveAll(line => line == "");

            File.WriteAllLines(DataFileHandler.Instance.GetPath(StorageFiles.Accounts), lines);
        }
        
        // Getters and setters for the age and points of the child
        
        public int GetAge()
        {
            return _age;
        }
        
        public int GetPoints()
        {
            return _points;
        }
        
        public void SetAge(int age)
        {
            _age = age;
        }
        
        public void SetPoints(int points)
        {
            _points = points;
        }
    }
}
