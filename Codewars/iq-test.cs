/*

Bob is preparing to pass IQ test. The most frequent task in this test is to find out which one of the given numbers 
differs from the others. Bob observed that one number usually differs from the others in evenness. 
Help Bob — to check his answers, he needs a program that among the given numbers finds one that is different in evenness, 
and return a position of this number.

! Keep in mind that your task is to help Bob solve a real IQ test, which means indexes of the elements start from 1 (not 0)

## Examples :

IQ.Test("2 4 7 8 10") => 3 // Third number is odd, while the rest of the numbers are even

IQ.Test("1 2 1 1") => 2 // Second number is even, while the rest of the numbers are odd

*/

// I tried very hard to get this solution. Although I realize it is not the perfect solution.
// A simple problem like counting the occurrences of an element inside an array had me spending too much time.
// And then I decided to write a method for that. I think that way will be clean and readable.

// The logic here is that I split the numbers to make a string array of one chars. And I convert all one element strings
// to Int32 to make it an int array. And then using the Select method of Linq, I convert this array to isEven array.
// Then I check if 1 is occuring too much. It means we should return 0 and vice versa.

using System;
using System.Linq;
using System.Collections.Generic;

public class IQ
    {
        public static int Test(string numbers)
        { 
            int[] evenOds = numbers.Split().Select(c => Convert.ToInt32(c)).Select(num => num % 2 == 0 ? 1 : 0).ToArray();
            
            if (GetCount(evenOds, 1) > 1) 
              return Array.IndexOf(evenOds, 0) + 1;
            
            return Array.IndexOf(evenOds, 1) + 1;
        }
        
        public static int GetCount(int[] numbers, int numberToCount) {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++) {
                if (numbers[i] == numberToCount) count++;
            }
            return count;
        }
    }
    
// I copy two better solutions here from the site.

using System;
using System.Linq;

public class IQ
    {
        public static int Test(string numbers)
        { 
            var ints = numbers.Split(' ').Select(int.Parse).ToList();
            var unique = ints.GroupBy(n => n % 2).OrderBy(c => c.Count()).First().First();
            return ints.FindIndex(c => c == unique) + 1;
        }
    }
    
--------------------
    
using System;
using System.Linq;

public class IQ
{
    public static int Test(string numbers)
    { 
        var nums = numbers.Split(' ').Select((s, i) => new { Value = int.Parse(s), Index = i });
        var even = nums.Where(x => x.Value % 2 == 0);
        var odd = nums.Where(x => x.Value % 2 == 1);
        return even.Count() == 1 ? even.First().Index + 1: odd.First().Index + 1; 
    }
}
