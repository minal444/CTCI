using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

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
            bool b = IsPalindromePermutaion("Minal Patel");
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
    }
}
