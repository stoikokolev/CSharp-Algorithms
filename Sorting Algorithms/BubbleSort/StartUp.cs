using System;

namespace BubbleSort
{
    public class StartUp
    {
        static void Main()
        {
            var sorted = BubbleSort(new[] { 7, 123, 6, -6, 0 ,11,1111,1,1,11,23,-2222,-3,0});

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
