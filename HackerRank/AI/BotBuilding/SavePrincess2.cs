using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincess2
{
    class Program
    {
        static void nextMove(int n, int br, int bc, String[] grid)
        {
            int l = grid.Length;
            int pr, pc;
            int found = 0;
            pr = pc = 0;
            for (int i = 0; (i < l) && (found < 1); i++)
            {
                for (int j = 0; (j < l) && (found < 1); j++)
                {
                    if (grid[i][j] == 'p')
                    {
                        pr = i;
                        pc = j;
                        found++;
                    }
                }
            }
            int d1 = pr - br;
            if (d1 < 0)
            {
                Console.WriteLine("UP");
                return;
            }
            else if (d1 > 0)
            {
                Console.WriteLine("DOWN");
                return;
            }

            d1 = pc - bc;
            if (d1 < 0)
            {
                Console.WriteLine("LEFT");
                return;
            }
            else if (d1 > 0)
            {
                Console.WriteLine("RIGHT");
                return;
            }
        }
        static void Main(String[] args)
        {
            int n;

            n = int.Parse(Console.ReadLine());
            String pos = Console.ReadLine();
            String[] position = pos.Split(' ');
            int[] int_pos = new int[2];
            int_pos[0] = Convert.ToInt32(position[0]);
            int_pos[1] = Convert.ToInt32(position[1]);
            String[] grid = new String[n];
            for (int i = 0; i < n; i++)
            {
                grid[i] = Console.ReadLine();
            }

            nextMove(n, int_pos[0], int_pos[1], grid);
        }
    }
}