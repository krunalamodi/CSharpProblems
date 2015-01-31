using System;
using System.Collections.Generic;

namespace Solutions
{
    public class NumbersSumToValueQuora
    {
        List<List<int>> findSetOfNumbers(List<int> numberList, int value)
        {
            return myHelper(numberList, value, new LinkedList<int>(), new List<List<int>>());
        }

        List<List<int>> myHelper(List<int> numberList, int remaining, LinkedList<int> currSet, List<List<int>> result)
        {
            if (remaining == 0)
            {
                result.Add(new List<int>(currSet));
                return result;
            }
            for (int i = 0; i < numberList.Count; i++)
            {
                int temp = numberList[i];
                int nVal = remaining - temp;
                if (nVal >= 0)
                {
                    numberList.RemoveAt(i);
                    currSet.AddLast(temp);

                    myHelper(numberList, remaining - temp, currSet, result);

                    currSet.RemoveLast();
                    numberList.Insert(i, temp);
                }
            }
            return result;
        }
        public static void HelperNumbersSumToValueQuora()
        {
            NumbersSumToValueQuora obj = new NumbersSumToValueQuora();

            List<List<int>> ans = obj.findSetOfNumbers(new List<int> { 1, 2, 3, 4, 5 }, 4);
            foreach (var slist in ans)
            {
                Console.WriteLine("{" + String.Join(", ", slist.ToArray()) + "}");
            }
        }
    }
}