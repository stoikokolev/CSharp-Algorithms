using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloReverseNumber
{
    class StartUp
    {
        static void Main()
        {
            Console.WriteLine("POWERED BY KST Tech. College");

            Console.WriteLine();

            int modulo;
            while (true)
            {
                Console.Write("Enter modulo:");
                modulo = int.Parse(Console.ReadLine());

                if (modulo <= 1)
                {
                    Console.WriteLine("Modulo must be less than 2");
                }
                else if (modulo > 100)
                {
                    Console.WriteLine("Modulo must be greater than 100");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine();

            var table = CreateMatrix(modulo);

            var reversibleNumbers = FindReversibleNumbers(modulo);

            var reverseDict = FindReversibleTuples(reversibleNumbers, table);

            Console.WriteLine();

            PrintReversedTuples(reverseDict);

            Console.WriteLine();

            PrintMatrix(modulo, table);
        }

        private static Dictionary<int, int> FindReversibleTuples(List<int> reversibleNumbers, int[,] table)
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
        }

        private static List<int> FindReversibleNumbers(int modulo)
        {
            var reversibleNumbers = new List<int> { 1 };
            for (int i = 2; i < modulo; i++)
            {
                var a = i;
                var b = modulo;

                int Remainder;

                while (b != 0)
                {
                    Remainder = a % b;
                    a = b;
                    b = Remainder;
                }

                if (a == 1)
                {
                    reversibleNumbers.Add(i);
                }
            }

            Console.WriteLine($"Reversible numbers are: {string.Join(", ", reversibleNumbers)}");
            return reversibleNumbers;
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

            if (modulo < 30)
            {
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
