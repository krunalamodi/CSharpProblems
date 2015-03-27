using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Solutions
{
    /*
        Write a function that takes a BST T and a key k, and returns the first entry larger than k that would appear
        in an inorder traversal. If k is absent or no key larger than k is present, return null.
    */
    public class BTree
    {
        public int data;
        public BTree left, right;
        public BTree(int d)
        {
            data = d;
        }
    }
    public class BST_Larger_than_K
    {
        public static BTree Find_Node_Larger_than_K(BTree root, int k)
        {
            BTree t = root;
            BTree res = null;
            bool isFound = false;

            while (t != null)
            {
                if (t.data == k)
                {
                    isFound = true;
                    t = t.right;
                }
                else if (t.data > k)
                {
                    res = t;
                    t = t.left;
                }
                else
                {
                    t = t.right;
                }
            }

            return isFound ? res : null;
        }

        public static void Larger_than_K_Helper()
        {
            /*
                    8
                  /   \
                 5     15
               /  \      \
              1    7      20

            */
            BTree root = new BTree(8);

            root.left = new BTree(5);
            root.left.left = new BTree(1);
            root.left.right = new BTree(7);

            root.right = new BTree(15);
            root.right.right = new BTree(20);

            Debug.Assert(Find_Node_Larger_than_K(root, 1).data == 5, "Node 5 comes after Node 1 ");
            Debug.Assert(Find_Node_Larger_than_K(root, 7).data == 8, "Node 8 comes after node 7");
            Debug.Assert(Find_Node_Larger_than_K(root, 9) == null, "Node 9 is not present in the BSTree. so we can't find any immediate inorder successor");
            Console.WriteLine("Done");
        }
    }
}