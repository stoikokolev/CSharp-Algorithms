using System;
using System.Collections.Generic;

namespace CyclesInAGraph
{
    public class StartUp
    {
        private static Dictionary<string, List<string>> _graph;
        private static HashSet<string> _visited;
        private static HashSet<string> _cycles;

        public static void Main()
        {
            _graph = ReadGraph("End");
            _visited = new HashSet<string>();
            _cycles = new HashSet<string>();

            foreach (var node in _graph.Keys)
            {
                try
                {
                    DFS(node);

                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            Console.WriteLine($"Acyclic: Yes");
        }

        private static void DFS(string node)
        {
            if (_cycles.Contains(node))
            {
                throw new InvalidOperationException("Acyclic: No");
            }

            if (_visited.Contains(node))
            {
                return;
            }

            _cycles.Add(node);
            _visited.Add(node);

            foreach (var child in _graph[node])
            {
                DFS(child);
            }

            _cycles.Remove(node);
        }

        private static Dictionary<string, List<string>> ReadGraph(string endCommand)
        {
            var result = new Dictionary<string, List<string>>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == endCommand)
                {
                    break;
                }

                var parts = line.Split("-", StringSplitOptions.RemoveEmptyEntries);
                var node = parts[0];
                var child = parts[1];

                if (!result.ContainsKey(node))
                {
                    result.Add(node, new List<string>());
                }

                if (!result.ContainsKey(child))
                {
                    result.Add(child, new List<string>());
                }

                result[node].Add(child);
            }

            return result;
        }
    }
}
