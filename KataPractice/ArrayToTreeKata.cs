using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    public class ArrayToTreeKata
    {
        //public static void Main(string[] args)
        //{
        //    var tree = ArrayToTree(new int[] { 17, 0, -4, 3, 15 });
        //    Console.ReadLine();
        //}

        public static TreeNode ArrayToTree(int[] array)
        {
            var tree = new List<TreeNode>(); // binary tree

            array.ToList().ForEach(i =>
            {
                if (!tree.Any())
                {
                    var n = new TreeNode(i);
                    tree.Add(n);
                }
                else
                {
                    var emptyNode = tree.FirstOrDefault(n => n.left == null || n.right == null);
                    var nextNode = new TreeNode(i);

                    if (emptyNode.left == null)
                        emptyNode.left = nextNode;
                    else
                        emptyNode.right = nextNode;

                    tree.Add(nextNode);
                }
            });

            return tree.FirstOrDefault();
        }

#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        public class TreeNode
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        {
            public TreeNode left;
            public TreeNode right;
            public int value;

            public TreeNode(int value, TreeNode left, TreeNode right)
            {
                this.value = value;
                this.left = left;
                this.right = right;
            }

            public TreeNode(int value)
            {
                this.value = value;
            }

            public override bool Equals(Object other)
            {
                // Already implemented for you and used in test cases 
                return this.value > (int)other;
            }
        }
    }

    // a better way to do it, has dual ternary-operator
    //static class Solution
    //{
    //    public static TreeNode ArrayToTree(int[] array) =>
    //      array.Aggregate<int, TreeNode>(null, (root, a) => root.Add(a));

    //    static TreeNode Add(this TreeNode root, int a) =>
    //      root == null
    //        ? new TreeNode(a)
    //        : root.left.Depth() <= root.right.Depth()
    //          ? new TreeNode(root.value, root.left.Add(a), root.right)
    //          : new TreeNode(root.value, root.left, root.right.Add(a));

    //    static int Depth(this TreeNode root) =>
    //      root == null ? 0 : 1 + Math.Min(root.left.Depth(), root.right.Depth());
    //}
}
