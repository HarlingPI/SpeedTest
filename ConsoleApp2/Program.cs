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
            string format = @"d\.hh\:mm\:ss\.fffffff";
            TimeSpan span = new TimeSpan(1, 23, 10, 10, 10);



            Console.WriteLine("格式化到字符串--------");
            Console.WriteLine($"cFormat: {span:c}");
            Console.WriteLine($"gFormat: {span:g}");
            Console.WriteLine($"GFormat: {span:G}");
            Console.WriteLine(span.ToString(format));

            int count = 100000;
            double time = RunTimeUtils.ReckonTime(() =>
            {
                for (int j = 0; j < count; j++)
                {
                    //span.ToString();
                    span.ToString(format);
                }
            });
            Console.WriteLine($"{count}次ToString耗时:{time}ms");
            Console.WriteLine();

            Console.WriteLine("从字符串格式化--------");
            string str = "1.23:10:10.0100000";
            span = TimeSpan.Parse(str);
            Console.WriteLine($"cFormat: {span:c}");
            Console.WriteLine($"gFormat: {span:g}");
            Console.WriteLine($"GFormat: {span:G}");
            Console.WriteLine(span.ToString(format));

            time = RunTimeUtils.ReckonTime(() =>
            {
                for (int j = 0; j < count; j++)
                {
                    TimeSpan.Parse(str);
                }
            });
            Console.WriteLine($"{count}次Parse耗时:{time}ms");
            Console.WriteLine();

            Console.WriteLine("从字符串格式化--------");
            span = TimeSpan.Parse(str);
            Console.WriteLine($"cFormat: {span:c}");
            Console.WriteLine($"gFormat: {span:g}");
            Console.WriteLine($"GFormat: {span:G}");
            Console.WriteLine(span.ToString(format));

            time = RunTimeUtils.ReckonTime(() =>
            {
                for (int j = 0; j < count; j++)
                {
                    TimeSpan.ParseExact(str, format, null);
                }
            });
            Console.WriteLine($"{count}次FormatParse:{time}ms");
            Console.WriteLine();

            Console.WriteLine("从字符串格式化--------");
            bool success = TimeSpan.TryParse(str, out span);
            Console.WriteLine($"cFormat: {span:c}");
            Console.WriteLine($"gFormat: {span:g}");
            Console.WriteLine($"GFormat: {span:G}");
            Console.WriteLine(span.ToString(format));

            time = RunTimeUtils.ReckonTime(() =>
            {
                for (int j = 0; j < count; j++)
                {
                    TimeSpan.TryParse(str, out span);
                }
            });
            Console.WriteLine($"{count}次FormatParse:{time}ms");
            Console.WriteLine();

            Console.Read();
        }
    }
}
