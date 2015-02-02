using System;

namespace Solutions
{
    public class TupleAverageCounting
    {
        public int findNumberOfSets(int n)
        {
            if (n < 3)
            {
                return 0;
            }

            if ((n & 1) == 1) // Odd
            {
                int en = n / 2;
                int e = (en) * (en - 1) / 2;
                int on = (n + 1) / 2;
                int o = (on) * (on - 1) / 2;

                return e + o;
            }
            else // Even
            {
                int en = n / 2;
                int e = (en) * (en - 1) / 2;
                return 2 * e;
            }
        }

        public static void HelperTupleAverage(int n)
        {
            TupleAverageCounting obj = new TupleAverageCounting();
            int res1 = obj.findNumberOfSets(n);
            int res2 = obj.findUsingIteration(n);

            if (res1 == res2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("PASS");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("FAILED !!");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" - For " + n + ": formula returned [" + res1 + "] and iterative moethod returned [" + res2 + "]");
        }
        public int findUsingIteration(int n)
        {
            int c = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    for (int k = 1; k <= n; k++)
                    {
                        if ((i == k) || (j == k))
                        {
                            continue;
                        }
                        if ((i + j) == (2 * k))
                        {
                            c++;
                        }
                    }
                }
            }

            return c;
        }
    }
}