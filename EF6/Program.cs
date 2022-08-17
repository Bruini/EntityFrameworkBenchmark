using BenchmarkDotNet.Running;
using System;

namespace EF6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Benchmark");

            var benchmark = BenchmarkRunner.Run<EF6Benchmark>();
        }
    }
}
