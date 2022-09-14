using System;
namespace Algorithm.Sort
{
    /// <summary>
    /// 快排 
    /// </summary>
    public class QuickSort
    {
        void Sort(int[] arr, int l, int r)
        {
            if (l >= r) return;
            var low = l;
            var high = r;
            var tmpK = arr[l];
            r++;
            while (l < r)
            {
                while (l < r)
                    if (arr[--r] < tmpK)
                        break;
                arr[l] = arr[r];
                while (l < r)
                    if (arr[++l] > tmpK)
                        break;
                arr[r] = arr[l];
            }
            arr[l] = tmpK;
            Sort(arr, low, l - 1);
            Sort(arr, l + 1, high);
        }
    }
}
