namespace WritingNumbers.Logic
{
    /// <summary>
    /// Dollar float currency parser
    /// </summary>
    public class DollarCurrencyParcerBuilder : CurrencyParserAbstractBuilder
    {
        /// <summary>
        /// Float number separator
        /// </summary>
        /// <returns>Float number separator</returns>
        protected override FloatNumberSeparator BuildFloatNumberSeparator()
        {
            return new FloatNumberSeparator(DefaultValues.SeparatorSign);
        }

        /// <summary>
        /// Name of integer part of float number in singular and plural forms
        /// </summary>
        /// <returns>Integer part name</returns>
        protected override NumberPartName BuildNameOfIntegerPart()
        {
            return new NumberPartName(DefaultValues.DollarSingular, DefaultValues.DollarPlural);
        }

        /// <summary>
        /// Name of fractional part of float number in singular and plural forms
        /// </summary>
        /// <returns>Fractional part name</returns>
        protected override NumberPartName BuildNameOfFractionalPart()
        {
            return new NumberPartName(DefaultValues.CentSingular, DefaultValues.CentPlural);
        }
    }
}
