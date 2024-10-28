using PIToolKit.Public.Utils;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeSpan span = new TimeSpan(1, 23, 10, 10, 10);

            Console.WriteLine(span.Days);
            Console.WriteLine(span.Hours);
            Console.WriteLine(span.Minutes);
            Console.WriteLine(span.Seconds);
            Console.WriteLine(span.ToString());

            int count = 100000;
            List<double> times = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                double time = RunTimeUtils.ReckonTime(() =>
                {
                    for (int j = 0; j < count; j++)
                    {
                        span.ToString();
                        //span.ToString(@"d\.hh\:mm\:ss\.fffff");
                    }
                });
                times.Add(time);
            }

            Console.WriteLine($"{count}次转换耗时: {times.Average()} ms");
        }
    }
}
