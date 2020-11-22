using System;
using System.Collections.Generic;

namespace EightQueensProblem
{
    public class StartUp
    {
        private const int Size = 8;
        private static readonly bool[,] Chessboard = new bool[Size, Size];

        private static readonly HashSet<int> AttackedRows = new HashSet<int>();
        private static readonly HashSet<int> AttackedCols = new HashSet<int>();
        private static readonly HashSet<int> AttackedLeftDiagonals = new HashSet<int>();
        private static readonly HashSet<int> AttackedRightDiagonals = new HashSet<int>();

        static void Main()
        {

            PutQueens(0);

        }

        private static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintBoard();
            }

            for (int col = 0; col < Size; col++)
            {
                if (!IsAttacked(row, col))
                {
                    Chessboard[row, col] = true;
                    AttackedRows.Add(row);
                    AttackedCols.Add(col);
                    AttackedLeftDiagonals.Add(col - row);
                    AttackedRightDiagonals.Add(col + row);

                    PutQueens(row + 1);

                    Chessboard[row, col] = false;
                    AttackedRows.Remove(row);
                    AttackedCols.Remove(col);
                    AttackedLeftDiagonals.Remove(col - row);
                    AttackedRightDiagonals.Remove(col + row);
                }
            }
        }

        private static bool IsAttacked(int row, int col)
        {
            return AttackedRows.Contains(row)
                   || AttackedCols.Contains(col)
                   || AttackedLeftDiagonals.Contains(col - row)
                   || AttackedRightDiagonals.Contains(row - col);
        }

        private static void PrintBoard()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Console.Write(Chessboard[row, col] ? '*' : '-');
                    Console.Write(' ');
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
