using System;
using System.Collections.Generic;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            var arr = new int[] { 1, 3 };
            //var arr = new int[] { 9, 7, 7, 9, 7, 7, 9 };
            //var arr = new int[] { 1,1000,1 };
            //var arr = new int[] { 1, 1, 100, 99, 98, 10, 11, 12 };
            //Console.WriteLine(solution.MaxScore_5393(arr, 3));
            //Console.WriteLine(solution.MaxScore_5392("011101"));
            //Console.WriteLine(solution.MaxScore_5392("0011101"));
            //Console.WriteLine(solution.MaxScore_5392("011101"));
            //Console.WriteLine(solution.MaxScore_5392("11110000"));

            solution.BuildArray_A(arr, 3);
        }
    }

    public partial class Solution
    {

    }
}
