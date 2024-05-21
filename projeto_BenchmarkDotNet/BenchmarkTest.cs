using BenchmarkDotNet.Attributes;
namespace projeto_BenchmarkDotNet
{
    [MemoryDiagnoser]
    public class BenchmarkTest
    {
        [Benchmark]
        public void TesteMetodo1()
        {
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                sum += i;
            }
        }

        [Benchmark]
        public void TesteMetodo2()
        {
            int sum = 0;
            for (int i = 0; i < 1000; i += 2)
            {
                sum += i;
            }
        }
    }
}