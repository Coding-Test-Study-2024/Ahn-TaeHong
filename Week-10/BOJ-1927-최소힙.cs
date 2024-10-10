using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    static StringBuilder sb = new StringBuilder();

    public class MinHeap
    {
        List<int> heap = new List<int>();

        public void Insert(int x)
        {
            heap.Add(x);
            int newIdx = heap.Count - 1;
            while (newIdx > 0 && heap[newIdx] < heap[(newIdx - 1) / 2])
            {
                Swap(newIdx, (newIdx - 1) / 2);
                newIdx = (newIdx - 1) / 2;
            }
        }

        public int Peek()
        {
            if (heap.Count == 0)
                return 0;

            int value = heap[0];
            Delete();
            return value;
        }

        private void Delete()
        {
            int lastIdx = heap.Count - 1;
            Swap(lastIdx, 0);
            heap.RemoveAt(lastIdx);

            int curIdx = 0;
            while (true)
            {
                int leftChild = curIdx * 2 + 1;
                int rightChild = curIdx * 2 + 2;

                int smallest = curIdx;
                if (leftChild < heap.Count && heap[leftChild] < heap[smallest])
                {
                    smallest = leftChild;
                }
                if (rightChild < heap.Count && heap[rightChild] < heap[smallest])
                {
                    smallest = rightChild;
                }

                if(smallest != curIdx)
                {
                    Swap(smallest, curIdx);
                    curIdx = smallest;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int x, int y)
        {
            int temp = heap[y];
            heap[y] = heap[x];
            heap[x] = temp;
        }
    }

    static void solution(int[] input)
    {
        MinHeap heap = new MinHeap();

        foreach (int x in input)
        {
            if (x == 0)
                sb.Append($"{heap.Peek()}\n");
            else
                heap.Insert(x);
        }
    }

    static void Main()
    {
        // 입력
        int N = int.Parse(Console.ReadLine());
        int[] input = new int[N];
        for(int i = 0; i < N; i++)
        {
            input[i] = int.Parse(Console.ReadLine());
        }

        solution(input);

        // 출력
        Console.WriteLine(sb.ToString());
    }
}