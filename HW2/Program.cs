using System;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i*10;
            }


            foreach (var item in a)
            {
                Console.WriteLine(item);
            }


        }
    }
}
