using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Runtime.CompilerServices;

namespace ConsoleAppCs
{
    // The above class gets converted to below class by compiler
    public class Program
    {
      dynamic x = "foo";
      dynamic y = x.Substring(1, 2);
    }

    public class Program
    {
        private static class CompilerGeneratedClass
        {
            public static CallSite<Func<CallSite, object, int, int, object>> CallSite;
        }

        public static void Main()
        {
            object arg = "foo";

            if (CompilerGeneratedClass.CallSite == null)
            {
                var typeFromHandle = typeof(Program);
                
                var args = new CSharpArgumentInfo[3];

                args[0] = CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null);
                args[1] = CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null);
                args[2] = CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null);

                var callSiteBinder = Binder.InvokeMember(CSharpBinderFlags.None, "Substring", null, typeFromHandle, args);
                
                CompilerGeneratedClass.CallSite = CallSite<Func<CallSite, object, int, int, object>>.Create(callSiteBinder);
            }
            
            CompilerGeneratedClass.CallSite.Target(CompilerGeneratedClass.CallSite, arg, 1, 2);
        }
    }
}
