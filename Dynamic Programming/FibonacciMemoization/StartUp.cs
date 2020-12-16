using System;
using System.Collections.Generic;

namespace FibonacciMemoization
{
    public class StartUp
    {
        static void Main()
        {
            var memory = new Dictionary<int, long>();
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(number, memory));
        }

        private static long Fibonacci(int number, IDictionary<int, long> memory)
        {

            if (memory.ContainsKey(number))
            {
                return memory[number];
            }

            if (number <= 2)
            {
                return 1;
            }
            
            var result = Fibonacci(number - 1, memory) + Fibonacci(number - 2, memory);
            memory.Add(number, result);

            return result;
        }
    }
}
