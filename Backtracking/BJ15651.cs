using System.Text;

namespace Backtracking
{
    // https://www.acmicpc.net/problem/15651
    class BJ15651
    {
        static void Main()
        {
            // 입력값 파싱
            string[] args = Console.ReadLine().Split();
            int N = int.Parse(args[0]);
            int M = int.Parse(args[1]);
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= N; i++)
            {
                sb.Append(i);
            }
            string nums = sb.ToString();
            sb.Clear();

            // DFS로 모든 순열 찾고 스트링빌더에 삽입후 출력
            dfs("", 0, nums, M, sb);
            Console.WriteLine(sb.ToString());
        }

        static void dfs(string cur, int count, string nums, int len, StringBuilder sb)
        {
            if (count == len)
            {
                sb.Append(cur);
                sb.Append("\n");
                return;
            }
            foreach (char n in nums)
            {
                StringBuilder temp = new StringBuilder(cur);
                temp.Append(n);
                temp.Append(" ");
                dfs(temp.ToString(), count + 1, nums, len, sb);
            }
        }
    }
}
