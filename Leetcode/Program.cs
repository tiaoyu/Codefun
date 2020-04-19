using System;
using System.Collections.Generic;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine(solution.MinNumberOfFrogs("ccrrooaakk"));
            Console.WriteLine(solution.MinNumberOfFrogs("croakcroa"));
            Console.WriteLine(solution.MinNumberOfFrogs("croakcroak"));
            Console.WriteLine(solution.MinNumberOfFrogs("crcoakroak"));
            Console.WriteLine(solution.MinNumberOfFrogs("croakcrook"));
        }
    }
}
