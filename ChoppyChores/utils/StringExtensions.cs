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
                return new Child(split[0], split[2], split[3], int.Parse(split[4]), int.Parse(split[5]), split[6].Split('+').ToList(), split[7].Split('+').ToList())
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
                return new Chore()
            }
        }
    }
}