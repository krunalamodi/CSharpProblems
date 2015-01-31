using System;

namespace Solutions
{
    public class HelloWorld
    {
        public void printHelloWorld(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Hello World");
            }
        }
        public static void HelloWorldHelper()
        {
            HelloWorld obj = new HelloWorld();
            obj.printHelloWorld(3);
        }
    }
}
