using System;
using System.Collections.Generic;

namespace Fibonacci
{
    public class StartUp
    {
        static void Main()
        {
            var memory = new Dictionary<int, int>();
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(number, memory));
        }

        private static int Fibonacci(int number, IDictionary<int, int> memory)
        {
            if (number <= 1)
            {
                return 1;
            }

            if (memory.ContainsKey(number))
            {
                return memory[number];
            }

            var result = Fibonacci(number - 1, memory) + Fibonacci(number - 2, memory);
            memory.Add(number,result);

            return result;
        }
    }
}

