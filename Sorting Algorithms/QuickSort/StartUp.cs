using System;
using System.Linq;

namespace QuickSort
{
    public class StartUp
    {
        static void Main()
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            Console.WriteLine(string.Join(' ', QuickSort(array, 0, array.Length)));
        }

        private static int[] QuickSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(array, start, end);
                QuickSort(array, start, pivot);
                QuickSort(array, pivot + 1, end);
            }
            
            return array;
        }

        private static int Partition(int[] array, int start, int end)
        {
            int pivot = array[start];
            int swapIndex = start;

            for (int i = start + 1; i < end; i++)
            {
                if (array[i] < pivot)
                {
                    swapIndex++;
                    Swap(array, i, swapIndex);
                }
            }

            Swap(array,start,swapIndex);

            return swapIndex;
        }

        private static void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
