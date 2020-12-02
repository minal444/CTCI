using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
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
            GetWinner(new int[] { 3, 2, 1 }, 10);
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
            if (hd < m)
                degree = md - hd;
            else
                degree = hd - md;

            if (degree > 180)
                degree = 360 - degree;
                   
            return degree;
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
    }
}
