using System;
using System.Linq;

namespace RecursiveArraySum
{
    public class StartUp
    {
        static void Main()
        {
            var array = Console.ReadLine()?
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(CalcSum(array, 0));
        }

        private static int CalcSum(int[] array, int index)
        {
            if (index == array.Length - 1)
            {
                return array[index];
            }

            return array[index] + CalcSum(array, index + 1);
        }
    }
}
