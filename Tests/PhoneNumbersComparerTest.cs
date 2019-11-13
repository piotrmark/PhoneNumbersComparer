using NUnit.Framework;
using PhoneNumbersComparer;

namespace Tests
{
    public class PhoneNumbersComparerTest
    {
        [Test]
        [TestCase("1234", "1234", true)]
        [TestCase("(123) 456 - 7890", "123.456.7890", true)]
        [TestCase("1-123-456-7890", "123-456-7890", false)]
        [TestCase(null, null, true)]
        [TestCase("", null, true)]
        [TestCase("   ", null, true)]
        [TestCase("asdf", "jk;l", true)]
        [TestCase("---1 2 3 -- 4 ----- ", "1 2 3  4", true)]
        [TestCase("1 2 3 4", "    123 ------", false)]
        public void PhoneNumbersMatchSimpleTest(string number1, string number2, bool expectedResult)
        {
            Assert.AreEqual(Comparer.PhoneNumbersMatchSimple(number1, number2), expectedResult);
        }

        [Test]
        [TestCase("1234", "1234", true)]
        [TestCase("(123) 456 - 7890", "123.456.7890", true)]
        [TestCase("1-123-456-7890", "123-456-7890", false)]
        [TestCase(null, null, true)]
        [TestCase("", null, true)]
        [TestCase("   ", null, true)]
        [TestCase("asdf", "jk;l", true)]
        [TestCase("---1 2 3 -- 4 ----- ", "1 2 3  4", true)]
        [TestCase("1 2 3 4", "    123 ------", false)]
        public void PhoneNumbersMatchOptimalTest(string number1, string number2, bool expectedResult)
        {
            Assert.AreEqual(Comparer.PhoneNumbersMatchOptimal(number1, number2), expectedResult);
        }
    }
}