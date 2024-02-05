using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2
{
    internal class BOJ_12904
    {
        static void Main()
        {
            // 입력값 받기
            string S = Console.ReadLine();
            string T = Console.ReadLine();

            // S, T를 정수 리스트 형태로 변환한다 (A == 0, B == 1)
            List<int> start = new List<int>();
            List<int> target = new List<int>();
            foreach (char c in S)
            {
                if (c == 'A')
                {
                    start.Add(0);
                }
                else
                {
                    start.Add(1);
                }
            }
            foreach (char c in T)
            {
                if (c == 'A')
                {
                    target.Add(0);
                }
                else
                {
                    target.Add(1);
                }
            }

            // 접근법: 문제를 처음 볼 때, 아마도 S를 T로 어떻게 바꿀지를 생각할 것이다.
            //        하지만, 그러면 A를 추가하는 상황과 B를 추가하는 상황을 둘 다 고려해야 한다. 
            //        반대로 T를 S로 변환하면, 뒤에있는 글자를 보고 마지막으로 어떤 글자가 추가되었는지 알 수가 있다.
            //        그래서, T가 S의 길이와 같을 때까지 마지막 글자에 따라 한글자씩 제거하고 S와T가 같은지 확인한다. 
            while (target.Count > start.Count)
            {
                // 마지막 글자가 A면, A를 제거하기
                if (target.Last<int>() == 0)
                {
                    target.RemoveAt(target.Count - 1);
                }
                // 마지막 글자가 B면, B를 제거하고 뒤집기
                else
                {
                    target.RemoveAt(target.Count - 1);
                    target.Reverse();
                }
            }
            Console.WriteLine(Convert.ToInt32(ListEquals(start, target)));
        }

        // C#에 리스트 Equals 함수가 없어서 직접 만듦
        static bool ListEquals(List<int> list1, List<int> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }
            bool equals = true;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
