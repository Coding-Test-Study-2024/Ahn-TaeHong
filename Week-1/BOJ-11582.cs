using System;
using System.Collections.Generic;
using System.Text;

namespace Baekjoon
{
    /*
    입력:
        8
        1 5 2 4 2 9 7 3
        2
    출력:
        1 2 4 5 2 3 7 9
    */
    class BOJ11582
    {
        public static int k;
        public static int N;
        static void Main()
        {
            // 입력값 받기
            N = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            int[] nums = new int[N];
            for (int i = 0; i < N; i++)
            {
                nums[i] = int.Parse(input[i]);
            }
            k = int.Parse(Console.ReadLine());

            // 병합 정렬
            MergeSort(nums, 0, nums.Length - 1); // T(n) = O(n log n)

            // 답 출력
            StringBuilder sb = new StringBuilder();
            foreach (int i in nums)
            {
                sb.Append(i);
                sb.Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }
        public static void MergeSort(IList<int> list, int left, int right)
        {
            if (left == right)
            {
                return;
            }
            int mid = (left + right) / 2;
            MergeSort(list, left, mid);
            MergeSort(list, mid + 1, right);

            // 헌제 정렬을 하는 회원 수(X) = 치킨집 총 개수(N) / 현제 회원이 정렬하는 치킨집 개수(C)
            int C = (right - left + 1);
            int X = N / C;
            // 현제 단계 회원수(X)가 원하는 단계(k) 보다 클때만 병합해야 원하는 답이 나온다
            if (X >= k)
            {
                Merge(list, left, mid, right);
            }
        }
        private static void Merge(IList<int> list, int left, int mid, int right)
        {
            int l = left;
            int r = mid + 1;
            List<int> merged = new List<int>();
            while (l <= mid && r <= right)
            {
                if (list[l] < list[r])
                {
                    merged.Add(list[l++]);
                }
                else
                {
                    merged.Add(list[r++]);
                }
            }
            while (l <= mid)
            {
                merged.Add(list[l++]);
            }
            while (r <= right)
            {
                merged.Add(list[r++]);
            }

            for (int i = 0; i < merged.Count; i++)
            {
                list[left + i] = merged[i];
            }
        }
    }
}