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
        
        public Child(string username, string password, int age, int points) : base(AccountType.Child, username, password)
        {
            _age = age;
            _points = points;
        }

        public Child(string username, string password, int age) : base(AccountType.Child, username, password)
        {
            _age = age;
            _points = 0;
        }

        public Child(string id, string username, string password, int age, int points) : base(AccountType.Child, id, username, password)
        {
            _age = age;
            _points = points;
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
                               _age + ";" + _points;
                    // Add new line to the end of the file
                    accountFile.WriteLine(line);
                    Console.WriteLine(line);
                }
                else
                {
                    // Ovewrite the iteration line with the new data
                    
                    lines[lineToEdit] = GetId() + ";" + AccountType.Child + ";" + GetUsername() + ";" + GetPassword() + ";" + _age + ";" + _points;
                    accountFile.Write(string.Join("\n", lines));
                }
            });
        }
        
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
