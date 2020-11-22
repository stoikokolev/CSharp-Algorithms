using System;

namespace Generating0_1Vectors
{
    public class StartUp
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var vector = new int[number];

            Generate01(vector, 0);
        }

        private static void Generate01(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int number = 0; number <= 1; number++)
            {
                vector[index] = number;
                Generate01(vector, index + 1);
            }
        }
    }
}
