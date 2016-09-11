using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    /*
        Given an array of size n, find the majority element.
        The majority element is the element that appears more than ⌊ n/2 ⌋ times.
        You may assume that the array is non-empty and the majority element always exist in the array.
    */
    public static int findMajority(int[] nums, int s, int e)
    {
        if (s > e)
        {
            return -1;
        }
        else if (s == e)
        {
            return nums[s];
        }

        int mid = s + (e - s) / 2;

        int l = findMajority(nums, s, mid);
        int r = findMajority(nums, mid + 1, e);

        /*
            Left, Right
            (1)  -1, -1 (not found; return immediately)
            (2)   a, -1 (confirm if a is >n/2 by iterating full array)
            (3)   a,  b (confirm if a or b is >n/2)
            (4)  -1,  a (confirm if a is >n/2 by iterating full array)
            (5)   a,  a (found; return immediately; >n/4 and >n/4 -  >n/2)
        */
        if (l == r)
        {
            // case 1 and 5
            return l;
        }
        else if (l != -1 && checkMajority(nums, l, s, e))
        {
            // case 2 and 3
            return l;
        }
        else if (r != -1 && checkMajority(nums, r, s, e))
        {
            // case 4 and 3
            return r;
        }
        else
        {
            return -1;
        }
    }

    static bool checkMajority(int[] nums, int val, int s, int e)
    {
        int count = 0;
        for (int i = s; i <= e; i++)
        {
            if (nums[i] == val)
            {
                count++;
            }
        }

        return (count > (e - s + 1) / 2) ? true : false;
    }

    public static int MajorityElement_DivideConquer(int[] nums)
    {
        if (nums.Length == 0)
        {
            return -1;
        }

        return findMajority(nums, 0, nums.Length - 1);
    }

    static void Main(string[] args)
    {
        //var res = MajorityElement_DivideConquer(new int[] { 2, 3, 2, 2, 1 });

        var res = MajorityElement_DivideConquer(new int[] { 1, 2, 2, 1, 2 });

        Console.WriteLine(res);
        Console.ReadLine();
    }
}