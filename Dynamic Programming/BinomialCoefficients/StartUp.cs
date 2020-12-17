using System;
using System.Collections.Generic;
using System.Xml.Xsl;

namespace BinomialCoefficients
{
    public class StartUp
    {
        private static Dictionary<string, long> memo;

        public static void Main()
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            memo=new Dictionary<string, long>();

            Console.WriteLine(GetBinom(row, col));
        }

        private static long GetBinom(int row, int col)
        {
            var id = $"{row} {col}";

            if (memo.ContainsKey(id))
            {
                return memo[id];
            }

            if (col == 0 || row == col)
            {
                return 1;
            }

            var result = (GetBinom(row - 1, col) + GetBinom(row - 1, col - 1));
            memo[id] = result;

            return result;
        }
    }
}
