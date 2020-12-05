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
            _elements = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
            _permutations = new string[_elements.Length];
            _used = new bool[_elements.Length];

            Permute(0);
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
                    Permute(permutationsIndex+1);
                    _used[elementIndex] = false;
                }
            }
        }
    }
}
