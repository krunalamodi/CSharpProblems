using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    /*
        https://en.wikipedia.org/wiki/Boyer%E2%80%93Moore_majority_vote_algorithm
    
        Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.
        You may assume that the array is non-empty and the majority element always exist in the array.
    */
    public static int MajorityElement(int[] nums)
    {
        if (nums.Length == 0)
        {
            return -1;
        }

        int count = 0;
        int candidate = nums[0];
        foreach (int i in nums)
        {
            if (count == 0)
            {
                candidate = i;
                count++;
            }
            else if (candidate == i)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        int max = nums.Length / 2;
        if (count == 0)
        {
            return -1;
        }
        else if (count > max)
        {
            return candidate;
        }

        count = 0;
        foreach (int i in nums)
        {
            if (candidate == i)
            {
                count++;
            }
        }

        return (count > max) ? candidate : -1;
    }

    static void Main(string[] args)
    {
        var res = MajorityElement(new int[] { 2, 3, 2, 2, 1 });

        Console.WriteLine(res);
        Console.ReadLine();
    }
}