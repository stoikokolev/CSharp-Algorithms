using System;
using System.Collections.Generic;

namespace exam1
{
    class Program
    {

        public class Node
        {
            public int Row { get; set; }

            public int Col { get; set; }
        }

        private static char[,] _matrix;
        private static bool[,] _visited;

        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            _matrix = ReadMatrix(rows, cols);
            _visited = new bool[rows, cols];

            var areas = new SortedDictionary<char, int>();
            var counter = 0;

            for (int row = 0; row < _matrix.GetLength(0); row++)
            {
                for (int col = 0; col < _matrix.GetLength(1); col++)
                {
                    if (_visited[row, col])
                    {
                        continue;
                    }

                    DFS(row, col);
                    counter++;

                    var key = _matrix[row, col];
                    if (!areas.ContainsKey(_matrix[row, col]))
                    {
                        areas.Add(key, 1);
                    }
                    else
                    {
                        areas[key] += 1;
                    }
                }
            }

            Console.WriteLine(areas.ContainsKey('t') ? areas['t'] : 0);
        }

        private static void DFS(int row, int col)
        {
            _visited[row, col] = true;

            var children = GetChildren(row, col);

            foreach (var child in children)
            {
                DFS(child.Row, child.Col);
            }
        }

        private static List<Node> GetChildren(int row, int col)
        {
            var result = new List<Node>();
            if (IsInside(row - 1, col) && IsChild(row, col, row - 1, col) && !_visited[row - 1, col])
            {
                result.Add(new Node() { Row = row - 1, Col = col });
            }
            if (IsInside(row + 1, col) && IsChild(row, col, row + 1, col) && !_visited[row + 1, col])
            {
                result.Add(new Node() { Row = row + 1, Col = col });
            }
            if (IsInside(row, col + 1) && IsChild(row, col, row, col + 1) && !_visited[row, col + 1])
            {
                result.Add(new Node() { Row = row, Col = col + 1 });
            }
            if (IsInside(row, col - 1) && IsChild(row, col, row, col - 1) && !_visited[row, col - 1])
            {
                result.Add(new Node() { Row = row, Col = col - 1 });
            } //diagonals
            if (IsInside(row - 1, col - 1) && IsChild(row, col, row - 1, col - 1) && !_visited[row - 1, col - 1])
            {
                result.Add(new Node() { Row = row - 1, Col = col - 1 });
            }
            if (IsInside(row - 1, col + 1) && IsChild(row, col, row - 1, col + 1) && !_visited[row - 1, col + 1])
            {
                result.Add(new Node() { Row = row - 1, Col = col + 1 });
            }
            if (IsInside(row + 1, col - 1) && IsChild(row, col, row + 1, col - 1) && !_visited[row + 1, col - 1])
            {
                result.Add(new Node() { Row = row + 1, Col = col - 1 });
            }
            if (IsInside(row + 1, col + 1) && IsChild(row, col, row + 1, col + 1) && !_visited[row + 1, col + 1])
            {
                result.Add(new Node() { Row = row + 1, Col = col + 1 });
            }

            return result;
        }

        private static bool IsChild(int parentRow, int parentCol, int childRow, int childCol) => _matrix[parentRow, parentCol] == _matrix[childRow, childCol];

        private static bool IsInside(int row, int col) => row >= 0 && row < _matrix.GetLength(0) && col >= 0 && col < _matrix.GetLength(1);

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = line[col];
                }
            }

            return result;
        }
    }
}
