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
            s.Hilberts_Hotel_round_639_div2_A();
        }
    }

    public partial class Solution
    {
        //public void Hilberts_Hotel_round_639_div2_A()
        //{
        //    var t = int.Parse(Console.ReadLine());
        //    while (t-- > 0)
        //    {
        //        //var tmp = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        //        var n = int.Parse(Console.ReadLine());
        //        var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //        var set = new HashSet<int>();
        //        var flg = false;
        //        for (var i = 0; i < n; ++i)
        //        {
        //            for (var j = i + 1; j < n; ++j)
        //            {
        //                if (Math.Abs(arr[i] - arr[j]) == (j - i))
        //                {
        //                    flg = true;
        //                    break;
        //                }
        //            }
        //            if (flg) break;
        //        }
        //        if (flg)
        //            Console.WriteLine("NO");
        //        else
        //            Console.WriteLine("YES");
        //    }
        //}
    }
}

