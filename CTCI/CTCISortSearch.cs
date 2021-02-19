using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCI
{
    public class CTCISortSearch
    {
        public void AllSortSearch()
        {
            //1 Sorted Merge --- TO Execute 

            //2 Grop Analgram --- TO Execute 

            //3 Search in rotated array --- TO Execute

            //4 Sorted Search -------TO Execute

            //Extra
            //Kth Largest element 
            //KthLargest obj = new KthLargest(3, new int[] { 4, 5, 8, 2 });
            //int param_1 = obj.Add(3);
            //param_1 = obj.Add(5);
            //param_1 = obj.Add(10);
            //param_1 = obj.Add(9);
            //param_1 = obj.Add(4);


            int[] index = FindLowerAndHigherIndex(new int[] { -1,0,5,5,5,5,17,20},20);

            //1760. Minimum Limit of Balls in a Bag
            int res = MinimumSize( new int[] {2, 4, 8, 2},4); //2 2 2 2 2 2 2 2

        }

        private int[] FindLowerAndHigherIndex(int[] arr, int target)
        { 
            int[] idx = new int[2];
            idx[0] = FindLowerAndHigherIndexHelper(arr,0, arr.Length-1, target,true);
            idx[1] = FindLowerAndHigherIndexHelper(arr, 0, arr.Length - 1, target,false);
            return idx;
        }
        private int FindLowerAndHigherIndexHelper(int[] arr, int start, int end,  int target,bool islower)
        {
            int idx;
            if (islower)
            {
                if (start > end && arr[start] == target) return start;
            }
            else if (islower == false)
            {
                if (start >= end && arr[end] == target) return end;
            }

            if (start > end) return -1;

            int mid = (start + end) / 2;

            if (islower)
            {
                if (arr[mid] >= target)
                    idx = FindLowerAndHigherIndexHelper(arr, start, mid - 1, target, islower);
                else
                    idx = FindLowerAndHigherIndexHelper(arr, mid + 1, end, target, islower);
            }
            else
            {
                if (arr[mid] <= target)
                    idx = FindLowerAndHigherIndexHelper(arr, mid + 1, end, target, islower); 
                else
                    idx = FindLowerAndHigherIndexHelper(arr, start, mid - 1, target, islower);
            }
            return idx;
        }

        public int MinimumSize(int[] nums, int maxOperations)
        {
            //find the theoretical min/max of penalty
            int max_penalty = 0;
            int sum = 0;
            for (int i =0;i <nums.Length; i++)
            {
                max_penalty = Math.Max(max_penalty, nums[i]); //max_penalty : max num // 8 
                sum += nums[i]; // 16 
            }
            //the max of bags is nums.Length() + maxOperations
            //the average of the ball is the theoretical min penalty
            int min_penalty = sum/(nums.Length + maxOperations); // 16 / 8 = 2 
            min_penalty = Math.Max(1, min_penalty); // in case of min_penalty is zero

            //binary search the real min penalty
            while (min_penalty < max_penalty) //2 // 16 
            {
                int mid = min_penalty + (max_penalty - min_penalty) / 2;

                //if the penalty is `mid`, then how many operation we need
                int ops = 0;
                for (int i =0; i <nums.Length; i++)
                {
                    if (nums[i] <= mid) continue; //no need seperation
                    ops += (nums[i] - 1) / mid;
                }

                //if the operation we need is beyoned the limitation, 
                //then we find in the large part, else find in the small part.
                if (ops > maxOperations)
                {
                    min_penalty = mid + 1;
                }
                else
                {
                    max_penalty = mid;
                }
            }
            return min_penalty;

        }

        public class KthLargest
        {

            /*
            int _k;
            List<int> numList;
            public KthLargest(int k, int[] nums) {
                _k = k;
                numList = new List<int>();
                for (int i =0 ; i <nums.Length; i++)
                {
                    numList.Add(nums[i]);
                }
            }

            public int Add(int val) {
                numList.Add(val);
                numList.Sort();
                return numList[numList.Count - _k ];
            }

            */

            private int kth;
            private SortedDictionary<int, int> minHeap;
            private int actualSize;

            public KthLargest(int k, int[] nums)
            {
                kth = k;
                minHeap = new SortedDictionary<int, int>();
                foreach (var n in nums)
                    Add(n);
            }

            public int Add(int num)
            {
                if (minHeap.ContainsKey(num))
                    minHeap[num]++;
                else
                    minHeap.Add(num, 1);
                actualSize++;

                if (actualSize > kth)
                {
                    var minKV = minHeap.First();
                    if (minKV.Value == 1)
                        minHeap.Remove(minKV.Key);
                    else
                        minHeap[minKV.Key]--;
                    actualSize--;
                }

                return minHeap.First().Key;
            }
        }
    }


}
