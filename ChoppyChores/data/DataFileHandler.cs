using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChoppyChores.models;
using ChoppyChores.utils;

namespace ChoppyChores.data
{
    internal class DataFileHandler
    {
        private static DataFileHandler _instance = null;
        private const string AccountsFile = "./storage/Accounts.txt";
        private const string ChoresFile = "./storage/Chores.txt";
        private const string RewardsFile = "./storage/Rewards.txt";
        private Child _currentChild;

        public enum ChoreSort
        {
            Name,
            Reward,
            Age
        }


        public static DataFileHandler Instance
        {
            get { return _instance ?? (_instance = new DataFileHandler()); }
        }

        /**
         * Gets a child from the specified id
         * @param id The id of the child to get
         * @return The child with the specified id, or null if no child with that id exists
         */
        public Child GetChildById(string id)
        {
            
            Child child = null;
            
            RunReader(StorageFiles.Accounts, accountFile =>
            {
                while (!accountFile.EndOfStream)
                {
                    string line = accountFile.ReadLine();
                    string[] split = line.Split(';');

                    if (split[0].Equals(id))
                    {
                        child = line.ToChild();
                        // child = new Child(split[1], split[2],  int.Parse(split[3]), int.Parse(split[4]),   split[5].Split('+').ToList(), split[6].Split('+').ToList());
                    }
                }
            });
            return child;
        }

        public string FindNewId(StorageFiles file)
        {
            string id = "";
            string[] lines = null;
            var random = new Random();
            RunReader(file, theFile =>
            {
                lines = theFile.ReadToEnd().Split('\n');
            });
            bool idExists = true;
            while (idExists)
            {
                id = random.Next(100, 999).ToString();
                idExists = lines.Any(line => line.Split(';')[0].Equals(id));
            }
            return id;
        }

        /**
         * Runs a reader on the specified file
         * @param file The file to read from
         * @param callback The code to run on the reader
         */
        public void RunReader(StorageFiles file, Action<StreamReader> callback)
        {
            switch (file)
            {
                case StorageFiles.Accounts:
                    var accountReader = File.OpenText(AccountsFile);
                    callback(accountReader);
                    accountReader.Close();
                    break;
                case StorageFiles.Chores:
                    var choreReader = File.OpenText(ChoresFile);
                    callback(choreReader);
                    choreReader.Close();
                    break;
                case StorageFiles.Rewards:
                    var rewardReader = File.OpenText(RewardsFile);
                    callback(rewardReader);
                    rewardReader.Close();
                    break;
                default:
                    callback(null);
                    break;
            }
        }

        /**
         * Runs a writer on the specified file
         * @param file The file to write to
         * @param callback The code to run on the writer
         */
        public void RunWriter(StorageFiles file, Action<StreamWriter> callback)
        {
            switch (file)
            {
                case StorageFiles.Accounts:
                    var accountWriter = File.AppendText(AccountsFile);
                    callback(accountWriter);
                    accountWriter.Close();
                    break;
                case StorageFiles.Chores:
                    var choreWriter = File.AppendText(ChoresFile);
                    callback(choreWriter);
                    choreWriter.Close();
                    break;
                case StorageFiles.Rewards:
                    var rewardWriter = File.AppendText(RewardsFile);
                    callback(rewardWriter);
                    rewardWriter.Close();
                    break;
                default:
                    callback(null);
                    break;
            }
        }
        
