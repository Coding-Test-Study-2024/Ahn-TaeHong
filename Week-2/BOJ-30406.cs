using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2
{
    internal class BOJ_30406
    {
        static void Main()
        {
            // 입력값 받기
            int N = int.Parse(Console.ReadLine());
            string[] line = Console.ReadLine().Split();

            // 선물 가격 해시 테이블 생성
            Dictionary<int, int> gifts = new Dictionary<int, int>();
            foreach (string s in line)
            {

                if (gifts.ContainsKey(int.Parse(s)))
                {
                    gifts[int.Parse(s)]++;
                }
                else
                {
                    gifts.Add(int.Parse(s), 1);
                }
            }

            // 접근법: 남은 선물 중에 제일 높은 만족도를 찾아서 합에 더한다.
            int sum = 0;
            while (gifts.Count > 0)
            {
                // 현제까지 가장 만족도가 높은 선물 짝을 gift에 보관한다
                int[] gift = new int[2];

                // 모든 선물을 보면서 가장 높은 짝을 찾는다
                foreach (int e in gifts.Keys)
                {
                    // 시간 단축을 위해 현제까지 가장 높은 만족도 보다 작은 짝은 무시
                    int curMax = gift[0] ^ gift[1];
                    for (int i = 3; i >= curMax; i--)
                    {
                        // XOR 연산을 이용해 더 큰 짝이 있는지 확인한다.
                        if (gifts.ContainsKey(e ^ i))
                        {
                            gift = new int[] { e, e ^ i };
                            break;
                        }
                    }
                }

                // 이 시점에는 gift가 최대 만족도인걸 알아서 sum에 더하고 해시테이블에서 제거한다.
                sum += gift[0] ^ gift[1];
                TrySubtract(gifts, gift[0]);
                TrySubtract(gifts, gift[1]);
            }

            // 답 출력
            Console.WriteLine(sum);
        }

        // 해시테이블에서 키의 값을 1 빼고 0이 되면 알아서 제거해줌
        static void TrySubtract(Dictionary<int, int> dict, int key)
        {
            dict[key]--;
            if (dict[key] == 0)
            {
                dict.Remove(key);
            }
        }
    }
}
