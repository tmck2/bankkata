using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Core.Modules.AccountOcrProcessor
{
    public class OcrFileProcessor
    {
        private readonly IOcrOutputConverter _outputConverter;
        private readonly IOcrAccountValidator _accountValidator;

        public OcrFileProcessor(IOcrOutputConverter outputConverter, IOcrAccountValidator accountValidator)
        {
            _outputConverter = outputConverter;
            _accountValidator = accountValidator;
        }
        
        public IEnumerable<Tuple<string, string>> ProcessFile(string filepath)
        {
            var ocrOutput =
                File
                    .ReadAllLines(filepath)
                    .ToList();


            for (int ix = 0; ix < ocrOutput.Count; ix+=4)
            {
                var input = ocrOutput.Skip(ix).Take(4).ToArray();

                var acct = _outputConverter.AccountNumberFrom(input);

                if (acct.Contains("?"))
                {
                    yield return new Tuple<string, string>(acct, "ILL");
                }

                if (_accountValidator.IsValidAccount(acct))
                {
                    yield return new Tuple<string, string>(acct, string.Empty);
                }
                else
                {
                    yield return new Tuple<string, string>(acct, "ERR");
                }
            }

        }
    }
}