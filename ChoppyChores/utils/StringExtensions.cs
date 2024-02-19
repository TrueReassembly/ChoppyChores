using System;
using System.Linq;
using ChoppyChores.models;

namespace ChoppyChores.utils
{
    public static class StringExtensions
    {
        public static Child ToChild(this string str)
        {
            var split = str.Split(';');
            try
            {
                return new Child(split[0], split[2], split[3], int.Parse(split[4]), int.Parse(split[5]));
            }
            catch
            {
                throw new Exception("String '" + str + "' cannot be converted to a Child");
            }
        }

        public static Chore ToChore(this string str)
        {
            var split = str.Split(';');
            try
            {
                var state = (ChoreState) Enum.Parse(typeof(ChoreState), split[6]);

                // Constructor: public Chore(string id, string name, int reward, bool isPublic, int minAge, string claimedBy, ChoreState state)
                // Saving: _id;_name;_reward;_public;_minAge;_claimedBy;_state

                return new Chore(split[0], split[1], int.Parse(split[2]), bool.Parse(split[3]), int.Parse(split[4]), split[5], state);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.StackTrace);
                
                throw new Exception("String '" + str + "' cannot be converted to a Chore");
            }
            
        }
        
        public static bool IsBefore(this string first, string second, int iteration = 0)
        {
            first = first.ToLower();
            second = second.ToLower();
            //If we reach the end of either string, return the shorter one because that will appear first
            if (first.Length == iteration || second.Length == iteration)
            {
                return first.Length < second.Length;
            }
            char[] chars = {'a' ,'b' ,'c' ,'d' ,'e' ,'f' ,'g' ,'h' ,'i' ,'j' ,'k' ,'l' ,'m' ,'n' ,'o' ,'p' ,'q' ,'r' ,'s' ,'t' ,'u' ,'v' ,'w' ,'x' ,'y' ,'z'};
            if (Array.IndexOf(chars, first[iteration]) == Array.IndexOf(chars, second[iteration]))
            {
                return IsBefore(first, second, iteration + 1);
            }
            return Array.IndexOf(chars, first[iteration]) > Array.IndexOf(chars, second[iteration]);
        }
    }
}