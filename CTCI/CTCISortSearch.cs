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
