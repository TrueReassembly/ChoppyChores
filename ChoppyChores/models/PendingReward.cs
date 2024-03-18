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

        public PendingReward(string name, int cost, string assignedTo)
        {
            _id = DataFileHandler.Instance.FindNewId(StorageFiles.Rewards);
            _name = name;
            _cost = cost;
            _assignedTo = assignedTo;
        }

        public PendingReward(string id, string name, int cost, string assignedTo)
        {
            _id = id;
            _name = name;
            _cost = cost;
        }

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

        public void Save()
        {
            var lineToEdit = -1;
            
            DataFileHandler.Instance.RunReader(StorageFiles.PendingRewards, reader =>
            {
                var iteration = 0;
                while (reader.Peek() >= 0)
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
            DataFileHandler.Instance.RunReader(StorageFiles.PendingRewards, reader =>
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    lines.Add(line);
                }
            });
            
            if (lineToEdit == -1)
            {
                lines.Add(_id + ";" + _name + ";" + _cost + ";" + _assignedTo);
            }
            else
            {
                lines[lineToEdit] = _id + ";" + _name + ";" + _cost + ";" + _assignedTo;
            }
            
            File.WriteAllLines(DataFileHandler.Instance.GetPath(StorageFiles.PendingRewards), lines.ToArray());
        }
    }
}
