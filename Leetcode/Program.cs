using System;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }));
        }
    }
}
