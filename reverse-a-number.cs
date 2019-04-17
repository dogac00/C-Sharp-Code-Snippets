/*

Given a number, write a function to output its reverse digits. (e.g. given 123 the answer is 321)

Numbers should preserve their sign; i.e. a negative number should still be negative when reversed.

Examples
 123 ->  321
-456 -> -654
1000 ->    1

*/

// My Simple and Intuitive Solution. And I think this is the best for performance too.

using System;

public class Kata
{
    public int ReverseNumber(int n)
    {
        int reverse = 0;
        
        while (n != 0) {
            reverse = reverse * 10 + n % 10;
            n /= 10;
        }
        
        return reverse;
    }
}
