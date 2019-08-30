using System;
using System.Collections.Generic;

namespace LongestPalindrome
{
    class PalindromeChecker
    {
        static string GetLongestPalindrome(string text)
        {
            int length = text.Length;
            int longestI = 0, longestJ = 0;

            for (int i = 0; i < length; i++)
            {
                for (int j = length - 1; j > i; j--)
                {
                    if (j - i <= longestJ - longestI) continue;
                    
                    if (IsPalindrome(text, i, j))
                    {
                        longestI = i;
                        longestJ = j;
                    }
                }
            }

            return text.Substring(longestI, longestJ - longestI + 1);
        }

        static bool IsPalindrome(string text, int low, int high)
        {
            while (high > low)
            {
                if (text[high--] != text[low++]) return false;
            }

            return true;
        }
    }
}
