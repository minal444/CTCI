using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI
{
    public class BackTracking
    {

        public void AllBackTracking()
        {
            IList<string> res = new List<string>();
            res = RemoveInvalidParentheses("()())()");

            res = new List<string>();
            res = PossibleString("123");
        }
        public IList<string> RemoveInvalidParentheses(string s)
        {
            this.reset();
            this.recurse(s, 0, 0, 0, new StringBuilder(), 0);
            return new List<string>(this.validExpressions);
        }

        private HashSet<String> validExpressions = new HashSet<String>();
        private int minimumRemoved;

        private void reset()
        {
            validExpressions.Clear();
            minimumRemoved = Int32.MaxValue;
        }

        private void recurse(
            String s,
            int index,
            int leftCount,
            int rightCount,
            StringBuilder expression,
            int removedCount)
        {

            // If we have reached the end of string.
            if (index == s.Length)
            {

                // If the current expression is valid.
                if (leftCount == rightCount)
                {

                    // If the current count of removed parentheses is <= the current minimum count
                    if (removedCount <= this.minimumRemoved)
                    {

                        // Convert StringBuilder to a String. This is an expensive operation.
                        // So we only perform this when needed.
                        String possibleAnswer = expression.ToString();

                        // If the current count beats the overall minimum we have till now
                        if (removedCount < this.minimumRemoved)
                        {
                            this.validExpressions.Clear();
                            this.minimumRemoved = removedCount;
                        }
                        this.validExpressions.Add(possibleAnswer);
                    }
                }
            }
            else
            {

                Char currentCharacter = s[index];
                int length = expression.Length;

                // If the current character is neither an opening bracket nor a closing one,
                // simply recurse further by adding it to the expression StringBuilder
                if (currentCharacter != '(' && currentCharacter != ')')
                {
                    expression.Append(currentCharacter);
                    this.recurse(s, index + 1, leftCount, rightCount, expression, removedCount);
                    expression.Remove(length, 1);
                }
                else
                {

                    // Recursion where we delete the current character and move forward
                    this.recurse(s, index + 1, leftCount, rightCount, expression, removedCount + 1);
                    expression.Append(currentCharacter);

                    // If it's an opening parenthesis, consider it and recurse
                    if (currentCharacter == '(')
                    {
                        this.recurse(s, index + 1, leftCount + 1, rightCount, expression, removedCount);
                    }
                    else if (rightCount < leftCount)
                    {
                        // For a closing parenthesis, only recurse if right < left
                        this.recurse(s, index + 1, leftCount, rightCount + 1, expression, removedCount);
                    }

                    // Undoing the append operation for other recursions.
                    expression.Remove(length, 1);
                }
            }
        }



        private  List<string> PossibleString(string str)
        {
            List<string> res = new List<string>();
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            map.Add("1", new List<string> { "A", "B", "C" });
            map.Add("2", new List<string> { "D", "E", "F" });
            map.Add("23", new List<string> { "H", "I", "J" });
            map.Add("123", new List<string> { "K", "L", "M" });
            int len = str.Length;

            for(int i=0; i <len; i++)
            {
                List<string> subset = new List<string>();
                for (int j=i;j<len; j++)
                {
                    string curr = str.Substring(i, j - i + 1);

                    if(map.ContainsKey(curr))
                    {
                        foreach(var item in map[curr])
                        {
                            subset.Add(item);
                        }
                    }

                    /*
                     A
                     B
                     C
                                          
                     */
                }


            }

            return res;
        }
    }







}
