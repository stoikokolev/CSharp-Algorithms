using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedComponents
{
    public class StartUp
    {
        private static Dictionary<int, List<int>> _graph;
        private static HashSet<int> _visited;

        public static void Main()
        {
            var nodesNumber = int.Parse(Console.ReadLine());

            _graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodesNumber; i++)
            {
                var edges = Console.ReadLine()
                    ?.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToList();
                _graph.Add(i, edges);
            }

            _visited = new HashSet<int>();

            foreach (var node in _graph.Keys)
            {
                var result = new List<int>();

                Dfs(node, result);

                if (result.Count > 0)
                {
                    Console.WriteLine($"Connected component: {string.Join(' ', result)}");
                }
            }

        }

        private static void Dfs(int node, List<int> result)
        {
            if (_visited.Contains(node))
            {
                return;
            }

            _visited.Add(node);

            foreach (var child in _graph[node])
            {
                Dfs(child, result);
            }

            result.Add(node);
        }
    }
}
