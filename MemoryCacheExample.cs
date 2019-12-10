using System.Runtime.Caching;
using ideal.Mocks;

namespace ideal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MemoryCache cache = new MemoryCache("My Cache");

            cache.Add("Ankara", 6, new CacheItemPolicy());
            cache.Add("Istanbul", 34, new CacheItemPolicy());

            System.Console.WriteLine(cache.Get("Ankara"));
        }
    }
}
