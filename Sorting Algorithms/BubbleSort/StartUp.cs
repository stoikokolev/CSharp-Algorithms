using System;
using System.Linq;

namespace BubbleSort
{
    public class StartUp
    {
        static void Main()
        {
            var sorted = BubbleSort(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Console.WriteLine(string.Join(' ', sorted));
        }

        private static int[] BubbleSort(int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                var swapped = false;

                for (int j = 0; j < i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        swapped = true;

                        Swap(array, j);
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }

            return array;
        }

        private static void Swap(int[] array, int j)
        {
            var temp = array[j];
            array[j] = array[j + 1];
            array[j + 1] = temp;
        }
    }
}
