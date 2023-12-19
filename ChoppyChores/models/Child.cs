using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoppyChores.models
{
    class Child : Account
    {
        private int age;
        private int points;
        private List<String> chores; //Stores Chore ID
        private List<String> rewards; //Stores Reward IDs
    }
}
