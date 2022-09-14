using System;
using Algorithm.Sort;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var topN = new TopN<TopNElement>(10);
            topN.Insert(new TopNElement { RankValue = 1 });
            topN.Insert(new TopNElement { RankValue = 3 });
            topN.Insert(new TopNElement { RankValue = 5 });
            topN.Insert(new TopNElement { RankValue = 7 });
            topN.Insert(new TopNElement { RankValue = 9 });
            topN.Insert(new TopNElement { RankValue = 2 });
            topN.Insert(new TopNElement { RankValue = 4 });
            topN.Insert(new TopNElement { RankValue = 6 });
            topN.Insert(new TopNElement { RankValue = 8 });
            topN.Insert(new TopNElement { RankValue = 10 });
            topN.Insert(new TopNElement { RankValue = 10 });
            topN.Insert(new TopNElement { RankValue = 11 });
            topN.Insert(new TopNElement { RankValue = 1 });
            topN.Insert(new TopNElement { RankValue = 19 });
            topN.Insert(new TopNElement { RankValue = 4 });
            topN.Insert(new TopNElement { RankValue = 13 });
            topN.DebugWrite();
            topN.Sort();
            topN.DebugWrite();
        }
    }
}
