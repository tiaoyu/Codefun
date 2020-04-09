using System;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 1, 2, 3, 5, 4, 3, 2, 1 };
            solution.NextPermutation(nums);
            foreach (var i in nums)
            {
                Console.Write($"{i},");
            }
        }
    }
}
