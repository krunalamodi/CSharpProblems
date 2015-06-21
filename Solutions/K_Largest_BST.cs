using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions
{
    /*
        Find K largest elements from Binary search tree 
    */
    public class K_Largest_BST
    {
        public static void find_K_Largest_Elements_BST(BTree root, int k, int[] arr)
        {
            int n = find_K_Largest(root, k, arr, 0);
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.ReadLine();
        }

        public static int find_K_Largest(BTree root, int k, int[] arr, int indx)
        {
            if ((root != null) && (indx < k))
            {
                indx = find_K_Largest(root.right, k, arr, indx);
                if (indx < k)
                {
                    arr[indx] = root.data;
                    indx++;
                    indx = find_K_Largest(root.left, k, arr, indx);
                }
            }

            return indx;
        }

        static public void Find_K_Largest_in_BST_Test()
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

            int k = 4;
            int[] arr = new int[k];

            find_K_Largest_Elements_BST(root, k, arr);
        }
    }
}