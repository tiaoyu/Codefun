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
            s.Hilberts_Hotel_round_639_div2_C();
        }
    }

    public partial class Solution
    {
        //public void Hilberts_Hotel_round_639_div2_C()
        //{
        //    var t = int.Parse(Console.ReadLine());
        //    while (t-- > 0)
        //    {
        //        var n = int.Parse(Console.ReadLine());
        //        var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //        var set = new HashSet<int>();
        //        var flg = false;
        //        var tmp = new int[n];
        //        for (var i = 0; i < n; ++i)
        //        {
        //            tmp[((i + arr[i]) % n + n) % n]++;
        //        } 
        //        for (var i = 0; i < n; ++i)
        //        {
        //            if (tmp[i] >= 2)
        //            {
        //                flg = true;
        //                break;
        //            }
        //        }
        //        if (flg)
        //            Console.WriteLine("NO");
        //        else
        //            Console.WriteLine("YES");
        //    }
        //}
    }
}

