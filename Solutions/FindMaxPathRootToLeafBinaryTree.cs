using System;
using System.Collections.Generic;

/*
 Given a tree, find the maximum path from root to leaf. Also, print the traversal information.
 */
class BTree
{
    public int data;
    public BTree left, right;
    public int maxPath;
    public LinkedList<string> maxPathDetail;
    public BTree(int d)
    {
        data = d;
        left = right = null;
    }
    public void maxPathHelper(BTree root, int maxLocal, LinkedList<string> maxDetailsLocal)
    {
        if ((root.left == null) && (root.right == null))
        {
            if (maxPath < maxLocal)
            {
                maxPath = maxLocal;
                maxPathDetail = new LinkedList<string>(maxDetailsLocal);
            }
            return;
        }
        if (root.left != null)
        {
            maxDetailsLocal.AddLast("left");
            maxPathHelper(root.left, maxLocal + (root.left.data), maxDetailsLocal);
            maxDetailsLocal.RemoveLast();
        }
        if (root.right != null)
        {
            maxDetailsLocal.AddLast("right");
            maxPathHelper(root.right, maxLocal + (root.right.data), maxDetailsLocal);
            maxDetailsLocal.RemoveLast();
        }
    }
    public void getMaximumPath()
    {
        maxPath = Int32.MinValue;
        maxPathHelper(this, this.data, new LinkedList<string>());
        Console.WriteLine("maximum Path:" + maxPath);
        foreach (string s in maxPathDetail)
        {
            Console.Write(s + "->");
        }
        Console.WriteLine();
        Console.ReadLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        /****************
        Input:
             5
          /    \
         8     7
        / \   /  \
       1   2 4    3

       Output:

        maximum Path:16
        right->left->

         ***************/
        BTree root = new BTree(5);

        root.left = new BTree(8);
        root.left.left = new BTree(1);
        root.left.right = new BTree(2);

        root.right = new BTree(7);
        root.right.left = new BTree(4);
        root.right.right = new BTree(3);

        root.getMaximumPath();
    }
}