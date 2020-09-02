/*

In this kata you will create a function that takes a list of non-negative integers and strings and returns a new list with the strings filtered out.

Example
ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b"}) => {1, 2}
ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b", 0, 15}) => {1, 2, 0, 15}
ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b", "aasf", "1", "123", 231}) => {1, 2, 231}

*/

// I think my solution is one of the more quickes and ituitive ones. And it is quite short too.
// At the end, I had to Cast the array to int array because it is of type object.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListFilterer
{
   public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
   {
      return listOfItems.Where(i => !(i is string)).Cast<int>();
   }
}

// I found that there is a shorter way :) It is incredible.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListFilterer
{
   public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
   {
      return listOfItems.OfType<int>(); 
   }
}
