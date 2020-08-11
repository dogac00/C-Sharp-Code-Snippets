/*
Your task is to sort a given string. Each word in the string will contain a single number. This number is the position the word should have in the result.

Note: Numbers can be from 1 to 9. So 1 will be the first word (not 0).

If the input string is empty, return an empty string. The words in the input String will only contain valid consecutive numbers.

Examples
"is2 Thi1s T4est 3a"  -->  "Thi1s is2 3a T4est"
"4of Fo1r pe6ople g3ood th5e the2"  -->  "Fo1r the2 g3ood 4of th5e pe6ople"
""  -->  ""
*/

using System;
using System.Collections.Generic;

public static class Kata
{
  public static string Order(string words)
  {
    string[] wordsArray = words.Split();
    
    List<string> wordList = new List<string>();
    
    int index = 1;
    for (int i = 0; i < wordsArray.Length; i++) {
      foreach (var word in wordsArray) {
        if (word.Contains(index.ToString()[0])) {
          wordList.Add(word);
        }
      }
      ++index;
    }
    
    return String.Join(" ", wordList);
  }
}

// This is my solution for now.
