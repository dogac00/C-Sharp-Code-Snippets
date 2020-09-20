using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppCs
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            var token = CancellationToken.None;
            
            // Use any of these methods you'd like
            await "Eternity";
            await ("Eternity", token);
            await TimeSpan.FromDays(1);
            await (TimeSpan.FromDays(1), token);
        }
    }
    
    public static class GetAwaiterExtensions 
    {
        public static TaskAwaiter GetAwaiter(this (TimeSpan, CancellationToken) valueTuple)
        {
            return Task.Delay((int) valueTuple.Item1.TotalMilliseconds, valueTuple.Item2)
                .GetAwaiter();
        }
        
        public static TaskAwaiter GetAwaiter(this TimeSpan timeSpan)
        {
            return Task.Delay((int) timeSpan.TotalMilliseconds)
                .GetAwaiter();
        }
        
        public static TaskAwaiter GetAwaiter(this string value)
        {
            if (value == "Eternity")
            {
                return Task.Delay(Timeout.Infinite)
                    .GetAwaiter();
            }
            
            throw new ArgumentException();
        }
        
        public static TaskAwaiter GetAwaiter(this (string, CancellationToken) valueTuple)
        {
            if (valueTuple.Item1 == "Eternity")
            {
                return Task
                    .Delay(Timeout.Infinite, cancellationToken: valueTuple.Item2)
                    .GetAwaiter();
            }
            
            throw new ArgumentException();
        }
    }
}
