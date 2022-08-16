using BenchmarkDotNet.Running;
using EFCore;



Console.WriteLine("Iniciando Benchmark");

var benchmark = BenchmarkRunner.Run<EFCoreBenchmark>();