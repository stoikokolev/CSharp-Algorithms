using System;

namespace RecursiveDrawing
{
    public class StartUp
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            PrintFigure(number);
        }

        private static void PrintFigure(int number)
        {
            PrintStars(number);
            PrintHashTags(1,number);
        }

        private static void PrintStars(int number)
        {
            if (number == 0)
            {
                return;
            }

            Console.WriteLine(new string('*',number));

            PrintStars(number-1);
        }

        private static void PrintHashTags(int startNumber,int number)
        {
            if (startNumber > number)
            {
                return;
            }

            Console.WriteLine(new string('#',startNumber));

            PrintHashTags(startNumber+1,number);
        }
    }
}
