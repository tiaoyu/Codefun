using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            s.Square_B();
        }
    }

    public partial class Solution
    {
        //public void Square()
        //{
        //    var t = int.Parse(Console.ReadLine());
        //    while (t-- > 0)
        //    {
        //        //var n = int.Parse(Console.ReadLine());
        //        var arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //        var arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //        var a1 = arr1[0];
        //        var b1 = arr1[1];
        //        var a2 = arr2[0];
        //        var b2 = arr2[1];
        //        var l = a1 > b1 ? a1 : b1;
        //        if (a1 != b1)
        //        {
        //            if ((a2 == a1 && b2 + b1 == l )|| a2 == b1 && b2 + a1 == l || b2 == a1 && a2 + b1 == l || b2 == b1 && a2 + a1 == l)
        //            {
        //                Console.WriteLine("YES");
        //                continue;
        //            }
        //        }
        //        Console.WriteLine("NO");
        //    }
        //}
    }
}

