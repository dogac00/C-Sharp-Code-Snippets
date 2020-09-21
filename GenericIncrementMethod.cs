using System;
using System.Reflection.Emit;

namespace ConsoleAppCs
{
    public static class Program
    {
        static void Main(string[] args)
        {
            ushort i = 111; 
            
            // The type of this variable could be byte, sbyte, short, ushort,
            // int, uint, long, ulong, float, double
            var inc = i.Inc();

            Console.WriteLine(inc);
        }
    }

    public static class Helper
    {
        public static T Inc<T>(this T value) where T : unmanaged
        {
            if (typeof(T) == typeof(decimal))
            {
                throw new ArgumentException("Decimal is not supported.");
            }
            
            var dynamicMethod = new DynamicMethod("Increment",
                typeof(T),
                new[] { typeof(T) });

            var ilGenerator = dynamicMethod.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldc_I4_1);
            ilGenerator.Emit(OpCodes.Add);
            ilGenerator.Emit(OpCodes.Ret);
            
            return (T) dynamicMethod.Invoke(null, new object[] { value });
        }
    }
}
