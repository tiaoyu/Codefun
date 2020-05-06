using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codeforces
{
    partial class Solution
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

        #region Codeforces Round #634 (Div. 3)
        /// <summary>
        /// AC
        /// </summary>
        public void CandiesandTwoSisters_634_div3()
        {
            var n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                var m = long.Parse(Console.ReadLine());
                if (m == 1 || m == 2)
                    Console.WriteLine(0);
                else
                    Console.WriteLine((m - 1) >> 1);
            }
        }

        /// <summary>
        /// AC
        /// </summary>
        public void ConstructTheString_634_div3()
        {
            var latin = "abcdefghijklmnopqrstuvwxyz";
            var ans = new List<char>();
            var m = int.Parse(Console.ReadLine());
            while (m-- > 0)
            {
                var tmp = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                var n = tmp[0];
                var a = tmp[1];
                var b = tmp[2];
                ans.AddRange(latin.Substring(0, b));
                var l = a - b;
                while (l-- > 0)
                {
                    ans.Add(latin[b - 1]);
                }
                var i = 0;
                var t = n - a;
                while (i < t)
                {
                    ans.Add(ans[i++]);
                }
                foreach (var r in ans)
                {
                    Console.Write(r);
                }
                Console.WriteLine();
                ans.Clear();
            }
        }

        /// <summary>
        /// AC
        /// </summary>
        public void TwoTeamsComposing_634_div3()
        {
            var a = new HashSet<int>();
            var b = new Dictionary<int, int>();
            var m = int.Parse(Console.ReadLine());
            while (m-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var tmp = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                for (var i = 0; i < n; ++i)
                {
                    a.Add(tmp[i]);

                    if (!b.ContainsKey(tmp[i]))
                        b.Add(tmp[i], 1);
                    else
                        b[tmp[i]]++;
                }
                var max = 0;
                for (var i = 0; i < n; ++i)
                {
                    if (b[tmp[i]] > max)
                    {
                        max = b[tmp[i]];
                    }
                }
                if (max > a.Count)
                {
                    Console.WriteLine(a.Count);
                }
                else if (max == a.Count)
                {
                    Console.WriteLine(a.Count - 1);
                }
                else
                {
                    Console.WriteLine(max);
                }
                a.Clear();
                b.Clear();
            }
        }

        /// <summary>
        /// AC
        /// </summary>
        public void Anti_Sudoku_634_div3()
        {
            var n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                for (var i = 0; i < 9; ++i)
                {
                    var tmp = Console.ReadLine();
                    if (i % 3 == 0)
                    {
                        Console.WriteLine(tmp.Replace(tmp[i / 3], tmp[1 + i / 3]));
                    }
                    else if (i % 3 == 1)
                    {
                        Console.WriteLine(tmp.Replace(tmp[3 + i / 3], tmp[4 + i / 3]));
                    }
                    else if (i % 3 == 2)
                    {
                        if (i == 8)
                            Console.WriteLine(tmp.Replace(tmp[6 + i / 3], tmp[5 + i / 3]));
                        else
                            Console.WriteLine(tmp.Replace(tmp[6 + i / 3], tmp[7 + i / 3]));
                    }
                }
            }
        }
        #endregion

        #region
        public void GuessTheNumber()
        {
            var l = 1;
            var r = 1000000;
            while (l != r)
            {
                var mid = (l + r + 1) / 2;
                Console.WriteLine(mid);
                Console.Out.Flush();

                var sign = Console.ReadLine();
                if ("<".Equals(sign))
                {
                    r = mid - 1;
                }
                else
                    l = mid;
            }
            Console.WriteLine($"! {l}");
            Console.Out.Flush();
        }
        #endregion

        #region
        public void IchihimeAndTriangle_635_div2()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var tmp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var a = tmp[0];
                var b = tmp[1];
                var c = tmp[2];
                var d = tmp[3];

                var x = b;
                var y = c;
                var z = c;

                if (x + y > z)
                {
                    Console.WriteLine(x + " " + y + " " + z);
                    Console.Out.Flush();
                }
            }
        }

        public void KanaandDragonQuestgame_635_div2()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var tmp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var x = tmp[0];
                var n = tmp[1];
                var m = tmp[2];

                var ans = false;

                var mHit = m * 10;
                if (x - mHit <= 0)
                {
                    ans = true;
                }
                else
                {
                    while (n-- > 0)
                    {
                        x = (x / 2 + 10);
                        if (x <= mHit)
                        {
                            ans = true;
                            break;
                        }
                    }
                }

                if (ans)
                {
                    Console.WriteLine("YES");
                    Console.Out.Flush();
                }
                else
                {
                    Console.WriteLine("NO");
                    Console.Out.Flush();
                }

            }
        }
        #endregion

        #region round 363 div3
        public void Candies_363_div3()
        {
            var t = int.Parse(Console.ReadLine());
            var res = new int[33];
            for (var i = 2; i < 33; ++i)
                res[i] = (int)Math.Pow(2, i) - 1;

            while (t-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                for (var i = 2; i < 33; ++i)
                {
                    if (n % res[i] == 0)
                    {
                        Console.WriteLine(n / res[i]);
                        break;
                    }
                }
            }
        }
        public void BalancedArray_363_div3()
        {
            var t = int.Parse(Console.ReadLine());

            while (t-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                if (n % 2 == 0 && (n / 2) % 2 != 0)
                {
                    Console.WriteLine("NO");
                    continue;
                }
                else
                {
                    Console.WriteLine("YES");
                }

                n /= 2;
                for (var i = 1; i <= n; ++i)
                {
                    Console.Write($"{i * 2} ");
                }

                for (var i = 1; i <= n - 1; ++i)
                {
                    Console.Write($"{i * 2 - 1} ");
                }
                Console.WriteLine(n * 2 + n - 1);
            }
        }
        public void AlternatingSubsequence_363_div3()
        {
            var t = int.Parse(Console.ReadLine());

            while (t-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var arr = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var sum = 0L;
                var isPositive = true;
                var tmp = 0L;
                for (var i = 0; i < n; ++i)
                {
                    if (i == 0)
                    {
                        isPositive = arr[i] > 0;
                        tmp = arr[i];
                        continue;
                    }
                    if (arr[i] > 0 && isPositive || arr[i] < 0 && !isPositive)
                    {
                        tmp = Math.Max(arr[i], tmp);
                    }
                    else if (arr[i] > 0 && !isPositive)
                    {
                        sum += tmp;
                        tmp = arr[i];
                        isPositive = true;
                    }
                    else if (arr[i] < 0 && isPositive)
                    {
                        sum += tmp;
                        tmp = arr[i];
                        isPositive = false;
                    }
                }
                Console.WriteLine(sum + tmp);
            }
        }
        #endregion

        #region edu round 686 div2
        public void RoadToZero_edu_round_86_div2()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var tmp1 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var tmp2 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

                var x = tmp1[0];
                var y = tmp1[1];

                var a = tmp2[0];
                var b = tmp2[1];

                if (x == 0 && y == 0)
                    Console.WriteLine(0);
                else if (x == 0)
                {
                    Console.WriteLine(y * a);
                }
                else if (y == 0)
                {
                    Console.WriteLine(x * a);
                }
                else
                {
                    if (a * 2 <= b)
                    {
                        Console.WriteLine((x + y) * a);
                    }
                    else
                    {
                        var min = Math.Min(x, y);
                        var max = x + y - min;
                        Console.WriteLine(min * b + (max - min) * a);
                    }

                }
            }
        }
        #endregion

        #region round 638 div2
        /// <summary>
        /// AC
        /// A.Phoenix and Balance
        /// </summary>
        public void PhoenixandBalance_round_686_div2_A()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                //var tmp1 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var n = int.Parse(Console.ReadLine());
                var ans = 0;
                for (var i = 1; i <= n / 2; ++i)
                    ans += 1 << i;
                Console.WriteLine(ans);
            }
        }
        #endregion

        #region round 639 div2
        /// <summary>
        /// AC
        /// A. 
        /// </summary>
        public void Puzzle_Pieces_round_639_div2_A()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var tmp = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var n = tmp[0];
                var m = tmp[1];
                if (n == 1 || m == 1 || (m == 2 && n == 2))
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }

        /// <summary>
        /// B.
        /// </summary>
        public void Card_Constructions_round_639_div2_A()
        {
            var a = new int[26000];
            for (var i = 1; i < 26000; ++i)
            {
                var sum = 2 * i + 3 * i * (i - 1) / 2;
                a[i] = sum;
            }

            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                //var tmp = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var n = int.Parse(Console.ReadLine());

                var ans = 0;
                for (var i = 25999; i >= 1; --i)
                {

                    if (n % a[i] == 0)
                    {
                        ans += (n / a[i]);
                        break;
                    }

                    if (n % a[i] < n)
                    {
                        ++ans;
                        n -= a[i];
                    }
                }

                Console.WriteLine(ans);
            }
        }

        /// <summary>
        /// C.
        /// </summary>
        public void Hilberts_Hotel_round_639_div2_A()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                //var tmp = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var n = int.Parse(Console.ReadLine());
                var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var set = new HashSet<int>();
                var flg = false;
                for (var i = 0; i < n; ++i)
                {
                    for (var j = i + 1; j < n; ++j)
                    {
                        if (Math.Abs(arr[i] - arr[j]) == (j - i))
                        {
                            flg = true;
                            break;
                        }
                    }
                    if (flg) break;
                }
                if (flg)
                    Console.WriteLine("NO");
                else
                    Console.WriteLine("YES");
            }
        }
        #endregion
    }
}
