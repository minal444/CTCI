using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace CTCI
{
    public class CTCIString
    {
        public void AllStrings()
        {
            //1 - Is Unique
            // bool isStrUnique =  IsUnique("minal patel ");
            // Console.WriteLine(isStrUnique);
            //Console.WriteLine(IsUniqueByBit("minal patel "));

            //2 IS Permutation
            //Console.WriteLine(IsPermutation("m in al", "ni m al"));
            //Console.WriteLine(IsPermutation2("M in al", "ni m al"));

            //3. URLify
            //URLify(new string[] { "M", "r", " ", "J", "o", "h", "n", " ", "S", "m", "i", "t", "h", " ", " ", " ", " " }, 13);

            //4. Pelidromic Permutation 
            //bool b = IsPalindromePermutaion("Minal Patel");

            //Geeks for geeks
            // List<string> dict = new List<string>();
            /*dict.Add("ale");
            dict.Add("apple");
            dict.Add("monkey");
            dict.Add("plea");
            string str = "abpcplea";*/
            //dict.Add("pintu");
            //dict.Add("geeksfor");
            //dict.Add("geeksgeeks");
            //dict.Add("forgeek");
            //string str = "geeksforgeeks";
            //string strdic = LargestWord(dict, str );

            //Find subarray with given sum
            //int[] arr = new int[] { 1, 4 };
            //int sum = 0;
            //SubArraySum(arr,sum);

            //Codility exam
            //int[] a = new int[] { 0,1,2,2,3,5};
            //int[] b = new int[] { 500000, 500000,0,0,0,20000};
            //int cnt = PossibleMultiplier(a,b);

            //FB exam
            //double degree = FindDegree(12, 0);

            //Leetcode
            //1640
            //CanFormArray(int[] arr, int[][] pieces);

            //Getwinner
            //GetWinner(new int[] { 3, 2, 1 }, 10);

            //Leet code 1638. Count Substrings That Differ by One Character
            //int ans = CountSubstrings("aba", "baba");


            //Leetcode Sliding Window //1658.Minimum Operations to Reduce X to Zero
            //int ans = MinOperations(new int[] { 1, 1, 4, 2, 3 }, 5);

            //int[] ans1  = minOperations("001011");

            //Print metrics
            //int[][]  arr;
            //arr = SpiralMatrixIII(1, 4, 0, 0);

            //1712.Ways to Split Array Into Three Subarrays
            int cnt = WaysToSplit(new int[6] { 1, 2, 2, 2, 5, 0 });

            cnt = FurthestBuilding(new int[9] { 4, 12, 2, 7, 3, 18, 20, 3, 19}, 10,2);

            string str = multiply("628","205");
        }
        //1
        //Questions:
        /*
        1. Can we assume the string only contains ASCII characters?
        2. Are the same lower and upper case consider unique ?

        //approach : 
        1. Brutforce compare each characters to each : O(n2)

        2. use hashtable and read each characters and keep adding those in hastable if the character is already exist then it not unique
        we can same thing with ASCII code with 128 character array.

        3. Bit manipulations
        */
        public bool IsUnique(string str)
        {
           
            //ASCII
            if (str.Length > 128) return false;

            bool[] char_set = new bool[128];
            for (int i=0; i < str.Length; i++)
            {
                int val = str[i];
                if(char_set[val])
                {
                    return false;
                }
                char_set[val] = true;
            }
            return true;

        }
        //BIT Manipulation
        // 1101 : 11010 
        public bool IsUniqueByBit(string str)
        {
            int checker = 0; 
            for (int i=0;i <str.Length; i++)
            {
                int val = str[i] - 'a';
                if((checker & (1 << val)) > 0)
                {
                    return false;
                }
                checker |= (1 << val);
            }

            return true;
        }

        //2. check permutation 
        /*
         * permutation is arrangement of string 
         * str1 : minalpatel str2: mnaliptela = true
         * str1 : minalpatel str2: mnali = false 
         * 
         * both the string has to be with the same length 
         * Is the permutation comparision is case sensitive 
         * For this we will consider comparision is case sensitive and space is significance - need toconsider space 
         * 
         *Approach :
         *1. sort both the string and compare both the string : O(n log n + n log n) . O(n) 
         *2. no of characters in one string should be same as no of characters in another one 
        */
        //1 with sort and compare 
        public bool IsPermutation(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            return sort(s1) == sort(s2);
            
        }

        public string sort(string s)
        {
            char[] c = s.ToCharArray();
            Array.Sort(c);
            return new String(c);
        }

        public bool IsPermutation2(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            int[] set = new int[128];

            for (int i=0; i<s1.Length; i++)
            {
                int val = s1[i];
                set[val]++;
            }

            for (int i =0; i < s2.Length; i++)
            {
                int val = s2[i];
                set[val]--;

                if (set[val] < 0)
                    return false;
            }
            return true;
        }

        //3 Input :   "Mr John Smith    ", 13
        //Output :  "Mr%20John%20Smith"

        /*        "Mr John Smith    "
         *        "Mr John     Smiht"
         */
        //Time : O(n) where n is the lenght of string/array, 
        //Space : O(1)
        public void URLify(string[] arr, int len)
        {
            
            int totalLen = arr.Length - 1;
            int currentIndex = len-1;
            while(totalLen>=0 && totalLen != currentIndex)
            {
                if(arr[currentIndex] != " ")
                {
                    arr[totalLen] = arr[currentIndex];
                    arr[currentIndex] = "";
                    currentIndex--;
                    totalLen--;
                }
                else
                {
                    arr[totalLen] = "0";
                    arr[totalLen-1] = "2";
                    arr[totalLen - 2] = "%";
                    totalLen = totalLen - 3;
                    currentIndex--;
                }
            }
            
            //Console.WriteLine(result);
        }

        //4 Palindrome Permutation
        //String - Tact Coa : True
        //String - Minal Patel : False 
        /*Pelindrom means the string should have all even characters, except only one odd characters
         * If that is the case then it can have palindrome permutaion
         * 
         */
        public String multiply(String num1, String num2)
        {
            int[] num = new int[num1.Length + num2.Length];
            int len1 = num1.Length, len2 = num2.Length;
            for (int i = len1 - 1; i >= 0; i--)
            {
                for (int j = len2 - 1; j >= 0; j--)
                {
                    int temp = (num1[i] - '0') * (num2[j] - '0');
                    num[i + j] += (temp + num[i + j + 1]) / 10;
                    num[i + j + 1] = (num[i + j + 1] + temp) % 10;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i =0;i<num.Length;i++) 
                if (sb.Length > 0 || num[i] > 0) sb.Append(num[i]);

            return (sb.Length == 0) ? "0" : sb.ToString();
        }
        public bool IsPalindromePermutaion(string str)
        {
            Hashtable ht = new Hashtable();
            int oddCounts = 0;
            str = str.ToLower();
            for (int i=0; i<str.Length; i++)
            {
                if (Char.IsLetter(str[i]))
                {
                    if (ht.Contains(str[i]))
                    {
                        ht[str[i]] = Convert.ToInt32(ht[str[i]]) + 1;
                    }
                    else
                    {
                        ht.Add(str[i], 1);
                    }

                    if (Convert.ToInt32(ht[str[i]]) % 2 != 0)
                    {
                        oddCounts++;
                    }
                    else
                    {
                        oddCounts--;
                    }
                }
            }
            return oddCounts <= 1;
        }

        //GeeksforGeeks
        public string LargestWord(List<string> dict,string str)
        {
            string result = "";
            int len = 0;
            foreach(string word in dict)
            {
                if(IsMatch(word,str) && len < word.Length)
                {
                    result = word;
                    len = word.Length;
                }
            }

            return result;
        }

        public bool IsMatch(string word, string str)
        {
            //bool isMatch;
            int strIdx = 0;
            int n = word.Length;
            string strNew = "";
            for(int i=0; i <n; i ++)
            {
                while(strIdx < str.Length)
                {
                    if (str[strIdx] == word[i])
                    {
                        strNew += str[strIdx];
                        strIdx++;
                        break;
                    }
                    else
                    {
                        strIdx++;
                    }
                }
            }

            return strNew == word;
            
           
        }

        public int PossibleMultiplier(int[] a, int[] b)
        {
            int count = 0;
            int n = a.Length;
            double million = 1000000.0;
            int billion = 1000000000;
            if (n == 1)
                return 0;

            double[] c = new double[n];

            for (int i =0; i < n; i++)
            {
                c[i] = a[i] + b[i] / million;
            }

            for (int p = 0; p<n-1; p++ )
            {
                for (int q = p+1; q< n; q++ )
                {
                    if(c[p] * c[q] >= c[p]+ c[q])
                    {
                        count++;
                    }
                }
            }

            if (count > billion)
                return billion;
            else
                return count;

        }

        public double FindDegree(int h, int m)
        {
            double degree;

            int md = m * 6;
            double hd = (h * 5 * 6) + (m * 0.5);
            if (hd < md)
                degree = md - hd;
            else
                degree = hd - md;

            //if (degree > 180)
            //    degree = 360 - degree;

            // return degree;

            if (Math.Abs(degree) > 180)
                degree = 360 - Math.Abs(degree);

            return Math.Abs(degree);

           
        }

        private void SubArraySum(int[] arr, int sum)
        {
            int left = 0;
            int right = 1;
            int newsum = arr[left];
            int n = arr.Length;

            
            while(left < n && right < n)
            {
                newsum += arr[right];
                if (newsum == sum)
                {
                    Console.WriteLine("Sum is between index " + left.ToString() + " and " + right.ToString());
                    break;
                }
                else if (newsum > sum)
                {
                    left++;
                    newsum = arr[left];
                    right = left + 1;
                }
                else
                    right++;

            }
            if (newsum != sum)
                Console.WriteLine("No sum found");


        }

        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            int len = arr.Length;
            int[] newArr = new int[len];

            //int p_len =0;
            Hashtable ht = new Hashtable();
            for (int i = 0; i < pieces.Length; i++)
            {
                if (!ht.Contains(pieces[i][0]))
                {
                    int[] subarr = new int[pieces[i].Length];
                    subarr = pieces[i];
                    ht.Add(pieces[i][0], subarr);
                }
            }

            // Console.WriteLine(p_len);
            int curr_idx = 0;
            while (curr_idx < len)
            {
                if (!ht.Contains(arr[curr_idx]))
                {
                    return false;
                }
                else
                {
                    int[] curr = (int[])ht[arr[curr_idx]];
                    Console.WriteLine(curr.Length);
                    for (int i = 0; i < curr.Length; i++)
                    {

                        newArr[curr_idx] = (int)curr[i];
                        if (newArr[curr_idx] != arr[curr_idx])
                            return false;
                        curr_idx++;
                    }
                }
            }



            return true;

        }
        //public int GetWinner(int[] arr, int k)
        //{
        //    /*
        //    int winner_counter = 0;
        //    int curr_winner = 0;
        //    loop through arr till winner count is K
        //    compare arr[0] with arr[1] 
        //    if arr[0] > arr[1]
        //        RorateArr(start from 1 to lenth)
        //    else 
        //        RorateArr(start from 0 to lenth)

        //    */
        //    int winner_counter = 0;
        //    int curr_winner = 0;

        //    while (winner_counter != k)
        //    {
        //        if (arr[0] > arr[1])
        //        {
        //            if (curr_winner == arr[0])
        //                winner_counter++;
        //            else
        //                winner_counter = 1;

        //            curr_winner = arr[0];
        //            arr = Rotate(arr, 1, arr.Length - 1);
        //        }
        //        else
        //        {
        //            if (curr_winner == arr[1])
        //                winner_counter++;
        //            else
        //                winner_counter = 1;

        //            curr_winner = arr[1];
        //            arr = Rotate(arr, 0, arr.Length - 1);
        //        }
        //    }


        //    return curr_winner;

        //}

        //private int[] Rotate(int[] arr, int start, int end)
        //{
        //    int[] arrnew = new int[arr.Length];
        //    int tmp = arr[start];
        //    for (int i = start; i < end; i++)
        //    {
        //        arrnew[i] = arr[i + 1];
        //    }

        //    arrnew[end] = tmp;
        //    return arrnew;
        //}

        public int GetWinner(int[] arr, int k)
        {
            int max = arr[0];
            int count = 0;
            int globalMax = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    count = 1;
                    max = arr[i];
                }
                else
                {
                    count++;
                }
                globalMax = Math.Max(globalMax, arr[i]);
                if (count == k)
                {
                    return max;
                }
            }
            return globalMax;
        }

        //
        public int CountSubstrings(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;

            int[][] diff = new int[n][];
            int[][] id = new int[n][];



            int total = 0;
            for (int i = 0; i < n; i++)
            {
                diff[i] = new int[m];
                diff[i][0] = s[i] == t[0] ? 0 : 1;
                id[i] = new int[m];
                id[i][0] = s[i] == t[0] ? 1 : 0;
                total += diff[i][0];
            }
            for (int j = 0; j < m; j++)
            {
                diff[0][j] = s[0] == t[j] ? 0 : 1;
                id[0][j] = s[0] == t[j] ? 1 : 0;
                total += diff[0][j];
            }
            total -= diff[0][0]; //double counted

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (s[i] == t[j])
                    {
                        diff[i][j] = diff[i - 1][j - 1];
                        id[i][j] = 1 + id[i - 1][j - 1];
                    }
                    else
                    {
                        diff[i][j] = 1 + id[i - 1][j - 1];
                        id[i][j] = 0;
                    }
                    total += diff[i][j];
                }
            }
            return total;
        }

        //1658. Minimum Operations to Reduce X to Zero
        public int MinOperations(int[] nums, int x)
        {
            int sum = 0;
            for(int i=0; i < nums.Length;   i++)
            {
                sum += nums[i];
            }
            sum -= x; // ****totalsum-target to find maxSubArray 
            int left = 0, right = 0, ans = -1;
            int subArraySum = 0;
            while (right < nums.Length)
            {
                subArraySum += nums[right];
                if (subArraySum > sum)
                {
                    while (subArraySum > sum && left <= right)
                    {
                        subArraySum -= nums[left++];
                    }
                }
                if (subArraySum == sum)
                {
                    ans = Math.Max(ans, right - left + 1);
                }
                right++;
            }
            return ans == -1 ? ans : nums.Length - ans;
        }


        //tesla first
        private int findMaxOperations(string s)
        {
            int returnResult = 0;
            int repeatCount = 1;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] != s[i + 1])
                {
                    repeatCount = 1;
                    continue;
                }
                else if (s[i] == s[i + 1])
                {
                    repeatCount += 1;
                }
                if (repeatCount == 3)
                {
                    returnResult += 1;
                    repeatCount = 0;
                    continue;
                }
            }

            return returnResult;
        }
        //tesla last 
        public int solution(string[] T, string[] R)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            //Get all the groups = test1 : 3 , test2 : 1, test 3 : 1
            Hashtable ht = new Hashtable();
            string grpName = "";
            bool IsPass;
            for (int i = 0; i < T.Length; i++)
            {
                grpName = GetGroupName(T[i]);

                if (ht.Contains(grpName))
                {
                    IsPass = (bool)ht[grpName];
                    if (IsPass != GetResultVal(R[i]))
                        ht[grpName] = false;

                }
                else
                {
                    ht.Add(grpName, GetResultVal(R[i]));
                }
            }
            int total = ht.Count;
            int passTotal = 0;
            //Get all results 
            foreach (var key in ht.Keys)
            {
                if ((bool)ht[key] == true)
                    passTotal++;
            }

            if (total > 0)
                return (int)(passTotal * 100) / total;
            return 0;

        }
        public string GetGroupName(string str)
        {
            //System.Text.RegularExpressions.Regex 
            return Regex.Match(str, @"\d+").Value;
        }

        public bool GetResultVal(string str)
        {
            if (str.ToLower() == "ok")
                return true;

            return false;
        }

        public int[] minOperations(String boxes)
        {
            int n = boxes.Length;
            char[] ch = boxes.ToCharArray();

            int[] left = new int[n];
            int count = ch[0] - '0';
            for (int i = 1; i < n; i++)
            {
                left[i] = left[i - 1] + count;
                count += ch[i] - '0';
            }

            int[] right = new int[n];
            count = ch[n - 1] - '0';
            for (int i = n - 2; i >= 0; i--)
            {
                right[i] = right[i + 1] + count;
                count += ch[i] - '0';
            }

            int[] answer = new int[n];
            for (int i = 0; i < n; i++)
            {
                answer[i] = left[i] + right[i];
            }

            return answer;
        }


        public int[][] SpiralMatrixIII(int R, int C, int r0, int c0)
        {
            int[][] res = new int[R * C][];
            int idx = 0;
            int noOfSteps = 1;
            int dir = 0;
            int steps = 0;
            res[idx++] = new int[2] { r0, c0 };
            //c0 = c0 + 1;
            //        while(r0 >=0 || r0 < R || c0 >=0 || c0 < C)
            while (idx < R * C)
            {
                steps = 0;
                if (dir == 0)
                {
                    //go till no of steps in direction right //if outside boudry do not do anything 
                    while (steps < noOfSteps)
                    {
                        c0 = c0 + 1;
                        //if (c0 + 1 < C && c0 + 1 >= 0 && r0 < R && r0 >= 0)
                        if (c0  < C && c0  >= 0 && r0 < R && r0 >= 0)
                        {
                            res[idx++] = new int[2] { r0, c0  };
                            //c0++;
                        }
                        steps++;
                    }
                    dir = 1;
                   //  r0++;
                }
                else if (dir == 1)
                {
                    //go till no of steps in direction bottom //if outside boudry do not do anything                             
                    while (steps < noOfSteps)
                    {
                        r0 = r0 + 1;
                        if (c0 < C && c0 >= 0 && r0  < R && r0   >= 0)
                        //if (c0 < C && c0 >= 0 && r0+1 < R && r0+1 >= 0)
                        {
                            res[idx++] = new int[2] { r0 , c0 };
                             //r0++;
                        }
                        //r0++;
                        steps++;
                    }
                    dir = 2;
                  //  c0--;
                    noOfSteps = noOfSteps + 1;
                }
                else if (dir == 2)
                {
                    //go till no of steps in direction left //if outside boudry do not do anything   
                    while (steps < noOfSteps)
                    {
                        c0 = c0 - 1;
                        if (c0  < C && c0   >= 0 && r0 < R && r0 >= 0)
                            //if (c0-1 < C && c0-1 >= 0 && r0 < R && r0 >= 0)
                        {
                            res[idx++] = new int[2] { r0, c0 };
                            //c0--;
                        }
                        //c0--;
                        steps++;
                    }
                    dir = 3;
                  // r0--;
                }
                else if (dir == 3)
                {
                    //go till no of steps in direction left //if outside boudry do not do anything   
                    while (steps < noOfSteps)
                    {
                        r0 = r0-1;
                        if (c0 < C && c0 >= 0 && r0  < R && r0  >= 0)
                            //if (c0 < C && c0 >= 0 && r0-1 < R && r0-1 >= 0)
                        {
                            res[idx++] = new int[2] { r0 , c0 };
                            //r0--;
                        }
                       // r0--;
                        steps++;
                    }
                    dir = 0;
                   //  c0++;
                    noOfSteps = noOfSteps + 1;
                }

            }

            

            return res;
        }


        public int WaysToSplit(int[] nums)
        {
            /*
            nums = [1,2,2,2,5,0]
            nums = [1,3,5,7,12,12]
            */
            int MOD = 1000000007;
            var len = nums.Length;
            for (int i = 1; i < len; i++)
            {
                nums[i] += nums[i - 1];
            }
            int l = 0, r = 0, cnt = 0;
            for (int i = 0; i < len; i++)
            {
                l = Math.Max(i + 1, l); //1 
                                        // 1< 6 && 3 - 1 < l 
                while (l < len && nums[l] - nums[i] < nums[i]) l++;

                r = Math.Max(l, r); // 1 
                                    //1 < 6 && 12 - 3 >= 3 - 1 
                while (r < len - 1 && nums[len - 1] - nums[r] >= nums[r] - nums[i]) r++;
                cnt += r - l;
                cnt %= MOD;
            }
            return cnt;
        }

        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            /*
            [4,12,2,7,3,18,20,3,19]
             4 12 2 7 3,18,20,3,
            bricks = 10 , 2 
            ladder = 2 , 1, 0 


            while idx < len && (bricks > 0 || ladder > 0)
            {

            }
            */
            int idx = 0;
            int len = heights.Length;
            while (idx < len && (bricks > 0 || ladders > 0))
            {
                if (heights[idx] < heights[idx + 1])
                {
                    //use either ladder or bricks
                    if (heights[idx + 1] - heights[idx] <= bricks)
                    {
                        bricks = bricks - (heights[idx + 1] - heights[idx]);
                        idx++;
                    }
                    else if (ladders > 0)
                    {
                        ladders--;
                        idx++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    idx++;
                }
            }

            return idx;
        }
    }
}
