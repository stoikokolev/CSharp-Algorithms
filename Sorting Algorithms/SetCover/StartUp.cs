using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetCover
{
    public class StartUp
    {
        public static void Main()
        {
            var universe = Console.ReadLine().Split(", ").Select(int.Parse).ToHashSet();
            var sets = new HashSet<HashSet<int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                var set = input.Split(", ").Select(int.Parse).ToHashSet();
                sets.Add(set);
            }

            var smallestSubset = GetSmallestSubset(universe, sets);

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Sets to take ({smallestSubset.Count}):");

            foreach (var set in smallestSubset)
            {
                stringBuilder.AppendLine(string.Join(", ", set));
            }

            Console.WriteLine(stringBuilder.ToString().TrimEnd());
        }

        private static HashSet<HashSet<int>> GetSmallestSubset(HashSet<int> universe, HashSet<HashSet<int>> sets)
        {
            var smallestSubset = new HashSet<HashSet<int>>();

            while (universe.Count > 0)
            {
                var greedySet = GetGreedySet(universe, sets);
                universe.ExceptWith(greedySet);

                smallestSubset.Add(greedySet);
            }

            return smallestSubset;
        }

        private static HashSet<int> GetGreedySet(HashSet<int> universe, IEnumerable<HashSet<int>> sets)
        {
            var greedySet = new HashSet<int>();
            var result = new HashSet<int>();

            foreach (var set in sets)
            {
                var current = set.Intersect(universe).ToHashSet();
                if (greedySet.Count >= current.Count) continue;
                greedySet = current;
                result = set;
            }

            return result;
        }
    }
}
