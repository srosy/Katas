using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class IsPefectBinaryTreeKata
    {
        //public static void Main(string[] args)
        //{
        //    var node = new TreeNode().WithLeaves();
        //    node.left.WithLeaves();
        //    node.left.left.WithLeftLeaf();
        //    var isPerfect = TreeNode.IsPerfect(node);
        //    Console.WriteLine(isPerfect); // false, height not matching

        //    //var node = new TreeNode().WithLeaves();
        //    //node.left.WithRightLeaf();
        //    //var isPerfect = TreeNode.IsPerfect(node);
        //    //Console.WriteLine(isPerfect); // false, imbalance of leaves

        //    //isPerfect = TreeNode.IsPerfect(new TreeNode());
        //    //Console.WriteLine(isPerfect); // true

        //    //isPerfect = TreeNode.IsPerfect(new TreeNode().WithLeaves());
        //    //Console.WriteLine(isPerfect); // true

        //    //isPerfect = TreeNode.IsPerfect(new TreeNode().WithLeftLeaf());
        //    //Console.WriteLine(isPerfect); // false

        //    //isPerfect = TreeNode.IsPerfect(new TreeNode().WithRightLeaf());
        //    //Console.WriteLine(isPerfect); // false

        //    Console.ReadLine();
        //}

        // A perfect binary tree is a binary tree in which all interior
        // nodes have two children and all leaves have the same depth/level/height.

        // a better way to do it...
        //public static bool IsPerfect(TreeNode root)
        //{
        //    IEnumerable<TreeNode> list = new List<TreeNode> { root };
        //    while (true)
        //    {
        //        if (list.All(n => n == null)) return true;
        //        if (list.Any(n => n == null)) return false;
        //        list = list.SelectMany(n => n.Children());
        //    }
        //}

        // or...
        //public static bool IsPerfect(TreeNode root)
        //{
        //    return (null == root) ||
        //      (Size(root.left) == Size(root.right)) &&
        //      IsPerfect(root.left) && IsPerfect(root.right);
        //}

        public class TreeNode
        {
            public TreeNode left;
            public TreeNode right;

            public static bool IsPerfect(TreeNode root, [Optional] int leftHeight, [Optional] int rightHeight)
            {
                if (root == null) return true;
                if (root.left == null && root.right == null)
                    return true;

                // check height
                if (GetHeight(root, leftHeight, true) != GetHeight(root, rightHeight, false))
                    return false;


                if (root.left == null && root.right != null ||
                    root.left != null && root.right == null)
                    return false;

                if (root.left != null)
                    return IsPerfect(root.left);

                if (root.right != null)
                    return IsPerfect(root.right); ;

                if (root.left != null && root.right != null)
                    return true;

                return false;
            }

            private static int GetHeight(TreeNode node, int height, bool left)
            {
                if (left)
                {
                    if (node.left != null)
                    {
                        return GetHeight(node.left, ++height, true);
                    }
                }
                else
                {
                    if (node.right != null)
                    {
                        return GetHeight(node.right, ++height, false);
                    }
                }
                return height;
            }

            public static bool IsBalanced(TreeNode node)
            {
                return node.right != null && node.left == null;
            }

            public static TreeNode Leaf()
            {
                return new TreeNode();
            }

            public static TreeNode Join(TreeNode left, TreeNode right)
            {
                return new TreeNode().WithChildren(left, right);
            }

            public TreeNode WithLeft(TreeNode left)
            {
                this.left = left;
                return this;
            }

            public TreeNode WithRight(TreeNode right)
            {
                this.right = right;
                return this;
            }

            public TreeNode WithChildren(TreeNode left, TreeNode right)
            {
                this.left = left;
                this.right = right;
                return this;
            }

            public TreeNode WithLeftLeaf()
            {
                return WithLeft(Leaf());
            }

            public TreeNode WithRightLeaf()
            {
                return WithRight(Leaf());
            }

            public TreeNode WithLeaves()
            {
                return WithChildren(Leaf(), Leaf());
            }
        }
    }
}
