using ChoppyChores.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChoppyChores.models
{
    public class Chore
    {
        private string _id;
        private string _name;
        private int _reward;
        private bool _public;
        private string _claimedBy; //User's ID
        private int _minAge;
        private ChoreState _state;

        public Chore(string id, string name, int reward, bool isPublic, int minAge)
        {
            _id = id;
            _name = name;
            _reward = reward;
            _public = isPublic;
            _minAge = minAge;
            _claimedBy = "-1";
            _state = ChoreState.Unclaimed;
        }

        public Chore(string id, string name, int reward, bool isPublic, int minAge, string claimedBy, ChoreState state)
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

            Console.WriteLine("SAVING CHORE");
            var lineToEdit = -1;

            DataFileHandler.Instance.RunReader(StorageFiles.Chores, reader =>
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
                        break;
                    }

                    iteration++;
                }
            });

            var lines = new List<string>();

            DataFileHandler.Instance.RunReader(StorageFiles.Chores, reader =>
            {
                lines = reader.ReadToEnd().Split('\n').ToList();
            });

            lines.RemoveAll(string.IsNullOrWhiteSpace);

            if (lineToEdit == -1)
            {
                var line = _id + ";" + _name + ";" + _reward + ";" +_public.ToString() + ";" + _claimedBy + ";" + _minAge + ";" + _state;
                // Add new line to the end of the file
                lines.Add(line);
            }
            else
            {
                // Ovewrite the iteration line with the new data
                lines[lineToEdit] = _id + ";" + _name + ";" + _reward + ";" + _public.ToString() + ";" + _claimedBy + ";" + _minAge + ";" + _state;
            }
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            File.WriteAllLines(DataFileHandler.Instance.GetPath(StorageFiles.Chores), lines);
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
        
        public string GetClaimedBy()
        {
            return _claimedBy;
        }
        
        public void SetClaimedBy(string id)
        {
            _claimedBy = id;
        }

        public ChoreState GetStatus()
        {
            return _state;
        }

        public void SetStatus(ChoreState state)
        {
            _state = state;
        }
    }
}
