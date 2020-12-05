using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Find the two entries that sum to 2020;
 * what do you get if you multiply them together?
 */
namespace Day1
{
    internal static class Program
    {
        private const int EntriesTotal = 2020;

        private static void Main(string[] args)
        {
            // Sort list
            var data = GetListData();
            var result = new List<int>();

            foreach (var firstEntry in data)
            {
                var secondEntry =  EntriesTotal - firstEntry;

                // Find the pair Number in list
                secondEntry = data.FindLast(num => num == secondEntry);

                // Multiply them together
                // And add to the result list
                if (secondEntry != 0)
                    result.Add(firstEntry * secondEntry);
            }

            // Remove duplicates
            result = result.Distinct().ToList();

            // Print out
            foreach (var num in result) Console.WriteLine(num);
        }

        /*
         * Return sorted list data
         */
        private static List<int> GetListData()
        {
            var data = "1721\n979\n366\n299\n675\n1456\n2021";

            // Conditions
            return data
                .Split("\n")
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse)
                .Where(num => num < EntriesTotal)
                .OrderBy(i => i)
                .ToList();
        }
    }
}