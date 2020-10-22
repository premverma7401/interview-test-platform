using System;

namespace Checkout
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Till till = new Till();
            till.Total();
        }
             
    }
}
