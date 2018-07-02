using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class BinarySearch
    {
        public static int MyBSearch(int[] arr, int left, int right, int value)
        {
            if (right >= left)
            {
                int pos = left + (right - left) / 2;

                if (arr[pos] == value)
                {
                    return pos;
                }

                if (value < arr[pos])
                {
                    return MyBSearch(arr, left, pos - 1, value);
                }
                else if (value > arr[pos])
                {
                    return MyBSearch(arr, pos + 1, right, value);
                }
            }
            return -1;
        }
    }
}
