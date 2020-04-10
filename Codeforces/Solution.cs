using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codeforces
{
    class Solution
    {
        public void LittleArtem_632_div2()
        {
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; ++i)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (var j = 0; j < line[0]; ++j)
                {
                    for (var k = 0; k < line[1]; ++k)
                    {
                        if (j == 0 && k == 0)
                            Console.Write("W");
                        else
                            Console.Write("B");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void KindAnton_632_div2()
        {
            var dic = new Dictionary<int, int>();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; ++i)
            {
                var m = int.Parse(Console.ReadLine());
                var line1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var line2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (line1[0] != line2[0])
                {
                    Console.WriteLine("NO");
                    continue;
                }

                dic[-1] = 0;
                dic[1] = 0;
                dic[0] = 0;
                foreach (var v in line1)
                {
                    dic[v]++;
                }
                for (var index = m - 1; index >= 0; --index)
                {
                    if (index == 0)
                        Console.WriteLine("YES");

                    dic[line1[index]]--;
                    if (line1[index] == line2[index])
                        continue;

                    if (line1[index] > line2[index])
                    {
                        if (dic[-1] > 0)
                            dic[-1]--;
                        else
                        {
                            Console.WriteLine("NO");
                            break;
                        }
                    }
                    else
                    {
                        if (dic[1] > 0)
                        {
                            dic[1]--;
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            break;
                        }
                    }
                }
            }
        }

        public void MiddleClass_Edu_85_div2()
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; ++i)
            {
                var tmp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var m = tmp[0];
                var x = tmp[1];
                var line1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Array.Sort(line1, (a, b) => { return b - a; });

                if (line1[0] < x)
                {
                    Console.WriteLine(0);
                    continue;
                }
                long sum = 0;
                var cnt = 0;
                foreach (var v in line1)
                {
                    if (v >= x)
                    {
                        sum += v - x;
                        cnt++;
                    }
                    else
                    {
                        sum -= x - v;
                        if (sum >= 0)
                        {
                            cnt++;
                        }
                        else
                        {
                            break;
                        }
                    }

                }
                Console.WriteLine(cnt);
            }
        }

        /// <summary>
        /// TLE!!! why~
        /// </summary>
        public void CircleofMonsters_Edu_85_div2()
        {
            var n = long.Parse(Console.ReadLine());

            for (var i = 0; i < n; ++i)
            {
                var m = Convert.ToInt32(Console.ReadLine());
                long[] a = new long[m];
                long[] b = new long[m];
                long[] health = new long[m];
                long cnt = 0;
                long minh = long.MaxValue;

                var tmp = Console.ReadLine().Split(' ').Select(x => Convert.ToInt64(x)).ToArray();
                a[0] = tmp[0];
                b[0] = tmp[1];
                for (var j = 1; j < m; ++j)
                {
                    tmp = Console.ReadLine().Split(' ').Select(x => Convert.ToInt64(x)).ToArray();
                    a[j] = tmp[0];
                    b[j] = tmp[1];
                    health[j] = Math.Max(a[j] - b[j - 1], 0);
                }
                health[0] = Math.Max(a[0] - b[m - 1], 0);

                for (var j = 0; j < m; ++j)
                {
                    minh = Math.Min(a[j] - health[j], minh);
                    cnt += health[j];
                }

                Console.WriteLine(cnt + minh);
            }
        }
    }
}
