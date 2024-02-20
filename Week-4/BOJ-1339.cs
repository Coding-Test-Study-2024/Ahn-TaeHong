using System;
using System.Collections.Generic;

namespace Baekjoon
{
    class Program
    {
        static void Main()
        {
            // 입력값 받기
            int N = int.Parse(Console.ReadLine());
            string[] strs = new string[N];
            for(int i = 0; i < N; i++)
            {
                strs[i] = Console.ReadLine();
            }

            // 문자열들을 보면서 글자를 볼때마다 딕셔너리에 자릿수만큼 값을 더하기
            // Ex) AB => A += 10, B += 1
            Dictionary<char, int> vals = new Dictionary<char, int>();
            for(int i = 0; i < strs.Length; i++)
            {
                string s = strs[i];
                int units = 1; // 자릿수
                while (s.Length > 0)
                {
                    int lastIndex = s.Length - 1;
                    if (vals.ContainsKey(s[lastIndex]))
                    {
                        vals[s[lastIndex]] += units;
                    }
                    else
                    {
                        vals.Add(s[lastIndex], units);
                    }
                    s = s.Substring(0, lastIndex);
                    units *= 10;
                }
            }

            // 딕셔너리를 글자의 합 내림순으로 우선순위큐에 입력
            PriorityQueue<char, int> chars = new PriorityQueue<char, int>();
            foreach(var e in vals)
            {
                chars.Enqueue(e.Key, -e.Value);
            }

            // 우선순위큐에서 글자를 꺼낼때마다 글자의 숫자를 정해준다
            // Ex) A = 100 => A = 9 , B = 50 => B = 8 , C = 10 => C = 7 
            int next = 9;
            Dictionary<char, int> charVals = new Dictionary<char, int>(); 
            while(chars.Count > 0)
            {
                char cur = chars.Dequeue();
                charVals.Add(cur, next--);
            }

            // 글자들의 숫자값을 알고있으니까 문자열을 숫자로 바꿔서 합에 더하기
            int sum = 0;
            for (int i = 0; i < strs.Length; i++)
            {
                string s = strs[i];
                int cur = 0;
                int units = 0;
                while (s.Length > 0)
                {
                    char c = s[s.Length - 1];
                    cur += charVals[c] * (int)MathF.Pow(10, units++);
                    s = s.Substring(0, s.Length - 1);
                }
                sum += cur;
            }

            Console.WriteLine(sum);
        }
    }
}