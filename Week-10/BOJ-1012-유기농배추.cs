using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

public class Solution
{
    public struct Coordinate
    {
        public int r = 0;
        public int c = 0;

        public Coordinate(int r, int c)
        {
            this.r = r;
            this.c = c;
        }
    }

    static int[] delta_row = { -1, 0, 1, 0 };
    static int[] delta_col = { 0, 1, 0, -1 };

    static int solution(int[,] farm)
    {
        int worms = 0;

        // Find worm count
        for (int r = 0; r < farm.GetLength(0); r++)
        {
            for(int c = 0; c < farm.GetLength(1); c++)
            {
                if (farm[r, c] == 0)
                    continue;

                DestroyChunk(ref farm, new Coordinate(r, c));
                worms++;
            }
        }

        return worms;
    }

    static void DestroyChunk(ref int[,] farm, Coordinate c)
    {
        Queue<Coordinate> queue = new();
        queue.Enqueue(c);
        while (queue.Count > 0)
        {
            Coordinate cur = queue.Dequeue();
            farm[cur.r, cur.c] = 0;

            for (int i = 0; i < 4; i++)
            {
                int neighbor_row = cur.r + delta_row[i];
                int neighbor_col = cur.c + delta_col[i];

                if (neighbor_row < 0 || neighbor_row >= farm.GetLength(0))
                    continue;
                if (neighbor_col < 0 || neighbor_col >= farm.GetLength(1))
                    continue;
                if (farm[neighbor_row, neighbor_col] == 0)
                    continue;

                queue.Enqueue(new Coordinate(neighbor_row, neighbor_col));
            }
        }
    }

    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        // Test Cases
        int T = int.Parse(Console.ReadLine());
        for (int t = 0; t < T; t++)
        {
            string[] split = Console.ReadLine().Split();
            int M = int.Parse(split[0]);
            int N = int.Parse(split[1]);
            int K = int.Parse(split[2]);

            int[,] farm = new int[M, N];
            for (int i = 0; i < K; i++)
            {
                split = Console.ReadLine().Split();
                int r = int.Parse(split[0]);
                int c = int.Parse(split[1]);
                farm[r, c] = 1;
            }

            sb.Append(solution(farm));
            sb.Append('\n');
        }

        Console.WriteLine(sb.ToString());
    }
}