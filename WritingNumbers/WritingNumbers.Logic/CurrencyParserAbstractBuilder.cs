namespace WritingNumbers.Logic
{
   /// <summary>
   /// Float number parser for particular currency names
   /// </summary>
    public abstract class CurrencyParserAbstractBuilder
    {
        /// <summary>
        /// Build particular parser
        /// </summary>
        /// <returns>Currency parser</returns>
        public FloatNumberParser GetParser()
        {
            var floatNumberSeparator = this.BuildFloatNumberSeparator();
            var integerPartName = this.BuildNameOfIntegerPart();
            var fractionalPartName = this.BuildNameOfFractionalPart();
            return new FloatNumberParser(floatNumberSeparator, integerPartName, fractionalPartName);
        }

        /// <summary>
        /// Float number separator
        /// </summary>
        /// <returns>Float number separator</returns>
        protected abstract FloatNumberSeparator BuildFloatNumberSeparator();

        /// <summary>
        /// Name of integer part of float number in singular and plural forms
        /// </summary>
        /// <returns>Integer part name</returns>
        protected abstract NumberPartName BuildNameOfIntegerPart();

        /// <summary>
        /// Name of fractional part of float number in singular and plural forms
        /// </summary>
        /// <returns>Fractional part name</returns>
        protected abstract NumberPartName BuildNameOfFractionalPart();
    }
}
