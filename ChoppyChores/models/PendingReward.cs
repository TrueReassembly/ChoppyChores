using ChoppyChores.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChoppyChores.models
{
    public class PendingReward
    {
        private string _id;
        private string _name;
        private int _cost;
        private string _assignedTo;

        /**
         * Constructor for the PendingReward class
         * @param name The name of the reward
         * @param cost The cost of the reward
         * @param assignedTo The user the reward is assigned to
         */
        public PendingReward(string name, int cost, string assignedTo)
        {
            _id = DataFileHandler.Instance.FindNewId(StorageFiles.Rewards);
            _name = name;
            _cost = cost;
            _assignedTo = assignedTo;
        }

        /**
         * Constructor for the PendingReward class
         * @param id The id of the reward
         * @param name The name of the reward
         * @param cost The cost of the reward
         * @param assignedTo The user the reward is assigned to
         */
        public PendingReward(string id, string name, int cost, string assignedTo)
        {
            _id = id;
            _name = name;
            _cost = cost;
            _assignedTo = assignedTo;
        }

        // Getters and Setters for the PendingReward class
        public string GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public int GetCost()
        {
            return _cost;
        }

        public void SetCost(int cost)
        {
            _cost = cost;
        }

        // Save the reward to the file
        public void Save()
        {
            var lineToEdit = -1;
            
            // Find the line to edit
            DataFileHandler.Instance.RunReader(StorageFiles.PendingRewards, reader =>
            {
                var iteration = 0;
                while (reader.Peek() >= 0) // While there is a line to read
                {
                    var line = reader.ReadLine();
                    if (line.StartsWith(_id))
                    {
                        lineToEdit = iteration;
                        break;
                    }
                    iteration++;
                }
            });
            
            var lines = new List<string>();
            // Get all the lines from the file separated by new line and add them to the list "lines"
            DataFileHandler.Instance.RunReader(StorageFiles.PendingRewards, reader =>
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    lines.Add(line);
                }
            });
            
            // If the line to edit is -1, add a new line to the end of the file with the new data, otherwise overwrite the iteration line with the new data
            if (lineToEdit == -1)
            {
                lines.Add(_id + ";" + _name + ";" + _cost + ";" + _assignedTo);
            }
            else
            {
                lines[lineToEdit] = _id + ";" + _name + ";" + _cost + ";" + _assignedTo;
            }
            // Write all the lines to the file, this will overwrite the file instead of creating blank spaces
            File.WriteAllLines(DataFileHandler.Instance.GetPath(StorageFiles.PendingRewards), lines.ToArray());
        }

        // Delete the reward from the file
        public void Delete()
        {
            List<string> allRewards = new List<string>();
            DataFileHandler.Instance.RunReader(StorageFiles.PendingRewards, reader => allRewards = reader.ReadToEnd().Split('\n').ToList());
            allRewards.RemoveAll(x => x.StartsWith(_id));
            allRewards.RemoveAll(x => x == "");
            File.WriteAllLines(DataFileHandler.Instance.GetPath(StorageFiles.PendingRewards), allRewards.ToArray());
        }

        // Get the user the reward is assigned to
        public string GetAssignedTo()
        {
            return _assignedTo;
        }
    }
}
