    using System;
    using System.Collections.Generic;
    using System.Threading;

    namespace CloneWithReflection
    {
        internal class Program
        {

            static void Main(string[] args)
            {
                Dictionary<int, string> dictionary = new Dictionary<int, string>();

                for (int i = 0; i < 10000; i++)
                {
                    dictionary[i] = (i >> 5 + i ^ 3) + "";
                }

                new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(10);

                        dictionary[new Random().Next(0, 10000)] = string.Concat(new Random().Next(0, 10000), "");
                    }
                }).Start();

                while (true)
                {
                    foreach (var pair in dictionary)
                    {
                        Console.WriteLine(pair);
                    }
                }
            }
        }
    }
