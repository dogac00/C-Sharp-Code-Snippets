public static class ArrayExtensions
    {
        public static T [] FastWhere<T>(this T [] array, Func<T, bool> predicate)
        {
            // Pre-allocate new array (a call to count is required)
            var count = FastCount(array, predicate);
            var newArr = new T[count];

            // This array.Length resolves to a single assembly code
            for (var i = 0; i < count; i++)
                if (predicate(array[i)))
                    newArr[i] = array[i];

            return newArr;
        }

        public static int FastCount<T>(this T [] array, Func<T, bool> predicate)
        {
            // These assertions will not affect Release build performance
            Debug.Assert(array != null);
            Debug.Assert(predicate != null);

            var count = 0;

            foreach (var item in array)
                if (predicate(item))
                    count++;

            return count;
        }
    }
