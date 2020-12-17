using System;
using System.Linq;

namespace SumWithUnlimitedCoins
{
    public class StartUp
    {

        public static void Main()
        {
            var coins =
                Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            var target = int.Parse(Console.ReadLine());

            var count = GetCount(coins, target);

            Console.WriteLine(count);
        }

        private static int GetCount(int[] coins, int target)
        {
            var sums = new int[target + 1];
            sums[0] = 1;

            foreach (var coin in coins)
            {
                for (int sum = coin; sum < sums.Length; sum++)
                {
                    sums[sum] += sums[sum - coin];
                }
            }

            return sums[target];
        }
    }
}
