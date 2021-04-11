using AnotherAssemblyP1;
using AnotherAssemblyP2;
using System;

namespace TestInternalsNetcore5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Assembly running name: {typeof(Program).Assembly.GetName()}");
            Console.WriteLine($"Assembly running name: {new Class1().GetName()}");
            Console.WriteLine($"Assembly running name: {new Class2().GetName()}");
            Console.WriteLine($"Assembly running name: {new Class2().GetClass1Name()}");
            Console.WriteLine($"Assembly running name: {new P2Class1().GetName()}");
            Console.WriteLine($"Assembly running name: {new P2Class1().GetClass1Name()}");
        }
    }
}
