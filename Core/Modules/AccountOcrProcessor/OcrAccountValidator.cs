using System;
using System.Linq;

namespace Core.Modules.AccountOcrProcessor
{
    public interface IOcrAccountValidator
    {
        bool IsValidAccount(string accountNumber);
    }
    
    public class OcrAccountValidator : IOcrAccountValidator
    {
        public bool IsValidAccount(string accountNumber)
        {
            if (accountNumber == null || accountNumber.Length != 9)
                return false;

            var vec = Enumerable.Range(1, 9).Reverse();
            var accountDigits = accountNumber.ToCharArray().Select(ch => ch - '0');

            var checksum = vec.Zip(accountDigits, (v, d) => v * d).Sum() % 11;

            return checksum == 0;
        }
    }
}