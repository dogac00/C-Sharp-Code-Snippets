static class MyLinq
{
    public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        foreach (TSource source1 in source)
            yield return selector(source1);
    }

    public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        foreach (TSource source1 in source)
            if (predicate(source1))
                yield return source1;
    }
}
