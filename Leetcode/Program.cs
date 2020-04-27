using System;
using System.Collections.Generic;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            //var arr = new int[] { 1, 2, 3, 4, 5, 6, 1 };
            //var arr = new int[] { 9, 7, 7, 9, 7, 7, 9 };
            //var arr = new int[] { 1,1000,1 };
            //var arr = new int[] { 1, 1, 100, 99, 98, 10, 11, 12 };
            //Console.WriteLine(solution.MaxScore_5393(arr, 3));
            //Console.WriteLine(solution.MaxScore_5392("011101"));
            //Console.WriteLine(solution.MaxScore_5392("0011101"));
            //Console.WriteLine(solution.MaxScore_5392("011101"));
            //Console.WriteLine(solution.MaxScore_5392("11110000"));
            var arr2 = new List<int[]>();
            arr2.Add(new List<int> { 1, 2, 3, 4, 5 }.ToArray());
            arr2.Add(new List<int> { 6, 7 }.ToArray());
            arr2.Add(new List<int> { 8 }.ToArray());
            arr2.Add(new List<int> { 9, 10, 11 }.ToArray());
            arr2.Add(new List<int> { 12, 13, 14, 15, 16 }.ToArray());

            solution.FindDiagonalOrder_5394(arr2.ToArray());
        }
    }
}
