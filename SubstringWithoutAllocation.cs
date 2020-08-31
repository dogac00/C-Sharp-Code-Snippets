// Just call this if you don't want to allocate a new string on the heap
// You can use Heap Allocator extension for Resharper for seeing the allocated objects
// Just call AsSpan on it an it returns a ReadOnlySpan<char> which is a ref struct

static class StringHelper
  {
      public static ReadOnlySpan<char> SubstringAsSpan(this string str, int start, int end)
      {
          return str.AsSpan(start, end);
      }
  }
