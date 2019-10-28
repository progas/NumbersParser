using NUnit.Framework;
using WritingNumbers.Logic;

namespace UnitTests.LogicTests
{
    [TestFixture]
    public class FloatNumberSeparatorTest
    {
        FloatNumberSeparator cut;

        [Test]
        public void InputFloatNumber_CorrectSeparateChar_InitializedSeparatorProperty()
        {
            char separator = ',';
            cut = new FloatNumberSeparator(separator);
            Assert.That(cut.SymbolSeparator == separator);
        }


        [Test]
        public void InputFloatNumber_CorrectSeparateChar_CorrectIntegerAndFractionalPart()
        {
            char separator = ',';
            cut = new FloatNumberSeparator(separator);
            string leftSideDigits = "123443231";
            string rightSideDigits = "3212341";

            string floatNumber = this.CombineFloatNumber(leftSideDigits, separator, rightSideDigits);
            Assert.That(leftSideDigits == cut.SeparateIntegerNumber(floatNumber));
            Assert.That(rightSideDigits == cut.SeparateFractionalNumber(floatNumber, rightSideDigits.Length));

        }


        [Test]
        public void InputFloatNumber_IncorrectSeparateChar_IncorrectIntegerAndEmptyFractionalParts()
        {
            char separator = ',';
            cut = new FloatNumberSeparator(';');
            string leftSideDigits = "123443231";
            string rightSideDigits = "3212341";

            string floatNumber = this.CombineFloatNumber(leftSideDigits, separator, rightSideDigits);
            var r = cut.SeparateFractionalNumber(floatNumber, rightSideDigits.Length);
            Assert.That(floatNumber == cut.SeparateIntegerNumber(floatNumber));
            Assert.That(string.IsNullOrEmpty(cut.SeparateFractionalNumber(floatNumber, rightSideDigits.Length)));

        }

        [Test]
        public void InputFloatNumber_NumberOfCutDigitsLessThenFractionalPartLength_FractionalPartEqualNumberOfDigits()
        {
            int numberOfCutDigits = 3;
            char separator = ',';
            cut = new FloatNumberSeparator(separator);
            string leftSideDigits = "123443231";
            string rightSideDigits = "3212341";

            string floatNumber = this.CombineFloatNumber(leftSideDigits, separator, rightSideDigits);
            var r = cut.SeparateFractionalNumber(floatNumber, numberOfCutDigits);

            Assert.That(cut.SeparateFractionalNumber(floatNumber, numberOfCutDigits).Length == numberOfCutDigits);

            Assert.That(cut.SeparateFractionalNumber(floatNumber, numberOfCutDigits).Length == rightSideDigits.Remove(numberOfCutDigits).Length);

        }

        [Test]
        public void InputFloatNumber_NumberOfCutDigitsMoreThenFractionalPartLength_FractionalPartWithAdditionalZeros()
        {
            int numberOfCutDigits = 3;
            char separator = ',';
            cut = new FloatNumberSeparator(separator);
            string leftSideDigits = "123443231";
            string rightSideDigits = "3";

            string floatNumber = this.CombineFloatNumber(leftSideDigits, separator, rightSideDigits);
            var result = cut.SeparateFractionalNumber(floatNumber, numberOfCutDigits);
            /// Assert.That(floatNumber == cut.SeparateIntegerNumber(floatNumber));
            Assert.That(cut.SeparateFractionalNumber(floatNumber, numberOfCutDigits).Length == numberOfCutDigits);
            Assert.That(rightSideDigits + "00" == result);

        }


        private string CombineFloatNumber(string leftPart, char separator, string rightPart)
        {
            return leftPart + separator + rightPart;
        }
    }
}
