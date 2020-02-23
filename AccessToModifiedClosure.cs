using System;

namespace ClosureApp
{
    class Program
    {
        public static unsafe void Main(string[] args)
        {
            int val = 12;

            Closure closure = new Closure(&val);

            val = 24;

            closure.Invoke();
        }
    }

    unsafe class Closure
    {
        private readonly int* _fieldPtr;

        public Closure(int* ptr)
        {
            _fieldPtr = ptr;
        }

        public void Invoke()
        {
            Console.WriteLine(*_fieldPtr);
        }
    }
}
