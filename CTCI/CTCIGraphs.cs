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

            int[][] arr = new int[3][]
            {
                new int[4] {1,0,0,1},
                new int[4] {1,1,0,1},
                new int[4] {0,0,1,0}
            };
            int ans = MaxIslandPerimeter(arr);

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

        public int MaxIslandPerimeter(int[][] grid)
        {
            int perimiter = 0;
            int n = grid.Length;
            int m = grid[0].Length;
            int maxPerimeter = Int32.MinValue;
           
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        //if (!IsInBoundry(i, j - 1, n, m, grid))
                        //    perimiter++;

                        //if (!IsInBoundry(i, j + 1, n, m, grid))
                        //    perimiter++;

                        //if (!IsInBoundry(i - 1, j, n, m, grid))
                        //    perimiter++;

                        //if (!IsInBoundry(i + 1, j, n, m, grid))
                        //    perimiter++;
                        perimiter = GetCurrentPerimeter(i, j, n, m, grid);
                        maxPerimeter = Math.Max(maxPerimeter, perimiter);
                    }
                }
            }

            return maxPerimeter;
        }
        private int GetCurrentPerimeter(int r, int c, int rows, int cols, int[][] grid)
        {
            int p = 0;
            if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r][c] != 1)
                return 0;

            //if (!IsInBoundry(r, c, rows, cols, grid))
            //    return 1;

            grid[r][c] = -1;

            if (!IsInBoundry(r, c - 1, rows, cols, grid))
                p++;

            if (!IsInBoundry(r, c + 1, rows, cols, grid))
                p++;

            if (!IsInBoundry(r - 1, c, rows, cols, grid))
                p++;

            if (!IsInBoundry(r + 1, c, rows, cols, grid))
                p++;

            p += GetCurrentPerimeter(r, c+1, rows, cols, grid);
            p += GetCurrentPerimeter(r, c-1, rows, cols, grid);
            p += GetCurrentPerimeter(r+1, c, rows, cols, grid);
            p += GetCurrentPerimeter(r-1, c, rows, cols, grid);
            grid[r][c] = 1;

            return p;
        }
        //private bool IsInBoundry(int r, int c, int rows, int cols, int[][] grid)
        //{
        //    if (r < 0 || r >= rows || c < 0 || c >= cols)
        //        return false;

        //    if (grid[r][c] == 0)
        //        return false;

        //    if (grid[r][c] == -1) return true;

        //    return true;
        //}

        private bool IsInBoundry(int r, int c, int rows, int cols, int[][] grid)
        {
            if (r < 0 || r >= rows || c < 0 || c >= cols)
                return false;

            if (grid[r][c] == 0)
                return false;

            return true;
        }


        public void FindWords(char[][] board, string[] words)
        {
            IList<string> res = new List<string>();

            for (int w = 0; w < words.Length; w++)
            {
                string ww = words[w];
                Console.WriteLine(ww);
                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board[0].Length; j++)
                    {
                        if (ww[0] == board[i][j])
                        {
                            Console.WriteLine(i); Console.WriteLine(j);

                            if (dfs(board, ww, 0, i, j))
                            {
                                Console.WriteLine(ww);
                                res.Add(ww);
                            }
                        }
                    }
                }
            }

           // return res;
        }

        private bool dfs(char[][] board, string word, int index, int r, int c)
        {
            if (word.Length <= index)
                return true;

            if (r < 0 || r > board.Length - 1 || c < 0 || c > board[0].Length - 1 || board[r][c] != word[index])
                return false;

            char ch = board[r][c];
            board[r][c] = '#';

            if (dfs(board, word, index + 1, r + 1, c))
                return true;

            if (dfs(board, word, index + 1, r - 1, c))
                return true;

            if (dfs(board, word, index + 1, r, c + 1))
                return true;

            if (dfs(board, word, index + 1, r, c - 1))
                return true;

            board[r][c] = ch;

            return false;
        }


    }
}
