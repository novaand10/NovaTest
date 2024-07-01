using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string input1 = "{[()]}";
        string input2 = "{[(])}";
        string input3 = "{(([])[])[]}";

        Console.WriteLine($"Input: {input1}");
        Console.WriteLine($"Output: {IsBalanced(input1)}");

        Console.WriteLine($"Input: {input2}");
        Console.WriteLine($"Output: {IsBalanced(input2)}");

        Console.WriteLine($"Input: {input3}");
        Console.WriteLine($"Output: {IsBalanced(input3)}");
    }

    static string IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (stack.Count == 0)
                {
                    return "NO"; // More closing brackets than opening ones
                }

                char top = stack.Pop();
                if ((c == ')' && top != '(') ||
                    (c == ']' && top != '[') ||
                    (c == '}' && top != '{'))
                {
                    return "NO"; // Mismatched opening and closing brackets
                }
            }
        }

        if (stack.Count == 0)
        {
            return "YES"; // All opening brackets have been matched
        }
        else
        {
            return "NO"; // More opening brackets than closing ones
        }
    }
}
