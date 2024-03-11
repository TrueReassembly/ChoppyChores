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

        public Reward(string id, string name, int cost, string description)
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

            DataFileHandler.Instance.RunReader(StorageFiles.Rewards, reader =>
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

            DataFileHandler.Instance.RunReader(StorageFiles.Rewards, reader =>
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
                lines.Add(_id + ";" + _name + ";" + _cost);
            }
            else
            {
                lines[lineToEdit] = _id + ";" + _name + ";" + _cost;
            }

            DataFileHandler.Instance.RunWriter(StorageFiles.Rewards, writer =>
            {
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            });
        }
    }
}
