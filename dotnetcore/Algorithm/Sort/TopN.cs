using System;
using System.Collections.Generic;

namespace Algorithm.Sort
{
    public class TopNElement
    {
        public int RankValue;
    }
    /// <summary>
    /// TopN问题在数据量非常大的情况下使用堆排序是最优的
    /// 因为在待排序的数据读完以前，只会调整堆顶结构，不会进行排序
    /// 在总数据量为 M 的情况下，
    /// 时间复杂度为 M * logN + (n-1) * logN
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TopN<T> where T : TopNElement
    {
        private int capacity;
        private List<T> topNRank;

        public List<T> TopNRank { get => topNRank; set => topNRank = value; }
        public int Capacity { get => capacity; set => capacity = value; }

        public TopN(int capacity)
        {
            this.capacity = capacity;
            topNRank = new List<T>(capacity);
        }
        /// <summary>
        /// 有新数据时只调整堆顶 不排序
        /// </summary>
        /// <param name="t"></param>
        public void Insert(T t)
        {
            if (t == null) return;
            if (topNRank.Count < capacity)
                topNRank.Add(t);
            else if (t.RankValue > topNRank[0].RankValue)
            {
                topNRank[0] = t;
            }
            Adjust(0, true);
        }
        public void Adjust(int l, bool isAll = true)
        {
            if (isAll) l = topNRank.Count - 1;
            for (var i = l / 2; i >= 0; --i)
            {
                var tmpL = i * 2 + 1;
                var tmpR = tmpL + 1;
                if (tmpR <= l)
                {
                    if (topNRank[tmpR].RankValue <= topNRank[tmpL].RankValue && topNRank[i].RankValue > topNRank[tmpR].RankValue)
                    {
                        var tmp = topNRank[i];
                        topNRank[i] = topNRank[tmpR];
                        topNRank[tmpR] = tmp;
                    }
                    else if (topNRank[tmpL].RankValue <= topNRank[tmpR].RankValue && topNRank[i].RankValue > topNRank[tmpL].RankValue)
                    {
                        var tmp = topNRank[i];
                        topNRank[i] = topNRank[tmpL];
                        topNRank[tmpL] = tmp;
                    }
                }
                else if (tmpL <= l)
                {
                    if (topNRank[i].RankValue > topNRank[tmpL].RankValue)
                    {
                        var tmp = topNRank[i];
                        topNRank[i] = topNRank[tmpL];
                        topNRank[tmpL] = tmp;
                    }
                }
            }

        }
        public void Sort()
        {
            for (var l = topNRank.Count - 1; l > 0; --l)
            {
                Adjust(l, false);
                var t = topNRank[l];
                topNRank[l] = topNRank[0];
                topNRank[0] = t;
            }
        }

        public void DebugWrite()
        {
            foreach (var t in topNRank)
            {
                Console.Write(t.RankValue + " ");
            }
            Console.WriteLine();
        }
    }
}
