using System;
using System.Linq;

namespace VariationsWithRepetitions
{
    public class StartUp
    {
        private static string[] _elements;
        private static string[] _variations;
        private static int _repeats;
        

        static void Main()
        {
            _elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            _repeats = int.Parse(Console.ReadLine());

            _variations = new string[_repeats];
            
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
                _variations[index] = _elements[i];
                Variations(index + 1);
            }
        }
    }
}
