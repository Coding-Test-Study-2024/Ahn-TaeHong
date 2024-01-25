using System;
using System.Collections.Generic;
using System.Text;

namespace Baekjoon
{
    /*
    입력:
        6 9
        -||--||--
        --||--||-
        |--||--||
        ||--||--|
        -||--||--
        --||--||-
    출력: 
        31
    */
    class BOJ1388
    {
        static void Main()
        {
            // 입력값 받기
            string[] input = Console.ReadLine().Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            // 판자 찾을 때마다 count에 1 더함
            int count = 0;

            // 가로 판자 찾고, 세로 판자 찾기 위해 배열 사용
            bool[] vertical_started = new bool[M];
            for (int r = 0; r < N; r++)   // T(n) = O(n^2)
            {
                string line = Console.ReadLine();
                bool horizontal_started = false;
                for (int c = 0; c < M; c++)
                {
                    char cur = line[c];

                    // '-'일 경우
                    if (cur == '-')
                    {
                        if (!horizontal_started)  // 가로 판자 시작점 찾으면 count++
                        {
                            count++;
                            horizontal_started = true;
                        }
                        if (vertical_started[c])  // 세로 판자 끝나서 상태 초기화
                        {
                            vertical_started[c] = false;
                        }
                    }
                    // '|'일 경우
                    else
                    {
                        if (horizontal_started)   // 가로 판자 끝나서 상태 초기화
                        {
                            horizontal_started = false;
                        }
                        if (!vertical_started[c]) // 세로 판자 시작점 찾으면 count++
                        {
                            count++;
                            vertical_started[c] = true;
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}