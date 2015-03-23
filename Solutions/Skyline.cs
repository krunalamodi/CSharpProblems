using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline
{
    class Program
    {
        public class Skyline
        {
            public int s, e, h;
            public Skyline(int start, int end, int height)
            {
                s = start;
                e = end;
                h = height;
            }
        }

        public class Ref
        {
            public int value;
            public Ref(int t)
            {
                value = t;
            }
        }

        static List<Skyline> drawSkyline(List<Skyline> arr, int s, int e)
        {
            if (s == e)
            {
                return new List<Skyline> { arr[s] };
            }

            int mid = s + ((e - s) / 2);
            List<Skyline> l = drawSkyline(arr, s, mid);
            List<Skyline> r = drawSkyline(arr, mid + 1, e);
            List<Skyline> res = mergeSkylines(l, r);

            return res;
        }
        static List<Skyline> mergeSkylines(List<Skyline> left, List<Skyline> right)
        {
            int li = 0;
            int ri = 0;
            List<Skyline> merged = new List<Skyline>();
            while ((li < left.Count) && (ri < right.Count))
            {
                if (left[li].e < right[ri].s)
                {
                    merged.Add(left[li]);
                    li++;
                }
                else if (right[ri].e < left[li].s)
                {
                    merged.Add(right[ri]);
                    ri++;
                }
                else if (left[li].s <= right[ri].s)
                {
                    Ref iObj = new Ref(li);
                    Ref jObj = new Ref(ri);
                    mergeOverlappingSkyline(merged, left[li], iObj, right[ri], jObj);
                    li = iObj.value;
                    ri = jObj.value;
                }
                else //(left[li].s > right[ri].s)
                {
                    Ref iObj = new Ref(li);
                    Ref jObj = new Ref(ri);
                    mergeOverlappingSkyline(merged, right[ri], jObj, left[li], jObj);
                    li = iObj.value;
                    ri = jObj.value;
                }
            }
            merged.AddRange(left.GetRange(li, left.Count - li));
            merged.AddRange(right.GetRange(ri, right.Count - ri));

            return merged;
        }

        public static void mergeOverlappingSkyline(List<Skyline> merged, Skyline left, Ref l, Skyline right, Ref r)
        {
            if (left.e <= right.e)
            {
                if (left.h > right.h)
                {
                    if (left.e == right.e)
                    {
                        r.value++;
                    }
                    else
                    {
                        merged.Add(left);
                        l.value++;
                        right.s = left.e;
                    }
                }
                else if (left.h == right.h)
                {
                    l.value++;
                    right.s = left.s;
                }
                else
                {//left.h < right.h
                    if (left.s != right.s)
                    {
                        merged.Add(new Skyline(left.s, right.s, left.h));
                    }
                    l.value++;
                }
            }
            else //left.e > right.e
            {
                if (left.h >= right.h)
                {
                    r.value++;
                }
                else
                {
                    if (left.s != right.s)
                    {
                        merged.Add(new Skyline(left.s, right.s, left.h));
                    }
                    merged.Add(right);
                    left.s = right.e;
                    r.value++;
                }
            }
        }
        public static void Main(string[] args)
        {
            Skyline o1 = new Skyline(1, 5, 6);
            Skyline o2 = new Skyline(4, 10, 4);
            Skyline o3 = new Skyline(8, 20, 2);
            Skyline o4 = new Skyline(30, 40, 5);
            Skyline o5 = new Skyline(38, 60, 10);
            Skyline o6 = new Skyline(42, 44, 5);

            List<Skyline> arr = new List<Skyline>();
            arr.Add(o1);
            arr.Add(o2);
            arr.Add(o3);
            arr.Add(o4);
            arr.Add(o5);
            arr.Add(o6);

            List<Skyline> res = drawSkyline(arr, 0, arr.Count-1);
            foreach (Skyline obj in res)
            {
                Console.WriteLine(obj.s + "," + obj.e + "," + obj.h);
            }
            Console.ReadLine();
        }
    }
}