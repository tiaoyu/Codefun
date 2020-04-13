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
    }
}
