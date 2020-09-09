using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppCs
{
    class Program
    {
        static void Main()
        {
            Run(() => { Console.WriteLine(1232345); return 1232345; });

            Console.ReadLine();
        }

        private static Task<T> Run<T>(Func<T> action)
        {
            var tcs = new TaskCompletionSource<T>();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    var t = action();
                    tcs.SetResult(t);
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            });

            return tcs.Task;
        }
    }
}
