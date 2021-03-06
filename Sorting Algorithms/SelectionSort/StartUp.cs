﻿using System;
using System.Linq;

namespace SelectionSort
{
    public class StartUp
    {
        static void Main()
        {
            var sorted = SelectionSort(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Console.WriteLine(string.Join(' ', sorted));
        }

        private static int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var minIndex = i;
                var min = array[i];
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                        minIndex = j;
                    }
                }

                array[minIndex] = array[i];
                array[i] = min;
            }

            return array;
        }
    }
}
