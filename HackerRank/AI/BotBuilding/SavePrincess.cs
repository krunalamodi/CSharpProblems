using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincess
{
    class Solution
    {
        public static void displayPathtoPrincess(int n, String[] grid)
        {
            int l = grid.Length;
            int pr, pc, br, bc;
            int found = 0;
            pr = pc = br = bc = 0;
            for (int i = 0; (i < l) && (found < 2); i++)
            {
                for (int j = 0; (j < l) && (found < 2); j++)
                {
                    if (grid[i][j] == 'p')
                    {
                        pr = i;
                        pc = j;
                        found++;
                    }
                    else if (grid[i][j] == 'm')
                    {
                        br = i;
                        bc = j;
                        found++;
                    }
                }
            }
            int d1 = pr - br;
            string str = "";
            if (d1 < 0)
            {
                str = "UP";
                d1 *= -1;
            }
            else if (d1 > 0)
            {
                str = "DOWN";
            }
            for (int i = 0; i < d1; i++)
            {
                Console.WriteLine(str);
            }
            d1 = pc - bc;
            if (d1 < 0)
            {
                str = "LEFT";
                d1 *= -1;
            }
            else if (d1 > 0)
            {
                str = "RIGHT";
            }
            for (int i = 0; i < d1; i++)
            {
                Console.WriteLine(str);
            }
        }
        public static void Main(String[] args)
        {
            int m;

            m = int.Parse(Console.ReadLine());

            String[] grid = new String[m];
            for (int i = 0; i < m; i++)
            {
                grid[i] = Console.ReadLine();
            }

            displayPathtoPrincess(m, grid);
            Console.ReadLine();
        }
    }
}