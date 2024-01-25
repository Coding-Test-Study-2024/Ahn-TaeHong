using System;
using System.Collections.Generic;
using System.Text;

namespace Baekjoon
{
    /*
    입력:
        0
        1
        3
        2
    출력: 
        -
        - -
        - -   - -         - -   - -
        - -   - -
    */
    class BOJ4779
    {
        static void Main()
        {
            // 스트링빌더를 쓰면 출력이 빠르다
            StringBuilder sb = new StringBuilder();

            string input = Console.ReadLine();
            // 입력값이 
            while (!string.IsNullOrEmpty(input))
            {
                // 입력값 받기
                int N = int.Parse(input);

                // N^3 크기의 int 배열 생성 (0 == '-', 1 == ' ')
                int len = (int)Math.Pow(3, N);
                int[] line = new int[len];

                // 분할 정복으로 가운데 구간을 빈칸(1)로 바꾸기
                Split(line, 0, len - 1);    // T(n) = O(n log n)

                // 출력값을 스트링빌더에 결합
                foreach (int i in line)
                {
                    if (i == 0)
                    {
                        sb.Append('-');
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }
                sb.AppendLine();

                // 입력값 계속 받기
                input = Console.ReadLine();
            }

            // 답 출력
            Console.WriteLine(sb.ToString());
        }

        static void Split(int[] line, int left, int right)
        {
            // 종료조건은 현제 크기가 1일때
            if (left >= right)
            {
                return;
            }

            // 영역 나누기
            // int[len] = [left ----- ][midLeft ----- midRight][ ----- right]
            int len = right - left + 1;
            int sectionSize = len / 3;
            int midLeft = left + sectionSize;
            int midRight = right - sectionSize;

            // 가운데 구간 지우기
            for (int i = midLeft; i <= midRight; i++)
            {
                line[i] = 1;
            }

            // 남은 구간에 반복하기
            Split(line, left, midLeft - 1);
            Split(line, midRight + 1, right);
        }
    }
}