using System;
using System.Linq;

namespace InsertionSort
{
    public class StartUp
    {
        static void Main()
        {
            var sorted = InsertionSort(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Console.WriteLine(string.Join(' ', sorted));
        }

        private static int[] InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                var j = i;
                while (j > 0 && array[j] < array[j - 1])
                {
                    var temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                    j--;
                }
                
            }
            
            return array;
        }
    }
}
