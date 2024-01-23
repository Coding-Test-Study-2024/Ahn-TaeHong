using System;
using System.Collections.Generic;
using System.Text;

namespace Baekjoon
{
    // https://www.acmicpc.net/problem/10026
    class BJ10026
    {
        static void Main()
        {
            // 입력값 파싱
            StringBuilder sb = new StringBuilder();
            int N = int.Parse(Console.ReadLine());

            // 일반인이 보는 그림 
            string[,] normalPainting = new string[N, N];
            // 적록색약인 사람이 보는 그림
            string[,] blindPainting = new string[N, N];
            // 그림별로 색칠하기
            for (int r = 0; r < N; r++)
            {
                string line = Console.ReadLine();
                for (int c = 0; c < N; c++)
                {
                    normalPainting[r, c] = line[c].ToString();
                    if (line[c].ToString() == "G") // 적록색약인 사람은 초록이 빨강이랑 똑같다
                    {
                        blindPainting[r, c] = "R";
                    }
                    else
                    {
                        blindPainting[r, c] = line[c].ToString();
                    }
                }
            }

            // 그림별로 따로 영역 찾고 개수 구하기
            int normal = 0;
            int blind = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (normalPainting[i, j] != "X")
                    {
                        GetSpace(normalPainting, i, j);
                        normal++;
                    }
                    if (blindPainting[i, j] != "X")
                    {
                        GetSpace(blindPainting, i, j);
                        blind++;
                    }
                }
            }

            // 답 출력
            sb.Append(normal.ToString());
            sb.Append(" ");
            sb.Append(blind.ToString());
            Console.Write(sb.ToString());
        }

        // bfs로 영역의 크기 찾기
        public static void GetSpace(string[,] painting, int r, int c)
        {
            int count = 0;
            string color = painting[r, c];

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
                    if (n[0] < 0 || n[1] < 0 || n[0] >= painting.GetLength(0) || n[1] >= painting.GetLength(1) || painting[n[0], n[1]] != color)
                    {
                        continue;
                    }
                    else
                    {
                        count++;
                        painting[n[0], n[1]] = "X";
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        int newX = n[0] + dx[i];
                        int newY = n[1] + dy[i];
                        queue.Enqueue(new int[] { newX, newY });
                    }
                }
            }
        }
    }
}