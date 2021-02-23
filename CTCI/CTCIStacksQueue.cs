using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;

namespace CTCI
{
    class CTCIStacksQueue
    {
        //1 TO DO

        //2. return stack min 

        //3. Stack of Plates

        //4. Quequ with Stacks

        //5 sort the stack

        //LeetCode
        //1544 - make good string
        //GoodString("LeEeetCode");
        //1249
        //MinRemoveToMakeValid("ac(f)c)ds");


        //
        public void AllStack()
        {
            //
            string ans = RemoveDuplicates("deeedbbcccbdaa", 3);
        }

        public string MakeGood(string s)
        {

            int len = s.Length;
            Stack<char> stk = new Stack<char>();
            stk.Push(s[0]);
            string goodString = s[0].ToString();
            int i = 1;

            while (i < len)
            {
                if (stk.Count > 0 && Char.ToUpper(s[i]) == Char.ToUpper(stk.Peek()) && (char)stk.Peek() != s[i])
                {
                    while (i < len && stk.Count > 0 && Char.ToUpper(s[i]) == Char.ToUpper(stk.Peek()) && (char)stk.Peek() != s[i])
                    {
                        char remov = stk.Pop();
                        //if(goodString.Length>1)
                        goodString = goodString.Substring(0, goodString.Length - 1);
                        i++;
                    }
                }
                else
                {
                    stk.Push(s[i]);
                    goodString += s[i].ToString();
                    i++;
                }
            }


            return goodString;
        }

        public string MinRemoveToMakeValid(string s)
        {
            StringBuilder sb = new StringBuilder();
            Stack<int> stk = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                Char c = s[i];
                if (c == '(' || c == ')')
                {
                    if (stk.Count > 0 && c == ')' && s[stk.Peek()] == '(')
                        stk.Pop();
                    else
                        stk.Push(i);
                }
            }

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (stk.Count > 0 && i == stk.Peek())
                    stk.Pop();
                else
                    sb.Append(s[i]);
                //sb.Insert(0,s[i]);
            }
            StringBuilder result = new StringBuilder();
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                result.Append(sb[i]);
            }

            return result.ToString();

        }
        //1209. Remove All Adjacent Duplicates in String II
        public string RemoveDuplicates(string s, int k)
        {
             
            int len = s.Length;

            if (len <= 1) return s;
            if (k < 2) return "";
            if (len < k) return s;

            Stack<char> charStack = new Stack<char>();
            Stack<int> counterStack = new Stack<int>();

            for (int i = 0; i < len; i++)
            {
                if (charStack.Count == 0)
                {
                    charStack.Push(s[i]);
                    counterStack.Push(1);
                }
                else
                {
                    Char top = charStack.Peek();
                    int topCounter = counterStack.Peek();
                    if (top == s[i] && topCounter + 1 == k)
                    {
                        while (topCounter != 0)
                        {
                            charStack.Pop();
                            counterStack.Pop();
                            topCounter--;
                        }
                    }
                    else
                    {
                        charStack.Push(s[i]);
                        if(top == s[i])
                            counterStack.Push(topCounter + 1);
                        else
                            counterStack.Push(1);
                    }
                }

            }

            StringBuilder sb = new StringBuilder();
            int count = charStack.Count;
            for (int i = 0; i < count; i++)
            {
                sb.Insert(0, charStack.Pop());
            }

            return sb.ToString();
        }
    }

    //2 Stack returns min element. Pop, push and min should be O(1)
    /* 
     * push (6)   : stack is (6) min 6
     * push (5)   : stack is (5, 6) min 5
     * push (9)   : stack is (9, 5, 6) min 5
     * push (1)   : stack is (1, 9, 5, 6) min 1
     * pop()      : stack is (9, 5, 6) min 5
     * 
  
     //approach 
     1. keep one min variable minStackVal. problem here is when min variable is poped we need to revisit stack to find minStackVal
     2. keep second stack just to store min values. if the pop happend then get the min value. This is more space efficient in terms of 
    if there first element which is min and stack is very large
    */
    
    public class StackWithMinVal : Stack<int>
    {
        Stack<int> minS;
        public StackWithMinVal()
        {
            minS = new Stack<int>();    
        }

        public void push(int val)
        {
            if(val < min())
            {
                minS.Push(val);
            }

            base.Push(val);
        }

        public int pop()
        {
            if(base.Peek() == min())
            {
                minS.Pop();
            }
            return base.Pop();
        }

        public int min()
        {
            if(minS.Count ==0)
            {
                return int.MaxValue;
            }
            else
            {
                return Convert.ToInt32(minS.Peek());
            }
        }
    }
    //3 implementation of the set od stacks and maintain the capacity
    public class SetofStacks
    {
        List<Stack> stacks = new List<Stack>();
        public int capacity;
        public SetofStacks(int capacity)
        {
            this.capacity = capacity;
        }

        public void Push(int val)
        {
            Stack s = GetLastStack();
            if(s != null && s.Count < capacity )
            {
                s.Push(val);
            }
            else
            {
                Stack sNew = new Stack(capacity);
                sNew.Push(val);
                stacks.Add(sNew);
            }
        }
        public int Pop()
        {
            Stack s = GetLastStack();
            if(s == null)
            {
                throw new Exception();
            }

            int val =Convert.ToInt32(s.Pop());
            if(s.Count ==0)
            {
                stacks.RemoveAt(stacks.Count - 1);
            }

            return val;
        }

        public Stack GetLastStack()
        {
            if (stacks.Count == 0) return null;
            return stacks[stacks.Count - 1];
        }

    }



    //4. Queues Via Stack
    //Space Complexity : O(1)
    //Time Complexity : O(1)
    public class QueueWithStack<T>
    {
        Stack<T> pushStack, popStack;

        public QueueWithStack()
        {
            pushStack = new Stack<T>();
            popStack = new Stack<T>();
        }

        public int Size()
        {
            return pushStack.Count + popStack.Count;
        }

        //Enqueue Method
        public void Enqueue(T val)
        {
            pushStack.Push(val);
        }
        //Dequeue Method
        public T Dequeue()
        {
            if (Size()==0)
            {
                throw new Exception("Queue is empty");
            }
            shiftStack();
            return popStack.Pop();
        }

        //Peek Method
        public T Peek()
        {
            if (Size() == 0)
            {
                throw new Exception("Queue is empty");
            }
            shiftStack();
            return popStack.Peek();
        }


        private void shiftStack()
        {
            if (popStack.Count ==0)
            {
                while (pushStack.Count != 0)
                {
                    popStack.Push(pushStack.Pop());
                }
            }
        }





    }



}
