/*
There are n integers a1, a2, ..., an. Each of those integers can be either 0 or 1. We are allowed to do exactly one move: We must choose two indices i and j (1 <= i <= j <= n) and flip all values ak for which their positions are in range [i, j] (that is i <= k <= j). Flip the value of x means to apply operation x = 1 - x.

The goal is - After exactly one move to obtain the maximum number of ones. 

Input:-

The first line of the input contains an integer n (1 <= n <= 10^6). In the second line of the input there are n integers: a1, a2, ..., an. It is guaranteed that each of those n values is either 0 or 1

Output:-
Print an integer - the maximal number of 1s that can be obtained after exactly one move.

Sample test(s)
input
5
1 0 0 1 0
output
4

input
4
1 0 0 1
output
4

Note:-
In the first case, flip the segment from 2 to 5 (i=2, j=5). That flip changes the sequence, it becomes: [1 1 1 0 1]. So, it contains four ones. There is no way to make the whole sequence equal to [1 1 1 1 1].

In the second case, flipping only the second and the third element (i=2, j=3) will turn all numbers into 1.


Source: http://codeforces.ru/problemset/problem/327/A
*/

using System;

namespace FlippingGame327A
{
    class Program
    {
        int kkMax(int a, int b)
        {
            return (a < b) ? b : a;
        }

        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int n = Convert.ToInt32(str);
            str = Console.ReadLine();
            string[] strArray = str.Split(' ');
            int[] input = new int[n + 3];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                input[i] = Convert.ToInt32(strArray[i]);
                if (input[i] == 1)
                {
                    sum++;
                }
            }

            // main logic
            // O(n) solution... it is a version of 'maximum subarray problem' which can be solved using Kadane's Algorithm
            int ans = (input[0] == 1) ? -1 : 1;
            int ends = ans;
            for (int i = 1; i < n; i++)
            {
                int temp = 1;
                if (input[i] == 1)
                {
                    temp = -1;
                }

                ends = kkMax(temp, ends + temp);
                ans = kkMax(ans, ends);
            }
            Console.WriteLine(sum + ans);
            Console.ReadLine();

            /*
			// O(n^2) solution
            int[,] res = new int[n, n];
            int ans = Int32.MinValue;
            for (int i = 0; i < n; i++)
            {
                int zeros = 0;
                for (int j = i; j < n; j++)
                {
                    if (input[j] == 0)
                    {
                        zeros++;
                        res[i, j] = zeros;
                    }
                    int temp = sum - (j - i + 1 - res[i, j]) + res[i, j];
                    ans = (temp > ans) ? temp : ans;
                }
            }
            Console.WriteLine(ans);
            Console.ReadLine();
            */
        }
    }
}