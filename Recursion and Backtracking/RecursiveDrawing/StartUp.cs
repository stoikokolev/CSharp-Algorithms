using System;

namespace RecursiveDrawing
{
    public class StartUp
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            PrintFigure(size);
        }

        private static void PrintFigure(int size)
        {
            if (size == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', size));

            PrintFigure(size - 1);

            Console.WriteLine(new string('#', size));
        }
    }
}
