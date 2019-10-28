using System.Text;
using WritingNumbers.Logic.IntegerParser;

namespace WritingNumbers.Logic
{
    /// <summary>
    /// Float number parser
    /// </summary>
    public class FloatNumberParser
    {
        /// <summary>
        /// Integer number part name
        /// </summary>
        protected NumberPartName IntegerPartName { get; }

        /// <summary>
        /// Fractional number part name
        /// </summary>
        protected NumberPartName FractionalPartName { get; }

        /// <summary>
        /// Float number separator
        /// </summary>
        private FloatNumberSeparator FloatNumberSeparator { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="floatNumberSeparator">Float number separator</param>
        /// <param name="integerPartName">INteger part names</param>
        /// <param name="fractionalPartName">Fractional part names</param>
        public FloatNumberParser(FloatNumberSeparator floatNumberSeparator, NumberPartName integerPartName, NumberPartName fractionalPartName)
        {
            this.IntegerPartName = integerPartName;
            this.FloatNumberSeparator = floatNumberSeparator;
            this.FractionalPartName = fractionalPartName;
        }

        /// <summary>
        /// Parse float number
        /// </summary>
        /// <param name="floatNumber">Float number to parse</param>
        /// <returns>Float number in words</returns>
        public string ParseFloatNumber(string floatNumber)
        {
            StringBuilder sb = new StringBuilder();
            string integerPart = DigitHelper.CleanNumberFromNonDigitSymbols(this.FloatNumberSeparator.SeparateIntegerNumber(floatNumber));
            int integerNumber = 0;
            if (int.TryParse(integerPart, out integerNumber))
            {
                sb.Append(NumberToWordsParser.NumberToWords(integerNumber).TrimEnd());
                sb.Append(DefaultValues.Space);
                sb.Append(this.IntegerPartName?.GetNumberName(integerPart));
            }


            string fractionalPart = DigitHelper.CleanNumberFromNonDigitSymbols(this.FloatNumberSeparator.SeparateFractionalNumber(floatNumber));
            int fractionalNumber = 0;
            if (int.TryParse(fractionalPart, out fractionalNumber))
            {
                sb.Append(DefaultValues.WordSeparator);
                sb.Append(NumberToWordsParser.NumberToWords(fractionalNumber).TrimEnd());
                sb.Append(DefaultValues.Space);
                sb.Append(this.FractionalPartName?.GetNumberName(fractionalPart));
            }

            return sb.ToString();
        }
    }
}
