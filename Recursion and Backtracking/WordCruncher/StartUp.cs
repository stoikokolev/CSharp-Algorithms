using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCruncher
{
    public class StartUp
    {
        private static string _current;
        private static string _target;
        private static Dictionary<int, List<string>> _wordsByLen;
        private static Dictionary<string, int> _occurances;
        private static List<string> _selectedWords;
        private static HashSet<string> _results = new HashSet<string>();

        public static void Main()
        {
            var words = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            _target = Console.ReadLine();

            _wordsByLen = new Dictionary<int, List<string>>();
            _occurances = new Dictionary<string, int>();
            _selectedWords = new List<string>();

            foreach (var word in words)
            {
                if (!_target.Contains(word))
                {
                    continue;
                }

                var len = word.Length;

                if (!_wordsByLen.ContainsKey(len))
                {
                    _wordsByLen.Add(len, new List<string>());
                }

                if (_occurances.ContainsKey(word))
                {
                    _occurances[word]++;
                }
                else
                {
                    _occurances.Add(word, 1);
                }

                _wordsByLen[len].Add(word);
            }

            _current = string.Empty;
            GenSolutions(_target.Length);

            Console.WriteLine(string.Join(Environment.NewLine, _results));
        }

        private static void GenSolutions(int len)
        {
            if (len == 0)
            {
                if (_current == _target)
                {
                    _results.Add(string.Join(" ", _selectedWords));
                }

                return;
            }

            foreach (var (key, value) in _wordsByLen)
            {
                if (key > len)
                {
                    continue;
                }

                foreach (var word in value.Where(word => _occurances[word] > 0))
                {
                    _current += word;

                    if (IsMatchingSoFar(_target, _current))
                    {
                        _occurances[word]--;
                        _selectedWords.Add(word);
                        GenSolutions(len - word.Length);
                        _occurances[word]++;
                        _selectedWords.RemoveAt(_selectedWords.Count - 1);
                    }

                    _current = _current.Remove(_current.Length - word.Length, word.Length);
                }
            }
        }

        private static bool IsMatchingSoFar(string expected, string actual)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
