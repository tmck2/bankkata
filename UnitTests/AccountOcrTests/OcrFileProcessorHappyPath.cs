using System;
using System.IO;
using Core.Modules.AccountOcrProcessor;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class OcrFileProcessorHappyPath
    {
        [Test]
        public void ProcessesFile()
        {
            var ocrAccountValidatorMoq = new Mock<IOcrAccountValidator>();
            ocrAccountValidatorMoq.Setup(x => x.IsValidAccount(It.IsAny<string>())).Returns(true);
            var expected = new[]
            {
                new Tuple<string, string>("000000000", ""),
                new Tuple<string, string>("111111111", ""),
                new Tuple<string, string>("222222222", ""),
                new Tuple<string, string>("333333333", ""),
                new Tuple<string, string>("444444444", ""),
                new Tuple<string, string>("555555555", ""),
                new Tuple<string, string>("666666666", ""),
                new Tuple<string, string>("777777777", ""),
                new Tuple<string, string>("888888888", ""),
                new Tuple<string, string>("999999999", ""),
                new Tuple<string, string>("123456789", "")
            };
            var sut = new OcrFileProcessor(new OcrOutputConverter(), ocrAccountValidatorMoq.Object);
            
            var result = sut.ProcessFile(Path.Combine("AccountOcrTests", "ProcessFileTest.txt"));

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}