/*

Count the number of Duplicates
Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits that occur more than once in the input string. The input string can be assumed to contain only alphabets (both uppercase and lowercase) and numeric digits.

Example
"abcde" -> 0 # no characters repeats more than once
"aabbcde" -> 2 # 'a' and 'b'
"aabBcde" -> 2 # 'a' occurs twice and 'b' twice (`b` and `B`)
"indivisibility" -> 1 # 'i' occurs six times
"Indivisibilities" -> 2 # 'i' occurs seven times and 's' occurs twice
"aA11" -> 2 # 'a' and '1'
"ABBA" -> 2 # 'A' and 'B' each occur twice

*/

// My solution was with GroupBy at last. I tried many ways to reach to this solution.

using System;
using System.Linq;

public class Kata
{
  public static int DuplicateCount(string str)
  {
    int count = 0;
    foreach (var num in str.ToLower().GroupBy(c => c).Select(c => c.Count())) {
      if (num > 1) count++;
    }
    
    return count;
  }
}

// First a create a Enumerable with counts of occurences of elements in it.

// I tried to get something like this. Then I see it in the best solutions.
