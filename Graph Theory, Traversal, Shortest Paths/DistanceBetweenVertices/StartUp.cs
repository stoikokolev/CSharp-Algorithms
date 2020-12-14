using System;
using System.Collections.Generic;
using System.Linq;

namespace DistanceBetweenVertices
{
    public class StartUp
    {
        private static Dictionary<int, List<int>> graph;

        public static void Main()
        {
            var graphElements = int.Parse(Console.ReadLine());
            var numberOfResults = int.Parse(Console.ReadLine());

            graph = ReadGraph(graphElements);

            for (int i = 0; i < numberOfResults; i++)
            {
                var pair = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var source = pair[0];
                var destination = pair[1];

                var steps = GetShortestPath(source, destination);

                Console.WriteLine($"{{{source}, {destination}}} -> {steps}");
            }
        }

        private static int GetShortestPath(int source, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(source);

            var steps = new Dictionary<int, int> { { source, 0 } };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return steps[node];
                }

                foreach (var child in graph[node].Where(child => !steps.ContainsKey(child)))
                {
                    queue.Enqueue(child);
                    steps[child] = steps[node] + 1;
                }
            }

            return -1;
        }

        private static Dictionary<int, List<int>> ReadGraph(int graphElements)
        {
            var result = new Dictionary<int, List<int>>();

            for (int i = 0; i < graphElements; i++)
            {
                var parts = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);

                var node = int.Parse(parts[0]);

                if (parts.Length == 1)
                {
                    result[node] = new List<int>();
                }
                else
                {
                    var children = parts[1]
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                    result[node] = children;
                }
            }

            return result;
        }
    }
}
