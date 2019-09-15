using Core.Modules.AccountOcrProcessor;
using NUnit.Framework;

namespace Tests
{
    public class OcrAccountValidatorTests
    {
        [TestCase("457508000", ExpectedResult = true)]
        [TestCase("671495", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        [TestCase("664371495", ExpectedResult = false)]
        public bool ComputeChecksum(string accountNumber)
        {
            var sut = new OcrAccountValidator();

            return sut.IsValidAccount(accountNumber);
        }
    }
}