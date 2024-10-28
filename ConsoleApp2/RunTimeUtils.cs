using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace PIToolKit.Public.Utils
{
    /// <summary>
    /// 运行时程序辅助类
    /// </summary>
    public static class RunTimeUtils
    {
        [DllImport("kernel32", SetLastError = true)]
        static extern bool FreeLibrary(IntPtr hModule);

        private const string Formate = "yyyy-MM-dd HH:mm:ss.ffff";
        private static string logFormate = "[{0}]:{1}\n";

        /// <summary>
        /// 指定格式当前时间字符串
        /// </summary>
        public static string Time { get { return DateTime.Now.ToString(Formate); } }
        /// <summary>
        /// 当前堆栈上正在运行的程序集
        /// </summary>
        public static Assembly CurrentAssembly { get { return new StackTrace().GetFrame(1).GetMethod().ReflectedType.Assembly; } }
        /// <summary>
        /// 程序启动路径
        /// </summary>
        public static string StartPath
        {
            get
            {
                return Process.GetCurrentProcess().MainModule.FileName;
            }
        }
        /// <summary>
        /// 当前程序的工作文件夹路径
        /// </summary>
        public static string WorkFolder
        {
            get { return Directory.GetCurrentDirectory() + "/"; }
        }
        /// <summary>
        /// 当前代码运行平台
        /// </summary>
        public static string Platform
        {
            get
            {
                PropertyInfo property = typeof(Environment).GetProperty("Platform", BindingFlags.NonPublic | BindingFlags.Static);
                if (property == null) return Environment.OSVersion.Platform.ToString();
                else return property.GetValue(null, new object[0]).ToString();
            }
        }
        /// <summary>
        /// 系统应用缓存数据路径
        /// </summary>
        public static string SystemADPath
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/"; }
        }
        /// <summary>
        /// 桌面路径
        /// </summary>
        public static string Desktop
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/"; }
        }
        /// <summary>
        /// 临时文件夹路径
        /// </summary>
        public static string TempPath
        {
            get { return Path.GetTempPath() + "/"; }
        }

        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <param name="logStr"></param>
        public static void LogError(string logStr)
        {
            string str = string.Format(logFormate, Time, logStr);
            File.AppendAllText("ErrorLog.txt", str);
        }
        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <param name="e"></param>
        public static void LogError(Exception e)
        {
            LogError(e.ToString());
        }
        /// <summary>
        /// 输出日志信息
        /// </summary>
        /// <param name="logStr"></param>
        public static void Log(string logStr)
        {
            string str = string.Format(logFormate, Time, logStr);
            File.AppendAllText("Log.txt", str);
        }
        /// <summary>
        /// 估算委托方法的执行时间,返回值是毫秒
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static double ReckonTime(Action action)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            action();
            watch.Stop();
            TimeSpan timespan = watch.Elapsed;
            return timespan.TotalMilliseconds;
        }
        /// <summary>
        /// 估算委托仿执行前后的内存变化，返回值是kb
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static double ReckonMemory(Action action)
        {
            long before = GC.GetTotalMemory(false);
            action();
            long after = GC.GetTotalMemory(false);
            return (after - before) / 1024.0;
        }
        /// <summary>
        /// 运行时卸载dll
        /// </summary>
        /// <param name="name"></param>
        public static void UnloadDll(string name)
        {
            foreach (ProcessModule mod in Process.GetCurrentProcess().Modules)
            {
                if (mod.ModuleName.Contains(name))
                {
                    FreeLibrary(mod.BaseAddress);
                }
            }
        }
    }
}