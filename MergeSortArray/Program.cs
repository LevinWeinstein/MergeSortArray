using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortArray
{
    class Program
    {
        static void PrintArray(int[] arr, int size)
        {
            Console.Write("Array: ");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }

        static void Merge(int[] arr, int left, int middle, int right)
        {
            int[] arr1 = new int[middle + 1 - left];
            int[] arr2 = new int[right - middle];


            // Array.Copy(fromArray, fromArrayIndex, toArray, toArrayIndex, length)
            Array.Copy(arr, left, arr1, 0, middle + 1 - left);
            Array.Copy(arr, middle + 1, arr2, 0, right - middle);

            int arr1pos = arr1.Length - 1;
            int arr2pos = arr2.Length - 1;

            int placementPosition = right;

            while (placementPosition >= left && arr2pos >= 0 && arr1pos >= 0)
            {
                if (arr1[arr1pos] > arr2[arr2pos])
                {
                    arr[placementPosition] = arr1[arr1pos--];
                }
                else
                {
                    arr[placementPosition] = arr2[arr2pos--];
                }
                placementPosition--;
            }

            while (arr1pos >= 0) arr[placementPosition--] = arr1[arr1pos--];
            while (arr2pos >= 0) arr[placementPosition--] = arr2[arr2pos--];

        }

        static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int mid = l + (r - l) / 2;
                MergeSort(arr, l, mid);
                MergeSort(arr, mid + 1, r);
                Merge(arr, l, mid, r);

            }

        }

        static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        static void test(int[] array)
        {
            array.ToList().Select(x => x.ToString()).ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();
            MergeSort(array);
            array.ToList().Select(x => x.ToString()).ToList().ForEach(x => Console.Write($"{x} "));
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            int[] test1 = new int[] { 4, 22, 19, 5 };
            int[] test2 = new int[] { 1, 4, 2, 5, 3, 6 };
            int[] test3 = new int[] { 1 };
            int[] test4 = new int[] { 1, 2, 3, 4, 5 };
            int[] test5 = new int[] { 5, 4, 3, 2, 1 };

            test(test1);
            test(test2);
            test(test3);
            test(test4);
            test(test5);
        }
    }
}
