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
            s.div2_C();
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

        public static long GCD_long(long[] arr, int minIndex)
        {
            var tmp = arr[minIndex];
            var tmpIndex = minIndex;
            var cnt = 0;
            for (var i = 0; i < arr.Length; ++i)
            {
                if (i != minIndex && arr[i] != 0)
                {
                    cnt++;
                    arr[i] %= arr[minIndex];
                    if (arr[i] == 0)
                    {

                    }
                    else if (arr[i] < tmp)
                    {
                        tmp = arr[i];
                        tmpIndex = i;
                    }
                }
            }
            if (cnt == 1)
                return tmp;
            else
                return GCD_long(arr, tmpIndex);
        }

        public static int GCD_int(HashSet<int> arr, int minTmp)
        {
            var cnt = arr.Count;
            while (cnt > 1)
            {
                cnt = 0;
                var newSet = new HashSet<int>();
                newSet.Add(minTmp);
                foreach (var v in arr)
                {
                    var tmp = v % minTmp;
                    if (tmp != 0)
                    {
                        cnt++;
                        newSet.Add(tmp);
                        minTmp = Math.Min(minTmp, tmp);
                    }
                }
                cnt = newSet.Count;
                arr = newSet;
            }
            return minTmp;
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

