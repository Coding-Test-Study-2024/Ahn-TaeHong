using System;
using System.Collections.Generic;
using System.Text;

namespace Baekjoon
{
    // https://www.acmicpc.net/problem/2583
    class BJ2583
    {
        static void Main()
        {
            // 입력값 파싱
            StringBuilder sb = new StringBuilder();
            string[] args = Console.ReadLine().Split();
            int M = int.Parse(args[0]);
            int N = int.Parse(args[1]);
            int K = int.Parse(args[2]);

            // 빈종이 생성
            int[,] page = new int[N, M];
            // 종이에 직사각형 표시하기
            for (int i = 0; i < K; i++)
            {
                string[] rec = Console.ReadLine().Split();
                int x1 = int.Parse(rec[0]);
                int y1 = int.Parse(rec[1]);
                int x2 = int.Parse(rec[2]);
                int y2 = int.Parse(rec[3]);

                for (int r = x1; r < x2; r++)
                {
                    for (int c = y1; c < y2; c++)
                    {
                        page[r, c] = 1; //그려진 좌표에 1 표시
                    }
                }
            }

            //빈 영역 찾기
            List<int> spaces = new List<int>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (page[i, j] == 0) //빈칸을 찾으면 그 영역의 크기를 배열에 보관
                    {
                        spaces.Add(GetSpace(page, i, j));
                    }
                }
            }
            spaces.Sort(); // 영역 넓이를 오름차순으로 정렬

            // 답 출력
            sb.AppendLine(spaces.Count.ToString());
            foreach (int i in spaces)
            {
                sb.Append(i.ToString());
                sb.Append(" ");
            }
            sb.AppendLine();
            Console.Write(sb.ToString());
        }

        // bfs로 영역의 크기 찾기
        public static int GetSpace(int[,] page, int r, int c)
        {
            int count = 0;

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { r, c });
            int[] dx = { 0, -1, 0, 1 };
            int[] dy = { -1, 0, 1, 0 };
            while (queue.Count > 0)
            {
                List<int[]> neighbors = new List<int[]>();
                while (queue.Count > 0)
                {
                    neighbors.Add(queue.Dequeue());
                }
                foreach (int[] n in neighbors)
                {
                    if (n[0] < 0 || n[1] < 0 || n[0] >= page.GetLength(0) || n[1] >= page.GetLength(1) || page[n[0], n[1]] == 1)
                    {
                        continue;
                    }
                    else
                    {
                        count++;
                        page[n[0], n[1]] = 1;
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        int newX = n[0] + dx[i];
                        int newY = n[1] + dy[i];
                        queue.Enqueue(new int[] { newX, newY });
                    }
                }
            }

            return count;
        }
    }
}