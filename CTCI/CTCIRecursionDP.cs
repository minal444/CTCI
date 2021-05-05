using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CTCI
{
    public class CTCIRecursionDP
    {
        public void AllRecursionDP()
        {

            //Recursion
            //int[] result = new int[2 * 4 - 1];
            //result = ConstructDistancedSequence(4);

            //Default 
            // int fib = Fib(4, "def");

            //1 Tripple Steps 
            // int way = CountWays(3);

            //2 Robot in Grid 
            //  List<Point> p = new List<Point>();
            //bool[][] b = new bool[3][];
            //b[0] = new bool[4];
            //b[1] = new bool[4];
            //b[2] = new bool[4];
            //b[0] = new bool[] { true, false, true, false };

            //bool[][] arr = new bool[][]
            //{
            //    new bool[] { true, true, false, true },
            //    new bool[] { true, false, true, true },
            //    new bool[] { true, true, true ,true }
            //};
            // p = FindPath(arr);

            // 3 Magic Index //To Execute

            //4 Power Set 
            //List<List<int>> allsubset = new List<List<int>>();
            //List<int> set = new List<int>();
            //set.Add(1);
            //set.Add(2);
            //set.Add(3);
            //allsubset = PowerSet(set,0);

            //7 Permutation of unique string 
            //ArrayList a = new ArrayList();
            //a = Permutation("abc");

            //Find Subarray String
            //List<List<Char>> allset = new List<List<Char>>();
            //allset = FindPowerSetString("abc",0);

            ////GreeksforGeeks
            ////Generate the Possible binary string based on Pattern
            ////string str = "1??01";
            //string str = "1??0?101";
            //char[] strArr = str.ToCharArray();
            //GenerateBinaryString(strArr,0);

            ////C# program to count number of strings  
            //// of n characters with a,b, c and b =1 at most and c=2 atmost
            //int n = 3;
            //int cnt = CountofString(n,1,2);
            //Console.WriteLine(cnt);

            //Extra 
            ////Knapsack
            //int[] v = new int[] { 60, 100, 120};
            //int[] w = new int[] {10, 20,30};
            //int capacity = 25;
            //int[][] tmp = new int[v.Length-1][];
            //int maxVal = GetMaxValue(v, w, capacity, v.Length-1, tmp);


            //// 967.Numbers With Same Consecutive Differences
            //int[] ans = NumsSameConsecDiff(3, 4);


            //LetterCombinations("23");


        //    IList<IList<int>> set = PermuteNumArr(new int[3] { 1, 2, 3 });


            //Generate Paranthesis 
            List<string> res = new List<string>();
            res = GenerateParanthesis(res, 3);
        }

        private List<string> GenerateParanthesis(List<string> res,int n)
        {
            char[] str = new char[n * 2];
            GenerateParanthesisHelper(res, n, n, 0, str);
            return res;
        }

        private void GenerateParanthesisHelper(List<string> res, int leftRem, int rightRem, int idx, char[] str)
        {
            if (leftRem < 0 || leftRem > rightRem) return;
            if(leftRem ==0 && rightRem ==0)
            {
                res.Add(String.Concat(str));
            }
            else
            {
                str[idx] = '(';
                GenerateParanthesisHelper(res, leftRem - 1, rightRem, idx+1, str);

                str[idx] = ')';
                GenerateParanthesisHelper(res, leftRem , rightRem-1, idx + 1, str);
            }
            
        }

        public int[] ConstructDistancedSequence(int n)
        {
            int[] result = new int[2 * n - 1];
            bool[] visited = new bool[n + 1];
            helper(0, result, visited, n);
            return result;
        }

        private bool helper(int currentIndex, int[] result, bool[] visited, int n)
        {
            if (currentIndex == result.Length)
            {
                return true;
            }

            if (result[currentIndex] != 0)
            {
                return helper(currentIndex + 1, result, visited, n);
            }

            for (int nextValue = n; nextValue > 0; nextValue--)
            {
                if (visited[nextValue])
                {
                    continue;
                }

                visited[nextValue] = true;
                result[currentIndex] = nextValue;

                if (nextValue == 1)
                {
                    if (helper(currentIndex + 1, result, visited, n))
                    {
                        return true;
                    }
                }

                else if (currentIndex + nextValue < result.Length && result[currentIndex + nextValue] == 0)
                {
                    result[currentIndex + nextValue] = nextValue;

                    if (helper(currentIndex + 1, result, visited, n))
                    {
                        return true;
                    }

                    result[currentIndex + nextValue] = 0;
                }

                visited[nextValue] = false;
                result[currentIndex] = 0;
            }

            return false;
        }

        public int Fib(int i, string src)
        {
            if (i == 0) return 0;
            if (i == 1) return 1;
            return Fib(i - 1, "first") + Fib(i - 2, "second");
        }

        //1. CountWays 
        public int CountWays(int n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;
            return CountWays(n - 1) + CountWays(n - 2) + CountWays(n - 3);
        }

        //2 Robot in Grid
        /*
         * 1 1 0 1
         * 1 0 1 1
         * 1 1 1 1
         * 
         * r = 0     
         *     1
         *     2
         *     3
         * c = 0
         *     0 
         *     0
         *     0
         * p = 0,0    
         *     1,0   
         *     2,0
         * path  = 
         * failedpath = 
         */
        public List<Point> FindPath(bool[][] arr)
        {
            List<Point> path = new List<Point>();
            HashSet<Point> failedPath = new HashSet<Point>();
            FindPath(arr, 0, 0, failedPath, path);
            return path;
        }

        private bool FindPath(bool[][] arr, int r, int c, HashSet<Point> failedPath, List<Point> path)
        {
            if (r >= arr.Length || c >= arr[0].Length || !arr[r][c])
            {
                return false;
            }

            Point p = new Point(r, c);

            if (failedPath.Contains(p))
                return false;

            bool isDestination = (r == arr.Length - 1 && c == arr[0].Length - 1);

            if (isDestination || FindPath(arr, r + 1, c, failedPath, path) || FindPath(arr, r, c + 1, failedPath, path))
            {
                path.Add(p);
                return true;
            }

            failedPath.Add(p);
            return false;

        }

        private List<List<int>> PowerSet(List<int> set, int index)
        {
            List<List<int>> allsubset;

            if (set.Count == index)
            {
                allsubset = new List<List<int>>();
                allsubset.Add(new List<int>());
            }
            else
            {
                allsubset = PowerSet(set, index + 1);
                int item = set[index];
                List<List<int>> moresubset = new List<List<int>>();
                foreach (List<int> subset in allsubset)
                {
                    List<int> newSubset = new List<int>();
                    newSubset.AddRange(subset);
                    newSubset.Add(item);
                    moresubset.Add(newSubset);
                }
                allsubset.AddRange(moresubset);
            }

            return allsubset;
        }

        private ArrayList Permutation(string str)
        {
            if (str == null) return null;

            ArrayList permutations = new ArrayList();
            if (str.Length == 0)
            {
                permutations.Add("");
                return permutations;
            }

            char first = str[0];//get first character
            string remainer = str.Substring(1); //remove first character
            ArrayList words = Permutation(remainer);

            foreach (string word in words)
            {
                for (int j = 0; j <= word.Length; j++)
                {
                    string s = InsertAtChar(word, first, j);
                    permutations.Add(s);
                }

            }

            return permutations;

        }

        public IList<IList<int>> PermuteNumArr(int[] nums)
        {
            /*
            1,2,3

            21, 12
            321,231, 231, 312,132,123
            */
            IList<IList<int>> list = new List<IList<int>>();
            helper(-1, nums, new List<int>(), list);
            return list;

        }


        private void helper(int idx, int[] nums, List<int> curr, IList<IList<int>> ans)
        {

            if (curr.Count == nums.Length)
            {
                ans.Add(new List<int>(curr));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (i != idx && !curr.Contains(nums[i]))
                {
                    curr.Add(nums[i]);
                    helper(i, nums, curr, ans);
                    curr.RemoveAt(curr.Count - 1);
                }
            }

        }

        private string InsertAtChar(string word, char c, int index)
        {
            string start = word.Substring(0, index);
            string end = word.Substring(index);
            return start + c + end;
        }

        private void GenerateBinaryString(char[] str, int idx)
        {
            if (str.Length == idx)
            {
                Console.WriteLine(str);
                return;
            }

            if (str[idx] == '?')
            {
                str[idx] = '0';
                GenerateBinaryString(str, idx + 1);

                str[idx] = '1';
                GenerateBinaryString(str, idx + 1);

                str[idx] = '?';
            }
            else
            {
                GenerateBinaryString(str, idx + 1);
            }

        }


        private int CountofString(int n, int bCount, int cCount)
        {
            int[,,] dp = new int[n + 1, bCount + 1, cCount + 1];

            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        dp[i, j, k] = -1;
                    }
                }
            }
            return CountofStringUtil(dp, n, bCount, cCount);
        }

        private int CountofStringUtil(int[,,] dp, int n, int bCount, int cCount)
        {

            if (bCount < 0 || cCount < 0) return 0;
            if (n == 0) return 1;
            if (bCount == 0 && cCount == 0) return 1;

            if (dp[n, bCount, cCount] != -1)
                return dp[n, bCount, cCount];

            int res = CountofStringUtil(dp, n - 1, bCount, cCount);
            res += CountofStringUtil(dp, n - 1, bCount - 1, cCount);
            res += CountofStringUtil(dp, n - 1, bCount, cCount - 1);
            dp[n, bCount, cCount] = res;
            return res;
        }

        private List<List<char>> FindPowerSetString(string str, int idx)
        {
            List<List<char>> allset;
            if (str.Length == idx)
            {
                allset = new List<List<char>>();
                allset.Add(new List<char>());
            }
            else
            {
                allset = FindPowerSetString(str, idx + 1);
                char item = str[idx];
                List<List<char>> moreset = new List<List<char>>();
                foreach (List<char> lst in allset)
                {
                    List<char> newset = new List<char>();
                    newset.AddRange(lst);
                    newset.Add(item);
                    moreset.Add(newset);
                }
                allset.AddRange(moreset);
            }

            return allset;
        }

        private int GetMaxValue(int[] v, int[] w, int capacity, int n, int[][] tmp)
        {
            int result;
            if (tmp[n][capacity] != 0) return tmp[n][capacity];
            if (n == 0 || capacity == 0)
                return 0;
            else if (w[n] > capacity)
                result = GetMaxValue(v, w, capacity, n - 1, tmp);
            else
            {
                result = Math.Max(v[n] + GetMaxValue(v, w, capacity - w[n], n - 1, tmp), GetMaxValue(v, w, capacity, n - 1, tmp));
            }
            tmp[n][capacity] = result;
            return result;
        }

        public int[] NumsSameConsecDiff(int n, int k)
        {

            int[] digits = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            if (n == 1)
            {
                return digits;
            }

            List<int> result = new List<int>();

            for (int i = 1; i < digits.Length; i++)
            {
                getNums(digits[i], digits, n - 1, k, result);
            }

            return result.ToArray();


        }

        private void getNums(int currentResult, int[] digits, int N, int k, List<int> result)
        {
            if (N == 0)
            {
                result.Add(currentResult);
                return;
            }

            int lastDigit = currentResult % 10;
            for (int i = 0; i < digits.Length; i++)
            {
                if (Math.Abs(digits[i] - lastDigit) == k)
                {
                    getNums(currentResult * 10 + digits[i], digits, N - 1, k, result);
                }
            }
        }

        private Dictionary<int, string> map = new Dictionary<int, string>();
        private List<string> res = new List<string>();
        public IList<string> LetterCombinations(string digits)
        {
            /*
            string[] map = 0   1  2    3     4    5    6    7    8      9 
                                  abc  def   ghi  jkl  mno  pqrs tuv    wxyz

            23

            ad
            ae
            af


            */

            map.Add(2, "abc");
            map.Add(3, "def");
            map.Add(4, "ghi");
            map.Add(5, "jkl");
            map.Add(6, "mno");
            map.Add(7, "pqrs");
            map.Add(8, "tuv");
            map.Add(9, "wxyz");
            StringBuilder sb = new StringBuilder();
            helper(digits, 0, sb);
            return res;
        }

        private void helper(string digits, int idx, StringBuilder sb)
        {
            if (sb.Length == digits.Length)
            {

                res.Add(sb.ToString());
                return;
            }

            int item = (int)Char.GetNumericValue(digits[idx]);

            string str = map[item];
            for (int i = 0; i < str.Length; i++)
            {
                sb.Append(str[i]);
                helper(digits, idx + 1, sb);
                sb.Remove(sb.Length - 1, 1);
            }

        }

    }


}
