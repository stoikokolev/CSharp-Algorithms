using System;
using System.Collections.Generic;

namespace TwoMinutesToMidnight
{
    public class StartUp
    {
        private static Dictionary<string, long> _memo;
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            _memo = new Dictionary<string, long>();

            var ways = GetBinom(n, k);

            Console.WriteLine(ways);
        }

        private static long GetBinom(int n, int k)
        {
            var id = $"{n} {k}";

            if (_memo.ContainsKey(id))
            {
                return _memo[id];
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            var result = GetBinom(n - 1, k) + GetBinom(n - 1, k - 1);

            _memo.Add(id,result);

            return result;
        }
    }
}
