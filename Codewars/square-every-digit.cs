/*
Welcome. In this kata, you are asked to square every digit of a number.

For example, if we run 9119 through the function, 811181 will come out, because 92 is 81 and 12 is 1.

Note: The function accepts an integer and returns an integer.
*/

/ My Solution using Linq is

using System;
using System.Collections.Generic;
using System.Linq;

public class Kata
{
  public static int SquareDigits(int n)
  {
    return Convert.ToInt32(String.Join("", n.ToString().
    ToCharArray().
    Select(ch => ch - '0').
    Select(num => (int)Math.Pow(num, 2))));
  }
}

// First I convert n to string.
// And then convert to a char array.
// Then mapped through it using a lambda expression and convert every char to int.
// Again mapped through it and take every integer's square.
// And finally join the whole char array.
