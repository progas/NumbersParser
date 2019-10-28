using System;

namespace WritingNumbers.Logic
{
    /// <summary>
    /// Helps with numbers in string
    /// </summary>
    public static class DigitHelper
    {
        /// <summary>
        /// Cheks zero number
        /// </summary>
        /// <param name="number">NUmber</param>
        /// <returns>Is zero</returns>
        public static bool IsZeroNumber(string number)
        {
            bool result = false;
            int numberResult = -1;

            if (int.TryParse(number, out numberResult))
            {
                result = numberResult == 0;
            }
            else
            {
                throw new FormatException("Invalid number format");
            }
            return result;
        }

        /// <summary>
        /// Clean number from non digit symbols 
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>Cleaned number</returns>
        public static string CleanNumberFromNonDigitSymbols(string number)
        {
            string numberResult = string.Empty;

            for (int i = 0; i < number.Length; i++)
            {
                if (Char.IsDigit(number[i]))
                {
                    numberResult = numberResult + number[i];
                }
            }

            return numberResult;
        }
    }
}
