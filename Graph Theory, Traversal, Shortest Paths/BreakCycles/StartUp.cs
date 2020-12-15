using System;
using System.Collections.Generic;
using System.Linq;

namespace BreakCycles
{
    public class StartUp
    {
        /*
        public class Edge
        {
            public Edge(string first, string second)
            {
                First = first;
                Second = second;
            }

            public string First { get; set; }

            public string Second { get; set; }

            public override string ToString()
            {
                return $"{this.First} - {this.Second}";
            }

            public string Reversed()
            {
                return $"{this.Second} - {this.First}";
            }
        }
        */
        //UNCOMMENT ABOVE FOR JUDGE

        private static Dictionary<string, List<string>> _graph;
        private static List<Edge> _edges;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            _graph = new Dictionary<string, List<string>>();
            _edges = new List<Edge>();

            ProcessInput(n);

            _edges = _edges
                .OrderBy(e => e.First)
                .ThenBy(e => e.Second)
                .ToList();

            var removedEdges = new List<Edge>();
            var blackListed = new HashSet<string>();

            foreach (var edge in _edges)
            {
                var first = edge.First;
                var second = edge.Second;

                _graph[first].Remove(second);
                _graph[second].Remove(first);

                if (HasPath(first, second))
                {
                    if (blackListed.Contains(edge.ToString()))
                    {
                        continue;
                    }

                    removedEdges.Add(edge);
                    blackListed.Add(edge.Reversed());
                }
                else
                {
                    _graph[first].Add(second);
                    _graph[second].Add(first);
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");

            foreach (var edge in removedEdges.Where(edge => !blackListed.Contains(edge.ToString())))
            {
                Console.WriteLine(edge.ToString());
                blackListed.Add(edge.Reversed());
            }
        }

        private static bool HasPath(string source, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(source);

            var visited = new HashSet<string> { source };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in _graph[node].Where(child => !visited.Contains(child)))
                {
                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return false;
        }

        private static void ProcessInput(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var node = parts[0];
                var children = parts[1].Split();

                if (!_graph.ContainsKey(node))
                {
                    _graph.Add(node, new List<string>());
                }

                foreach (var child in children)
                {
                    _graph[node].Add(child);
                    _edges.Add(new Edge(node, child));
                }
            }
        }
    }
}
