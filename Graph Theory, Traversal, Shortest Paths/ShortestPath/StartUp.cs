using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPath
{
    public class StartUp
    {
        private static List<int>[] _graph;
        private static bool[] _visited;
        private static int[] _parents;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            _graph = ReadGraph(n, e);
            _visited=new bool[_graph.Length];
            _parents=new int[_graph.Length];
            Array.Fill(_parents,-1);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());
            
                Bfs(source,destination);
            
        }

        private static void Bfs(int startNode, int destination)
        {
            if (_visited[startNode])
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(startNode);

            while (queue.Count>0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var path = ReconstructPath(destination);

                    Console.WriteLine($"Shortest path length is: {path.Count-1}");
                    Console.WriteLine(string.Join(' ', path));
                    return;
                    
                }

                foreach (var child in _graph[node])
                {
                    if (!_visited[child])
                    {
                        _parents[child] = node;
                        queue.Enqueue(child);
                        _visited[child] = true;
                    }
                }
            }
        }

        private static Stack<int> ReconstructPath(int destination)
        {
            var path = new Stack<int>();
            var index = destination;

            while (index!=-1)
            {
                path.Push(index);
                index = _parents[index];
            }

            return path;
        }

        private static List<int>[] ReadGraph(int n, int e)
        {
            var result = new List<int>[n+1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i]=new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edge[0];
                var to = edge[1];
                
                result[from].Add(to);
            }

            return result;
        }
    }
}
