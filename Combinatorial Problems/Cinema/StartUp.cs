using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    public class StartUp
    {
        private static HashSet<int> _lockedSeats;
        private static List<string> _names;
        private static string[] _seats;

        static void Main()
        {
            _names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            _seats = new string[_names.Count];
            _lockedSeats = new HashSet<int>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "generate")
                {
                    break;
                }

                var parts = input.Split(" - ");
                var name = parts[0];
                var position = int.Parse(parts[1]) - 1;

                _seats[position] = name;
                _lockedSeats.Add(position);

                _names.Remove(name);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= _names.Count)
            {
                var namesIndex = 0;
                for (int i = 0; i < _seats.Length; i++)
                {
                    if (_lockedSeats.Contains(i))
                    {
                        continue;
                    }

                    _seats[i] = _names[namesIndex];
                    namesIndex++;
                }

                Console.WriteLine(string.Join(' ', _seats));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < _names.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = _names[first];
            _names[first] = _names[second];
            _names[second] = temp;
        }
    }
}
