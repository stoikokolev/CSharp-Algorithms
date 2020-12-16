using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSum
{
    public class StartUp
    {
        public static void Main()
        {
            var nums = new[] { 3, 5, 1, 4, 2 };
            var target = 6;

            var sums = GetAllSums(nums);

            var sumsAndNumbers = GetSumsAndNumbers(nums);

            if (sums.Contains(target))
            {
                Console.WriteLine(sums.Contains(target));

                while (target != 0)
                {
                    var number = sumsAndNumbers[target];
                    target -= number;

                    Console.Write(number + " ");
                }
            }
            else
            {
                Console.WriteLine(sums.Contains(target));
            }

        }

        private static Dictionary<int, int> GetSumsAndNumbers(int[] nums)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in nums)
            {
                var currentSums = sums.Keys.ToArray();

                foreach (var sum in currentSums)
                {
                    var newSum = sum + num;

                    if (!sums.ContainsKey(newSum))
                    {
                        sums.Add(newSum, num);
                    }
                }
            }

            return sums;
        }

        private static HashSet<int> GetAllSums(int[] nums)
        {
            var sums = new HashSet<int> { 0 };

            foreach (var num in nums)
            {
                var newSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    var newSum = num + sum;
                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            return sums;
        }
    }
}
