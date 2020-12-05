using System;

namespace N_Choose__K_Count
{
   public class StartUp
    {
        //Pascal Triangle
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            
            Console.WriteLine(GetBinom(n,k));
        }

        private static int GetBinom(int row, int col)
        {
            if (row == 0 || row == 1 || col==0 || col==row)
            {
                return 1;
            }

            return GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
        }
    }
}
