using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input = "abbcccd";
        int[] queries = { 1, 3, 9, 8 };

        Console.WriteLine("Input String:"+input);
        Console.Write("Input Query:" );
        foreach (var item in queries) { 
            Console.Write(item+ " ");
        }
        Console.WriteLine();
        List<string> weightsStatus = CalculateWeightsStatus(input, queries);

        Console.WriteLine("Output:");
        Console.WriteLine("[" + string.Join(", ", weightsStatus.Select(status => $"\"{status}\"")) + "]");
    }

    static List<string> CalculateWeightsStatus(string input, int[] queries)
    {
        List<string> weightsStatus = new List<string>();

        // Step 1: Calculate weights of all characters and substrings in the input string
        Dictionary<string, int> weights = new Dictionary<string, int>();
        int n = input.Length;

        for (int i = 0; i < n; i++)
        {
            int weight = input[i] - 'a' + 1; // calculate weight of character
            string substring = input[i].ToString();
            weights[substring] = weight;

            // Check for consecutive identical characters
            int count = 1;
            while (i + 1 < n && input[i + 1] == input[i])
            {
                count++;
                substring += input[i];
                weights[substring] = weight * count;
                i++;
            }
        }

        // Step 2: Determine status of each query
        foreach (int query in queries)
        {
            if (weights.ContainsValue(query))
            {
                weightsStatus.Add("Yes");
            }
            else
            {
                weightsStatus.Add("No");
            }
        }

        return weightsStatus;
    }
}
