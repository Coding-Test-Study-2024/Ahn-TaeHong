using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearch
{
    // https://www.acmicpc.net/problem/7576

    class BJ7576
    {
        static void Main()
        {
            string[] args = Console.ReadLine().Split();
            int C = int.Parse(args[0]);
            int R = int.Parse(args[1]);

            int[,] farm = new int[R, C];
            Queue<int[]> ripes = new Queue<int[]>();

            // 익은 토마토를 큐에 보관
            for (int r = 0; r < R; r++)
            {
                string[] row = Console.ReadLine().Split();
                for (int c = 0; c < C; c++)
                {
                    farm[r, c] = int.Parse(row[c]);
                    if (farm[r, c] == 1)
                    {
                        ripes.Enqueue(new int[] { r, c });
                    }
                }
            }

            int days = -1;
            // 이미 익은 토마토마다 옆에 있는 토마토 익히기
            while (ripes.Count > 0)
            {
                List<int[]> today = new List<int[]>();
                days++;
                while (ripes.Count > 0)
                {
                    today.Add(ripes.Dequeue());
                }
                foreach (var ripe in today)
                {
                    int r = ripe[0];
                    int c = ripe[1];
                    if (r > 0) //Up
                    {
                        if (farm[r - 1, c] == 0)
                        {
                            farm[r - 1, c] = 1;
                            ripes.Enqueue(new int[] { r - 1, c });
                        }
                    }
                    if (r < R - 1) //Down
                    {
                        if (farm[r + 1, c] == 0)
                        {
                            farm[r + 1, c] = 1;
                            ripes.Enqueue(new int[] { r + 1, c });
                        }
                    }
                    if (c > 0) //Left
                    {
                        if (farm[r, c - 1] == 0)
                        {
                            farm[r, c - 1] = 1;
                            ripes.Enqueue(new int[] { r, c - 1 });
                        }
                    }
                    if (c < C - 1) //Right
                    {
                        if (farm[r, c + 1] == 0)
                        {
                            farm[r, c + 1] = 1;
                            ripes.Enqueue(new int[] { r, c + 1 });
                        }
                    }
                }
            }

            //안익은 토마토가 있는지 확인
            bool unripeExists = false;
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (farm[r, c] == 0)
                    {
                        unripeExists = true;
                        break;
                    }
                }
                if (unripeExists)
                {
                    break;
                }
            }

            if (unripeExists)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(days);
            }
        }
    }
}
