using System;
using System.Collections.Generic;

namespace SortingAlgorithms;

public class Sorter
{
    // Bubble Sort
    /// <summary>
    /// <para>Description: Bubble sort repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order.</para>
    /// <para>Time Complexity: O(n^2) in the worst and average cases, O(n) in the best case (when the list is already sorted).</para>
    /// <para>Space Complexity: O(1) (in-place sorting).</para>
    /// <para>Stability: Stable.</para>
    /// <para>Example: Used for educational purposes due to its simplicity.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    public static void BubbleSort<T>(T[] arr) where T : IComparable<T>
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    T temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Quick Sort
    /// <summary>
    /// <para>Description: Quick sort is a divide-and-conquer algorithm that selects a pivot element and partitions the array into two subarrays (elements less than the pivot and elements greater than the pivot).
    /// </para>
    /// <para>Time Complexity: O(n^2) in the worst case, O(n log n) on average.</para>
    /// <para>Space Complexity: O(log n) (in-place sorting).</para>
    /// <para>Stability: Unstable.</para>
    /// <para>Example: Widely used due to its efficiency.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    public static void QuickSort<T>(T[] arr) where T : IComparable<T>
    {
        QuickSort(arr, 0, arr.Length - 1);
    }

    private static void QuickSort<T>(T[] arr, int low, int high) where T : IComparable<T>
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    private static int Partition<T>(T[] arr, int low, int high) where T : IComparable<T>
    {
        T pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (arr[j].CompareTo(pivot) < 0)
            {
                i++;
                Swap(ref arr[i], ref arr[j]);
            }
        }
        Swap(ref arr[i + 1], ref arr[high]);
        return i + 1;
    }

    // Heap Sort
    /// <summary>
    /// <para>Average-case performance:
    /// Heap sort runs in O(n log n) time, which scales well as n grows.
    /// Unlike quicksort, there’s no worst-case O(n^2) complexity.
    /// </para>
    /// <para>Space Efficiency:
    /// Heap sort takes O(1) space (in-place sorting).
    /// It doesn’t require additional memory proportional to the input size.
    /// </para>
    /// <para>Explanation:
    /// Heap sort builds a max heap (or min heap) from the input array.
    /// It repeatedly extracts the maximum (or minimum) element from the heap and places it at the end of the sorted array.
    /// The heap is adjusted after each extraction to maintain the heap property.
    /// </para>
    /// <para>Example:
    /// Suppose we have an array: [4, 10, 3, 5, 1].
    /// After applying heap sort, the sorted array would be: [1, 3, 4, 5, 10].
    /// </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    public static void HeapSort<T>(T[] arr) where T : IComparable<T>
    {
        int n = arr.Length;

        // Build max heap (rearrange array)
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);

        // Extract elements from heap one by one
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root to end
            Swap(ref arr[0], ref arr[i]);

            // Call max heapify on the reduced heap
            Heapify(arr, i, 0);
        }
    }

    private static void Heapify<T>(T[] arr, int n, int i) where T : IComparable<T>
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left].CompareTo(arr[largest]) > 0)
            largest = left;

        if (right < n && arr[right].CompareTo(arr[largest]) > 0)
            largest = right;

        if (largest != i)
        {
            Swap(ref arr[i], ref arr[largest]);
            Heapify(arr, n, largest);
        }
    }

    // Selection Sort
    /// <summary>
    /// <para>Description: Selection sort repeatedly selects the smallest (or largest) element from the unsorted part of the array and places it at the beginning (or end).</para>
    /// <para>Time Complexity: O(n^2) in all cases.</para>
    /// <para>Space Complexity: O(1) (in-place sorting).</para>
    /// <para>Stability: Unstable.</para>
    /// <para>Example: Simple but inefficient for large lists.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j].CompareTo(arr[minIndex]) < 0)
                    minIndex = j;
            }
            Swap(ref arr[i], ref arr[minIndex]);
        }
    }

    // Used by Selection and Heap sort.
    private static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    /// <summary>
    /// <para>Description:
    /// Insertion sort is a simple sorting algorithm that works by iteratively inserting each element of an unsorted list into its correct position in a sorted portion of the list.
    /// It is a stable sorting algorithm, meaning that elements with equal values maintain their relative order in the sorted output.
    /// Imagine sorting playing cards in your hands: you split the cards into two groups (sorted and unsorted) and insert each card into the correct position.
    /// </para>
    /// <para>Time Complexity:Best Case: O(n) (when the list is already sorted)</para>
    /// <para>Average Case: O(n^2)</para>
    /// <para>Worst Case: O(n^2) (when the list is reversed)</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    public static void InsertionSort<T>(T[] arr) where T : IComparable<T>
    {
        for (int i = 1; i < arr.Length; i++)
        {
            T current = arr[i];
            int j = i - 1;

            // Move elements greater than 'current' one position ahead
            while (j >= 0 && arr[j].CompareTo(current) > 0)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            // Insert 'current' into the correct position
            arr[j + 1] = current;
        }
    }

    // Merge Sort
    /// <summary>
    /// <para>Description: Merge sort divides the array into halves, recursively sorts each half, and then merges the sorted halves.</para>
    /// <para>Time Complexity: O(n log n) in all cases.</para>
    /// <para>Space Complexity: O(n) (requires additional memory for merging).</para>
    /// <para>Stability: Stable.</para>
    /// <para>Example: Used for external sorting and when stability is important.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    public static void MergeSort<T>(T[] arr) where T : IComparable<T>
    {
        MergeSort(arr, 0, arr.Length - 1);
    }

    private static void MergeSort<T>(T[] arr, int low, int high) where T : IComparable<T>
    {
        if (low < high)
        {
            int mid = (low + high) / 2;
            MergeSort(arr, low, mid);
            MergeSort(arr, mid + 1, high);
            Merge(arr, low, mid, high);
        }
    }

    private static void Merge<T>(T[] arr, int low, int mid, int high) where T : IComparable<T>
    {
        // Implementation for merging two sorted arrays
        int leftSize = mid - low + 1;
        int rightSize = high - mid;

        // Create temporary arrays to hold the left and right subarrays
        T[] leftArray = new T[leftSize];
        T[] rightArray = new T[rightSize];

        // Copy data to temporary arrays
        for (int i = 0; i < leftSize; i++)
            leftArray[i] = arr[low + i];
        for (int j = 0; j < rightSize; j++)
            rightArray[j] = arr[mid + 1 + j];

        // Merge the two subarrays back into the original array
        int leftIndex = 0, rightIndex = 0, mergedIndex = low;
        while (leftIndex < leftSize && rightIndex < rightSize)
        {
            if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) <= 0)
            {
                arr[mergedIndex] = leftArray[leftIndex];
                leftIndex++;
            }
            else
            {
                arr[mergedIndex] = rightArray[rightIndex];
                rightIndex++;
            }
            mergedIndex++;
        }

        // Copy any remaining elements from leftArray and rightArray
        while (leftIndex < leftSize)
        {
            arr[mergedIndex] = leftArray[leftIndex];
            leftIndex++;
            mergedIndex++;
        }
        while (rightIndex < rightSize)
        {
            arr[mergedIndex] = rightArray[rightIndex];
            rightIndex++;
            mergedIndex++;
        }
    }

    
}
