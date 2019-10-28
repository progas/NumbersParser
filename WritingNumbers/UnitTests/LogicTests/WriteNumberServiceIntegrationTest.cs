using NUnit.Framework;
using WritingNumbers.Logic;
using WritingNumbersService;

namespace UnitTests.LogicTests
{
    [TestFixture]
    public class WriteNumberServiceIntegrationTest
    {
        WriteDollarCurrencyNumberService cut;

        [SetUp]
        public void InitializeCUT()
        {
            cut = new WriteDollarCurrencyNumberService();
        }

        [Test]
        public void InputZeroOutputInPlural()
        {

            string zero = "0";
            string expectedResult = $"zero {DefaultValues.DollarPlural}";

            string parseResult = cut.ConvertNumberToWords(zero);

            Assert.That(expectedResult == parseResult);

        }

        [Test]
        public void InputOneOutputInSingular()
        {

            string one = "1";
            string expectedResult = $"one {DefaultValues.DollarSingular}";

            string parseResult = cut.ConvertNumberToWords(one);

            Assert.That(expectedResult == parseResult);

        }


        [Test]
        public void FractionalOneOutputTenCents()
        {
            string fractionalOne = "25,1";
            string expectedResult = $"twenty-five dollars and ten {DefaultValues.CentPlural}";

            string parseResult = cut.ConvertNumberToWords(fractionalOne);

            Assert.That(expectedResult == parseResult, $"Was expected: {expectedResult} But got: {parseResult}");
        }

        [Test]
        public void FractionalOOneOutputOneCent()
        {

            string fractionalOOne = "0,01";
            string expectedResult = $"zero {DefaultValues.DollarPlural} and one {DefaultValues.CentSingular}";

            string parseResult = cut.ConvertNumberToWords(fractionalOOne);

            Assert.That(expectedResult == parseResult, $"Was expected: {expectedResult} But got: {parseResult}");
        }

        [Test]
        public void RegularIntegerNumberOutputWrittenNumber()
        {

            string integerNumber = "45 100 ";
            string expectedResult = $"forty-five thousand one hundred {DefaultValues.DollarPlural}";

            string parseResult = cut.ConvertNumberToWords(integerNumber);

            Assert.That(expectedResult == parseResult, $"Was expected: {expectedResult} But got: {parseResult}");
        }

        [Test]
        public void NumberWithMillionsOutputNumberWithMillions()
        {

            string integerNumber = "999 999 999,99";
            string expectedResult = $"nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine {DefaultValues.DollarPlural} and ninety-nine {DefaultValues.CentPlural}";

            string parseResult = cut.ConvertNumberToWords(integerNumber);

            Assert.That(expectedResult == parseResult, $"Was expected: {expectedResult} But got: {parseResult}");
        }

        [Test]
        public void NumberWithZeroThousandOutputWithoutThousand()
        {

            string integerNumber = "999 000 999,99";
            string expectedResult = $"nine hundred ninety-nine million nine hundred ninety-nine {DefaultValues.DollarPlural} and ninety-nine {DefaultValues.CentPlural}";

            string parseResult = cut.ConvertNumberToWords(integerNumber);

            Assert.That(expectedResult == parseResult, $"Was expected: {expectedResult} But got: {parseResult}");
        }

        [Test]
        public void NumberWithZeroMillionsOutputWithoutThousand()
        {

            string integerNumber = "000 999  999,99";
            string expectedResult = $"nine hundred ninety-nine thousand nine hundred ninety-nine {DefaultValues.DollarPlural} and ninety-nine {DefaultValues.CentPlural}";

            string parseResult = cut.ConvertNumberToWords(integerNumber);

            Assert.That(expectedResult == parseResult, $"Was expected: {expectedResult} But got: {parseResult}");
        }

        [Test]
        public void NumberWithZeroHundredsAndThousandsOutputWithoutMillionsAndThousand()
        {

            string integerNumber = "999000000,99";
            string expectedResult = $"nine hundred ninety-nine million {DefaultValues.DollarPlural} and ninety-nine {DefaultValues.CentPlural}";

            string parseResult = cut.ConvertNumberToWords(integerNumber);

            Assert.That(expectedResult == parseResult, $"Was expected: {expectedResult} But got: {parseResult}");
        }
    }
}
