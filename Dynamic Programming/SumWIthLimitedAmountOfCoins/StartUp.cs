using System;
using System.Collections.Generic;
using System.Linq;

namespace SumWIthLimitedAmountOfCoins
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers =
                Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var target = int.Parse(Console.ReadLine());

            var sums = CalcSums(numbers);

            Console.WriteLine(sums[target]);
        }

        private static Dictionary<int,int> CalcSums(int[] numbers)
        {
            var result = new Dictionary<int,int>{{0,1}};

            foreach (var number in numbers)
            {
                var sums = result.Keys.ToArray();

                foreach (var sum in sums)
                {
                    var newSum = sum + number;

                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum,1);
                    }
                    else
                    {
                        result[newSum]++;
                    }
                }
            }

            return result;
        }
    }
}
