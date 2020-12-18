using System;
using System.Collections.Generic;
using System.Linq;

namespace Time
{
    public class StartUp
    {
        public static void Main()
        {
            var str1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var str2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var table = new int[str1.Length + 1, str2.Length + 1];
            
            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                    {
                        TakeTopLeftDiagonalElement(table, row, col);
                    }
                    else
                    {
                        TakeBiggerTopOrLeft(table, row, col);
                    }
                }
            }

            var matches = FindMatches(str1, str2, table);

            Console.WriteLine(string.Join(" ", matches));

            Console.WriteLine(table[str1.Length, str2.Length]);
        }

        private static Stack<int> FindMatches(int[] str1, int[] str2, int[,] table)
        {
            var matches = new Stack<int>();

            var row = str1.Length;
            var col = str2.Length;


            while (row > 0 && col > 0)
            {
                if (str1[row - 1] == str2[col - 1])
                {
                    row--;
                    col--;

                    matches.Push(str1[row]);
                }
                else if (table[row - 1, col] > table[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            return matches;
        }

        private static void TakeBiggerTopOrLeft(int[,] table, int row, int col)
        {
            table[row, col] = Math.Max(table[row - 1, col], table[row, col - 1]);
        }

        private static void TakeTopLeftDiagonalElement(int[,] table, int row, int col)
        {
            table[row, col] = table[row - 1, col - 1] + 1;
        }
    }
}
