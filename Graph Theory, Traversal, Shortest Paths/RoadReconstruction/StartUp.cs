using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadReconstruction
{
    public class Street
    {
        public Street(int firstBuilding, int secondBuilding)
        {
            this.FirstBuilding = firstBuilding;
            this.SecondBuilding = secondBuilding;
        }

        public int FirstBuilding { get; }

        public int SecondBuilding { get; }

        public override string ToString()
        {
            return this.FirstBuilding < this.SecondBuilding ? $"{FirstBuilding} {SecondBuilding}" : $"{SecondBuilding} {FirstBuilding}";
        }
    }

    public class StartUp
    {
        private static Dictionary<int, List<int>> _graph;
        private static List<Street> _streets;

        public static void Main()
        {
            var buildingsCount = int.Parse(Console.ReadLine());
            var streetsCount = int.Parse(Console.ReadLine());

            _streets = new List<Street>(streetsCount);
            _graph = ReadGraph(buildingsCount, streetsCount);

            var importantStreets = new List<Street>();

            foreach (var street in _streets)
            {
                var firstBuilding = street.FirstBuilding;
                var secondBuilding = street.SecondBuilding;

                _graph[firstBuilding].Remove(secondBuilding);
                _graph[secondBuilding].Remove(firstBuilding);

                if (IsImportant(firstBuilding, secondBuilding))
                {
                    importantStreets.Add(street);
                }

                _graph[firstBuilding].Add(secondBuilding);
                _graph[secondBuilding].Add(firstBuilding);
            }

            Console.WriteLine("Important streets:");
            foreach (var street in importantStreets)
            {
                Console.WriteLine(street);
            }
        }

        //BFS
        private static bool IsImportant(int firstBuilding, int secondBuilding)
        {
            var queue = new Queue<int>();
            queue.Enqueue(firstBuilding);

            var visited = new HashSet<int> {firstBuilding};

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == secondBuilding)
                {
                    return false;
                }

                foreach (var child in _graph[node].Where(child => !visited.Contains(child)))
                {
                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return true;
        }

        private static Dictionary<int, List<int>> ReadGraph(int buildingsCount, int streetsCount)
        {
            var result = new Dictionary<int, List<int>>(buildingsCount);

            for (int i = 0; i < streetsCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                var firstBuilding = int.Parse(input[0]);
                var secondBuilding = int.Parse(input[1]);

                if (!result.ContainsKey(firstBuilding))
                {
                    result[firstBuilding] = new List<int>();
                }

                if (!result.ContainsKey(secondBuilding))
                {
                    result[secondBuilding] = new List<int>();
                }

                result[firstBuilding].Add(secondBuilding);
                result[secondBuilding].Add(firstBuilding);

                AddStreets(firstBuilding, secondBuilding);
            }

            return result;
        }

        private static void AddStreets(int firstBuilding, int secondBuilding)
        {
            var street = new Street(firstBuilding, secondBuilding);

            _streets.Add(street);
        }
    }
}