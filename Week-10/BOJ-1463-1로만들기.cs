using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class Solution
{
    static int solution(int n)
    {
        // DP memo
        int[] memo = new int[n + 1];
        // Base case
        memo[1] = 0;

        // Find all values up to n
        for (int i = 2; i <= n; i++)
        {
            memo[i] = memo[i - 1] + 1;

            if(i % 2 == 0)
            {
                memo[i] = Math.Min(memo[i], memo[i / 2] + 1);
            }
            if (i % 3 == 0)
            {
                memo[i] = Math.Min(memo[i], memo[i / 3] + 1);
            }
        }

        return memo[n];
    }

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        // Test Cases
        int N = int.Parse(Console.ReadLine());
        
        sb.Append(solution(N));

        Console.WriteLine(sb.ToString());
    }
}