using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreasInAMatrix
{
    public class StartUp
    {
        private const char Visited = 'v';
        private const char Wall = '*';

        //public class Area
        //{
        //    public Area(int row, int col, int size)
        //    {
        //        this.Row = row;
        //        this.Col = col;
        //        this.Size = size;
        //    }

        //    public int Row { get; set; }
        //    public int Col { get; set; }
        //    public int Size { get; set; }
        //}

        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new char[rows, cols];

            FillMatrix(matrix);

            var areas = new List<Area>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] != Visited && matrix[row, col] != Wall)
                    {
                        var size = GetSize(row, col, matrix);
                        var area = new Area(row, col, size);
                        areas.Add(area);
                    }
                }
            }

            Console.WriteLine($"Total areas found: {areas.Count}");
            var count = 0;
            foreach (var area in areas.OrderByDescending(x => x.Size).ThenBy(x => x.Row).ThenBy(x => x.Col))
            {
                count++;
                Console.WriteLine($"Area #{count} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static int GetSize(int row, int col, char[,] matrix)
        {
            if (IsOutside(row, col, matrix))
            {
                return 0;
            }

            if (IsVisited(row, col, matrix))
            {
                return 0;
            }

            if (IsWall(row, col, matrix))
            {
                return 0;
            }

            matrix[row, col] = 'v';

            return 1 + GetSize(row + 1, col, matrix) +
                   GetSize(row - 1, col, matrix) +
                   GetSize(row, col + 1, matrix) +
                   GetSize(row, col - 1, matrix);
        }

        private static bool IsOutside(in int row, in int col, char[,] matrix)
        {
            return row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);
        }

        private static bool IsWall(int row, int col, char[,] matrix)
        {
            return matrix[row, col] == Wall;
        }

        private static bool IsVisited(int row, int col, char[,] matrix)
        {
            return matrix[row, col] == Visited;
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
