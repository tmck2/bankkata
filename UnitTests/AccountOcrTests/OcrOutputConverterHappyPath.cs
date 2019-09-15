using Core.Modules;
using Core.Modules.AccountOcrProcessor;
using NUnit.Framework;

namespace Tests
{
    public class OcrOutputConverterHappyPath
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(""+
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                "                           ", ExpectedResult = "123456789")
        ]
        [TestCase(""+
                " _  _  _  _  _  _  _  _  _ ",
                "| | _| _||_||_ |_   || ||_|",
                "|_||_  _| _| _| _|  ||_||_|",
                "                           ", ExpectedResult = "023955708")
        ]
        public string SuccessfullyConvertsOutputFromOcr(string line1, string line2, string line3, string line4)
        {
            var sut = new OcrOutputConverter();

            return sut.AccountNumberFrom(new [] { line1, line2, line3, line4});
        }
    }
}