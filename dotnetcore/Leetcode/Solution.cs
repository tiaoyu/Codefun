﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class Solution
    {
        public void NextPermutation(int[] nums)
        {
            int lasti = nums.Length - 1;
            int tmp = 0;
            int tmpi = 0;
            int tmpii = 0;
            for (var i = 1; i < nums.Length; ++i)
            {
                if (nums[i] > nums[i - 1])
                {
                    tmp = nums[i];
                    tmpi = i;
                    tmpii = i;
                }
                if (tmpi != 0)
                {
                    if (nums[i] > nums[tmpi - 1] && nums[i] < tmp)
                    {
                        tmpii = i;
                    }
                }
            }

            if (tmpi == 0)
            {
                // max
                Array.Reverse(nums);
            }
            else if (tmpi == nums.Length - 1)
            {
                // last
                nums[lasti - 1] = nums[lasti - 1] ^ nums[lasti];
                nums[lasti] = nums[lasti - 1] ^ nums[lasti];
                nums[lasti - 1] = nums[lasti - 1] ^ nums[lasti];
            }
            else
            {
                nums[tmpi - 1] = nums[tmpi - 1] ^ nums[tmpii];
                nums[tmpii] = nums[tmpi - 1] ^ nums[tmpii];
                nums[tmpi - 1] = nums[tmpi - 1] ^ nums[tmpii];

                Array.Sort(nums, tmpi, nums.Length - tmpi);
            }
        }

        /// <summary>
        /// AC
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<string> StringMatching(string[] words)
        {
            var len = words.Length;
            var lenArray = new int[len];
            var resList = new List<string>(len);

            Array.Sort(words, (a, b) => { return a.Length - b.Length; });
            for (var i = 0; i < len; ++i)
            {
                for (var j = i + 1; j < len; ++j)
                {
                    if (words[j].Contains(words[i]))
                    {
                        resList.Add(words[i]);
                        break;
                    }
                }
            }
            return resList;
        }

        /// <summary>
        /// AC
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int[] ProcessQueries(int[] queries, int m)
        {
            var piTopv = new int[m];
            var pvTopi = new int[m + 1];

            var res = new int[queries.Length];
            var resi = 0;
            for (var i = 1; i <= m; ++i)
            {
                piTopv[i - 1] = i;
                pvTopi[i] = i - 1;
            }

            foreach (var q in queries)
            {
                var index = pvTopi[q];
                res[resi++] = index;

                for (var i = index; i > 0; --i)
                {
                    piTopv[i] = piTopv[i - 1];
                    pvTopi[piTopv[i - 1]] = i;
                }
                piTopv[0] = q;
                pvTopi[q] = 0;
            }

            return res;
        }

        /// <summary>
        /// AC
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string EntityParser(string text)
        {
            var staticDic = new Dictionary<string, char> { { "&quot;", '\"' }, { "&apos;", '\'' }, { "&amp;", '&' }, { "&gt;", '>' }, { "&lt;", '<' }, { "&frasl;", '/' } };
            var res = new StringBuilder();
            for (var i = 0; i < text.Length;)
            {
                if (text[i] == '&')
                {
                    if (text[i + 3] == ';')
                    {
                        if (staticDic.TryGetValue(text.Substring(i, 4), out var resChar))
                        {
                            res.Append(resChar);
                            i += 4;
                            continue;
                        }
                    }
                    else if (text[i + 4] == ';')
                    {
                        if (staticDic.TryGetValue(text.Substring(i, 5), out var resChar))
                        {
                            res.Append(resChar);
                            i += 5; continue;
                        }
                    }
                    else if (text[i + 5] == ';')
                    {
                        if (staticDic.TryGetValue(text.Substring(i, 6), out var resChar))
                        {
                            res.Append(resChar);
                            i += 6; continue;
                        }
                    }
                    else if (text[i + 6] == ';')
                    {
                        if (staticDic.TryGetValue(text.Substring(i, 7), out var resChar))
                        {
                            res.Append(resChar);
                            i += 7; continue;
                        }
                    }
                }

                res.Append(text[i]);
                i++;
            }
            return res.ToString();
        }

        public int NumOfWays(int n)
        {
            if (n == 1) return 12;

            var ABA = 6L;
            var ABC = 6L;

            while (--n > 0)
            {
                var tmp = ABA;
                ABA = ABA * 3 % 1000000007 + ABC * 2 % 1000000007;
                ABC = tmp * 2 % 1000000007 + ABC * 2 % 1000000007;
            }
            return (int)((ABA + ABC) % 1000000007);
        }

        /// <summary>
        /// 给定一堆石子 每次取走1或3个 最后取光的人为赢家。现在 A 先取 判断结果他是否能赢
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CanWinNim(int n)
        {
            return n % 4 != 0;
        }

        /// <summary>
        /// 汉明距离 两个数二进制进行异或运算 结果中1的个数即为汉明距离
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int HammingDistance(int x, int y)
        {
            var v = x ^ y;
            var res = 0;
            while (v != 0)
            {
                res += v & 1;
                v >>= 1;
            }
            return res;
        }

        /// <summary>
        /// 类型：动态规划
        /// 难度：easy
        /// 描述：求给定数组最大上升自序列长度
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            var dp = new int[nums.Length];
            for (var i = 0; i < nums.Length; ++i)
            {
                dp[i] = 1;
                for (var j = 0; j < i; ++j)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }
            var res = 0;
            for (var i = 0; i < dp.Length; ++i)
            {
                res = Math.Max(res, dp[i]);
            }
            return res;
        }

        #region contest 185 
        /// <summary>
        /// AC
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Reformat(string s)
        {
            var res = new StringBuilder();
            var number = new Queue<char>();
            var latin = new Queue<char>();
            foreach (var c in s)
            {
                if (c >= 'a' && c <= 'z')
                {
                    latin.Enqueue(c);
                }
                else if (c >= '0' && c <= '9')
                {
                    number.Enqueue(c);
                }
            }

            if (Math.Abs(latin.Count - number.Count) > 1)
            {
                return "";
            }

            var lc = latin.Count;
            var nc = number.Count;
            if (lc > nc)
            {
                for (var i = 0; i < lc; ++i)
                {
                    if (latin.Count > 0)
                        res.Append(latin.Dequeue());
                    if (number.Count > 0)
                        res.Append(number.Dequeue());
                }
            }
            else
            {
                for (var i = 0; i < nc; ++i)
                {
                    if (number.Count > 0)
                        res.Append(number.Dequeue());
                    if (latin.Count > 0)
                        res.Append(latin.Dequeue());
                }
            }

            return res.ToString();
        }

        /// <summary>
        /// WA
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public IList<IList<string>> DisplayTable(IList<IList<string>> orders)
        {
            var res = new SortedDictionary<int, Dictionary<string, int>>();
            var tableSet = new HashSet<string>();


            foreach (var customer in orders)
            {
                var cm = int.Parse(customer[1]);
                tableSet.Add(customer[2]);
                if (!res.ContainsKey(cm))
                {
                    res.Add(cm, new Dictionary<string, int>());
                }

                var table = res[cm];

                if (!table.ContainsKey(customer[2]))
                {
                    table[customer[2]] = 1;
                }
                else
                {
                    table[customer[2]]++;
                }
            }
            var tableList = new List<string>(tableSet);

            tableList.Sort((s1, s2) =>
            {
                for (var i = 0; i < s1.Length; ++i)
                {
                    if (i >= s2.Length)
                        return 1;
                    if (s1[i] == s2[i]) continue;

                    return s1[i] - s2[i];
                }
                return 0;
            });

            var ans = new List<List<string>>();

            foreach (var (tableNo, table) in res)
            {
                var dishList = new List<string>();
                dishList.Add($"{tableNo}");
                foreach (var dish in tableList)
                {
                    if (table.ContainsKey(dish))
                        dishList.Add($"{table[dish]}");
                    else dishList.Add("0");
                }
                ans.Add(dishList);
            }

            tableList.Insert(0, "Table");

            ans.Insert(0, tableList);

            //foreach (var i in ans)
            //{
            //    foreach (var j in i)
            //    {
            //        Console.Write(j + " ");
            //    }
            //    Console.WriteLine();
            //}

            return ans.ToArray();
        }

        /// <summary>
        /// AC
        /// </summary>
        /// <param name="croakOfFrogs"></param>
        /// <returns></returns>
        public int MinNumberOfFrogs(string croakOfFrogs)
        {
            var staticCh = new char[200];
            staticCh['c'] = 'k';
            staticCh['r'] = 'c';
            staticCh['o'] = 'r';
            staticCh['a'] = 'o';
            staticCh['k'] = 'a';

            var chList = new int[200];
            chList['c'] = 0;
            chList['r'] = 0;
            chList['o'] = 0;
            chList['a'] = 0;
            chList['k'] = 0;



            var ans = 0;
            foreach (var c in croakOfFrogs)
            {
                chList[c]++;
                if (c != 'c' && chList[c] > chList[staticCh[c]])
                    return -1;

                if (c == 'k')
                {
                    --chList['c'];
                    --chList['r'];
                    --chList['o'];
                    --chList['a'];
                    --chList['k'];
                }
                ans = Math.Max(chList['c'], ans);
            }

            return chList['c'] != 0 ? -1 : ans;
        }
        #endregion

        #region leetcode contest 186
        /// <summary>
        /// AC
        /// 1.分割字符串的最大得分
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxScore_5392(string s)
        {
            var one = 0;
            foreach (var ch in s)
            {
                if (ch == '1')
                {
                    one++;
                }
            }

            var zero = 0;

            if (s[0] == '1') one--;
            if (s[0] == '0') zero++;
            var max = zero + one;

            for (var i = 1; i < s.Length - 1; ++i)
            {
                if (s[i] == '0')
                {
                    max = Math.Max(max, ++zero + one);
                }
                else if (s[i] == '1')
                {
                    max = Math.Max(max, zero + --one);
                }

            }
            return max;
        }

        /// <summary>
        /// AC
        /// 2.可获得的最大点数
        /// </summary>
        /// <param name="cardPoints"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxScore_5393(int[] cardPoints, int k)
        {
            var tmp = 0;
            for (var i = 0; i < k; ++i)
            {
                tmp += cardPoints[i];
            }
            var ans = tmp;
            for (var i = 0; i < k; ++i)
            {
                tmp -= cardPoints[k - i - 1];
                tmp += cardPoints[cardPoints.Length - i - 1];
                ans = Math.Max(ans, tmp);
            }

            return ans;
        }
        /// <summary>
        /// AC
        /// 3.对角线遍历 II
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FindDiagonalOrder_5394(IList<IList<int>> nums)
        {
            var ans = new List<int>();

            var tmp = new List<int[]>();
            for (var i = 0; i < nums.Count; ++i)
            {
                for (var j = 0; j < nums[i].Count; ++j)
                {
                    tmp.Add(new int[] { i, j });
                }
            }
            tmp.Sort((v1, v2) =>
            {

                if (v1[0] + v1[1] == v2[0] + v2[1])
                {
                    return v2[1] - v1[1];
                }
                return v1[0] + v1[1] - v2[0] - v2[1];
            });
            foreach (var v in tmp)
            {
                ans.Add(nums[v[0]][v[1]]);
            }
            return ans.ToArray();
        }
        /// <summary>
        /// AC
        /// 4.带限制的子序列和
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int ConstrainedSubsetSum(int[] nums, int k)
        {
            var dp = new int[nums.Length];
            var tmp = new SortedSet<int>();

            dp[0] = nums[0];
            var ans = dp[0];
            tmp.Add(dp[0]);
            for (var i = 1; i < nums.Length; ++i)
            {
                dp[i] = Math.Max(tmp.Max + nums[i], nums[i]);
                ans = Math.Max(ans, dp[i]);

                if (tmp.Count >= k)
                    tmp.Remove(dp[i - k]);
                tmp.Add(dp[i]);
            }
            return ans;
        }
        #endregion

        #region contest 187
        /// <summary>
        /// AC
        /// A. 旅行终点站
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public string DestCity(IList<IList<string>> paths)
        {
            var ans = string.Empty;
            var dicTarget = new Dictionary<string, int>();
            var dicSource = new Dictionary<string, int>();
            foreach (var path in paths)
            {
                if (dicSource.ContainsKey(path[0]))
                {
                    dicSource[path[0]]++;
                }
                else
                {
                    dicSource.Add(path[0], 1);
                }

                if (dicTarget.ContainsKey(path[1]))
                {
                    dicTarget[path[1]]++;
                }
                else
                {
                    dicTarget.Add(path[1], 1);
                }
            }
            foreach (var (k, v) in dicTarget)
            {
                if (v == 1 && !dicSource.ContainsKey(k))
                {
                    ans = k;
                    break;
                }
            }
            return ans;
        }

        /// <summary>
        /// AC
        /// B. 是否所有 1 都至少相隔 k 个元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool KLengthApart(int[] nums, int k)
        {
            var flg = false;
            var tmp = 0;
            foreach (var v in nums)
            {
                if (!flg)
                {
                    if (v == 1)
                    {
                        flg = true;
                        tmp = 0;
                    }
                }
                else
                {
                    if (v == 1)
                    {
                        if (tmp >= k)
                        {
                            tmp = 0;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (v == 0)
                    {
                        tmp++;
                    }
                }

            }
            return true;
        }

        /// <summary>
        /// AC
        /// C. 绝对差不超过限制的最长连续子数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int LongestSubarray(int[] nums, int limit)
        {
            var ans = 0;

            var l = 0;
            var min = nums[0];
            var max = nums[0];
            for (var i = 1; i < nums.Length; ++i)
            {
                max = Math.Max(max, nums[i]);
                min = Math.Min(min, nums[i]);

                if (max - min <= limit)
                {
                    ans = Math.Max(ans, i - l + 1);
                }
                else
                {
                    l = i;
                    max = nums[i];
                    min = nums[i];
                    while (l > 0 && Math.Abs(nums[i] - nums[l]) <= limit)
                    {
                        max = Math.Max(max, nums[l]);
                        min = Math.Min(min, nums[l]);
                        --l;
                    }
                    ++l;
                }
            }

            return ans;
        }

        /// <summary>
        /// D. 有序矩阵中的第 k 个最小数组和
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest(int[][] mat, int k)
        {
            var ans = 0;
            // TODO
            return ans;
        }
        #endregion

        #region lettcode contest 188

        /// <summary>
        /// AC
        /// </summary>
        /// <param name="target"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> BuildArray_A(int[] target, int n)
        {
            var ans = new List<string>();
            var p = 0;
            for (var i = 1; ; ++i)
            {
                if (p >= target.Length)
                    break;
                if (target[p] == i)
                {
                    ans.Add("Push");
                    ++p;
                }
                else
                {
                    ans.Add("Push");
                    ans.Add("Pop");
                }
            }
            return ans;
        }
        #endregion

        #region leetcode contest 189
        /// <summary>
        /// AC
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="queryTime"></param>
        /// <returns></returns>
        public int BusyStudent_189_A(int[] startTime, int[] endTime, int queryTime)
        {
            var ans = 0;
            for (var i = 0; i < startTime.Length; ++i)
            {
                if (queryTime >= startTime[i] && queryTime <= endTime[i])
                    ans++;
            }
            return ans;
        }

        /// <summary>
        /// AC
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ArrangeWords_189_B(string text)
        {
            var strs = text.Split(' ');

            for (var i = 0; i < strs.Length; ++i)
            {
                strs[i] = strs[i].ToLower();
                for (var j = 1; j < strs.Length; ++j)
                {
                    if (strs[j - 1].Length > strs[j].Length)
                    {
                        var tmp = strs[j];
                        strs[j] = strs[j - 1];
                        strs[j - 1] = tmp;
                    }
                }
            }
            var ans = strs[0];
            for (var i = 0; i < strs.Length; ++i)
            {
                ans = $"{ans} {strs[i]}";
            }
            ans = ans.Substring(0, 1).ToUpper() + ans.Substring(1);
            return ans;
        }


        /// <summary>
        /// AC
        /// </summary>
        /// <param name="favoriteCompanies"></param>
        /// <returns></returns>
        public IList<int> PeopleIndexes_189_C(IList<IList<string>> favoriteCompanies)
        {
            var dic = new Dictionary<int, HashSet<string>>();

            var inx = -1;
            foreach (var s in favoriteCompanies)
            {
                dic.Add(++inx, new HashSet<string>());
                foreach (var i in s)
                {
                    dic[inx].Add(i);
                }
            }
            var ans = new List<int>();
            for (var i = 0; i < dic.Count; ++i)
            {
                var flg = false;
                for (var j = 0; j < dic.Count; ++j)
                {
                    if (i != j && dic[j].IsProperSupersetOf(dic[i]))
                    {
                        flg = true;
                        break;
                    }
                }
                if (!flg)
                    ans.Add(i);
            }
            return ans;
        }
        #endregion

        /// <summary>
        /// 最长有效括号
        /// 给定一个只包含 '(' 和 ')' 的字符串，找出最长的包含有效括号的子串的长度。
        /// </summary>
        public int LongestValidParentheses(string s)
        {
            var set = new HashSet<V>();
            var res = 0;
            var tmp = 0;
            var stack = new Stack<int>();
            for (var i = 0; i < s.Length; ++i)
            {
                if (s[i] == '(')
                {
                    stack.Push(i + 1);
                }
                else if (s[i] == ')')
                {
                    if (stack.Count <= 0)
                        continue;
                    var peek = stack.Peek();
                    if (peek > 0)
                    {
                        stack.Pop();
                        var vTmp = new V { i = peek, j = i + 1 };
                        var rmList = new List<V>();
                        foreach (var v in set)
                        {
                            if (vTmp.j + 1 == v.i)
                            {
                                rmList.Add(v);
                                vTmp.j = v.j;
                            }
                            else if (vTmp.i + 1 == v.i && vTmp.j - 1 == v.j)
                            {
                                rmList.Add(v);
                            }
                            else if (vTmp.i - 1 == v.j)
                            {
                                rmList.Add(v);
                                vTmp.i = v.i;
                            }
                        }
                        foreach (var l in rmList)
                        {
                            set.Remove(l);
                        }
                        set.Add(vTmp);
                    }
                    else
                    {
                        stack.Push(-(i + 1));
                    }
                }
            }
            foreach (var v in set)
            {
                res = Math.Max(res, v.j - v.i + 1);
            }

            return res;
        }
        public struct V
        {
            public int i;
            public int j;
        }

        /// <summary>
        /// 搜索旋转排序数组
        /// 假设按照升序排序的数组在预先未知的某个点上进行了旋转。
        /// (例如，数组[0, 1, 2, 4, 5, 6, 7] 可能变为[4, 5, 6, 7, 0, 1, 2] )。
        /// 搜索一个给定的目标值，如果数组中存在这个目标值，则返回它的索引，否则返回 -1 。
        /// 你可以假设数组中不存在重复的元素。
        /// 你的算法时间复杂度必须是 O(log n) 级别。
        /// 来源：力扣（LeetCode）
        /// 链接：https://leetcode-cn.com/problems/search-in-rotated-sorted-array
        /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            if (nums.Length <= 0) return -1;
            // 二分法
            var res = -1;
            var l = 0;
            var r = nums.Length - 1;
            var mid = (l + r) >> 1;
            while (target != nums[mid])
            {
                if (l == r) break;
                // 4561 >2< 3 
                if (nums[mid] <= nums[l] && nums[mid] <= nums[r])
                {
                    if (target > nums[mid])
                    {
                        if (target <= nums[r])
                            l = mid + 1;
                        else
                            r = mid;
                    }
                    else
                    {
                        r = mid;
                    }
                }
                // 4 >5< 6123
                else if (nums[mid] >= nums[l] && nums[mid] >= nums[r])
                {
                    if (target > nums[mid])
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        if (target < nums[l])
                            l = mid + 1;
                        else
                            r = mid;
                    }
                }
                else
                {
                    if (target > nums[mid])
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid;
                    }
                }
                mid = (l + r) >> 1;
            }
            if (target == nums[mid])
                res = mid;
            return res;
        }

        /// <summary>
        /// 在排序数组中查找元素的第一个和最后一个位置
        /// 给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。
        /// 你的算法时间复杂度必须是 O(log n) 级别。
        /// 如果数组中不存在目标值，返回[-1, -1]。
        /// 来源：力扣（LeetCode）
        /// 链接：https://leetcode-cn.com/problems/find-first-and-last-position-of-element-in-sorted-array
        /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            var res = new int[] { -1, -1 };
            if (nums.Length <= 0) return res;
            var min = int.MaxValue;
            var max = int.MinValue;
            var l = 0;
            var r = nums.Length - 1;
            void f(int[] nums, int l, int r)
            {
                if (l == r)
                {
                    if (target == nums[l])
                    {
                        min = Math.Min(min, l);
                        max = Math.Max(max, l);
                    }
                    return;
                }

                var mid = (l + r) >> 1;
                if (nums[mid] == target)
                {
                    min = Math.Min(min, mid);
                    max = Math.Max(max, mid);
                    f(nums, l, mid);
                    f(nums, mid + 1, r);

                }
                else if (nums[mid] < target)
                {
                    f(nums, mid + 1, r);
                }
                else
                {
                    f(nums, l, mid);
                }
            }
            f(nums, l, r);

            res[0] = min == int.MaxValue ? -1 : min;
            res[1] = max == int.MinValue ? -1 : max;

            return res;
        }
        /// <summary>
        /// 组合总和
        /// 给定一个无重复元素的数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
        /// candidates 中的数字可以无限制重复被选取。
        /// 说明：
        /// 所有数字（包括 target）都是正整数。
        /// 解集不能包含重复的组合。 
        /// 来源：力扣（LeetCode）
        /// 链接：https://leetcode-cn.com/problems/combination-sum
        /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var res = new List<List<int>>();
            Array.Sort(candidates);

            void dfs(int t, List<int> list)
            {
                foreach (var item in candidates)
                {
                    if (item == t)
                    {
                        if (list.Count > 0 && list[list.Count - 1] > item)
                            continue;
                        var tmp = new List<int>(list);
                        tmp.Add(item);
                        res.Add(tmp);
                    }
                    else if (t > item)
                    {
                        if (list.Count > 0 && list[list.Count - 1] > item)
                            continue;
                        var tmp = new List<int>(list);
                        tmp.Add(item);
                        dfs(t - item, tmp);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            dfs(target, new List<int>());

            return res.ToArray();
        }

        /// <summary>
        /// 接雨水
        /// 给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。
        /// 上面是由数组[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1] 表示的高度图，在这种情况下，可以接 6 个单位的雨水（蓝色部分表示雨水）。
        /// 来源：力扣（LeetCode）
        /// 链接：https://leetcode-cn.com/problems/trapping-rain-water
        /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            if (height.Length <= 0) return 0;
            var maxInx = 0;
            var max = height[0];
            // 寻找最高的柱子
            for (var i = 0; i < height.Length; ++i)
            {
                if (height[i] > max)
                {
                    max = height[i];
                    maxInx = i;
                }
            }

            // 从左侧往高柱子处取水
            var res = 0;
            for (var i = 0; i <= maxInx; ++i)
            {
                var tmp = 0;
                for (var j = i + 1; j <= maxInx; ++j)
                {
                    if (height[j] >= height[i])
                    {
                        res += tmp;
                        //取好水后应从当前最高处继续取水
                        i = j - 1;
                        break;
                    }
                    tmp += height[i] - height[j];
                }
            }

            // 从右侧往高柱子处取水
            for (var i = height.Length - 1; i >= maxInx; --i)
            {
                var tmp = 0;
                for (var j = i - 1; j >= maxInx; --j)
                {
                    if (height[j] >= height[i])
                    {
                        res += tmp;
                        //取好水后应从当前最高处继续取水
                        i = j + 1;
                        break;
                    }
                    tmp += height[i] - height[j];
                }
            }
            return res;
        }

        /// <summary>
        /// 全排列
        /// 给定一个 没有重复 数字的序列，返回其所有可能的全排列。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            var res = new List<List<int>>();
            res.Add(new List<int>(nums));

            // 计算下一个全排列数列
            void GetNextPermute(int[] nums)
            {
                var flg = false;
                // 从后往前遍历 寻找第一个打破单调增的数
                // 将单调增数列中最小的且大于当前数的数  与 其交换位置
                // 然后将其后数列逆序为单调减 即为下一个全排列数列
                // 若当前数列已经是最大的全排列数列 则整体逆序为解
                for (var i = nums.Length - 2; i >= 0; --i)
                {
                    if (nums[i] < nums[i + 1])
                    {
                        flg = true;
                        var inx = nums.Length - 1;
                        for (var j = i + 1; j < nums.Length; ++j)
                        {
                            if (nums[j] < nums[i])
                            {
                                inx = j - 1;
                                break;
                            }
                        }
                        var tmp = nums[i];
                        nums[i] = nums[inx];
                        nums[inx] = tmp;
                        if (i + 1 < nums.Length - 1)
                            Array.Reverse(nums, i + 1, nums.Length - i - 1);
                        break;
                    }
                }
                if (!flg)
                {
                    Array.Reverse(nums);
                }
            }
            // 计算阶乘
            int fun(int len)
            {
                if (len == 1) return 1;
                return len * fun(len - 1);
            }

            for (var i = 1; i < fun(nums.Length); ++i)
            {
                GetNextPermute(nums);
                res.Add(new List<int>(nums));
            }

            return res.ToArray();
        }

        /// <summary>
        /// 旋转图像
        /// 给定一个 n × n 的二维矩阵表示一个图像。
        /// 将图像顺时针旋转 90 度。
        /// 说明：
        /// 你必须在原地旋转图像，这意味着你需要直接修改输入的二维矩阵。请不要使用另一个矩阵来旋转图像。
        /// 来源：力扣（LeetCode）
        /// 链接：https://leetcode-cn.com/problems/rotate-image
        /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            var list = new List<List<int>>();
            for (var i = 0; i < matrix.Length; ++i)
            {
                list.Add(new List<int>());
                for (var j = matrix[i].Length - 1; j >= 0; --j)
                {
                    list[i].Add(matrix[j][i]);
                }
            }

            for (var i = 0; i < matrix.Length; ++i)
            {
                for (var j = 0; j < matrix.Length; ++j)
                {
                    matrix[i][j] = list[i][j];
                }
            }
        }

        /// <summary>
        /// 编辑距离
        /// 给你两个单词 word1 和 word2，请你计算出将 word1转换成 word2 所使用的最少操作数 。
        /// 你可以对一个单词进行如下三种操作：
        ///     1. 插入一个字符
        ///     2. 删除一个字符
        ///     3. 替换一个字符
        /// 来源：力扣（LeetCode）
        /// 链接：https://leetcode-cn.com/problems/edit-distance
        /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            // dp[i,j] => word1 前i位 转为 word2 前j位 需要的操作数
            // 初始化，默认前0为 转为 前 i 位 需要 i个操作
            //    dp[i,0] => { 0, 1, 2, 3 .. i}
            //    dp[0,j] => { 0, 1, 2, 3 .. j} 
            // 状态转移，
            //    dp[i,j] = min(dp[i-1,j-1],dp[i,j-1],dp[i-1,j]) + 1; (word1[i] == word2[j])
            //    dp[i,j] = dp[i-1,j-1];
            var dp = new int[word1.Length + 1, word2.Length + 1];
            for (var i = 0; i < word1.Length + 1; ++i)
                dp[i, 0] = i;
            for (var i = 0; i < word2.Length + 1; ++i)
                dp[0, i] = i;

            for (var i = 0; i < word2.Length; ++i)
            {
                for (var j = 0; j < word1.Length; ++j)
                {
                    if (word1[j] == word2[i])
                        dp[j + 1, i + 1] = dp[j, i];
                    else
                        dp[j + 1, i + 1] = Math.Min(Math.Min(dp[j, i], dp[j + 1, i]), dp[j, i + 1]) + 1;

                }
            }
            return dp[word1.Length, word2.Length];
        }

        /// <summary>
        /// 字母异位词分组  
        /// 给定一个字符串数组，将字母异位词组合在一起。字母异位词指字母相同，但排列不同的字符串。
        /// 说明：
        /// 所有输入均为小写字母。不考虑答案输出的顺序。
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dic = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                var tmp = str.ToCharArray();
                Array.Sort(tmp);
                var tmpStr = new string(tmp);
                if (!dic.TryGetValue(tmpStr, out var list))
                    dic.Add(tmpStr, new List<string>());
                dic[tmpStr].Add(str);
            }

            var res = new List<List<string>>();
            foreach (var (_, v) in dic)
            {
                res.Add(v);
            }

            return res.ToArray();
        }

        /// <summary>
        /// 最大子序和
        /// 给定一个整数数组 nums ，找到一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。
        /// 进阶:
        ///    如果你已经实现复杂度为 O(n) 的解法，尝试使用更为精妙的分治法求解。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length <= 0)
                return 0;

            var max = nums[0];
            var front = nums[0];
            for (var i = 1; i < nums.Length; ++i)
            {
                front = Math.Max(nums[i], front + nums[i]);
                max = Math.Max(max, front);
            }

            return max;
        }

        /// <summary>
        /// 跳跃游戏
        /// 给定一个非负整数数组，你最初位于数组的第一个位置。
        /// 数组中的每个元素代表你在该位置可以跳跃的最大长度。
        /// 判断你是否能够到达最后一个位置。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanJump(int[] nums)
        {
            if (nums.Length <= 0) return false;
            if (nums.Length == 1) return true;
            if (nums[0] == 0) return false;
            var flg = true;
            for (var i = nums.Length - 1 - 1; i >= 0; --i)
            {
                if (nums[i] != 0) continue;
                for (var j = i - 1; j >= 0; --j)
                {
                    if (nums[j] >= (i - j + 1))
                        break;
                    if (j == 0)
                        flg = false;
                }
                if (flg == false)
                    break;
            }
            return flg;
        }
    }
}
