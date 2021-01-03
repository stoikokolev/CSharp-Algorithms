using System;
using System.Collections.Generic;
using System.Linq;

namespace exam3
{
    class Program
    {
        private static Dictionary<int, List<int>> _graph;

        static void Main(string[] args)
        {
            var nodesNumber = int.Parse(Console.ReadLine());
            _graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodesNumber; i++)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    _graph.Add(i, new List<int>());
                    continue;
                }
                var edges = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToList();
                _graph.Add(i, edges);
            }

            var paths = int.Parse(Console.ReadLine());

            for (int i = 0; i < paths; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToList();
                var isPath = true;
                for (int j = 0; j < input.Count - 1; j++)
                {
                    if (_graph.ContainsKey(input[j]))
                    {
                        if (_graph[input[j]].Contains(input[j + 1]))
                        {

                        }
                        else
                        {
                            isPath = false;
                            break;
                        }
                    }
                    else
                    {
                        isPath = false;
                        break;
                    }
                }

                Console.WriteLine(isPath ? "yes" : "no");
            }
        }
    }
}
