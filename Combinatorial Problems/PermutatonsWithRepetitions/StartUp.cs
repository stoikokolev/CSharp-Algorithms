using System;
using System.Collections.Generic;
using System.Linq;

namespace PermutationsWithRepetitions
{
    public class StartUp
    {
        private static string[] _elements;

        static void Main()
        {
            _elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Permute(0);
        }

        private static void Permute(int permutationsIndex)
        {
            if (permutationsIndex >= _elements.Length)
            {
                Console.WriteLine(string.Join(' ', _elements));
                return;
            }

            Permute(permutationsIndex + 1);

            var swapped = new HashSet<string>() { _elements[permutationsIndex] };

            for (int i = permutationsIndex + 1; i < _elements.Length; i++)
            {
                if (!swapped.Contains(_elements[i]))
                {
                    Swap(permutationsIndex, i);
                    Permute(permutationsIndex + 1);
                    Swap(permutationsIndex, i);
                    swapped.Add(_elements[i]);
                }
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = _elements[first];
            _elements[first] = _elements[second];
            _elements[second] = temp;
        }
    }
}
