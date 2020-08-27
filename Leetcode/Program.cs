
using System;
using System.Collections.Generic;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var str = new string[] { "eat", "tea", "tan", "ate", "nat", "bat", "aabbcc", "abc", "aabc" };
            //var inte = new int[] { 2, 3, 1, 1, 4 };
            var inte = new int[] { 3, 2, 1, 0, 4 };
            Console.WriteLine(solution.CanJump(inte));
        }
    }

    public partial class Solution
    {

    }
}
