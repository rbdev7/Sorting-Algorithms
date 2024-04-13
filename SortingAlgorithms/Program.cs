// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using SortingAlgorithms;

int arraySize = 1000;
int[] unsortedArray;
int[] array;
Dictionary<string, long> algoTimes = new Dictionary<string, long>();

void Setup() {
    Random random = new Random();

    unsortedArray = new int[arraySize];
    array = new int[arraySize];

    foreach(int i in Enumerable.Range(0, arraySize)) {
        unsortedArray[i] = random.Next(0, 10);
    }
}

void ResetArray() {
    Array.Copy(unsortedArray, array, unsortedArray.Length);
}

void DisplayArray<T>(T[] array) {
    foreach(var i in array){
        Console.Write($" {i}, ");
    }
    Console.WriteLine();
}

void DisplayStartMessage(string algorithm) {
    Console.WriteLine($"----{algorithm}----");
    //Console.WriteLine($"Unsorted array: ");
    //DisplayArray(array);

    Console.WriteLine($"Sorting {arraySize} items with {algorithm}...");
}

void DisplayEndMessage(long elapsedTime) {
    Console.WriteLine("Sorted");
    //Console.WriteLine($"Sorted array: ");
    //DisplayArray(array);
    Console.WriteLine($"Elapsed time: {elapsedTime.ToString()}ms");
    Console.WriteLine();
}

void DisplaySummary() {
    Console.WriteLine($"Number of items to sort: {arraySize}");
    foreach (var kv in algoTimes){
        Console.WriteLine($"Algorithm: {kv.Key}, Time: {kv.Value}ms");
    }
}

void UpdateAlgoTimes(string algoName, long time) {
    algoTimes.Add(algoName, time);
}

void PerformBubbleSort() {
    DisplayStartMessage("Bubble Sort");
    Stopwatch watch = new Stopwatch();
    watch.Start();
    Sorter.BubbleSort(array);
    watch.Stop();
    UpdateAlgoTimes("Bubble Sort", watch.ElapsedMilliseconds);
    DisplayEndMessage(watch.ElapsedMilliseconds);
    ResetArray();
}

void PerformSelectionSort() {
    DisplayStartMessage("Selection Sort");
    Stopwatch watch = new Stopwatch();
    watch.Start();
    Sorter.SelectionSort(array);
    watch.Stop();
    UpdateAlgoTimes("Selection Sort", watch.ElapsedMilliseconds);
    DisplayEndMessage(watch.ElapsedMilliseconds);
    ResetArray();
}

void PerformMergeSort() {
    DisplayStartMessage("Merge Sort");
    Stopwatch watch = new Stopwatch();
    watch.Start();
    Sorter.MergeSort(array);
    watch.Stop();
    UpdateAlgoTimes("Merge Sort", watch.ElapsedMilliseconds);
    DisplayEndMessage(watch.ElapsedMilliseconds);
    ResetArray();
}

void PerformQuickSort() {
    DisplayStartMessage("Quick Sort");
    Stopwatch watch = new Stopwatch();
    watch.Start();
    Sorter.QuickSort(array);
    watch.Stop();
    UpdateAlgoTimes("Quick Sort", watch.ElapsedMilliseconds);
    DisplayEndMessage(watch.ElapsedMilliseconds);
    ResetArray();
}

void PerformInsertionSort() {
    DisplayStartMessage("Insertion Sort");
    Stopwatch watch = new Stopwatch();
    watch.Start();
    Sorter.InsertionSort(array);
    watch.Stop();
    UpdateAlgoTimes("Insertion Sort", watch.ElapsedMilliseconds);
    DisplayEndMessage(watch.ElapsedMilliseconds);
    ResetArray();
}

void PerformHeapSort() {
    DisplayStartMessage("Heap Sort");
    Stopwatch watch = new Stopwatch();
    watch.Start();
    Sorter.HeapSort(array);
    watch.Stop();
    UpdateAlgoTimes("Heap Sort", watch.ElapsedMilliseconds);
    DisplayEndMessage(watch.ElapsedMilliseconds);
    ResetArray();
}

void PerformCSBuiltInSort() {
    DisplayStartMessage("C Sharp Sort");
    Stopwatch watch = new Stopwatch();
    watch.Start();
    Array.Sort(array);
    watch.Stop();
    UpdateAlgoTimes("C Sharp Sort", watch.ElapsedMilliseconds);
    DisplayEndMessage(watch.ElapsedMilliseconds);
    ResetArray();
}

// Main
// ====
if (args.Length > 0)
{
    try
    {
        arraySize = Convert.ToInt32(args[0]);
    }
    catch (System.FormatException ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Usage: SortingAlgorithms.exe <number of items to sort>");
        Environment.Exit(1);
    }
}

Setup();
ResetArray();
PerformBubbleSort();
PerformQuickSort();
PerformSelectionSort();
PerformInsertionSort();
PerformMergeSort();
PerformHeapSort();
PerformCSBuiltInSort();

DisplaySummary();

//DisplayArray(array);
