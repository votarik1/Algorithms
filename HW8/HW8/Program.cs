using System;

namespace HW8
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[100];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 100);
            }
            Print(arr);
            Print(MySorts.ExternalSort(arr, 11));
            Print(MySorts.BucketSort(arr, 7));
        }

        public static void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

    }
}
