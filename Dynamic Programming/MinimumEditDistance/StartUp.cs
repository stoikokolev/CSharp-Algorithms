using System;

namespace MinimumEditDistance
{
    public class StartUp
    {
        public static void Main()
        {
            var replaceCost = int.Parse(Console.ReadLine());
            var insertCost = int.Parse(Console.ReadLine());
            var deleteCost = int.Parse(Console.ReadLine());

            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();

            int result = CalculateMinimumEditDistance(s1, s2, replaceCost, insertCost, deleteCost);

            Console.WriteLine($"Minimum edit distance: {result}");
        }

        private static int CalculateMinimumEditDistance(string s1, string s2, int replaceCost, int insertCost, int deleteCost)
        {
            var table = new int[s2.Length + 1, s1.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                table[r, 0] = r * insertCost;
            }

            for (int c = 1; c < table.GetLength(1); c++)
            {
                table[0, c] = c * deleteCost;
            }

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (s2[r - 1] != s1[c - 1])
                    {
                        int insert = table[r - 1, c] + insertCost;
                        int replace = table[r - 1, c - 1] + replaceCost;
                        int delete = table[r, c - 1] + deleteCost;

                        table[r, c] = Math.Min(Math.Min(delete, insert), replace);
                    }
                    else
                    {
                        table[r, c] = table[r - 1, c - 1];
                    }
                }
            }

            return table[table.GetLength(0) - 1, table.GetLength(1) - 1];
        }
    }
}
