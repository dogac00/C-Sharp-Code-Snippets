
// The example in above class gets converted to the class below
// If we look at the IL we can see that these two are exactly the same

namespace TestArrayLength
{
    class RestParameters
    {
        public static void Main(string[] args)
        {
            Sum(1, 2, 3, 4, 5);
        }

        private static int Sum(params int[] args)
        {
            var sum = 0;

            foreach (var i in args)
                sum += i;

            return sum;
        }
    }

    class GetsConvertedTo
    {
        public static void Run()
        {
            Sum(new [] { 1, 2, 3, 4, 5 });
        }

        private static int Sum(int[] args)
        {
            var sum = 0;

            foreach (var i in args)
                sum += i;

            return sum;
        }
    }
}
