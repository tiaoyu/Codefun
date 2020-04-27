using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public class Solution
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

        #region leetcode 第 185 场周赛
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

        public int MaxScore_5393(int[] cardPoints, int k)
        {
            int calc(int[] cardPoints, int l, int r, int index, int k)
            {
                if (k == 1) return cardPoints[index];

                var lc = Math.Max(calc(cardPoints, l + 1, r, l + 1, k - 1), calc(cardPoints, l + 1, r, r, k - 1));
                var rc = Math.Max(calc(cardPoints, l, r - 1, r - 1, k - 1), calc(cardPoints, l, r - 1, l, k - 1));

                return Math.Max(lc + cardPoints[index], rc + cardPoints[index]);
            }
            var l = 0;
            var r = cardPoints.Length - 1;
            var ans = Math.Max(calc(cardPoints, l, r, l, k), calc(cardPoints, l, r, r, k));
            return ans;
        }

        public int[] FindDiagonalOrder_5394(IList<IList<int>> nums)
        {
            var ans = new List<int>();

            var inxArr = new List<int>();
            var inx = new List<int>();
            var dset = new HashSet<int>();
            var maxCol = 0;
            for(var i = 0; i < nums.Count; ++i)
            {
                maxCol = Math.Max(maxCol, nums[i].Count);
                if (inxArr.Count < nums.Count) { inxArr.Add(i);inx.Add(-1); }

                for (var j = inxArr.Count - 1; j >= 0; --j)
                {
                    if(inx[j] < nums[inxArr[j]].Count - 1)
                    {
                        ans.Add(nums[inxArr[j]][++inx[j]]);
                    }
                    else
                    {
                        dset.Add(inxArr[j]);
                    }
                }
                foreach (var x in dset)
                    inxArr.Remove(x);
                dset.Clear();
            }
           
            return ans.ToArray();
        }
        #endregion
    }
}
