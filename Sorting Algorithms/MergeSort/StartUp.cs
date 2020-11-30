using System;

namespace MergeSort
{
    public class StartUp
    {
        static void Main()
        {
            var sorted = new[] { 7, 123, 6, -6, 0, 11, 1111, 1, 1, 11, 23, -2222, -3, 0 };
            MergeSort(sorted);

            Console.WriteLine(string.Join(' ', sorted));
        }

        private static void MergeSort(Span<int> result)
        {
            if (result.Length > 1)
            {
                var center = result.Length / 2;

                MergeSort(result.Slice(0, center));
                MergeSort(result.Slice(center));
                Merge(result, center);
            }
        }

        private static void Merge(Span<int> result, int center)
        {
            var unsorted = result.ToArray();
            var leftPointer = 0;
            var rightPointer = center;
            var resultPointer = 0;

            while (leftPointer < center && rightPointer < unsorted.Length)
            {
                if (unsorted[leftPointer] <= unsorted[rightPointer])
                {
                    result[resultPointer] = unsorted[leftPointer];
                    leftPointer++;
                }
                else
                {
                    result[resultPointer] = unsorted[rightPointer];
                    rightPointer++;
                }

                resultPointer++;
            }

            FillTheRestNumbers(result, center, leftPointer, resultPointer, unsorted, rightPointer);
        }

        private static void FillTheRestNumbers(Span<int> result, int center, int leftPointer, int resultPointer, int[] unsorted,
            int rightPointer)
        {
            while (leftPointer < center)
            {
                result[resultPointer] = unsorted[leftPointer];
                leftPointer++;
                resultPointer++;
            }

            while (rightPointer < unsorted.Length)
            {
                result[resultPointer] = unsorted[rightPointer];
                rightPointer++;
                resultPointer++;
            }
        }
    }
}
