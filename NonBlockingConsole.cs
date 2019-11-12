using System;
using System.Collections.Concurrent;
using System.Threading;

namespace NonBlockingConsoleApp
{
    public static class NonBlockingConsole
    {
        private static BlockingCollection<string> m_blockingCollection = new BlockingCollection<string>();

        static NonBlockingConsole()
        {
            var thread = new Thread(() =>
            {
                while (true) 
                    Console.WriteLine(m_blockingCollection.Take());
            });

            thread.IsBackground = true;
            thread.Start();
        }

        public static void WriteLine(object value)
        {
            WriteLine(value.ToString());
        }

        public static void WriteLine(string value)
        {
            m_blockingCollection.Add(value);
        }
    }
}
