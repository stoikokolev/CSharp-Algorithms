using System;
using System.Collections.Generic;
using System.Linq;

namespace TheStoryTelling
{
    public class StartUp
    {
        private static readonly Dictionary<string, List<string>> Graph = new Dictionary<string, List<string>>();
        private static readonly Stack<string> Result = new Stack<string>();
        private static readonly HashSet<string> Visited = new HashSet<string>();

        public static void Main()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var line = input
                    .Split("->")
                    .ToArray();

                var node = line[0]
                    .TrimEnd();
                var children = new List<string>();
                if (line.Length > 1)
                {
                    children = line[1]
                        .TrimStart()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                }

                if (!Graph.ContainsKey(node))
                {
                    Graph[node] = new List<string>();
                }

                Graph[node].AddRange(children);
            }

            foreach (var graphKey in Graph.Keys)
            {
                if (Visited.Contains(graphKey))
                {
                    continue;
                }

                Dfs(graphKey);
            }

            Console.WriteLine(string.Join(" ", Result));
        }

        private static void Dfs(string node)
        {
            if (Visited.Contains(node))
            {
                return;
            }

            foreach (var child in Graph[node])
            {
                if (Visited.Contains(child))
                {
                    continue;
                }
                Dfs(child);
            }

            Visited.Add(node);
            Result.Push(node);
        }
    }
}