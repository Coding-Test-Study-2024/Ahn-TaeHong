using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2
{
    internal class BOJ_2630
    {
        static void Main()
        {
            // 입력값 받기
            int N = int.Parse(Console.ReadLine());

            // 종이 생성
            int[,] paper = new int[N, N];
            for (int r = 0; r < N; r++)
            {
                string[] line = Console.ReadLine().Split();
                for (int c = 0; c < N; c++)
                {
                    paper[r, c] = int.Parse(line[c]);
                }
            }

            // 분할정복으로 답 구하고 출력
            int blues = 0;
            int whites = 0;
            dfs(paper, ref blues, ref whites);
            Console.WriteLine(whites);
            Console.WriteLine(blues);
        }

        // 분할정복 : 재귀로 종이를 4등분하고 같은 색인지 확인. 같은 색이면 그 색의 개수에 더함.
        static void dfs(int[,] paper, ref int blues, ref int whites)
        {
            if (IsFilled(paper) == 1)
            {
                blues++;
                return;
            }
            else if (IsFilled(paper) == 0)
            {
                whites++;
                return;
            }

            // 입력된 종이를 4등분
            int subRows = paper.GetLength(0) / 2;
            int subCols = paper.GetLength(1) / 2;
            int[,] subArray1 = GetSubArray(paper, 0, 0, subRows, subCols);
            int[,] subArray2 = GetSubArray(paper, 0, subCols, subRows, subCols);
            int[,] subArray3 = GetSubArray(paper, subRows, 0, subRows, subCols);
            int[,] subArray4 = GetSubArray(paper, subRows, subCols, subRows, subCols);

            // 4등분된 종이들에 재귀
            dfs(subArray1, ref blues, ref whites);
            dfs(subArray2, ref blues, ref whites);
            dfs(subArray3, ref blues, ref whites);
            dfs(subArray4, ref blues, ref whites);
        }

        // 종이가 같은 색이면 true, 아니면 false
        static int IsFilled(int[,] paper)
        {
            if (paper.Length == 0)
            {
                return -1;
            }
            int color = paper[0, 0];
            for (int r = 0; r < paper.GetLength(0); r++)
            {
                for (int c = 0; c < paper.GetLength(1); c++)
                {
                    if (paper[r, c] != color)
                    {
                        return -1;
                    }
                }
            }
            return color;
        }

        // 4등분을 하기 위한 함수
        static int[,] GetSubArray(int[,] original, int startRow, int startCol, int subRows, int subCols)
        {
            int[,] subArray = new int[subRows, subCols];

            for (int i = 0; i < subRows; i++)
            {
                for (int j = 0; j < subCols; j++)
                {
                    subArray[i, j] = original[startRow + i, startCol + j];
                }
            }

            return subArray;
        }
    }
}
