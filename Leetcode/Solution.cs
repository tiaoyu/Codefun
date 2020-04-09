using System;
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

    }
}
