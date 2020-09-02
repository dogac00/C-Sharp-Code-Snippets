using System.Globalization;

public static class StringExtensions
{
  private static readonly CultureInfo Fr = new CultureInfo("fr-FR");
  
  public static decimal ToDecimal(this string value)
  {
    if (value.Contains(','))
      return decimal.Parse(value, Fr);
      
    return decimal.Parse(value, CultureInfo.InvariantCulture);
  }
}
