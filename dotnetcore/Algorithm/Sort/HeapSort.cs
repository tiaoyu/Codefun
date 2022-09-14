using System;
namespace Algorithm.Sort
{
    /// <summary>
    /// 二叉数组 每个子节点下标为父节点的2倍加1和2
    /// :  leftChirldInx  = fatherInx * 2 + 1
    ///    rightChirldInx = fatherInx * 2 + 2
    /// </summary>
    public class HeapSort
    {
        public void Sort(int[] arr)
        {
            for (var l = arr.Length - 1; l > 0; --l)
            {
                for (var i = l / 2; i >= 0; --i)
                {
                    var tmpL = i * 2 + 1;
                    var tmpR = tmpL + 1;
                    if (tmpR <= l)
                    {
                        if (arr[tmpR] >= arr[tmpL] && arr[i] < arr[tmpR])
                        {
                            var tmp = arr[i];
                            arr[i] = arr[tmpR];
                            arr[tmpR] = tmp;
                        }
                        else if (arr[tmpL] >= arr[tmpR] && arr[i] < arr[tmpL])
                        {
                            var tmp = arr[i];
                            arr[i] = arr[tmpL];
                            arr[tmpL] = tmp;
                        }
                    }
                    else if (tmpL <= l)
                    {
                        if (arr[i] < arr[tmpL])
                        {
                            var tmp = arr[i];
                            arr[i] = arr[tmpL];
                            arr[tmpL] = tmp;
                        }
                    }
                }
                var t = arr[l];
                arr[l] = arr[0];
                arr[0] = t;
            }
        }
    }
}
