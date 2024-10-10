using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    static SortedSet<string> solution(string[] deuddo, string[] bodo)
    {
        SortedSet<string> result = new();

        // HashSet로 듣도못한 이름들 보관
        HashSet<string> set = new(deuddo);

        // 보도못한 이름들을 보면서 HashSet에 있으면 듣보잡임
        foreach (string b in bodo)
        {
            if (set.Contains(b))
                result.Add(b);
        }

        return result;
    }

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        // 입력
        string[] split = Console.ReadLine().Split();
        int N = int.Parse(split[0]);
        int M = int.Parse(split[1]);
        string[] deuddo = new string[N];
        string[] bodo = new string[M];
        for(int i = 0; i < N; i++)
        {
            deuddo[i] = Console.ReadLine();
        }
        for (int i = 0; i < M; i++)
        {
            bodo[i] = Console.ReadLine();
        }

        // 출력
        SortedSet<string> deudbo = solution(deuddo, bodo);
        sb.Append(deudbo.Count);
        sb.AppendLine();
        foreach (string b in deudbo)
        {
            sb.Append(b);
            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString());
    }
}