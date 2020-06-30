
using System;
using System.Collections.Generic;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            //var str = "(()";
            var str = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Console.WriteLine(solution.Trap(str));
        }
    }

    public partial class Solution
    {

    }
}
