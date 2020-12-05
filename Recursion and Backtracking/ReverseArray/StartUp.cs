using System;

namespace ReverseArray
{
    public class StartUp
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split(); 

            ReverseArr(0,array);

            Console.WriteLine(string.Join(' ', array));
        }

        private static void ReverseArr(int left, string[] array)
        {
            if (left == array.Length / 2)
            {
                return;
            }

            var right = array.Length - 1 - left;
            Swap(array, left, right); 

            ReverseArr(left+1,array);
        }

        private static void Swap(string[] array, int left,int right)
        {
            var temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }
    }
}
