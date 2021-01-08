using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ModuloReverseNumber
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("POWERED BY KST Tech. College");
            Console.WriteLine();

            var modulo = UserInputModulo();

            var table = CreateMatrix(modulo);

            var reversibleNumbers = FindReversibleNumbers(modulo);

            var reverseDict = FindReversibleTuples(reversibleNumbers, table);

            PrintReversedTuples(reverseDict);

            Delay();

            PrintMatrix(modulo, table);
        }

        private static void Delay()
        {
            Console.Write("Loading multiply table.");

            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }

            Console.WriteLine();
        }

        private static int UserInputModulo()
        {
            var isInputValid = false;
            var modulo = int.MinValue;

            while (!isInputValid)
            {
                Console.Write("Enter modulo number: ");
                string input = Console.ReadLine();
                try
                {
                    modulo = int.Parse(input);
                    if (modulo >= 2 && modulo <= 100)
                    {
                        isInputValid = true;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Enter valid number from 2 to 100");
                }
            }

            Console.WriteLine();

            return modulo;
        }

        private static Dictionary<int, int> FindReversibleTuples(IEnumerable<int> reversibleNumbers, int[,] table)
        {
            var reverseDict = new Dictionary<int, int> { { 1, 1 } };

            foreach (var number in reversibleNumbers)
            {
                for (int i = 1; i < table.GetLength(0); i++)
                {
                    if (table[number, i] == 1)
                    {
                        reverseDict[number] = i;
                    }
                }
            }

            return reverseDict;
        }

        private static void PrintReversedTuples(Dictionary<int, int> reverseDict)
        {
            foreach (var (key, value) in reverseDict)
            {
                Console.WriteLine($"Reversed of {key} is {value}");
            }

            Console.WriteLine();
        }

        private static int GreatestCommonDivisor(int num1, int num2)
        {
            while (num2 != 0)
            {
                var remainder = num1 % num2;
                num1 = num2;
                num2 = remainder;
            }

            return num1;
        }

        private static IEnumerable<int> FindReversibleNumbers(int modulo)
        {
            var reversibleNumbers = new List<int> { 1 };
            for (int i = 2; i < modulo; i++)
            {
                if (GreatestCommonDivisor(i, modulo) == 1)
                {
                    reversibleNumbers.Add(i);
                }
            }

            PrintReversibleNumbers(reversibleNumbers);
            return reversibleNumbers;
        }

        private static void PrintReversibleNumbers(IEnumerable<int> reversibleNumbers)
        {
            Console.WriteLine($"Reversible numbers are: {string.Join(", ", reversibleNumbers)}");
            Console.WriteLine();
        }

        private static int[,] CreateMatrix(int modulo)
        {
            var table = new int[modulo, modulo];

            for (int r = 0; r < table.GetLength(0); r++)
            {
                for (int c = 0; c < table.GetLength(1); c++)
                {
                    table[r, c] = (r * c) % modulo;
                }
            }

            return table;
        }

        private static void PrintMatrix(int modulo, int[,] table)
        {
            Console.WriteLine();
            var sb = new StringBuilder();

            sb.Append("   ");
            for (int i = 0; i < modulo; i++)
            {
                sb.Append(i + "   ");
            }

            sb.AppendLine();
            sb.AppendLine("   " + new string('_', modulo * 4));
            for (int r = 0; r < table.GetLength(0); r++)
            {
                sb.Append(r + " |");
                for (int c = 0; c < table.GetLength(1); c++)
                {
                    sb.Append(table[r, c] + " | ");
                }

                sb.AppendLine();
            }

            Console.WriteLine(modulo < 30 ? sb.ToString() : "Unable to generate table when modulo is greater than 30!");
        }
    }
}
