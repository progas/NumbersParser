using System;

namespace WritingNumbers.Logic.IntegerParser
{
    /// <summary>
    /// Parse integer number to words
    /// </summary>
    public class NumberToWordsParser
    {
        /// <summary>
        /// Max avilable number to parse
        /// </summary>
        private static int maxNumber = 999999999;

        /// <summary>
        /// Zero number
        /// </summary>
        private static string zero = "zero";

        /// <summary>
        /// Convert integer number to words
        /// </summary>
        /// <param name="number">Integer number</param>
        /// <returns></returns>
        public static string NumberToWords(int number)
        {
            if (number > maxNumber || number < 0)
            {
                throw new ArgumentOutOfRangeException($"The number {number} is out of range");
            }

            if (number == 0)
                return zero;

            string words = string.Empty;

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + WrapWithSpaces(DefaultValues.Million);
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + WrapWithSpaces(DefaultValues.Thousand);
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + WrapWithSpaces(DefaultValues.Hundred);
                number %= 100;
            }

            if (number > 0)
            {
                if (number < 20)
                {
                    words += DictionaryProvider.GetOnesName(number); 
                }
                else
                {
                    words += DictionaryProvider.GetTenName(number / 10); 

                    if ((number % 10) > 0)
                    {
                        words += "-" + DictionaryProvider.GetOnesName(number % 10); 
                    }
                }
            }

            return words;
        }

        /// <summary>
        /// Wraps string with spaces
        /// </summary>
        /// <param name="stringToWrap">String to wrap</param>
        /// <returns>Wrapped result</returns>
        private static string WrapWithSpaces(string stringToWrap)
        {
            return DefaultValues.Space + stringToWrap + DefaultValues.Space;
        }
    }
}
