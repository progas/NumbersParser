using System.Collections.Generic;

namespace WritingNumbers.Logic
{
    /// <summary>
    /// Provides number name in word
    /// </summary>
    public class DictionaryProvider
    {
        /// <summary>
        /// Names less then 20
        /// </summary>
        private static readonly Dictionary<int, string> OneNames = new Dictionary<int, string>()
        {
            {0, "zero"},
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
            {10, "ten"},
            {11, "eleven"},
            {12, "twelve"},
            {13, "thirteen"},
            {14, "fourteen"},
            {15, "fifteen"},
            {16, "sixteen"},
            {17, "seventeen"},
            {18, "eighteen"},
            {19, "nineteen"},
        };

        /// <summary>
        /// Names of tens
        /// </summary>
        private static readonly Dictionary<int, string> TenNames = new Dictionary<int, string>()
        {
            {1, "ten"},
            {2, "twenty"},
            {3, "thirty"},
            {4, "forty"},
            {5, "fifty"},
            {6, "sixty"},
            {7, "seventy"},
            {8, "eighty"},
            {9, "ninety"},
        };

        /// <summary>
        /// Provides name of number up to 19
        /// </summary>
        /// <param name="input">Number</param>
        /// <returns>Number name</returns>
        public static string GetOnesName(int input)
        {
            return OneNames[input];
        }

        /// <summary>
        /// Provides tens name
        /// </summary>
        /// <param name="input">number</param>
        /// <returns>Number name</returns>
        public static string GetTenName(int input)
        {
            return TenNames[input];
        }
    }
}
