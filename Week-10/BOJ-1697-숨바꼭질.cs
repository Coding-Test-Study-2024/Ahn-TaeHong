using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    static int solution(int pos, int target)
    {
        int count = 0;
        Queue<int> queue = new(); // BFS용 큐
        bool[] visited = new bool[100001]; // DP용 배열
        queue.Enqueue(pos); 
        while (true) // 잡을 때까지 집 안간다
        {
            int curLevelCount = queue.Count; // 이번 시간에 확인해야할 숫자들
            for(int i = 0; i < curLevelCount; i++)
            {
                int cur = queue.Dequeue();


                if (cur == target) // 잡았다 요놈
                    return count;
                if (cur < 0 || cur > 100000 || visited[cur]) // 예외처리
                    continue;
                else
                    visited[cur] = true; // 방문기록

                // 다음 시간을 위한 숫자 모두 추가
                queue.Enqueue(cur - 1);
                queue.Enqueue(cur + 1);
                queue.Enqueue(cur * 2);
            }
            count++; // 시간 1초 추가
        }
    }

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        // 입력
        string[] split = Console.ReadLine().Split();
        int N = int.Parse(split[0]);
        int K = int.Parse(split[1]);

        sb.Append(solution(N, K));

        Console.WriteLine(sb.ToString());
    }
}