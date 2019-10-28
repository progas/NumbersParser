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

        private static readonly int million = 1000000;
        private static readonly int thousand = 1000;
        private static readonly int hundred = 100;
        private static readonly int ten = 10;
        private static readonly int twenty = 20;
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

            if ((number / million) > 0)
            {
                words += NumberToWords(number / million) + WrapWithSpaces(DefaultValues.Million);
                number %= million;
            }

            if ((number / thousand) > 0)
            {
                words += NumberToWords(number / thousand) + WrapWithSpaces(DefaultValues.Thousand);
                number %= thousand;
            }

            if ((number / hundred) > 0)
            {
                words += NumberToWords(number / hundred) + WrapWithSpaces(DefaultValues.Hundred);
                number %= hundred;
            }

            if (number > 0)
            {
                if (number < twenty)
                {
                    words += DictionaryProvider.GetOnesName(number); 
                }
                else
                {
                    words += DictionaryProvider.GetTenName(number / ten); 

                    if ((number % ten) > 0)
                    {
                        words += "-" + DictionaryProvider.GetOnesName(number % ten); 
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
