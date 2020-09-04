public static string GetValueOrAdd(int value)
{
    if (!_nZeroDictionary.TryGetValue(value, out _))
    {
        _nZeroDictionary[value] = value.ToString("N0");
    }

    return _nZeroDictionary[value];
}
