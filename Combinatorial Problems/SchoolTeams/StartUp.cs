using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTeams
{
    public class StartUp
    {
        static void Main()
        {
            const int girlsInTeam = 3;
            const int boysInTeam = 2;

            var girls = Console.ReadLine().Split(", ");
            var boys = Console.ReadLine().Split(", ");

            var girlsComb = new string[girlsInTeam];
            var girlsList= new List<string[]>();
            Combo(0, 0, girlsComb, girls,girlsList);
            var boysComb = new string[boysInTeam];
            var boysList= new List<string[]>();
            Combo(0, 0, boysComb, boys,boysList);

            foreach (var girlsOutput in girlsList)
            {
                foreach (var boysOutputb in boysList)
                {
                    Console.WriteLine($"{string.Join(", ", girlsOutput)}, {string.Join(", ", boysOutputb)}");
                }
            }

        }

        private static void Combo(int cellIndex, int personIndex, string[] peopleComb, string[] people, List<string[]> result)
        {
            if (cellIndex >= peopleComb.Length)
            {
               result.Add(peopleComb.ToArray());

                return;
            }

            for (int i = personIndex; i < people.Length; i++)
            {
                peopleComb[cellIndex] = people[i];
                Combo(cellIndex + 1, i + 1, peopleComb, people,result);
            }
        }
    }
}
