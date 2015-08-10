using System;
using System.Collections.Generic;
using System.Linq;


/*
Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.

For example,
Given the following matrix:

[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]

You should return [1,2,3,6,9,8,7,4,5].
*/
public class SpiralMatrix
{
    public static IList<int> SpiralOrder(int[,] matrix)
    {
        IList<int> ans = new List<int>();
        int rs, re, cs, ce;
        rs = cs = 0;
        re = matrix.GetLength(0) - 1;
        ce = matrix.GetLength(1) - 1;
        int turn = 0;
        while ((rs <= re) && (cs <= ce))
        {
            if (turn == 0)
            {
                // column - left to right
                for (int i = cs; i <= ce; i++)
                {
                    ans.Add(matrix[rs, i]);
                }
                rs++;
            }

            if (turn == 1)
            {
                // row - top to bottom
                for (int i = rs; i <= re; i++)
                {
                    ans.Add(matrix[i, ce]);
                }
                ce--;
            }

            if (turn == 2)
            {
                // column - right to left
                for (int i = ce; i >= cs; i--)
                {
                    ans.Add(matrix[re, i]);
                }
                re--;
            }

            if (turn == 3)
            {
                // row - bottom to top
                for (int i = re; i >= rs; i--)
                {
                    ans.Add(matrix[i, cs]);
                }
                cs++;
            }
            turn = (turn + 1) % 4;
        }
        return ans;
    }
    static void Main(string[] args)
    {
        IList<int> ans = SpiralOrder(new int[,] { 
                                                        { 2, 3 }
                                                    });
        /*
        IList<int> ans = SpiralOrder(new int[,] {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9}
            });
        */
        Console.WriteLine(string.Join(",", ans.ToArray()));
        Console.ReadLine();
    }
}