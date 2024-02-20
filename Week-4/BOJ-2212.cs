using System;
using System.Collections.Generic;
using Internal;

namespace Baekjoon
{
    class Program
    {
        static void Main()
        {
            // 입력값 받기
            int N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());
            string[] line = Console.ReadLine().Split(" ");
            List<int> sensors = new List<int>();
            foreach (string s in line)
            {
                sensors.Add(int.Parse(s));
            }

            if (sensors.Count == 1)
            {
                Console.WriteLine(0);
                return;
            }

            // 센서 좌표 정렬
            sensors.Sort();

            // 각 좌표사이 거리를 우선순위큐에 입력 후 
            int ans = 0;
            PriorityQueue<int, int> diffs = new PriorityQueue<int, int>();
            for (int i = 0; i < sensors.Count - 1; i++)
            {
                int diff = sensors[i + 1] - sensors[i];
                ans += diff;
                diffs.Enqueue(diff, -diff);
            }

            // (K - 1)개의 가장 큰 거리를 빼기
            for (int i = 0; i < K - 1; i++)
            {
                ans -= diffs.Dequeue();
            }

            Console.WriteLine(ans);
        }
    }
}