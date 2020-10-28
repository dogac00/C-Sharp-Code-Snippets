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
        
        // The examples above only works with integers
        // and in a 64-bit build
        // Here is the generic version of it
        // This works with all unmanaged data types and structs
        private static unsafe int GetLength<T>(T[] arr) where T : unmanaged  
        {  
            fixed (T* ptr = arr)      
                return ptr == null                 
                        ? 0                  
                        : ((int*)ptr)[-(sizeof(IntPtr) / sizeof(int))]; 
        }
    }
}
