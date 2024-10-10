using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    public struct Result
    {
        public int zeroes { get; set; }
        public int ones { get; set; }
    }

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        int N = int.Parse(Console.ReadLine());
        int max = 0;
        int n;
        int[] nums = new int[N];

        for (int i = 0; i < N; i++)
        {
            n = int.Parse(Console.ReadLine());
            max = Math.Max(max, n);
            nums[i] = n;
        }

        if(max == 0)
        {
            Console.WriteLine("1 0");
            return;
        }
        if(max == 1)
        {
            Console.WriteLine("0 1");
            return;
        }

        Result[] dp = new Result[max + 1];
        dp[0].zeroes = 1;
        dp[1].ones = 1;
        for (int i = 2; i <= max; i++)
        {
            dp[i].zeroes = dp[i - 2].zeroes + dp[i - 1].zeroes;
            dp[i].ones = dp[i - 2].ones + dp[i - 1].ones;
        }

        foreach (int i in nums)
        {
            sb.Append($"{dp[i].zeroes} {dp[i].ones}\n");
        }

        Console.WriteLine(sb.ToString());
    }
}