using System;

namespace CombinationsWithoutRepetitionExercise
{
    public class StartUp
    {
        private static int[] _elements;
        private static int _repeats;

        private static int[] _combinations;

        public static void Main()
        {
            var numberOfElements = int.Parse(Console.ReadLine());
            _elements = new int[numberOfElements];
            for (int i = 0; i < numberOfElements; i++)
            {
                _elements[i] = i + 1;
            }

            _repeats = int.Parse(Console.ReadLine());

            _combinations = new int[_repeats];

            Combinations(0, 0);
        }

        private static void Combinations(int combinationIndex, int elementStartIndex)
        {
            if (combinationIndex >= _combinations.Length)
            {
                Console.WriteLine(string.Join(' ', _combinations));
                return;
            }

            for (int i = elementStartIndex; i < _elements.Length; i++)
            {
                _combinations[combinationIndex] = _elements[i];
                Combinations(combinationIndex + 1, i+1);
            }
        }
    }
}
