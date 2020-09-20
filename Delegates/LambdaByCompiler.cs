using System;
using System.Linq;

namespace ConsoleAppCs
{
    class Program
    {
        public static void Main()
        {
            var names = new [] { "asdf", "dsfadf", "adsfadf" };
            
            names.Count(n => n.Length == 5);
        }
    }
}

// The program above gets converted to this by compiler

namespace ConsoleAppCs
{
    class ProgramConverted
    {
        private sealed class CompilerGeneratedClass
        {
            public static readonly CompilerGeneratedClass Instance 
                = new CompilerGeneratedClass();
            
            public static Func<string, bool> LengthFunc;
            
            internal bool GetLength(string var) => var.Length == 5;
        }
        
        public static void Main()
        {
            var names = new [] { "asdf", "dsfadf", "adsfadf" };
            var cmp = CompilerGeneratedClass.Instance;
            Func<string, bool> func = CompilerGeneratedClass.LengthFunc ?? 
                (CompilerGeneratedClass.LengthFunc = 
                 new Func<string, bool>(cmp.GetLength));
            
            names.Count(func);
        }
    }
}
