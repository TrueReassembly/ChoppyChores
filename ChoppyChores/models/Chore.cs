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
        private string _claimedBy; //User's ID, 0 if unclaimed
        private int _minAge;
        private ChoreState _state;

        /**
         * Constructor for the Chore class
         * @param id The id of the chore
         * @param name The name of the chore
         * @param reward The reward for the chore
         * @param isPublic Whether the chore was public by default (claimable by a child at their own will)
         * @param minAge The minimum age for the chore
         */
        public Chore(string id, string name, int reward, bool isPublic, int minAge)
        {
            _id = id;
            _name = name;
            _reward = reward;
            _public = isPublic;
            _minAge = minAge;
            _claimedBy = "0";
            _state = ChoreState.Unclaimed;
        }

        /**
         * Constructor for the Chore class
         * @param id The id of the chore
         * @param name The name of the chore
         * @param reward The reward for the chore
         * @param isPublic Whether the chore was public by default (claimable by a child at their own will)
         * @param minAge The minimum age for the chore
         * @param claimedBy The user claiming the chore
         * @param state The state of the chore
         */
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

        // Check if the chore was public
        public bool WasPublic()
        {
            return _public;
        }

        // Set the chore to public or not public
        public void SetPublic(bool pub)
        {
            _public = pub;
        }

        // Save the chore to the file
        public void Save()
        {
            var lineToEdit = -1;

            // Find the line to edit
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

            // Read all the lines from the file split by a new line, adding it to "lines"
            DataFileHandler.Instance.RunReader(StorageFiles.Chores, reader =>
            {
                lines = reader.ReadToEnd().Split('\n').ToList();
            });

            // If the line to edit is -1, add a new line to the end of the file with the new data, otherwise overwrite the iteration line with the new data
            if (lineToEdit == -1)
            {
                var line = _id + ";" + _name + ";" + _reward + ";" +_public.ToString() + ";" + _minAge + ";" + _claimedBy + ";" + _state;
                // Add new line to the end of the file
                lines.Add(line);
            }
            else
            {
                // Ovewrite the iteration line with the new data
                lines[lineToEdit] = _id + ";" + _name + ";" + _reward + ";" + _public.ToString() + ";" + _minAge + ";" + _claimedBy + ";" + _state;
            }

            var newLines = new List<string>(lines.Count);
            foreach (var line in lines)
            {
                if (line.Split(';').Length > 6)
                {
                    newLines.Add(line.Trim());
                }
            }
            
            File.WriteAllLines(DataFileHandler.Instance.GetPath(StorageFiles.Chores), newLines.ToArray());
        }

        // Delete the chore from the file
        public void Delete()
        {
            List<string> allChores = new List<string>();
            DataFileHandler.Instance.RunReader(StorageFiles.Chores, reader => allChores = reader.ReadToEnd().Split('\n').ToList());
            allChores.RemoveAll(x => x.StartsWith(_id));
            allChores.RemoveAll(x => x == "");
            File.WriteAllLines(DataFileHandler.Instance.GetPath(StorageFiles.Chores), allChores.ToArray());
            
        }
        
        // Getters and setters for the reward, name, minimum age, ID, claimed by, and status of the chore
        
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
