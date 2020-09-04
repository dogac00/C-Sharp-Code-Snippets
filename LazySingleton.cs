using System;

namespace LazySingletonImplementation
{
    public class LazySingleton
    {
        // Start of Singleton

        private LazySingleton() { }

        private static Lazy<LazySingleton> lazy = new Lazy<LazySingleton>(() => new LazySingleton());

        public static LazySingleton Instance { get { return lazy.Value; } }

        // End of Singleton

        // Write your Methods Below

        // ...
    }
}
