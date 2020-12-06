using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceRemovalTopologicalSorting
{
    public class StartUp
    {
        private static Dictionary<string, List<string>> _graph;
        private static Dictionary<string, int> _dependencies;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            _graph = ReadGraph(n);
            _dependencies = ExtractDependencies();

            var sorted = TopologicalSorting();

            Console.WriteLine(sorted == null
                ? "Invalid topological sorting"
                : $"Topological sorting: {string.Join(", ", sorted)}");
        }

        private static List<string> TopologicalSorting()
        {
            var sorted = new List<string>();

            while (_dependencies.Count > 0)
            {
                var nodeToRemove = _dependencies.FirstOrDefault(n => n.Value == 0);
                if (string.IsNullOrEmpty(nodeToRemove.Key))
                {
                    break;
                }

                var node = nodeToRemove.Key;
                var children = _graph[node];

                sorted.Add(node);

                foreach (var child in children)
                {
                    _dependencies[child]--;
                }

                _dependencies.Remove(node);
            }

            if (_dependencies.Count > 0)
            {
                return null;
            }

            return sorted;
        }

        private static Dictionary<string, int> ExtractDependencies()
        {
            var dep = new Dictionary<string, int>();

            foreach (var (node, children) in _graph)
            {
                if (!dep.ContainsKey(node))
                {
                    dep.Add(node, 0);
                }

                foreach (var child in children)
                {
                    if (!dep.ContainsKey(child))
                    {
                        dep.Add(child, 1);
                    }
                    else
                    {
                        dep[child]++;

                    }
                }

            }

            return dep;
        }

        private static Dictionary<string, List<string>> ReadGraph(int lines)
        {
            var graphResult = new Dictionary<string, List<string>>();

            for (int i = 0; i < lines; i++)
            {
                var parts = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                var key = parts[0].Trim();

                if (parts.Length == 1||string.IsNullOrEmpty(parts[1]))
                {
                    graphResult[key] = new List<string>();
                }
                else
                {
                    var children = parts[1]
                        .Trim()
                        .Split(", ")
                        .ToList();

                    graphResult[key] = children;
                }


            }

            return graphResult;
        }
    }
}
