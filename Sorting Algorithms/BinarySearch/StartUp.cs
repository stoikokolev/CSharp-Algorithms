using System;
using System.Linq;

namespace BinarySearch
{
    public class StartUp
    {
        static void Main()
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearchPosition(number, array));
        }

        private static int BinarySearchPosition(int number, int[] array)
        {
            var startIndex = 0;
            var endIndex = array.Length - 1;

            while (startIndex <= endIndex)
            {
                var midIndex = (startIndex + endIndex) / 2;

                if (array[midIndex] == number)
                {
                    return midIndex;
                }

                if (array[midIndex] < number)
                {
                    startIndex = midIndex + 1;
                }
                else
                {
                    endIndex = midIndex - 1;
                }
            }

            return -1;
        }
    }
}
