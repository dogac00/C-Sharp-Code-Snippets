/*
You live in the city of Cartesia where all roads are laid out in a perfect grid. 
You arrived ten minutes too early to an appointment, so you decided to take the opportunity to go for a short walk. 
The city provides its citizens with a Walk Generating App on their phones -- everytime you press the button 
it sends you an array of one-letter strings representing directions to walk (eg. ['n', 's', 'w', 'e']). 
You always walk only a single block in a direction and you know it takes you one minute to traverse one city block, 
so create a function that will return true if the walk the app gives you will take you exactly ten minutes 
(you don't want to be early or late!) and will, of course, return you to your starting point. Return false otherwise.
Note: you will always receive a valid array containing a random assortment of direction letters ('n', 's', 'e', or 'w' only). 
It will never give you an empty array (that's not a walk, that's standing still!).
*/

// My solution was this. But firstly I thought it could be done with Linq. But this way I find it way more clear.

using System;

public class Kata
{
  public static bool IsValidWalk(string[] walk)
  {
    int[] sum = {0, 0};
    int minute = 0;
    char temp;
    
    foreach (var w in walk) {
      temp = Convert.ToChar(w);
      
      if (temp == 'n') {
        sum[0]++;
        minute++;
      }
      
      else if (temp == 's') {
        sum[0]--;
        minute++;
      }
      
      else if (temp == 'e') {
        sum[1]++;
        minute++;
      }
      
      else {
        sum[1]--;
        minute++;
      }
    }
    
    return sum[0] == 0 && sum[1] == 0 && minute == 10;
  }
}

// Simple improvements may be made by removing the minute and first checking if the array length is 10.
// And not converting strings and compare them with "w" double quotes.

// Here's the one-line Linq solution. But I find it uneffficient. Because it has to loop the array every step.
// This may be a concern for performance in case of large arrays.

using System.Linq;

public class Kata
{
  public static bool IsValidWalk(string[] walk)
  {
    return walk.Length == 10 && walk.Count(x => x == "n") == walk.Count(x => x == "s") && walk.Count(x => x == "e") == walk.Count(x => x == "w");
  }
}

// In this code however, it is good that it checks the length first. It makes it efficient.
