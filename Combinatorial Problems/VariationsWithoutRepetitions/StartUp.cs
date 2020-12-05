using System;
using System.Linq;

namespace VariationsWithoutRepetitions
{
    public class StartUp
    {
        private static string[] _elements;
        private static string[] _variations;
        private static int _repeats;
        private static bool[] _used;

        static void Main()
        {
            _elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            _repeats = int.Parse(Console.ReadLine());

            _variations=new string[_repeats];

            _used=new bool[_elements.Length];

            Variations(0);
        }

        private static void Variations(int index)
        {
            if (index >= _variations.Length)
            {
                Console.WriteLine(string.Join(' ', _variations));
                return;
            }

            for (int i = 0; i < _elements.Length; i++)
            {
                if (!_used[i])
                {
                    _used[i] = true;
                    _variations[index] = _elements[i];
                    Variations(index+1);
                    _used[i] = false;
                }
            }
        }
    }
}
