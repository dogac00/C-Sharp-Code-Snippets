using System;
using System.Collections.Generic;

public class C {
    public void M() {
        var lst = new List<int>(52);
        
        foreach (var i in lst)
            Console.WriteLine(i);
    }
}

// This gets converted to
// Important point here is that the enumerator of List`1 is a struct
// which occupies memory on stack
// so there will be no allocations for List<T>.Enumerator

public class C
{
    public void M()
    {
        List<int>.Enumerator enumerator = new List<int>(52).GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
        finally
        {
            ((IDisposable)enumerator).Dispose();
        }
    }
}
