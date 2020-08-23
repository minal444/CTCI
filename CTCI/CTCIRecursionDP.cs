using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CTCI
{
    public class CTCIRecursionDP
    {
        public void AllRecursionDP()
        {
            //Default 
            int fib = Fib(4, "def");

            //1 Tripple Steps 
            //int way = CountWays(3);

            //2 Robot in Grid 
            List<Point> p = new List<Point>();
            //bool[][] b = new bool[3][];
            //b[0] = new bool[4];
            //b[1] = new bool[4];
            //b[2] = new bool[4];
            //b[0] = new bool[] { true, false, true, false };

            bool[][] arr = new bool[][]
            {
                new bool[] { true, true, false, true },
                new bool[] { true, false, true, true },
                new bool[] { true, true, true ,true }
            };
            p = FindPath(arr);

            // 3 Magic Index //To Execute
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

        private bool FindPath(bool[][] arr, int r , int c, HashSet<Point> failedPath, List<Point> path)
        {
            if(r >= arr.Length || c >= arr[0].Length || !arr[r][c])
            {
                return false;
            }

            Point p = new Point(r, c);

            if (failedPath.Contains(p))
                return false; 

            bool isDestination = (r == arr.Length-1 && c == arr[0].Length-1);

            if(isDestination || FindPath(arr, r+1, c, failedPath, path) || FindPath(arr, r, c+1, failedPath,  path))
            {
                path.Add(p);
                return true;
            }

            failedPath.Add(p);
            return false;

        }
    }


}
