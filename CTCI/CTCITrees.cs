using System;
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
            TreeNode root = new TreeNode();
            root.val = 20;
            root.left = new TreeNode();
            root.left.val = 10;
            root.right = new TreeNode();
            root.right.val = 30;
            root.right.right = new TreeNode();
            root.right.right.val = 45;

            root.right.right.left = new TreeNode();
            root.right.right.left.val = 15;

            //   bool bal = IsBalanced(root);

            //5 Valid BST
            bool _isValidBST = IsValidBST(root);

            //6 Sucessor -- TO Execute
            TreeNode node = new TreeNode();
            TreeNode n = Sucessor(node);

            //7 Build Order -- TO Execute
            //8 First Common Ancesstor-- TO Execute
            //9 BST Sequence -- TO Execute
            //Extra 
            //Level Order Traversal 
            LevelOrderTravesal(root);

            //Extra 
            //DFS - Pre Order
            //Console.WriteLine("Pre Order");
            //PreOrder(root);
            //Console.WriteLine("Post Order");
            //PostOrder(root);
            //Console.WriteLine("In Order");
            //InOrder(root);

            //Level order Traversal
            Console.WriteLine("Leverl order traversal");
            LevelOrder(root);
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
    }

}
