using System.Collections.Generic;
using System.Linq;

namespace Core.Modules.AccountOcrProcessor
{
    public interface IOcrOutputConverter
    {
        string AccountNumberFrom(string[] inputLines);
    }
    
    public class OcrOutputConverter : IOcrOutputConverter
    {
        public string AccountNumberFrom(string[] inputLines)
        {
            // Get individual character cells of input
            var charCells = 
                Enumerable
                    .Range(0, 9)
                    .Select(ix => GetCharCell(inputLines, ix));
                
            // Look up digit for each cell
            var digits = charCells.Select(cell => OcrToIntMapping.FirstOrDefault(kv => MatchCell(kv.Key, cell)).Value ?? "?");
                
            return string.Concat(digits);
        }

        private static string[] GetCharCell(string[] inputLines, int ix)
        {
            return new[]
            {
                inputLines[0].Substring(ix * 3, 3),
                inputLines[1].Substring(ix * 3, 3),
                inputLines[2].Substring(ix * 3, 3),
                inputLines[3].Substring(ix * 3, 3)
            };
        }

        private static bool MatchCell(string[] cell1, string[] cell2)
        {
            return cell1.Zip(cell2, (lhs, rhs) => new { lhs, rhs }).All(x => x.lhs == x.rhs);
        }
        
        private Dictionary<string[], string> OcrToIntMapping = new Dictionary<string[], string>
        {
            {
                new[] {
                    " _ ",
                    "| |",
                    "|_|",
                    "   "
                }, "0"
            },
            {
                new[] {
                    "   ",
                    "  |",
                    "  |",
                    "   "
                }, "1"
            },
            {
                new[] {
                    " _ ",
                    " _|",
                    "|_ ",
                    "   "
                }, "2"
            },
            {
                new[] {
                    " _ ",
                    " _|",
                    " _|",
                    "   "
                }, "3"
            },
            {
                new[] {
                    "   ",
                    "|_|",
                    "  |",
                    "   "
                }, "4"
            },
            {
                new[] {
                    " _ ",
                    "|_ ",
                    " _|",
                    "   "
                }, "5"
            },
            {
                new[] {
                    " _ ",
                    "|_ ",
                    "|_|",
                    "   "
                }, "6"
            },
            {
                new[] {
                    " _ ",
                    "  |",
                    "  |",
                    "   "
                }, "7"
            },
            {
                new[] {
                    " _ ",
                    "|_|",
                    "|_|",
                    "   "
                }, "8"
            },
            {
                new[] {
                    " _ ",
                    "|_|",
                    " _|",
                    "   "
                }, "9"
            },
        };

    }
}