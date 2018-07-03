using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class SearchingAlgorithms
    {
        public static int LinearSearch(int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == value)
                    return arr[i];
            }

            return -1;
        }
        public static int BinarySearch(int[] arr, int value)
        {
            int right = 0;
            int left = arr.Length - 1;

            while (left > right)
            {
                int mid = right + (left - right) / 2;
                if (arr[mid] == value)
                    return arr[mid];

                if (value < arr[mid] )
                {
                    left = mid - 1;
                }
                else
                {
                    right = mid + 1;
                }
            }
            return -1;
        }

    }
}
