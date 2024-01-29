using ChoppyChores.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChoppyChores.models
{
    public class Chore
    {
        private string _id;
        private string _name;
        private int _reward;
        private bool _public;
        private int _claimedBy; //User's ID
        private int _minAge;
        private ChoreState _state;

        public Chore(string id, string name, int reward, bool isPublic, int minAge)
        {
            _id = id;
            _name = name;
            _reward = reward;
            _public = isPublic;
            _minAge = minAge;
            _claimedBy = -1;
            _state = ChoreState.Unclaimed;
        }

        public Chore(string id, string name, int reward, bool isPublic, int minAge, int claimedBy, ChoreState state)
        {
            _id = id;
            _name = name;
            _reward = reward;
            _public = isPublic;
            _minAge = minAge;
            _claimedBy = claimedBy;
            _state = state;
        }

        public bool WasPublic()
        {
            return _public;
        }

        public void SetPublic(bool pub)
        {
            _public = pub;
        }

        public void Save()
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

                    if (split[0].Equals(_id))
                    {
                        lineToEdit = iteration;
                    }

                    iteration++;
                }
            });

            var lines = new List<string>();

            DataFileHandler.Instance.RunReader(StorageFiles.Chores, reader =>
            {
                lines = reader.ReadToEnd().Split('\n').ToList();
            });

            DataFileHandler.Instance.RunWriter(StorageFiles.Chores, accountFile =>
            {
                if (lineToEdit == -1)
                {
                    var line = _id + ";" + _name + ";" + _public.ToString() + ";" + _claimedBy + ";" + _minAge;
                    // Add new line to the end of the file
                    accountFile.WriteLine(line);
                    Console.WriteLine(line);
                }
                else
                {
                    // Ovewrite the iteration line with the new data

                    lines[lineToEdit] = _id + ";" + _name + ";" + _public.ToString() + ";" + _claimedBy + ";" + _minAge;
                    accountFile.Write(string.Join("\n", lines));
                }
            });
        }
        
        public int GetReward()
        {
            return _reward;
        }
        
        public void SetReward(int reward)
        {
            _reward = reward;
        }
        
        public string GetName()
        {
            return _name;
        }
        
        public void SetName(string name)
        {
            _name = name;
        }
        
        public int GetMinAge()
        {
            return _minAge;
        }
        
        public void SetMinAge(int age)
        {
            _minAge = age;
        }
        
        public string GetId()
        {
            return _id;
        }
        
        public void SetId(string id)
        {
            _id = id;
        }
        
        public int GetClaimedBy()
        {
            return _claimedBy;
        }
        
        public void SetClaimedBy(int id)
        {
            _claimedBy = id;
        }
    }
}
