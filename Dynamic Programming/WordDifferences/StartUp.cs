using System;

namespace WordDifferences
{
    public class StartUp
    {
        public static void Main()
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var table = new int[str1.Length + 1, str2.Length + 1];

            FillFirstRowAndCol(table);

            FillRestOfTheTable(table, str1, str2);

            Console.WriteLine($"Deletions and Insertions: {table[str1.Length, str2.Length]}");
        }

        private static void FillRestOfTheTable(int[,] table, string str1, string str2)
        {
            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1];
                    }
                    else
                    {
                        table[r, c] = Math.Min(table[r, c - 1], table[r - 1, c]) + 1;
                    }
                }
            }
        }

        private static void FillFirstRowAndCol(int[,] table)
        {
            for (int r = 1; r < table.GetLength(0); r++)
            {
                table[r, 0] = r;
            }

            for (int c = 1; c < table.GetLength(1); c++)
            {
                table[0, c] = c;
            }
        }
    }
}
