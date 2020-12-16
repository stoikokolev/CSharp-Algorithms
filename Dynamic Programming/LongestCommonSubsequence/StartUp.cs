using System;
using System.Collections.Generic;

namespace LongestCommonSubsequence
{
    public class StartUp
    {
        public static void Main()
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var table = CreateTableWithMatches(str1, str2);

            var matches = FindMatches(str1, str2, table);

            Console.WriteLine(table[str1.Length, str2.Length]);

            Console.WriteLine(string.Join(" ", matches));
        }

        private static Stack<char> FindMatches(string str1, string str2, int[,] table)
        {
            var matches = new Stack<char>();

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

        private static int[,] CreateTableWithMatches(string str1, string str2)
        {
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

            return table;
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
