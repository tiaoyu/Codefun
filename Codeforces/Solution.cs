﻿using System;
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
        /// B. AC
        /// Card Constructions
        /// </summary>
        public void Card_Constructions_round_639_div2_B()
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
                    if (n >= a[i])
                    {
                        ans += (n / a[i]);
                        n %= a[i];
                    }
                }

                Console.WriteLine(ans);
            }
        }

        /// <summary>
        /// AC
        /// C. Hilbert's Hotel
        /// </summary>
        public void Hilberts_Hotel_round_639_div2_C()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var set = new HashSet<int>();
                var flg = false;
                var tmp = new int[n];
                for (var i = 0; i < n; ++i)
                {
                    tmp[((i + arr[i]) % n + n) % n]++;
                }
                for (var i = 0; i < n; ++i)
                {
                    if (tmp[i] >= 2)
                    {
                        flg = true;
                        break;
                    }
                }
                if (flg)
                    Console.WriteLine("NO");
                else
                    Console.WriteLine("YES");
            }
        }
        #endregion

        #region Testing Round 16 (Unrated)
        /// <summary>
        /// AC
        /// A. A + B
        /// </summary>
        public void AplusB_A()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                //var n = int.Parse(Console.ReadLine());
                var ans = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                Console.WriteLine(ans[0] + ans[1]);
            }
        }

        /// <summary>
        /// AC
        /// B. Square?
        /// </summary>
        public void Square_B()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                //var n = int.Parse(Console.ReadLine());
                var arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var a1 = arr1[0];
                var b1 = arr1[1];
                var a2 = arr2[0];
                var b2 = arr2[1];
                var l = a1 > b1 ? a1 : b1;
                if (a1 != b1)
                {
                    if ((a2 == a1 && b2 + b1 == l) || a2 == b1 && b2 + a1 == l || b2 == a1 && a2 + b1 == l || b2 == b1 && a2 + a1 == l)
                    {
                        Console.WriteLine("YES");
                        continue;
                    }
                }
                Console.WriteLine("NO");
            }
        }

        /// <summary>
        /// AC
        /// C. Skier
        /// </summary>
        public void Skier_C()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                //var n = int.Parse(Console.ReadLine());
                var arr = Console.ReadLine();
                var dic = new Dictionary<Test, bool>();
                var sx = 0;
                var sy = 0;
                var tx = 0;
                var ty = 0;
                var ans = 0;
                for (var i = 0; i < arr.Length; ++i)
                {
                    switch (arr[i])
                    {
                        case 'N':
                            ++ty;
                            break;
                        case 'S':
                            --ty;
                            break;
                        case 'W':
                            --tx;
                            break;
                        case 'E':
                            ++tx;
                            break;
                    }
                    if (!dic.ContainsKey(new Test { sx = sx, sy = sy, tx = tx, ty = ty }))
                    {
                        dic.Add(new Test { sx = sx, sy = sy, tx = tx, ty = ty }, true);
                        dic.Add(new Test { sx = tx, sy = ty, tx = sx, ty = sy }, true);
                        ans += 5;
                    }
                    else
                    {
                        ans++;
                    }
                    sx = tx;
                    sy = ty;
                }
                Console.WriteLine(ans);
            }
        }
        public struct Test
        {
            public int sx;
            public int sy;
            public int tx;
            public int ty;

            public override int GetHashCode()
            {
                return (((((((sx.GetHashCode() * 17) + sy.GetHashCode()) * 17) * 17) + tx.GetHashCode()) * 17) + ty.GetHashCode()) & 0x7fffffff;
            }
        }
        #endregion

        #region round 640 div4

        /// <summary>
        /// AC
        /// </summary>
        public void SumofRoundNumbers_round_640_div4()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var list = new List<long>();
                var n = long.Parse(Console.ReadLine());
                var tmp = 1L;
                while (n > 0)
                {
                    if (n % 10 == 0)
                    {
                        n /= 10;
                        tmp *= 10;
                        continue;
                    }

                    list.Add((n % 10) * tmp);
                    n /= 10;
                    tmp *= 10;
                }

                Console.WriteLine(list.Count);
                Console.Write(list[0]);
                for (var i = 1; i < list.Count; ++i)
                    Console.Write(" " + list[i]);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// AC
        /// </summary>
        public void SameParitySummands_round_640_div4()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var arr1 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var n = arr1[0];
                var k = arr1[1];
                if (k > n)
                {
                    Console.WriteLine("NO");
                    continue;
                }

                if (k == n)
                {
                    Console.WriteLine("YES");
                    Console.Write(1);
                    for (var i = 0; i < k - 1; ++i)
                    {
                        Console.Write(" " + 1);
                    }
                    Console.WriteLine();
                    continue;
                }

                var tmp1 = n - (k - 1);

                if ((tmp1 & 1) == 1)
                {
                    Console.WriteLine("YES");
                    Console.Write(tmp1);
                    for (var i = 0; i < k - 1; ++i)
                    {
                        Console.Write(" " + 1);
                    }
                    Console.WriteLine();
                    continue;
                }


                var tmp2 = n - ((k - 1) * 2);
                if (tmp2 <= 0)
                {
                    Console.WriteLine("NO");
                    continue;
                }
                if ((tmp2 & 1) == 0)
                {
                    Console.WriteLine("YES");
                    Console.Write(tmp2);
                    for (var i = 0; i < k - 1; ++i)
                    {
                        Console.Write(" " + 2);
                    }
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine("NO");

            }
        }

        /// <summary>
        /// AC
        /// </summary>
        public void K_thNotDivisiblebyn_round_640_div4()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var arr1 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var n = arr1[0];
                var k = arr1[1];

                if (n > k)
                {
                    Console.WriteLine(k);
                }
                else if (n == k)
                {
                    Console.WriteLine(n + 1);
                }
                else
                {
                    var res = k / (n - 1);

                    var count = res * (n - 1);
                    var remain = k - count;
                    if (remain == 0)
                    {
                        Console.WriteLine(res * n - 1);
                    }
                    else
                    {
                        Console.WriteLine(res * n + remain);
                    }
                }
            }
        }

        /// <summary>
        /// AC
        /// </summary>
        public void AliceBobandCandies_round_640_div4()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var l = 0;
                var r = arr1.Length - 1;
                var flg = true;
                var a = 0;
                var b = 0;
                var eatA = 0;
                var eatB = 0;
                var prev = 0;
                while (l <= r)
                {
                    if (flg)
                    {
                        var sum = 0;
                        for (var i = l; i <= r; ++i)
                        {
                            sum += arr1[i];
                            if (sum > prev)
                            {
                                prev = sum;
                                flg = false;
                                a++;
                                l = i + 1;
                                eatA += sum;
                                break;
                            }
                        }
                        if (flg)
                        {
                            a++;
                            l = r;
                            eatA += sum;
                            break;
                        }
                    }
                    else
                    {
                        var sum = 0;
                        for (var i = r; i >= l; --i)
                        {
                            sum += arr1[i];
                            if (sum > prev)
                            {
                                prev = sum;
                                flg = true;
                                b++;
                                r = i - 1;
                                eatB += sum;
                                break;
                            }
                        }
                        if (!flg)
                        {
                            b++;
                            r = l;
                            eatB += sum;
                            break;
                        }
                    }
                }

                Console.WriteLine(a + b + " " + eatA + " " + eatB);
            }
        }

        /// <summary>
        /// MLE
        /// </summary>
        public void SpecialElements_round_640_div4()
        {
            var t = int.Parse(Console.ReadLine());
            var set = new HashSet<int>();
            while (t-- > 0)
            {
                set.Clear();
                var n = int.Parse(Console.ReadLine());
                var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (var i = 0; i < n; ++i)
                {
                    var sum = arr[i];
                    for (var j = i + 1; j < n; ++j)
                    {
                        sum += arr[j];
                        set.Add(sum);
                    }
                }

                var ans = 0;
                for (var i = 0; i < n; ++i)
                {
                    if (set.Contains(arr[i]))
                    {
                        ++ans;
                    }
                }
                Console.WriteLine(ans);
            }
        }

        #endregion
    }
}
