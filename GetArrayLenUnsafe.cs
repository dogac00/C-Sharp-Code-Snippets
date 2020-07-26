using System;

// I discovered it
// I am thinking about making a blog post about this

namespace TestArrayLength
{
    class Program
    {
        public static void Main(string[] args)
        {
            AssertLength(new []    {1,2,3,4,5});
            AssertLength(new []    {-1,-2,-3,-2323,33454325,456456,54354});
            AssertLength(new []    {0});
            AssertLength(new int[] {});
            AssertLength(new []    {5,7,1,-4576,4345,8888,9678,5,5,8459});
        }

        private static unsafe void AssertLength(int[] arr)
        {
            if (GetLength(arr) != arr.Length)
                throw new Exception("Not Equal!");
        }

        private static unsafe int GetLength(int[] arr)
        {
            fixed (int* ptr = arr)
                return ptr != null ? ptr[-2] : 0;
        }
    }
}
