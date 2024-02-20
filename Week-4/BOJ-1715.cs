using System;
using System.Collections.Generic;
using Internal;

namespace Baekjoon
{
    class Program
    {
        static void Main()
        {
            // 입력값 받고 우선순위큐에 입력하기
            int N = int.Parse(Console.ReadLine());
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            for (int i = 0; i < N; i++)
            {
                int n = int.Parse(Console.ReadLine());
                pq.Enqueue(n, n);
            }


            // 그리디 : 제일 작은 묶음 2개를 골라서 합친 후 비교 개수에 더하고 다시 큐에 넣어놓기
            int ans = 0;
            while (pq.Count >= 2)
            {
                int n1 = pq.Dequeue();
                int n2 = pq.Dequeue();
                int sum = n1 + n2;
                ans += sum;
                pq.Enqueue(sum, sum);
            }
            Console.WriteLine(ans);
        }
    }
}