        public List<Chore> sortChoresBy(ChoreSort sort, bool ascending)
        {
            List<Chore> unsortedChores = new List<Chore>();
            bool swapped = false;
            
            RunReader(StorageFiles.Accounts, accountFile =>
            {
                List<Chore> chores = new List<Chore>();
                while (!accountFile.EndOfStream)
                {
                    string line = accountFile.ReadLine();
                    string[] split = line.Split(';');
                    
                }
            });
            switch (sort)
            {
                case ChoreSort.Age:

                    if (ascending)
                    {
                        do
                        {
                            swapped = false;
                            for (int i = 0; i < unsortedChores.Count - 1; i++)
                            {
                                if (unsortedChores[i].GetMinAge() > unsortedChores[i + 1].GetMinAge())
                                {
                                    var temp = unsortedChores[i];
                                    unsortedChores[i] = unsortedChores[i + 1];
                                    unsortedChores[i + 1] = temp;
                                    swapped = true;
                                }
                            }
                        } while (swapped);
                    }
                    else
                    {
                        do
                        {
                            swapped = false;
                            for (int i = 0; i < unsortedChores.Count - 1; i++)
                            {
                                if (unsortedChores[i].GetMinAge() < unsortedChores[i + 1].GetMinAge())
                                {
                                    var temp = unsortedChores[i];
                                    unsortedChores[i] = unsortedChores[i + 1];
                                    unsortedChores[i + 1] = temp;
                                    swapped = true;
                                }
                            }
                        } while (swapped);
                    }

                    break;
                case ChoreSort.Reward:
                    if (ascending)
                    {
                        do
                        {
                            swapped = false;
                            for (int i = 0; i < unsortedChores.Count - 1; i++)
                            {
                                if (unsortedChores[i].GetReward() > unsortedChores[i + 1].GetReward())
                                {
                                    var temp = unsortedChores[i];
                                    unsortedChores[i] = unsortedChores[i + 1];
                                    unsortedChores[i + 1] = temp;
                                    swapped = true;
                                }
                            }
                        } while (swapped);
                    }
                    else
                    {
                        do
                        {
                            swapped = false;
                            for (int i = 0; i < unsortedChores.Count - 1; i++)
                            {
                                if (unsortedChores[i].GetReward() >= unsortedChores[i + 1].GetReward()) continue;
                                var temp = unsortedChores[i];
                                unsortedChores[i] = unsortedChores[i + 1];
                                unsortedChores[i + 1] = temp;
                                swapped = true;
                            }
                        } while (swapped);
                    }

                    break;
                case ChoreSort.Name:
                    
                    if (ascending)
                    {
                        do
                        {
                            swapped = false;
                            for (int i = 0; i < unsortedChores.Count - 1; i++)
                            {
                                string name1 = unsortedChores[i].GetName();
                                string name2 = unsortedChores[i + 1].GetName();
                                if (name2.IsBefore(name1))
                                {
                                    swapped = true;
                                    var temp = unsortedChores[i];
                                    unsortedChores[i] = unsortedChores[i + 1];
                                    unsortedChores[i + 1] = temp;
                                }
                            }
                        } while (swapped);
                    }

                    break;
            
            }

            return unsortedChores;
        }

        /**
         * Gets a child from the specified name
         * @param name The name of the child to get
         * @return The child with the specified name, or null if no child with that name exists
         */
        public Child GetChildFromName(string name)
        {
            Child child = null;
            RunReader(StorageFiles.Accounts, reader =>
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var split = line.Split(';');
                    if (split[1].Equals("Child") && split[2].Equals(name))
                    {
                        child = line.ToChild();
                    }
                }
            });
            return child;
        }

        /**
         * Gets a list of all children
         * @return A list of all children, or an empty list if no children exist
         */
        public List<Child> GetAllChildren()
        {
            List<Child> children = new List<Child>();
            RunReader(StorageFiles.Accounts, reader =>
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var split = line.Split(';');
                    if (split[1].Equals("Child"))
                    {
                        children.Add(line.ToChild());
                    }
                }
            });
            return children;
        }

        public List<Chore> GetAllChores()
        {
            List<Chore> temp = new List<Chore>();
            RunReader(StorageFiles.Chores, reader =>
            {
                while (!reader.EndOfStream)
                {
                    try {
                        temp.Add(reader.ReadLine().ToChore());
                    } 
                    catch (Exception e)
                    {
                        continue;
                    }
                }
            });
            return temp;
        }

        public List<Child> GetChildrenSortedByName()
        {
            List<Child> children = GetAllChildren();
            while (true)
            {
                bool swapped = false;
                for (int i = 0; i < children.Count - 1; i++)
                {
                    if (children[i].GetUsername().IsBefore(children[i + 1].GetUsername()))
                    {
                        var temp = children[i];
                        children[i] = children[i + 1];
                        children[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
            return children;
        }

        internal string GetPath(StorageFiles chores)
        {
            switch (chores)
            {
                case StorageFiles.Accounts:
                    return AccountsFile;
                case StorageFiles.Chores:
                    return ChoresFile;
                case StorageFiles.Rewards:
                    return RewardsFile;
                default:
                    return "";
            }
        }

        public void SetLoggedInChild(Child child)
        {
            _currentChild = child;
        }

        public Child GetLoggedInChild()
        {
            return GetAllChildren()[0];
            // return; _currentChild
        }

        public List<>
    }
}
