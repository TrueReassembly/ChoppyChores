using ChoppyChores.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChoppyChores.models
{
    public class Reward
    {
        private string _id;
        private string _name;
        private int _cost;

        public Reward(string name, int cost)
        {
            _id = DataFileHandler.Instance.FindNewId(StorageFiles.Rewards);
            _name = name;
            _cost = cost;
        }

        public Reward(string id, string name, int cost)
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
            

            var lines = new List<string>();

            DataFileHandler.Instance.RunReader(StorageFiles.Rewards, reader =>
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    lines.Add(line);
                }
            });
            
            var lineToEdit = -1;
            var iteration = 0;
            
            foreach (var line in lines)
            {
                    if (line == null) continue;
                    var split = line.Split(';');

                    if (split[0].Equals(GetId()))
                    {
                        lineToEdit = iteration;
                        break;
                    }

                    iteration++;
            }

            if (lineToEdit == -1)
            {
                lines.Add(_id + ";" + _name + ";" + _cost);
            }
            else
            {
                lines[lineToEdit] = _id + ";" + _name + ";" + _cost;
            }

            File.WriteAllLines(DataFileHandler.Instance.GetPath(StorageFiles.Rewards), lines.ToArray());
        }

        public void Delete()
        {
            List<string> allChores = new List<string>();
            DataFileHandler.Instance.RunReader(StorageFiles.Chores, reader => allChores = reader.ReadToEnd().Split('\n').ToList());
            allChores.RemoveAll(x => x.StartsWith(_id));
            allChores.RemoveAll(x => x == "");
            File.WriteAllLines(DataFileHandler.Instance.GetPath(StorageFiles.Chores), allChores.ToArray());
        }
    }
}
