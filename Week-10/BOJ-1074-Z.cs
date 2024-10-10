using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class Solution
{
    static int solution(int N, int r, int c)
    {
        return FindZ((int)Math.Pow(2, N), r, c);
    }

    static int FindZ(int length, int r, int c)
    {
        if (length == 1)
            return 0;

        int half = length / 2;
        int quadSize = half * half;
        int offset = 0;
        if(r < half && c < half) // TopLeft
        {
            offset = 0;
        }
        else if(r < half && c >= half) // TopRight
        {
            offset = quadSize;
            c -= half;
        }
        else if (r >= half && c < half) // BottomLeft
        {
            offset = quadSize * 2;
            r -= half;
        }
        else if (r >= half && c >= half)// BottomRight
        {
            offset = quadSize * 3;
            r -= half;
            c -= half;
        }

        return offset + FindZ(half, r, c);
    }

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        // Test Cases
        string[] split = Console.ReadLine().Split();
        int N = int.Parse(split[0]);
        int r = int.Parse(split[1]);
        int c = int.Parse(split[2]);

        sb.Append(solution(N, r, c));

        Console.WriteLine(sb.ToString());
    }
}