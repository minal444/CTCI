using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CTCI
{
    public class CTCITrees
    {
        
        public void AllTree()
        {
            //2 Minimal Tree
            createMinimumBST(new int[] { 2, 5, 7, 9, 11, 18, 20, 25, 70 });

            //3 List of Depth
            //NodesByDepth()

            //4 Check Balanced
            //TreeNode root = new TreeNode();
            //root.val = 20;
            //root.left = new TreeNode();
            //root.left.val = 10;
            //root.right = new TreeNode();
            //root.right.val = 30;
            //root.right.right = new TreeNode();
            //root.right.right.val = 45;

            //root.right.right.left = new TreeNode();
            //root.right.right.left.val = 15;

            ////   bool bal = IsBalanced(root);

            ////5 Valid BST
            //bool _isValidBST = IsValidBST(root);

            ////6 Sucessor -- TO Execute
            //TreeNode node = new TreeNode();
            //TreeNode n = Sucessor(node);

            //7 Build Order -- TO Execute
            //8 First Common Ancesstor-- TO Execute
            //9 BST Sequence -- TO Execute
            //Extra 
            //Level Order Traversal 
            //LevelOrderTravesal(root);

            //Extra 
            //DFS - Pre Order
            //Console.WriteLine("Pre Order");
            //PreOrder(root);
            //Console.WriteLine("Post Order");
            //PostOrder(root);
            //Console.WriteLine("In Order");
            //InOrder(root);

            //Level order Traversal
            //Console.WriteLine("Leverl order traversal");
            //LevelOrder(root);


            //Pelindrom
            TreeNode root = new TreeNode();
            root = new TreeNode();
            root.val = 2;
            root.left = new TreeNode();
            root.left.val = 3;
            root.left.left = new TreeNode();
            root.left.left.val = 3;
            root.left.right = new TreeNode();
            root.left.right.val = 1;

            root.right = new TreeNode();
            root.right.val = 1;
            root.right.right = new TreeNode();
            root.right.right.val = 1;
            PseudoPalindromicPaths(root);


            //1443. Minimum Time to Collect All Apples in a Tree
            int[][] arr = new int[6][];
            arr[0] = new int[2] {0, 1};
            arr[1] = new int[2] { 0,2};
            arr[2] = new int[2] {1,4 };
            arr[3] = new int[2] { 1,5};
            arr[4] = new int[2] { 2,3}; 
            arr[5] = new int[2] { 2,6};

            List<bool> lst = new List<bool>();
            lst.Add(false);
            lst.Add(false);
            lst.Add(true);
            lst.Add(false);
            lst.Add(true);
            lst.Add(true);
            lst.Add(false);
            int count = minTime(7,arr, lst);
        }
        //2 Minimal Tree
        //Input [2,5,7,9,11,18,20,25,70]
        //Output 
        /*
                         11
                    7          25
                5       9   18     70
             3                  20

        */
        public class TreeNode
        {
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
            public TreeNode parent { get; set; }
            public int val { get; set; }
        }
        //Time: O(n)
        //Space: O(n)
        public void createMinimumBST(int [] arr)
        {
            TreeNode bst = new TreeNode();
            bst  = createMinimumBST(arr, 0, arr.Length-1);
            
        }

        private TreeNode createMinimumBST(int[] arr, int start, int end)
        {
            if (start > end) return null;

            int mid = (start + end) / 2;
            TreeNode n = new TreeNode();
            n.val = arr[mid];

            n.left = createMinimumBST(arr, start, mid-1);
            n.right = createMinimumBST(arr, mid+1, end);
            return n;
        }

        //Linklist of all numbers in the same depth
        public List<LinkedList<TreeNode>> NodesByDepth(TreeNode root)
        {
            List<LinkedList<TreeNode>> result = new List<LinkedList<TreeNode>>();
            if (root == null) return null;
            LinkedList<TreeNode> current = new LinkedList<TreeNode>();
            current.AddFirst(root);

            while (current.Count > 0)
            {
                result.Add(current);
                LinkedList<TreeNode> parent = current;
                current = new LinkedList<TreeNode>();
                foreach (TreeNode c in parent)
                {

                    if (c.left != null)
                    {
                        if (current.Count == 0)
                            current.AddFirst(c.left);
                        else
                            current.AddLast(c.left);
                    }
                    if (c.right != null)
                    {
                        if (current.Count == 0)
                            current.AddFirst(c.right);
                        else
                            current.AddLast(c.right);
                    }
                }
            }

            return result;

        }

        //4 
        /*
         * 
         * */
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            return checkHeight(root) != int.MinValue;
        }

        private int checkHeight(TreeNode root)
        {
            if (root == null) return -1;

            int leftHeight = checkHeight(root.left);
            if (leftHeight == int.MinValue) return int.MinValue;

            int rightHeight = checkHeight(root.right);
            if (rightHeight == int.MinValue) return int.MinValue;

            int hightDiff = leftHeight - rightHeight;

            if (Math.Abs(hightDiff)>1)
            {
                return int.MinValue;
            }
            else
            {
                int h = Math.Max(leftHeight, rightHeight) + 1;
                return h;
            }

        }
        /* Do Inorder tranversal and check if the last value is less than the current value as Valid BST has In-order traversal always sorted
         * 
         */
        Int32? previousVal;
        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;

            if (!IsValidBST(root.left)) return false;

            //check for left
            if (previousVal != null && root.val <= previousVal)
                return false;

            previousVal = root.val;

            //check for right
            if (!IsValidBST(root.right)) return false;

            return true; 
        }

        /*
         * If the tree has right subtree then return right most node
         */
        public TreeNode Sucessor(TreeNode node)
        {
            if (node == null) return null;
            
            if (node.right != null)
            {
                return   getLeftMost(node.right);
            }
            else
            {
                TreeNode n = node;
                TreeNode p = node.parent;
                while (p != null && p.left !=n)
                {
                    n = p;
                    p = p.parent;
                }
                return p;
            }
        }

        private TreeNode getLeftMost(TreeNode n)
        {
            if (n == null) return null;

            while (n.left != null)
            {
                n = n.left;
            }

            return n;
        }

        private void LevelOrderTravesal(TreeNode root)
        {
            //BST
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                TreeNode n = q.Dequeue();
                Console.WriteLine(n.val);
                if (n.left != null)
                    q.Enqueue(n.left);

                if (n.right != null)
                    q.Enqueue(n.right);

            }
        }

        //public class TreeNodeO
        //{
        //    public TreeNodeO left;
        //    public TreeNodeO right;
        //    public int val;
        //    public TreeNodeO(int val, TreeNodeO left = null, TreeNodeO right =null)
        //    {
        //        this.val = val;
        //        this.left = left;
        //        this.right = right;
        //    }
        //}

        public void PreOrder(TreeNode root)
        {
            if (root == null) return;
            Console.WriteLine(root.val);
            PreOrder(root.left);
            PreOrder(root.right);
        }

        public void PostOrder(TreeNode root)
        {
            if (root == null) return;
            PostOrder(root.left);
            PostOrder(root.right);
            Console.WriteLine(root.val);
        }

        public void InOrder(TreeNode root)
        {
            if (root == null) return;
            InOrder(root.left);
            Console.WriteLine(root.val);
            InOrder(root.right);
        }

        public void LevelOrder(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                TreeNode node = q.Dequeue();
                Console.WriteLine(node.val);
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
        }


        int count = 0;
        public int PseudoPalindromicPaths(TreeNode root)
        {
            /*
                find path from root to leaf node
                    --iterate till left and right node is null
                    --if hashtable has value and its 1 then add else not add 


                DFS Pre traversal
                keep trake of the counts in hashtable 
                    if exist then remove else add 

                1. 233 ==> check if permutation is pelindrom increment counter 
                2. 231 ==> check if permutation is pelindrom increment counter 
                3. 211 ==> check if permutation is pelindrom increment counter 

                //PermutationPelindrom 
                1. even 
                    all the numbner shoud have even counts
                2. odd
                    there should be only one letter with one (odd) count
                    if more than one letter has one (odd) count then its not palindrom   
            */
            Hashtable ht = new Hashtable();
            if (root == null)
                return 1;
            if (root.left == null && root.right == null)
                return 1;
            DFS(root, ht, false);
            return count;
        }

        public void DFS(TreeNode node, Hashtable ht, bool IsLeafNode)
        {
            if (ht.Contains(node.val))
            {
                ht.Remove(node.val);
                /*ht[node.val] = (int) ht[node.val] - 1;
                if((int)ht[node.val]==0)
                {
                    ht.Remove(node.val);
                }*/
            }
            else
            {
                ht.Add(node.val, 1); //2   
            }

            //if(node.left == null && node.right == null)
            if (IsLeafNode)
            {
                //check for pelindrom permutation  
                if (ht.Count == 1)
                {
                    foreach (var key in ht.Keys)
                    {
                        if ((int)ht[key] == 1)
                            count++;   //1 
                    }
                }
                else if (ht.Count == 0)
                {
                    count++;
                }

                return;
            }

          
            if (node.left != null)
                DFS(node.left, ht, node.left.left == null && node.left.right == null ? true : false);
            if (node.right != null)
                DFS(node.right, ht, node.right.left == null && node.right.right == null ? true : false);

        }

        public int minTime(int n, int[][] edges, List<Boolean> hasApple)
        {
            List<int>[] arr = new List<int>[n];
            foreach(var edge in edges)
            {
                int i = edge[0], j = edge[1];
                if (arr[i] == null) arr[i] = new List<int>();
                arr[i].Add(j);
                if (arr[j] == null) arr[j] = new List<int>();
                arr[j].Add(i);
            }
            var visited = new bool[n];
            return dfs(0, arr, hasApple, visited);
        }

        private int dfs(int val, List<int>[] arr, List<Boolean> flags, bool[] visited)
        {
            visited[val] = true;
            var sum = 0;
            foreach(var c in arr[val])
            {
                if (visited[c]) continue;
                var cnt = dfs(c, arr, flags, visited);
                sum += cnt;
                if (cnt > 0 || flags[c]) sum += 2;
            }
            return sum;
        }
    }

}
