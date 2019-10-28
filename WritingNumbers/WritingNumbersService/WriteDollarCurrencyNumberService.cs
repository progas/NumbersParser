using WritingNumbers.Logic;

namespace WritingNumbersService
{
    public class WriteDollarCurrencyNumberService : IWriteNumberService
    {
        /// <summary>
        /// Currency parser
        /// </summary>
        FloatNumberParser currencyParser;

        /// <summary>
        /// ctor
        /// </summary>
        public WriteDollarCurrencyNumberService()
        {
            var parserBuilder = new DollarCurrencyParcerBuilder(); 
            this.currencyParser = parserBuilder.GetParser();
        }

        /// <summary>
        /// Convert number to currency in words
        /// </summary>
        /// <param name="number">Number to parse</param>
        /// <returns>Currency in words</returns>
        public string ConvertNumberToWords(string number)
        {
            return this.currencyParser.ParseFloatNumber(number);
        }
    }
}