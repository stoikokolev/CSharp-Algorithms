using System;
using System.Collections.Generic;

namespace DFSAndBFS
{
    public class StartUp
    {
        private static Dictionary<int, List<int>> _graph;
        private static HashSet<int> _visited;

        public static void Main()
        {
            _graph = new Dictionary<int, List<int>>()
            {
                {1, new List<int>{19,21,14}},
                {19, new List<int>{7,12,31,21}},
                {7, new List<int>{1}},
                {12, new List<int>()},
                {21, new List<int>{14}},
                {31, new List<int>{21}},
                {14, new List<int>{23,6}},
                {23, new List<int>{21}},
                {6, new List<int>()}
            };

            _visited = new HashSet<int>();

            //foreach (var node in _graph.Keys)
            //{
            //    Dfs(node);
            //}

            foreach (var node in _graph.Keys)
            {
                if (!_visited.Contains(node))
                {
                    Bfs(node);
                }
            }
        }

        private static void Bfs(int start)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            _visited.Add(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                Console.WriteLine(node);

                foreach (var child in _graph[node])
                {
                    if (!_visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        _visited.Add(child);
                    }
                }
            }
        }

        private static void Dfs(int node)
        {
            if (_visited.Contains(node))
            {
                return;
            }

            _visited.Add(node);

            foreach (var child in _graph[node])
            {
                Dfs(child);
            }

            Console.WriteLine(node);
        }
    }
}
