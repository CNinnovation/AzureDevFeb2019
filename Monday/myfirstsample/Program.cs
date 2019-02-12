using System;

namespace myfirstsample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            if (args.Length >= 1)
            {
                Console.WriteLine(args[0]);
            }
        }
    }
}
