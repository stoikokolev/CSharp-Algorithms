using System;

namespace SubsetSumsWithRepetition
{
    public class StartUp
    {
        public static void Main()
        {
            var nums = new[] { 3, 5, 2 };
            var target = 17;

            var sums = new bool[target + 1];
            sums[0] = true;

            for (var sum = 0; sum < sums.Length; sum++)
            {
                if (sums[sum])
                {
                    foreach (var num in nums)
                    {
                        var newSum = sum + num;

                        if (newSum <= target)
                        {
                            sums[newSum] = true;
                        }
                    }
                }
            }

            while (target > 0)
            {
                foreach (var num in nums)
                {
                    var prev = target - num;

                    if (prev >= 0)
                    {
                        if (sums[prev])
                        {
                            Console.Write(num + " ");
                            target = prev;
                        }
                    }
                }
            }

        }
    }
}
