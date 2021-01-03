using System;
using System.Linq;

namespace exam2
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftSocks = Console.ReadLine().Split();
            var rightSocks = Console.ReadLine().Split();

            var bag = new int[leftSocks.Length + 1, rightSocks.Length + 1];

            for (int row = 1; row < bag.GetLength(0); row++)
            {
                for (int col = 1; col < bag.GetLength(1); col++)
                {
                    if (leftSocks[row - 1] == rightSocks[col - 1])
                    {
                        bag[row, col] = bag[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        bag[row, col] = Math.Max(bag[row - 1, col], bag[row, col - 1]);
                    }
                }
            }

            Console.WriteLine(bag[leftSocks.Length,rightSocks.Length]);
        }
    }
}
