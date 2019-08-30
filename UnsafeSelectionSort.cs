using System;

namespace UnsafeSelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 1, 5, 2, 0, -5, -4, -1, 4 };

            SelectionSort(arr);

            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        }

        static unsafe void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                fixed (int* first = &arr[i], second = &arr[minIndex])
                {
                    Swap(first, second);
                }
            }
        }

        static unsafe void Swap(int* a, int *b)
        {
            int temp = *a;
            *a = *b;
            *b = temp;
        }
    }
}
