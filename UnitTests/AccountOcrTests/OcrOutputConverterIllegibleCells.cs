using Core.Modules.AccountOcrProcessor;
using NUnit.Framework;

namespace Tests
{
    public class OcrOutputConverterIllegibleCells
    {
        [TestCase(""+
                "    _  _  _  _  _  _  _  _ ",
                "| | _| _||_||_ |_   || ||_|",
                "|_||_  _| x| _| _|  ||_||_|",
                "                           ", ExpectedResult = "?23?55708")
        ]
        public string IllegibleCellsReplacedWithQuestionMarks(string line1, string line2, string line3, string line4)
        {
            var sut = new OcrOutputConverter();

            return sut.AccountNumberFrom(new [] { line1, line2, line3, line4});
        }
    }
}