using System;
using System.Collections.Generic;

public class C {
    
    public static List<int> GetList() => new List<int>(256);
    
    public void Iterate() {
        
        foreach (int i in GetList())
        {
            Console.WriteLine(i);
        }
    }
}

// This generates code like this:

public class C
{
    public static List<int> GetList()
    {
        return new List<int>(256);
    }

    public void Iterate()
    {
        List<int>.Enumerator enumerator = GetList().GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                Console.WriteLine((int) enumerator.Current);
            }
        }
        finally
        {
            ((IDisposable)enumerator).Dispose();
        }
    }
}
