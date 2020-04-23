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
            s.ConstantPalindromeSum_363_div3();
        }
    }

    public partial class Solution
    {
        public void ConstantPalindromeSum_363_div3()
        {
            var t = int.Parse(Console.ReadLine());
            var dic = new Dictionary<int, int>();
            while (t-- > 0)
            {
                dic.Clear();
                var tmp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var n = tmp[0];
                var k = tmp[1];
                var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var max = 0;
                var maxv = 0;
                for (var i = 0; i < n / 2; ++i)
                {
                    var res = arr[i] + arr[n - i - 1];
                    if (dic.ContainsKey(res))
                    {
                        dic[res]++;
                    }
                    else
                    {
                        dic.Add(res, 1);
                    }

                    if (dic[res] > max)
                    {
                        max = dic[res];
                        maxv = res;
                    }else if(dic[res] == max)
                    {
                        if(maxv < res)
                        {
                            max = dic[res];
                            maxv = res;
                        }
                    }
                }
                if (max == n / 2)
                {
                    Console.WriteLine(0);
                    continue;
                }
                var sum = 0;
                for (var i = 0; i < n / 2; ++i)
                {
                    var tamp = arr[i] + arr[n - i - 1];
                    if (tamp == maxv)
                        continue;
                    else if (tamp < maxv)
                    {
                        if (arr[i] + k < maxv && arr[n - i - 1] + k < maxv)
                            sum += 2;
                        else sum++;
                    }
                    else if (tamp > maxv)
                    {
                        if (arr[i] >= maxv && arr[n - i - 1] >= maxv)
                            sum += 2;
                        else sum++;
                    }
                }
                if (max == 1)
                    sum = Math.Min(sum, n / 2);
                Console.WriteLine(sum);
            }
        }
    }
}

