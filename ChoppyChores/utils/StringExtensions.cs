using System;
using System.Linq;
using ChoppyChores.models;

namespace ChoppyChores.utils
{
    public static class StringExtensions
    {
        /**
         * Converts a string to a Child object
         * @param str The string to convert
         * @return The Child object
         * @throws Exception If the string cannot be converted to a Child
         */
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

        /**
         * Converts a string to a Chore object
         * @param str The string to convert
         * @return The Chore object
         * @throws Exception If the string cannot be converted to a Chore
         */
        public static Chore ToChore(this string str)
        {
            var split = str.Split(';');
            try
            {
                if (str == null) throw new Exception("String is null");
                var state = (ChoreState) Enum.Parse(typeof(ChoreState), split[6]);

                // Constructor: public Chore(string id, string name, int reward, bool isPublic, int minAge, string claimedBy, ChoreState state)
                // Saving: _id;_name;_reward;_public;_minAge;_claimedBy;_state

                return new Chore(split[0], split[1], int.Parse(split[2]), bool.Parse(split[3]), int.Parse(split[4]), split[5], state);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                
                throw new Exception("Failed to convert string '" + str + "' to a Chore. Error: " + e.Message, e);
            }
            
        }
        
        /**
         * Checks if the first string comes before the second string alphabetically
         * @param first The first string
         * @param second The second string
         * @param iteration The current iteration of the recursive function, do not set this manually.
         * @return Whether the first string comes before the second string alphabetically
         */
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

        /**
         * Converts a string to a Parent object
         * @param str The string to convert
         * @return The Parent object
         * @throws Exception If the string cannot be converted to a Parent
         */
        public static Parent ToParent(this string str)
        {
            var split = str.Split(';');
            try
            {
                return new Parent(split[0], split[2], split[3]);
            }
            catch
            {
                throw new Exception("String '" + str + "' cannot be converted to a Parent");
            }
        }
    }
}