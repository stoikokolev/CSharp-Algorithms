using System;
using System.Collections.Generic;

namespace Fibonacci
{
    class StartUp
    {
        static readonly Dictionary<int, int> Memory = new Dictionary<int, int>() {
            {1, 1},
            {2, 1}
        };

        static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(RecursiveFibonacci(number));

            static int RecursiveFibonacci(int number)
            {
                int result;

                if (Memory.ContainsKey(number))
                {
                    result = Memory[number];
                }
                else
                {
                    result = RecursiveFibonacci(number - 1) + RecursiveFibonacci(number - 2);
                    Memory[number] = result;
                }
                
                return result;
            }
        }
    }
}
