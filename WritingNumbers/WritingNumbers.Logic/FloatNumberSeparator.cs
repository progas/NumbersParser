using System.Linq;

namespace WritingNumbers.Logic
{
    /// <summary>
    /// Determines the separation char of float number, etc ',','.','/'... 
    /// </summary>
    public class FloatNumberSeparator
    {
        /// <summary>
        /// Currently used symbol for separation float number
        /// </summary>
        public char SymbolSeparator { get; }

        /// <summary>
        /// Float number separator
        /// </summary>
        /// <param name="symbolSeparator">Separator char</param>
        public FloatNumberSeparator(char symbolSeparator )
        {
            this.SymbolSeparator = symbolSeparator;
        }

        /// <summary>
        /// Separate integer part of float
        /// </summary>
        /// <param name="number">Float number</param>
        /// <returns>Integer part of float</returns>
        public string SeparateIntegerNumber(string number)
        {
            if (number.Contains(this.SymbolSeparator))
            {
                return number.Substring(0, number.IndexOf(this.SymbolSeparator));
            }

            return number;
        }

        /// <summary>
        /// Fractional part of float
        /// </summary>
        /// <param name="number">Float number</param>
        /// <param name="numberOfCuttingDigits">Amount of digits in fractional part</param>
        /// <returns>Fractional part of float</returns>
        public string SeparateFractionalNumber(string number, int numberOfCuttingDigits = DefaultValues.FractionalPartDigits)
        {
            if (number.Contains(this.SymbolSeparator))
            {
                string fractionalNumber = number.Substring(number.IndexOf(this.SymbolSeparator) + 1);
                if (fractionalNumber.Length > numberOfCuttingDigits)
                {
                    fractionalNumber = fractionalNumber.Substring(0, numberOfCuttingDigits);
                }
                if (fractionalNumber.Length < numberOfCuttingDigits)
                {
                    for (int i = 0; i <= numberOfCuttingDigits - fractionalNumber.Length; i++)
                    {
                        fractionalNumber = fractionalNumber + "0";
                    }
                }
                return fractionalNumber;
            }

            return string.Empty;
        }
    }
}
