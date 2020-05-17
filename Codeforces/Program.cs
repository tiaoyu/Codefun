using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codeforces
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
        }
    }

    public partial class Solution
    {

    }

    public class Utilities
    {
        public static int[] GetIntArray(string input)
        {
            return input.Split(' ').Select(int.Parse).ToArray();
        }

        public static long[] GetLongArray(string input)
        {
            return input.Split(' ').Select(long.Parse).ToArray();
        }

        public static int GCD_int(int a, int b)
        {
            return b > 0 ? GCD_int(b, a % b) : a;
        }

        public static long GCD_long(long a, long b)
        {
            return b > 0 ? GCD_long(b, a % b) : a;
        }

        public static int LCM_int(int a, int b)
        {
            return (a * b) / GCD_int(a, b);
        }

        public static long LCM_long(long a, long b)
        {
            return (a * b) / GCD_long(a, b);
        }


    }
}

