using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2
{
    internal class BOJ_24460
    {
        static void Main()
        {
            // 입력값 받기
            int N = int.Parse(Console.ReadLine());

            // 의자 2차원 배열 생성
            int[,] grid = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                string[] line = Console.ReadLine().Split();
                for (int j = 0; j < N; j++)
                {
                    grid[i, j] = int.Parse(line[j]);
                }
            }

            // 답 출력
            Console.WriteLine(DivideAndConquer(grid, 0, 0, N));
        }

        // 접근방법: 분할정복으로 네 개의 구역을 우선순위큐에다 넣고 하나를 빼면 두번째로 작은 수를 찾을 수 있다
        static int DivideAndConquer(int[,] grid, int sr, int sc, int len)
        {
            // 종료조건은 의자가 하나일때
            if (len == 1)
            {
                return grid[sr, sc];
            }

            // 우선순위큐 생성후 재귀로 구한 네 개의 구역의 두 번째로 작은 값을 입력
            PriorityQueue<int, int> chairs = new PriorityQueue<int, int>();
            int mid = len / 2;
            int topLeft = DivideAndConquer(grid, sr, sc, mid);
            int topRight = DivideAndConquer(grid, sr, sc + mid, mid);
            int bottomLeft = DivideAndConquer(grid, sr + mid, sc, mid);
            int bottomRight = DivideAndConquer(grid, sr + mid, sc + mid, mid);
            chairs.Enqueue(topLeft, topLeft);
            chairs.Enqueue(topRight, topRight);
            chairs.Enqueue(bottomLeft, bottomLeft);
            chairs.Enqueue(bottomRight, bottomRight);

            // 우선순위큐에서 한 값을 빼면 두 번째로 작은 값을 구할수있다
            chairs.Dequeue();
            return chairs.Peek();
        }
    }
}
