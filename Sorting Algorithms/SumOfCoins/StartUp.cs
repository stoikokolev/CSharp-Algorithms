using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumOfCoins
{
    public class StartUp
    {
        static void Main()
        {
            var coins = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var sortedCoins = new SortedSet<int>(coins);

            var target = int.Parse(Console.ReadLine());
            var result = 0;
            var sb = new StringBuilder();

            while (target > 0 && sortedCoins.Count > 0)
            {
                var maxCoin = sortedCoins.Max;
                sortedCoins.Remove(maxCoin);

                if (maxCoin > target)
                {
                    continue;
                }

                var counter = target / maxCoin;
                result += counter;

                target = target - maxCoin * counter;
                sb.AppendLine($"{counter} coin(s) with value {maxCoin}");
            }

            if (target > 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {result}");
                Console.WriteLine(sb.ToString());
            }

        }
    }
}
