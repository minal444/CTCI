using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI
{
    class CTCIGraphs 
    {
        public void AllGraphs()
        {
            //1 Find the Route between node

            //Extra - Island
            //int[][] arr = new int[3][];
            //arr[0] = new int[4] {1,0,0,1};
            //arr[1] = new int[4] {1,1,0,1};
            //arr[2] = new int[4] {0,0,1,0};

            int[][] arr = new int[][]
            {
                new int[] {1,0,0,1},
                new int[] {1,1,1,1},
                new int[] { 0, 0, 1, 0 }
            };
            int count = FindNoofIsland(arr);
        }

        //public IsPath()
        //{

        //}

        private int FindNoofIsland(int[][] arr)
        {
            int count = 0;
            for (int i =0; i < arr.Length; i++)
            {
                for (int j =0; j < arr[0].Length; j++)
                {
                    if(arr[i][j] == 1)
                    {
                        count++;
                        FindNoofIsland(arr, i, j);
                    }
                }
            }

            return count;
            
        }

        private void FindNoofIsland(int[][] arr, int row, int col)
        {
            if ((row > arr.Length-1 || row < 0 || col > arr[0].Length-1 || col<0 ) || arr[row][col] != 1)
                return;

            arr[row][col] = 0;
            FindNoofIsland(arr, row,col-1);
            FindNoofIsland(arr, row,col+1);
            FindNoofIsland(arr, row-1,col);
            FindNoofIsland(arr, row+1, col);
        }


    }
}
