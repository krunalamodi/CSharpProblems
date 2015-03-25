/*
You are climbing a stair case. It takes n steps to reach to the top.
Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top ?

Tags: Dynamic Programming
source: https://leetcode.com/problems/climbing-stairs/
*/

public class ClimbingStairs {
    public int ClimbStairs(int n) {
        if (n <= 2)
        {
            return n;
        }
        
        int prev1 = 2;
        int prev2 = 1;
        int ans = 0;
        for (int i=3 ; i<=n ; i++)
        {
            ans = prev1 + prev2;
            prev2 = prev1;
            prev1 = ans;
        }
        return ans;
    }
}