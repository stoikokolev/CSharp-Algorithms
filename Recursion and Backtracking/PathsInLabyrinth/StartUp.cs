using System;
using System.Collections.Generic;

namespace PathsInLabyrinth
{
    public class StartUp
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var lab = ReadLabyrinth(rows, cols);

            var directions = new List<char>();

            FindAllPaths(lab, 0, 0, directions, '\0');
        }

        private static void FindAllPaths(char[,] lab, int row, int col, List<char> directions, char dir)
        {
            if (!IsPotentialCandidate(lab, row, col)) return;

            directions.Add(dir);

            if (IsExit(lab, row, col))
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count-1);
                return;
            }

            lab[row, col] = 'v';

            FindAllPaths(lab, row, col + 1, directions, 'R');
            FindAllPaths(lab, row - 1, col, directions, 'U');
            FindAllPaths(lab, row + 1, col, directions, 'D');
            FindAllPaths(lab, row, col - 1, directions, 'L');

            directions.RemoveAt(directions.Count-1);
            lab[row, col] = '-';
        }

        private static bool IsPotentialCandidate(char[,] lab, int row, int col)
        {
            if (!IsValid(lab, row, col) || IsWall(lab, row, col) || IsVisited(lab, row, col))
            {
                return false;
            }

            return true;
        }

        private static bool IsVisited(char[,] lab, int row, int col)
        {
            return lab[row, col] == 'v';
        }

        private static char[,] ReadLabyrinth(int rows, int cols)
        {
            var lab = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    lab[row, col] = input[col];
                }
            }

            return lab;
        }

        private static bool IsValid(char[,] lab, int row, int col)
        {
            return row >= 0
                   && row < lab.GetLength(0)
                   && col >= 0
                   && col < lab.GetLength(1);
        }

        private static bool IsWall(char[,] lab, int row, int col)
        {
            return lab[row, col] == '*';
        }

        private static bool IsExit(char[,] lab, int row, int col)
        {
            return lab[row, col] == 'e';
        }
    }
}
