using System;

namespace ThrowHelper
{
    class Program
    {
        public static void Main(string[] args)
        {
            ThrowHelper.Throw<NullReferenceException>("Throw a NullReferenceException.");
        }
    }

    class ThrowHelper
    {
        public static void Throw<T>(string message) where T : Exception, new()
        {
            T t = (T) Activator.CreateInstance(typeof(T), message);

            throw t;
        }
    }
}
