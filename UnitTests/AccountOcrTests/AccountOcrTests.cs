using Core.Modules;
using NUnit.Framework;

namespace Tests
{
    public class HappyPathScenario
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(""+ 
                "    _  _     _  _  _  _  _ " +
                "  | _| _||_||_ |_   ||_||_|" +
                "  ||_  _|  | _||_|  ||_| _|" +
                "                           ", ExpectedResult = "123456789")
        ]
        [TestCase(""+ 
                " _  _  _  _  _  _  _  _  _ " +
                "| | _| _||_||_ |_   || ||_|" +
                "|_||_  _|  | _| _|  ||_||_|" +
                "                           ", ExpectedResult = "023955708")
        ]
        public string SuccessfullyConvertsOutputFromOcr(string input)
        {
            var sut = new AccountOcr();

            return sut.AccountNumberFromOcrOutput(input);
        }
    }
}