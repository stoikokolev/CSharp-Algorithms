using System;
using System.Collections.Generic;
using System.Linq;

namespace DividingPresents
{
    public class StartUp
    {
        public static void Main()
        {
            var presents =
                Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var sums = CalcSums(presents);
            var presentsSum = presents.Sum();

            var bobScore = FindBobScore(presentsSum, sums);
            var alanScore = presentsSum - bobScore;

            var alanPresents = GetPresents(sums, alanScore);
            //var bobPresents = GetPresents(sums, bobScore);

            PrintOutput(bobScore, alanScore, alanPresents);
        }

        private static void PrintOutput(int bobScore, int alanScore, List<int> alanPresents)
        {
            Console.WriteLine($"Difference: {bobScore - alanScore}");
            Console.WriteLine($"Alan:{alanScore} Bob:{bobScore}");
            Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static List<int> GetPresents(Dictionary<int, int> sums, int target)
        {
            var presents = new List<int>();

            while (target != 0)
            {
                var present = sums[target];
                presents.Add(present);
                target -= present;
            }

            return presents;
        }

        private static int FindBobScore(int presentsSum, Dictionary<int, int> sums)
        {
            var bobScore = (int)Math.Ceiling(presentsSum / 2.0);

            while (!sums.ContainsKey(bobScore))
            {
                bobScore++;
            }

            return bobScore;
        }

        private static Dictionary<int, int> CalcSums(int[] numbers)
        {
            var result = new Dictionary<int, int> { { 0, 0 } };

            foreach (var number in numbers)
            {
                var sums = result.Keys.ToArray();

                foreach (var sum in sums)
                {
                    var newSum = sum + number;

                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, number);
                    }
                }
            }

            return result;
        }
    }
}
