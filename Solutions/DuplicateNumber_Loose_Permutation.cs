using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Find a duplicated number in a loose permutation of numbers.  A permutation is an array that is size N, and also has positive numbers from 1 thru N.  A loose permutation is a permutation where some numbers are missing and some are duplicated, but the total number is still N.

* We want to find any one duplicated number; not necessarily the first or the least.

* It can occur anywhere in the input array, and we don't care how many times it's duplicated.

* Input array may nor may not be sorted.

* You can only use constant extra memory.

* There is no limit/constraint on N i.e it is a normal 4-byte integer.

e.g.

Input: 1,7,4,3,2,7,4: This array has 7 numbers from 1 thru 7, with some missing (5 and 6) and some duplicated (4 and 7). Albeit unsorted, but sorting is irrelevant to a permutation.

Output: 4 or 7

Input: 3,1,2:  This array has nothing missing.

Output: -1

Solution: Aim for constant memory and linear run time. Think bucket sort.

Solution: https://soham.box.com/s/wte4tqbjbfocnhy76teobzki7sxi5lq8
*/
class Program
{
    static void swap(int[] arr, int a, int b)
    {
        int t = arr[a];
        arr[a] = arr[b];
        arr[b] = t;
    }

    static int findDuplicateFromPermutation(int[] arr)
    {
        int n = arr.Length;
        int i = 0;

        while (i < n)
        {
            int indexFromOne = i + 1;

            // if value is not at correct position, then place it at right place
            if (arr[i] != indexFromOne)
            {
                // If correct value is already present at that location, report duplicate.
                if (arr[arr[i] - 1] == arr[i])
                {
                    return arr[i];
                }

                // place it at correct place and use swapped value as current one.
                swap(arr, i, arr[i] - 1);
            }

            // if value is already at right place, move to next index
            if (arr[i] == indexFromOne)
            {
                i++;
            }
        }

        return -1;
    }

    static void Main(string[] args)
    {
        var res = findDuplicateFromPermutation(new int[] { 1, 7, 4, 3, 2, 7, 4 });

        Console.WriteLine(res);
        Console.ReadLine();
    }
}
