using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveDownRightSum
{
    public class StartUp
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var numbers = ReadMatrix(rows, cols);

            var sums = new int[rows, cols];
            sums[0, 0] = numbers[0, 0];

            FirstColSums(cols, sums, numbers);

            FirstRowSums(rows, sums, numbers);

            FindAllOtherSums(rows, cols, sums, numbers);

            var path = FindPath(rows, cols, sums);
            
            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<string> FindPath(int rows, int cols, int[,] sums)
        {
            var row = rows - 1;
            var col = cols - 1;

            var path = new Stack<string>();
            path.Push($"[{row}, {col}]");

            while (row > 0 && col > 0)
            {
                var upper = sums[row - 1, col];
                var left = sums[row, col - 1];

                if (upper > left)
                {
                    row--;
                }
                else
                {
                    col--;
                }

                path.Push($"[{row}, {col}]");
            }

            FillRestElements(row, col, path);
            return path;
        }

        private static void FillRestElements(int row, int col, Stack<string> path)
        {
            if (row == 0)
            {
                for (int i = col - 1; i >= 0; i--)
                {
                    path.Push($"[{row}, {i}]");
                }
            }
            else
            {
                for (int i = row - 1; i >= 0; i--)
                {
                    path.Push($"[{i}, {col}]");
                }
            }
        }

        private static void FindAllOtherSums(int rows, int cols, int[,] sums, int[,] numbers)
        {
            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    var upperCell = sums[row - 1, col];
                    var leftCell = sums[row, col - 1];

                    sums[row, col] = Math.Max(upperCell, leftCell) + numbers[row, col];
                }
            }
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            var numbers = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var elements =
                    Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    numbers[row, col] = elements[col];
                }
            }

            return numbers;
        }

        private static void FirstRowSums(int rows, int[,] sums, int[,] numbers)
        {
            for (int row = 1; row < rows; row++)
            {
                sums[row, 0] = sums[row - 1, 0] + numbers[row, 0];
            }
        }

        private static void FirstColSums(int cols, int[,] sums, int[,] numbers)
        {
            for (int col = 1; col < cols; col++)
            {
                sums[0, col] = sums[0, col - 1] + numbers[0, col];
            }
        }
    }
}
