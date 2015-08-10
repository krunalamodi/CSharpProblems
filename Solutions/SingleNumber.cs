using System;

/*
Given an array of integers, every element appears twice except for one. Find that single one.

Note:
Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
*/
class SingleNumber
{
    // We can solve this problem using hashset as well. First time add element and on second encounter remove it.
    public static int SingleNumber(int[] nums)
    {
        int len = nums.Length;
        int ans = 0;
        for (int i = 0; i < len; i++)
        {
            ans = ans ^ nums[i];
        }

        return ans;
    }

    static void Main(string[] args)
    {
        int t = SingleNumber(new int[] { 1, 3, 4, 3, 1, 5, 6, 6, 4 });
        Console.WriteLine(t);
        Console.ReadLine();
    }
}