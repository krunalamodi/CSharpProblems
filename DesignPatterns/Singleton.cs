using System;
namespace SingletonTest
{
    public class SingletonAlmostLazy
    {
        private static readonly SingletonAlmostLazy sObj = new SingletonAlmostLazy();
 
        // this ensures that type initialization will be done only when this class is referenced by 'SingletonAlmostLazy.XXX'
        // v4.0 onwards type initilization changed a bit (Don't exactly know what that is :) )
        // In < v4.0, type initialization may happen before as well - i.e, before the actual reference
        static SingletonAlmostLazy() { }
        private SingletonAlmostLazy()
        {
            Console.WriteLine("This is singleton constructor");
        }
        public static SingletonAlmostLazy Instance { get { return sObj; } }
 
        public static void DoSomething()
        {
            Console.WriteLine("Doing something in SingletonAlmostLazy");
        }
    }
 
    class SingletonFullLazy
    {
        private class SingletonHolder
        {
            internal static readonly SingletonFullLazy sObj = new SingletonFullLazy();
 
            // Lazy
            static SingletonHolder() { }
        }
 
        private SingletonFullLazy()
        {
            Console.WriteLine("This is singleton constructor");
        }
 
        public static SingletonFullLazy Instance { get { return SingletonHolder.sObj; } }
 
        public static void DoSomething()
        {
            Console.WriteLine("Doing something in SingletonFullLazy");
        }
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            SingletonAlmostLazy.DoSomething();
            Console.WriteLine("After SingletonAlmostLazy.DoSomething()");
            SingletonAlmostLazy obj = SingletonAlmostLazy.Instance;
            SingletonAlmostLazy obj2 = SingletonAlmostLazy.Instance;
 
            Console.WriteLine("Done with AlmostLazy...");
            Console.WriteLine("\n\n\n");
 
            //---------------
 
            SingletonFullLazy.DoSomething();
 
            Console.WriteLine("After SingletonFullLazy.DoSomething()");
 
            SingletonFullLazy o = SingletonFullLazy.Instance;
            SingletonFullLazy o2 = SingletonFullLazy.Instance;
 
            Console.WriteLine("Done with FullLazy...");
            Console.ReadLine();
        }
    }
}

/*
Output:
This is singleton constructor
Doing something in SingletonAlmostLazy
After SingletonAlmostLazy.DoSomething()
Done with AlmostLazy...




Doing something in SingletonFullLazy
After SingletonFullLazy.DoSomething()
This is singleton constructor
Done with FullLazy...
*/