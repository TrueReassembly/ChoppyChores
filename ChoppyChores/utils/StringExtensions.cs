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
                return new Child(split[1], split[2], int.Parse(split[3]), int.Parse(split[4]),
                    split[5].Split('+').ToList(), split[6].Split('+').ToList());
            }
            catch
            {
                throw new Exception("String '" + str + "' cannot be converted to a Child");
            }
        }
    }
}