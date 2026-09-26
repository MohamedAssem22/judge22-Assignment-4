using System.Text;
using BenchmarkDotNet.Attributes;

namespace AcademyScheduleAnalyzer.Benchmarks;

[MemoryDiagnoser]
public class StringBenchmark
{
    [Params(100, 1000, 10000, 100000)]
    public int N;

    [Benchmark]
    public string StringConcatenation()
    {
        string result = "";
        for (int i = 0; i < N; i++)
        {
            result += i.ToString(); 
        }

        return result;
    }

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < N; i++)
        {
            result.Append(i.ToString()); 
        }

        return result.ToString(); 
    }
}