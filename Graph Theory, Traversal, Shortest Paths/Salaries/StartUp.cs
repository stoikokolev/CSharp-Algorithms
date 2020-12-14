using System;
using System.Collections.Generic;
using System.Linq;

namespace Salaries
{
    public class StartUp
    {
        private static List<int>[] graph;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);

            var totalSalary = 0;

            for (int node = 0; node < graph.Length; node++)
            {
                var salary = GetSalary(node);
                totalSalary += salary;
            }

            Console.WriteLine(totalSalary);
        }

        private static int GetSalary(int node)
        {
            var children = graph[node];

            if (children.Count == 0)
            {
                return 1;
            }

            var sum = 0;

            foreach (var child in children)
            {
                sum += GetSalary(child);
            }

            return sum;
        }

        private static List<int>[] ReadGraph(int n)
        {
            var result = new List<int>[n];

            for (int node = 0; node < n; node++)
            {
                var children = new List<int>();
                var line = Console.ReadLine();

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == 'Y')
                    {
                        children.Add(i);
                    }
                }

                result[node] = children;
            }

            return result;
        }
    }
}