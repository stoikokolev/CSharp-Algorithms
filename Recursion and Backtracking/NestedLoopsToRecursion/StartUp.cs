using System;

namespace NestedLoopsToRecursion
{
    public class StartUp
    {
        private static int number;

        static void Main()
        {
            number = int.Parse(Console.ReadLine());

            var vector = new int[number];

            Generate01(vector, 0);
        }

        private static void Generate01(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int count = 1; count <= number; count++)
            {
                vector[index] = count;
                Generate01(vector, index + 1);
            }
        }
    }
}