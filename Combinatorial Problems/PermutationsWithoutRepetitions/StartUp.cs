using System;
using System.Linq;

namespace PermutationsWithoutRepetitions
{
    public class StartUp
    {
        private static string[] _elements;
        private static string[] _permutations;
        private static bool[] _used;

        static void Main()
        {
            _elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            _permutations = new string[_elements.Length];
            _used = new bool[_elements.Length];

            PermuteWithSingleCollection(0);
            //Permute(0);
        }

        private static void Permute(int permutationsIndex)
        {
            if (permutationsIndex >= _elements.Length)
            {
                Console.WriteLine(string.Join(' ', _permutations));
                return;
            }

            for (int elementIndex = 0; elementIndex < _elements.Length; elementIndex++)
            {
                if (!_used[elementIndex])
                {
                    _used[elementIndex] = true;
                    _permutations[permutationsIndex] = _elements[elementIndex];
                    Permute(permutationsIndex + 1);
                    _used[elementIndex] = false;
                }
            }

        }

        private static void PermuteWithSingleCollection(int permutationsIndex)
        {
            if (permutationsIndex >= _elements.Length)
            {
                Console.WriteLine(string.Join(' ', _elements));
                return;
            }

            PermuteWithSingleCollection(permutationsIndex+1);

            for (int i = permutationsIndex+1; i < _elements.Length; i++)
            {
                Swap(permutationsIndex, i);
                PermuteWithSingleCollection(permutationsIndex+1);
                Swap(permutationsIndex, i);
            }
        }

        private static void Swap( int first, int second)
        {
            var temp = _elements[first];
            _elements[first] = _elements[second];
            _elements[second] = temp;
        }
    }
}
