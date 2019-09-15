using System.IO;
using Core.Modules.AccountOcrProcessor;
using NUnit.Framework;

namespace Tests
{
    public class OcrFileProcessorHappyPath
    {
        [Test]
        public void ProcessesFile()
        {
            var expected = new[]
            {
                "000000000",
                "111111111",
                "222222222",
                "333333333",
                "444444444",
                "555555555",
                "666666666",
                "777777777",
                "888888888",
                "999999999",
                "123456789"
            };
            var sut = new OcrFileProcessor(new OcrOutputConverter());
            
            var result = sut.ProcessFile(Path.Combine("AccountOcrTests", "ProcessFileTest.txt"));

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}