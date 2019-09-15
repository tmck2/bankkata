using Core.Modules;
using NUnit.Framework;

namespace Tests
{
    public class AccountOcrTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var sut = new AccountOcr();

            var input =
                "    _  _     _  _  _  _  _ " +
                "  | _| _||_||_ |_   ||_||_|" +
                "  ||_  _|  | _||_|  ||_| _|";

            var expected = "123456789";

            var result = sut.AccountNumberFromOcrOutput(input);
            
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}