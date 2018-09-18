using System;
using System.Globalization;
using System.Linq;

namespace CleanThatCode.Community.Common
{
    // Your job is to implement this class
    public static class StringHelpers
    {
        // Instead of spaces it should be separated with dots, e.g. Hello World -> Hello.World
        public static string ToDotSeparatedString(this string str)
        {
            String phrase = str;
            phrase = phrase.Replace(" ", ".");
            return phrase;
        }
        
        // All words in the string should be capitalized, e.g. teenage mutant ninja turtles -> Teenage Mutant Ninja Turtles
        public static string CapitalizeAllWords(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        // The words should be reversed in the string, e.g. Hi Ho Silver Away! -> Away! Silver Ho Hi
        public static string ReverseWords(this string str)
        {
            return String.Join(" ", str.Split(' ').Reverse());
        }
    }
}