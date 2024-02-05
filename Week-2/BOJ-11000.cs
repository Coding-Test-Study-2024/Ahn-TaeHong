using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2
{
    internal class BOJ_11000
    {
        static void Main()
        {
            // 입력값 받기
            int N = int.Parse(Console.ReadLine());

            // times는 시작시간이 작은 순으로 수업 시간을 보관한다.
            PriorityQueue<int[], int> times = new PriorityQueue<int[], int>();
            for (int i = 0; i < N; i++)
            {
                string[] line = Console.ReadLine().Split();
                int S = int.Parse(line[0]);
                int T = int.Parse(line[1]);
                times.Enqueue(new int[] { S, T }, S);
            }

            // rooms는 종료시간이 작은 순으로 현제 수업 진행중인 강의실을 보관한다.
            PriorityQueue<int[], int> rooms = new PriorityQueue<int[], int>();
            // 시작시간이 작은 순으로 수업을 하나씩 보면서,
            while (times.Count > 0)
            {
                int[] cur = times.Dequeue();
                int curS = cur[0];
                int curT = cur[1];
                
                if (rooms.Count > 0)
                {
                    // cur의 시작시간이 현제 수업중인 강의실중에 수업을 제일 빠르게 끝나는 강의실보다 늦으면, 강의실이 추가로 필요없다.
                    if (curS >= rooms.Peek()[1])
                    {
                        rooms.Dequeue();
                        rooms.Enqueue(new int[] { curS, curT }, curT);
                    }
                    // 아니면, 강의실이 필요하다.
                    else
                    {
                        rooms.Enqueue(new int[] { curS, curT }, curT);
                    }
                }
                else // 수업중인 강의실이 없으면, 강의실을 추가한다.
                {
                    rooms.Enqueue(new int[] { curS, curT }, curT);
                }
            }

            // 강의실의 개수 출력
            Console.WriteLine(rooms.Count);
        }
    }
}
