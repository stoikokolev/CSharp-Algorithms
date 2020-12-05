using System;
using System.Linq;

namespace CombinationsWithoutRepetitions
{
    public class StartUp
    {
        private static string[] elements;
        private static int repeats;

        private static string[] combinations;

        public static void Main()
        {
            elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            repeats = int.Parse(Console.ReadLine());

            combinations = new string[repeats];

            Combinations(0,0);
        }

        private static void Combinations(int combinationIndex, int elementStartIndex)
        {
            if (combinationIndex >= combinations.Length)
            {
                Console.WriteLine(string.Join(' ', combinations));
                return;
            }

            for (int i = elementStartIndex; i < elements.Length; i++)
            {
                combinations[combinationIndex] = elements[i];
                Combinations(combinationIndex+1, i+1);
            }
        }
    }
}
