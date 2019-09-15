using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Core.Modules.AccountOcrProcessor
{
    public class OcrFileProcessor
    {
        private readonly IOcrOutputConverter _outputConverter;

        public OcrFileProcessor(IOcrOutputConverter outputConverter)
        {
            _outputConverter = outputConverter;
        }
        
        public IEnumerable<string> ProcessFile(string filepath)
        {
            var ocrOutput =
                File
                    .ReadAllLines(filepath)
                    .ToList();


            for (int ix = 0; ix < ocrOutput.Count; ix+=4)
            {
                var input = ocrOutput.Skip(ix).Take(4).ToArray();

                yield return _outputConverter.AccountNumberFrom(input);
            }

        }
    }
}