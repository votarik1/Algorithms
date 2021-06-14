using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    public class Serch
    {

        public static int Binsearch(int[] arr, int value) // O(log(n))
        {
            int min = 0;
            int max = arr.Length - 1;
            while (min<=max)
            {
                int mid = (max + min) / 2;
                if (arr[mid] == value)
                {
                    return mid;
                }
                else if (arr[mid] > value)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }

            }
            return -1;
        }

    }
}
