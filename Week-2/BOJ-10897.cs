using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace Baekjoon
{
    class Programs
    {
        const int M = 1000000007;
        static void Main()
        {
            // 입력값 받기
            int N = int.Parse(Console.ReadLine());
            string[] line = Console.ReadLine().Split();

            //
            StringBuilder sb = new StringBuilder();
            int gen = 0;
            int curLineFirst = 0;
            int curLineLen = 1;
            int parentOrder = 0;
            for (int i = 0; i < N; i++)
            {
                int nthChild = int.Parse(line[i]) - 1;
                int childrenToBeBorn = (gen + 1);

                curLineFirst = (curLineLen + curLineFirst) % M;
                curLineLen *= childrenToBeBorn;
                int jeongmin = (curLineFirst + (parentOrder * childrenToBeBorn) + nthChild) % M;
                sb.Append(jeongmin);
                sb.AppendLine();

                parentOrder = nthChild;
                gen++;
            }

            // 답 출력
            Console.WriteLine(sb.ToString());
        }
    }
}