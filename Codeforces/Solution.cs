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

        #region round 641 div2
        /// <summary>
        /// AC
        /// Orac and Factors
        /// </summary>
        public void OracandFactors_div2_A()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var arr1 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var n = arr1[0];
                var k = arr1[1];

                var res = (long)Math.Sqrt(n);
                var i = 2L;
                for (i = 2; i <= res; ++i)
                {
                    if (n % i == 0)
                        break;
                }

                if (i > res)
                    Console.WriteLine(n + n + 2 * (k - 1));
                else
                    Console.WriteLine(n + i + 2 * (k - 1));
            }
        }

        public void OracandModels_div2_B()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var arr = Utilities.GetLongArray(Console.ReadLine());
                var ans = 1;
                var tmp = new int[n + 1];
                for (var i = 0; i <= n; ++i)
                    tmp[i] = 1;
                for (var i = 1; i <= n; ++i)
                {
                    for (var j = i * 2; j <= n; j += i)
                    {
                        if (arr[j - 1] > arr[i - 1])
                        {
                            tmp[j] = Math.Max(tmp[j], tmp[i] + 1);
                            ans = Math.Max(ans, tmp[j]);
                        }
                    }
                }
                Console.WriteLine(ans);
            }

        }

        public void OracandLCM_div2_C()
        {
            var n = int.Parse(Console.ReadLine());
            var arr = Utilities.GetIntArray(Console.ReadLine());
            var tmp = new List<int>();
            var minTmp = int.MaxValue;
            for (var i = 0; i < n; ++i)
            {
                for (var j = i + 1; j < n; ++j)
                {
                    var t = Utilities.LCM_int(arr[i], arr[j]);
                    tmp.Add(t);
                    minTmp = Math.Min(minTmp, t);
                }
            }
            var ans = tmp[0];
            for (var i = 1; i < tmp.Count; ++i)
            {
                ans = Utilities.GCD_int(ans, tmp[i]);
                if (ans == 1)
                    break;
            }
            Console.WriteLine(ans);
        }

        #endregion

        #region round 642 div3
        /// <summary>
        /// AC
        /// Most Unstable Array
        /// </summary>
        public void MostUnstableArray_div3_A()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var arr1 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var n = arr1[0];
                var m = arr1[1];
                if (n == 1)
                    Console.WriteLine(0);
                else if (n == 2)
                    Console.WriteLine(m);
                else
                {
                    Console.WriteLine(2 * m);
                }
            }
        }

        /// <summary>
        /// AC
        /// Two Arrays And Swaps
        /// </summary>
        public void TwoArraysAndSwaps_div3_B()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var arr = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var arr1 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var arr2 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var n = arr[0];
                var k = arr[1];

                Array.Sort(arr1);
                Array.Sort(arr2);

                for (var i = 0; i < k; ++i)
                {
                    if (arr1[i] < arr2[n - i - 1])
                    {
                        arr1[i] = arr2[n - i - 1];
                    }
                }
                var sum = 0L;
                for (var i = 0; i < n; ++i)
                {
                    sum += arr1[i];
                }
                Console.WriteLine(sum);
            }
        }

        /// <summary>
        /// AC
        /// Board Moves
        /// </summary>
        public void Board_Moves_div3_C()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var n = long.Parse(Console.ReadLine());

                if (n == 1)
                    Console.WriteLine(0);
                else
                {
                    var sum = 0L;
                    for (var i = 3L; i <= n; i += 2L)
                        sum += (i >> 1) * (i * 2 + (i - 2) * 2);
                    Console.WriteLine(sum);
                }

            }
        }

        /// <summary>
        /// AC
        /// Constructing the Array
        /// </summary>
        public void Constructing_the_Array_div3_D()
        {
            var t = int.Parse(Console.ReadLine());
            //var queue = new SortedList<Test1, Test1>(new TestComparer());
            var queue = new SortedSet<Test1>(new TestComparer());
            while (t-- > 0)
            {
                queue.Clear();
                var k = 0L;
                var n = long.Parse(Console.ReadLine());

                var ans = new long[n];

                var l = 0L;
                var r = n - 1;
                queue.Add(new Test1 { l = l, r = r });
                while (queue.Count > 0)
                {
                    var tmp = queue.ElementAt(0);
                    queue.Remove(tmp);
                    if (tmp.l > tmp.r)
                        continue;
                    var mid = (tmp.l + tmp.r) >> 1;
                    if (ans[mid] != 0)
                        continue;
                    ans[mid] = ++k;

                    if (tmp.l == tmp.r)
                        continue;

                    if (((tmp.r - tmp.l + 1) & 1) == 1)
                    {

                        queue.Add(new Test1 { l = tmp.l, r = mid - 1 });
                        queue.Add(new Test1 { l = mid + 1, r = tmp.r });
                    }
                    else
                    {
                        queue.Add(new Test1 { l = mid + 1, r = tmp.r });
                        queue.Add(new Test1 { l = tmp.l, r = mid - 1 });
                    }

                }

                Console.Write(ans[0]);
                for (var i = 1; i < n; ++i)
                {
                    Console.Write(" " + ans[i]);
                }
                Console.WriteLine();
            }
        }
        public class TestComparer : IComparer<Test1>
        {
            public int Compare(Test1 v1, Test1 v2)
            {
                if (v1.r - v1.l == v2.r - v2.l)
                {
                    return (int)(v1.l - v2.l);
                }
                else
                {
                    return (int)(v2.r - v2.l - v1.r + v1.l);
                }
            }
        }
        public struct Test1
        {
            public long l;
            public long r;

            public override int GetHashCode()
            {
                return $"{l} {r}".GetHashCode();
            }
        }

        //public void div3_E()
        //{
        //    var t = int.Parse(Console.ReadLine());
        //    while (t-- > 0)
        //    {
        //        var arr = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        //        var arr1 = Console.ReadLine();
        //        var n = arr[0];
        //        var k = arr[1];

        //        var flg = false;
        //        var val = 0;
        //        var ans = 0;
        //        for (var i = 0; i < n; ++i)
        //        {
        //            if (flg)
        //            {
        //                if ((i - val) % k == 0)
        //                {
        //                    if (arr1[i] != '1')
        //                        ans++;
        //                }
        //                else
        //                {
        //                    if (arr1[i] != '0')
        //                        ans++;
        //                }
        //            }
        //            else
        //            {
        //                if (arr1[i] == '1')
        //                {
        //                    flg = true;
        //                    val = i;
        //                }
        //            }
        //        }
        //        Console.WriteLine(ans);
        //    }
        //}
        #endregion

        #region round 643 div2
        /// <summary>
        /// AC
        /// </summary>
        public void SequencewithDigits_div2_A()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var arr = Utilities.GetLongArray(Console.ReadLine());
                var a1 = arr[0];
                var k = arr[1];


                while (--k > 0)
                {
                    var min = long.MaxValue;
                    var max = long.MinValue;
                    var tmp = a1;
                    while (a1 > 0)
                    {
                        if (a1 % 10 == 0)
                        {
                            min = 0;
                            break;
                        }
                        min = Math.Min(min, a1 % 10);
                        max = Math.Max(max, a1 % 10);
                        a1 /= 10;
                    }
                    a1 = tmp + min * max;
                    if (a1 == tmp)
                        break;
                }

                Console.WriteLine(a1);
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void YoungExplorers_div2_B()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var n = long.Parse(Console.ReadLine());
                var arr = Utilities.GetLongArray(Console.ReadLine());
                Array.Sort(arr);

                var ans = 0;
                var cur = 0;
                for (var i = 0; i < n; ++i)
                {
                    if (++cur >= arr[i])
                    {
                        ans++;
                        cur = 0;
                    }
                }
                Console.WriteLine(ans);
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void CountTriangles_div_C()
        {
            var arr = Utilities.GetLongArray(Console.ReadLine());
            var a = arr[0];
            var b = arr[1];
            var c = arr[2];
            var d = arr[3];

            var ans = 0L;

            if (a + b > d)
                ans = (b - a + 1) * (c - b + 1) * (d - c + 1);
            else
                for (var z = d; z >= c; --z)
                {
                    if (a + b > z)
                    {
                        ans += (b - a + 1) * (c - b + 1) * (z - c + 1);
                        break;
                    }
                    for (var x = a; x <= b; ++x)
                    {
                        if (x + b > z)
                        {
                            ans += (b - x + 1) * (c - b + 1);
                            break;
                        }
                        for (var y = b; y <= c; ++y)
                        {
                            if (x + y > z)
                                ++ans;
                        }
                    }
                }
            Console.WriteLine(ans);
        }

        #endregion

        #region edu round 87
        /// <summary>
        /// AC
        /// </summary>
        public void AlarmClock_round_87_A()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var arr = Utilities.GetLongArray(Console.ReadLine());

                var a = arr[0];
                var b = arr[1];
                var c = arr[2];
                var d = arr[3];

                if (a <= b)
                    Console.WriteLine(b);
                else if (c <= d)
                    Console.WriteLine(-1);
                else
                    Console.WriteLine(b + ((a - b + (c - d - 1)) / (c - d)) * c);
            }
        }

        /// <summary>
        /// AC
        /// </summary>
        public void TernaryString_round_87_B()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var arr = Console.ReadLine();
                var indx1 = -1;
                var indx2 = -1;
                var indx3 = -1;
                var ans = int.MaxValue;
                for (var i = 0; i < arr.Length; ++i)
                {
                    if (indx1 >= 0 && indx2 >= 0 && indx3 >= 0)
                    {
                        var min = Math.Min(Math.Min(indx1, indx2), indx3);
                        var max = Math.Max(Math.Max(indx1, indx2), indx3);
                        ans = Math.Min(ans, max - min + 1);

                        if (i - max > max - min || max - min == 2)
                            break;

                        if (arr[i] == '1')
                        {
                            indx1 = i;
                        }
                        else if (arr[i] == '2')
                        {
                            indx2 = i;
                        }
                        else if (arr[i] == '3')
                        {
                            indx3 = i;
                        }
                    }
                    else
                    {
                        if (arr[i] == '1')
                        {
                            indx1 = i;
                        }
                        else if (arr[i] == '2')
                        {
                            indx2 = i;
                        }
                        else if (arr[i] == '3')
                        {
                            indx3 = i;
                        }
                    }

                    if (indx1 >= 0 && indx2 >= 0 && indx3 >= 0)
                    {
                        var min = Math.Min(Math.Min(indx1, indx2), indx3);
                        var max = Math.Max(Math.Max(indx1, indx2), indx3);
                        ans = Math.Min(ans, max - min + 1);
                    }
                }
                Console.WriteLine(ans == int.MaxValue ? 0 : ans);
            }
        }

        /// <summary>
        /// AC
        /// </summary>
        public void SimplePolygonEmbedding_round_87_C1()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                //var arr = Utilities.GetLongArray(Console.ReadLine());
                var n = int.Parse(Console.ReadLine());
                var ans = 1.0D / 2.0D;
                for (var i = 1; i <= n * 2 / 4 - 1; ++i)
                {
                    ans += Math.Cos(2 * Math.PI / (2 * n) * i);
                }
                Console.WriteLine(Math.Round(ans * 2.0D, 9));
            }
        }
        /// <summary>
        /// AC
        /// </summary>
        public void NotSoSimplePolygonEmbedding_round_87_C2()
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var ans = 1.0D / 2.0D;
                for (var i = 1; i <= n * 2 / 4; ++i)
                {
                    ans += Math.Cos(2 * Math.PI / (2 * n) * i);
                }
                // half of inside angle
                ans = (ans * 2) * Math.Cos(Math.PI / (2 * n) / 2);
                Console.WriteLine(Math.Round(ans, 9));
            }
        }

        /// <summary>
        /// MLE
        /// </summary>
        public void Multiset_round_87_D()
        {
            var args = Utilities.GetIntArray(Console.ReadLine());
            var arrs = Utilities.GetIntArray(Console.ReadLine());
            var queries = Utilities.GetIntArray(Console.ReadLine());

            var n = args[0];
            var q = args[1];
            var tmp = n;
            Array.Sort(arrs);

            foreach (var query in queries)
            {
                if (query < 0)
                {
                    for (var i = -query - 1; i < n - 1; ++i)
                    {
                        arrs[i] = arrs[i + 1];
                    }
                    --n;
                }
                else
                {
                    for (var i = 0; i < n; ++i)
                    {

                        if (arrs[i] >= query)
                        {
                            if (n >= tmp)
                            {
                                Array.Resize(ref arrs, n + 1);
                            }
                            for (var j = n - 1; j >= i; --j)
                                arrs[j + 1] = arrs[j];
                            arrs[i] = query;
                            if (n >= tmp)
                            {
                                tmp = n + 1;
                                n = n + 1;
                            }
                            else
                            {
                                ++n;
                            }
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(n > 0 ? arrs[0] : 0);
        }
        #endregion
    }
}
