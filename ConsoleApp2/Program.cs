using PIToolKit.Public.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeSpan span = new TimeSpan(1, 23, 10, 10, 10);



            Console.WriteLine("格式化到字符串");
            Console.WriteLine($"cFormat: {span:c}");
            Console.WriteLine($"gFormat: {span:g}");
            Console.WriteLine($"GFormat: {span:G}");
            Console.WriteLine(span.ToString(@"d\.hh\:mm\:ss\.fffff"));

            int count = 100000;
            double time = RunTimeUtils.ReckonTime(() =>
            {
                for (int j = 0; j < count; j++)
                {
                    //span.ToString();
                    span.ToString(@"d\.hh\:mm\:ss\.fffff");
                }
            });
            Console.WriteLine($"{count}次转换耗时:{time}ms");

            Console.WriteLine("从字符串格式化");
            string str = "1.23:10:10.0100000";
            span = TimeSpan.Parse(str);
            Console.WriteLine($"cFormat: {span:c}");
            Console.WriteLine($"gFormat: {span:g}");
            Console.WriteLine($"GFormat: {span:G}");
            Console.WriteLine(span.ToString(@"d\.hh\:mm\:ss\.fffff"));

            time = RunTimeUtils.ReckonTime(() =>
            {
                for (int j = 0; j < count; j++)
                {
                    TimeSpan.Parse(str);
                }
            });
            Console.WriteLine($"{count}次转换耗时:{time}ms");
            Console.Read();
        }
    }
}
