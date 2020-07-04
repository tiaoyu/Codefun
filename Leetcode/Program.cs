
using System;
using System.Collections.Generic;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            //var str1 = "intention";
            //var str2 = "execution";
            //var str1 = "horse";
            //var str2 = "rorse";
            //var str1 = "horse";
            //var str2 = "ros";
            var str1 = "zoologicoarchaeologist";
            var str2 = "zoogeologist";
            Console.WriteLine(solution.MinDistance(str1, str2));
        }
    }

    public partial class Solution
    {
    }
}
