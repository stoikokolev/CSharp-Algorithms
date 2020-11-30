using System;

namespace QuickSort
{
    public class StartUp
    {
        static void Main()
        {
            var sorted = QuickSort(new[] { 7, 123, 6, -6, 0, 11, 1111, 1, 1, 11, 23, -2222, -3, 0 }, 0, 14);

            Console.WriteLine(string.Join(' ', sorted));
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
