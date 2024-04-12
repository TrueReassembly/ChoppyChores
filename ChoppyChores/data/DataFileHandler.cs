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
        private const string PendingRewardsFile = "./storage/PendingRewards.txt";
        private Child _currentChild;

        public enum ChoreSort
        {
            Name,
            Reward,
            Age
        }

        /**
         * Gets a usable Singleton instance of the DataFileHandler
         *
         * @return The instance of the DataFileHandler
         */
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
                        child = line.ToChild(); // Convert the string to a child object
                    }
                }
            });
            return child;
        }

        /**
         * Finds a new available ID for the specified storage file
         * @param file the Storage file to use
         * @returns an available Id
         */
        public string FindNewId(StorageFiles file)
        {
            string id = "";
            string[] lines = null;
            var random = new Random();
            RunReader(file, theFile =>
            {
                lines = theFile.ReadToEnd().Split('\n'); // write each line to an array
            });
            bool idExists = true;
            while (idExists)
            {
                id = random.Next(10000, 99999).ToString();
                idExists = lines.Any(line => line.Split(';')[0].Equals(id)); // if the line does not exist in any of the lines, then the id is unique therefore we set idExists to false, breaking out of the loop
            }
            return id;
        }

        /**
         * Runs a file reader on the specified file
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
                case StorageFiles.PendingRewards:
                    var pendingRewardReader = File.OpenText(PendingRewardsFile);
                    callback(pendingRewardReader);
                    pendingRewardReader.Close();
                    break;
                default:
                    callback(null);
                    break;
            }
        }

        /**
         * Runs a file writer on the specified file
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
                case StorageFiles.PendingRewards:
                    var pendingRewardWriter = File.AppendText(PendingRewardsFile);
                    callback(pendingRewardWriter);
                    pendingRewardWriter.Close();
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
                                    // if they are unsorted, swap them (bubble sort)
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
                        var line = reader.ReadLine();
                        //If any line is malformed for whatever reason, skip it
                        if (line == null) continue;
                        if (line.Equals("")) continue;
                        temp.Add(line.ToChore());
                    } 
                    catch (Exception e)
                    {
                        continue;
                    }
                }
            });
            return temp;
        }

        /**
         * Gets all the children sorted by their name in ascending order
         *
         * @return A list of all children sorted by their name in ascending order
         */
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
                        // if they are unsorted, swap them (bubble sort)
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

        /**
         * Gets the path of the specified storage file
         *
         * @param chores The storage file to get the path of
         * @return The path of the specified storage file
         */
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
                case StorageFiles.PendingRewards:
                    return PendingRewardsFile;
                default:
                    return "";
            }
        }

        /**
         * Sets the currently logged in child
         *
         * @param child The child to set as the currently logged in child
         */
        public void SetLoggedInChild(Child child)
        {
            _currentChild = child;
        }

        /**
         * Gets the currently logged in child
         *
         * @return The currently logged in child
         */
        public Child GetLoggedInChild()
        {
            return _currentChild;
        }

        /**
         * Gets a list of all accounts
         * @return A list of all accounts, or an empty list if no accounts exist
         */
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            RunReader(StorageFiles.Accounts, file =>
            {
                while (!file.EndOfStream)
                {
                    // If the ID (split[1]) is "Child", then it is a child account, and we add it as such. Otherwise, it is a parent account. We already skip the line if it is empty, so we don't need to check for that.
                    var line = file.ReadLine();
                    if (line == null) continue;
                    var split = line.Split(';');
                    if (split[1].Equals("Child"))
                    {
                        accounts.Add(line.ToChild());
                    } else
                    {
                        accounts.Add(line.ToParent());
                    }
                }
            });

            return accounts;
        }

        /**
         * Gets a list of all parents
         * @return A list of all parents, or an empty list if no parents exist
         */
        public List<Parent> GetParents()
        {
            List<Parent> accounts = new List<Parent>();
            RunReader(StorageFiles.Accounts, file =>
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    if (line == null) continue;
                    var split = line.Split(';');
                    // If the ID (split[1]) is "Parent", then it is a parent account, and we add it as such.
                    if (split[1].Equals("Parent"))
                    {
                        accounts.Add(line.ToParent());
                    }
                }
            });

            return accounts;
        }

        /**
         * Gets a list of the pending chores
         * @return A list of all pending chores
         */
        public List<Chore> GetPendingChores()
        {
            var chores = GetAllChores();
            var toReturn = new List<Chore>();
            foreach (var chore in chores)
            {
                // If the chore is pending, add it to the list
                if (chore.GetStatus().Equals(ChoreState.Pending))
                {
                    toReturn.Add(chore);
                }
            }

            return toReturn;
        }

        /**
         * Gets a list of the pending rewards
         * @return A list of all pending rewards
         */
        public List<PendingReward> GetAllPendingRewards()
        {
            List<PendingReward> rewards = new List<PendingReward>();
            RunReader(StorageFiles.PendingRewards, reader =>
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var split = line.Split(';');
                    // Parse the line as a PendingReward object and add it to the list
                    rewards.Add(new PendingReward(split[0], split[1], int.Parse(split[2]), split[3]));
                }
            });
            return rewards;
        }
        
        /**
         * Gets a list of all the rewards
         *
         * @return A list of all the rewards
         */
        public List<Reward> GetAllRewards()
        {
            List<Reward> rewards = new List<Reward>();
            RunReader(StorageFiles.Rewards, reader =>
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var split = line.Split(';');
                    rewards.Add(new Reward(split[0], split[1], int.Parse(split[2])));
                }
            });
            return rewards;
        }
    }
}