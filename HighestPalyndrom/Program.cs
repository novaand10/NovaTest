using System;

class Program
{

    static void Main(string[] args)
    {
        string s1 = "3943";
        int k1 = 1;
        Console.WriteLine($"Input: s = {s1}, k = {k1}");
        Console.WriteLine($"Output: {FindLargestPalindrome(s1, k1)}");
        Console.WriteLine("==========================================");
        string s = "932239";
        int k = 2;

        string largestPalindrome = FindLargestPalindrome(s, k);

        Console.WriteLine($"Input: s = {s}, k = {k}");
        Console.WriteLine($"Output: {largestPalindrome}");
    }

    static string FindLargestPalindrome(string s, int k)
    {
        // Convert string s to character array for easier manipulation
        char[] charArray = s.ToCharArray();

        int left = 0;
        int right = charArray.Length - 1;

        while (left < right)
        {
            if (charArray[left] != charArray[right])
            {
                // Replace the smaller character with the larger one
                charArray[left] = charArray[right] = (char)Math.Max(charArray[left], charArray[right]);
                k--;
            }

            left++;
            right--;
        }

        // After making the string a palindrome, use remaining k for further enhancements
        left = 0;
        right = charArray.Length - 1;

        while (left <= right)
        {
            if (left == right)
            {
                // If k > 0 and there's a middle character, change it to '9'
                if (k > 0)
                    charArray[left] = '9';
            }

            if (charArray[left] < '9')
            {
                // If k > 1, change both characters to '9'
                if (k >= 2)
                {
                    charArray[left] = charArray[right] = '9';
                    k -= 2;
                }
                else if (k >= 1)
                {
                    // If k = 1, change only one character to '9' (maximize the palindrome)
                    charArray[left] = charArray[right] = '9';
                    k--;
                }
            }

            left++;
            right--;
        }

        return new string(charArray);
    }
}