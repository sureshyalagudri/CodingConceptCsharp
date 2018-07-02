using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SortingAlgorithms
    {
        /// <summary>
        /// Selection sort is an algorithm of sorting an array where it loop 
        /// from the start of the loop, and check through other elements to 
        /// find the minimum value.After the end of the first iteration, 
        /// the minimum value is swapped with the current element.
        /// The iteration then continues from the 2nd element and so on.
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(ref int[] arr)
        {
            int temp, min;
            for (int j = 0; j < arr.Length - 1; j++)
            {
                min = j;
                for (int k = j + 1; k < arr.Length; k++)
                {
                    if (arr[k] < arr[min])
                    {
                        min = k;
                    }
                }
                // Let's Swap.
                temp = arr[min];
                arr[min] = arr[j];
                arr[j] = temp;
            }
        }

        /// <summary>
        /// The Insertion sort algorithm views the data in two halves.
        /// The left half of sorted elements and the right half of elements to be sorted.
        /// In each iteration, one element from the right half is taken and added to the left 
        /// half so that the left half is still sorted.
        /// Insertion sort is of order O(n2)
        /// Insertion sort takes an element from the list and places it in the correct location in the list.
        /// This process is repeated until there are no more unsorted items in the list.
        /// </summary>
        /// <param name="data"></param>
        public static void InsertionSort(ref int[] data)
        {
            int i = 0, j = 0;
            for (i = 1; i < data.Length; i++)
            {
                int item = data[i];
                int ins = 0;
                for (j = i - 1; j >= 0 && ins != 1;)
                {
                    if (item < data[j])
                    {
                        data[j + 1] = data[j];
                        j--;
                        data[j + 1] = item;
                    }
                    else
                    {
                        ins = 1;
                    }
                }
            }
        }

        /// <summary>
        /// it divides its input into a sorted and an unsorted region, 
        /// and it iteratively shrinks the unsorted region by extracting 
        /// the largest element and moving that to the sorted region
        /// It first removes the topmost item(the largest) and replace 
        /// it with the rightmost leaf.The topmost item is stored in an 
        /// array and Re-establish the heap.this is done until there 
        /// are no more items left in the heap
        /// </summary>
        /// <param name="arr"></param>
        public static void HeapSort(ref int[] arr)
        {
            int i, t;
            for (i = 5; i >= 0; i--)
            {
                adjust(i, 9, ref arr);
            }
            for (i = 8; i >= 0; i--)
            {
                t = arr[i + 1];
                arr[i + 1] = arr[0];
                arr[0] = t;
                adjust(0, i, ref arr);
            }
        }
        private static void adjust(int i, int n, ref int[] arr)
        {
            int t, j;
            try
            {
                t = arr[i];
                j = 2 * i;
                while (j <= n)
                {
                    if (j < n && arr[j] < arr[j + 1])
                        j++;
                    if (t >= arr[j])
                        break;
                    arr[j / 2] = arr[j];
                    j *= 2;
                }
                arr[j / 2] = t;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Array Out of Bounds ", e);
            }
        }


        /// <summary>
        /// Merge Sort is one of the popular sorting algorithms in C# as it uses the minimum number of comparisons.
        /// The idea behind merge sort is that it is merging two sorted lists.
        /// Merge sort is of order O(nlogn)
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void MergeSort(ref int[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort(ref numbers, left, mid);
                MergeSort(ref numbers, (mid + 1), right);
                DoMerge(ref numbers, left, (mid + 1), right);
            }
        }
        private static void DoMerge(ref int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }


        /// <summary>
        /// Quicksort is a divide and conquer algorithm. 
        /// Here Quicksort first divides a large array into two smaller sub-array: 
        /// the low elements and the high elements. Quicksort can then recursively sort the sub-arrays
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSort(ref int[] arr)
        {
            sort(ref arr, 0, arr.Length - 1);
        }
        private static void sort(ref int[] arr, int left, int right)
        {
            int pivot, leftend, rightend;

            leftend = left;
            rightend = right;
            pivot = arr[left];

            while (left < right)
            {
                while ((arr[right] >= pivot) && (left < right))
                {
                    right--;
                }

                if (left != right)
                {
                    arr[left] = arr[right];
                    left++;
                }

                while ((arr[left] >= pivot) && (left < right))
                {
                    left++;
                }

                if (left != right)
                {
                    arr[right] = arr[left];
                    right--;
                }
            }

            arr[left] = pivot;
            pivot = left;
            left = leftend;
            right = rightend;

            if (left < pivot)
            {
                sort(ref arr, left, pivot - 1);
            }
            else
            {
                sort(ref arr, pivot + 1, right);
            }
        }

        /// <summary>
        /// Bubble sort changes the postion of numbers or changing 
        /// an unordered sequence into an ordered sequence.
        /// Bubble sort follows a simple logic.It compares 
        /// adjacent elements in a loop and swaps them if they are not in order.
        /// Bubble sort is named this way because, in this sorting method, 
        /// the smaller elements gradually bubble up to the top of the list.
        /// Bubble sort has worst-case and average complexity both О(n2), 
        /// where n is the number of items being sorted.
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(ref int[] arr)
        {
            int t;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        t = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = t;
                    }
                }
            }
        }
    }
}
