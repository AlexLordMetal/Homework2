using System;
using System.Diagnostics;
using System.IO;

namespace Homework2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Задайте диапазон чисел.");
            Console.Write("MIN: ");
            int min = Int32.Parse(Console.ReadLine());
            Console.Write("MAX: ");
            int max = Int32.Parse(Console.ReadLine());
            int[] numArray = new int[max - min + 1];

            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = min + i;
            }

            Random random = new Random();
            int j = 0;          // Additional value for random array element
            int tempNum = 0;    // Additional value for changing array elements

            for (int i = 0; i < numArray.Length; i++)     // Randomize array
            {
                j = random.Next(numArray.Length);
                if (i != j)
                {
                    tempNum = numArray[i];
                    numArray[i] = numArray[j];
                    numArray[j] = tempNum;
                }
            }

            Console.WriteLine("\nМассив с рандомом:");
            foreach (int i in numArray)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine("\n\nКаким алгоритмом вы хотите отсортировать массив:");
            Console.WriteLine("1 - Шейкерная сортировка;");
            Console.WriteLine("2 - Сортировка вставками;");
            Console.WriteLine("3 - Сортировка Шелла;");
            Console.WriteLine("4 - Быстрая сортировка.");
            string answer = Console.ReadLine();
            Console.WriteLine();
            switch (answer)
            {
                case "1":
                    sw.Start();
                    ShakerSort(numArray);
                    sw.Stop();
                    Console.WriteLine($"Шейкерная сортировка заняла {sw.ElapsedMilliseconds} миллисекунды");
                    break;
                case "2":
                    sw.Start();
                    InsertionSort(numArray);
                    sw.Stop();
                    Console.WriteLine($"Cортировка вставками заняла {sw.ElapsedMilliseconds} миллисекунды");
                    break;
                case "3":
                    sw.Start();
                    ShellSort(numArray);
                    sw.Stop();
                    Console.WriteLine($"Сортировка Шелла заняла {sw.ElapsedMilliseconds} миллисекунды");
                    break;
                case "4":
                    sw.Start();
                    QuickSort(numArray, 0, numArray.Length - 1);
                    sw.Stop();
                    Console.WriteLine($"Быстрая сортировка заняла {sw.ElapsedMilliseconds} миллисекунды");
                    break;
                default:
                    Console.WriteLine("Вы нажали что-то не то");
                    break;
            }

            Console.WriteLine("Вывести отсортированный массив в консоль (1) или в файл (2)?");
            answer = Console.ReadLine();
            if (answer == "1")
            {
                Console.WriteLine("\nОтсортированный массив:");
                foreach (int i in numArray)
                {
                    Console.Write($"{i} ");
                }
                Console.ReadKey();
            }
            else if (answer == "2")
            {
                StreamWriter arrayToFile = new StreamWriter("SortedArray.txt");
                foreach (int i in numArray)
                {
                    arrayToFile.Write($"{i} ");
                }
                arrayToFile.Close();
                Process.Start("SortedArray.txt");

            }
        }

        /// <summary>
        /// Method sorts array of Int32 with Shaker sort algorithm
        /// </summary>
        /// <param name="intArray"></param>
        /// <returns></returns>
        static int[] ShakerSort(int[] intArray)
        {
            int startNum = 0;
            int endNum = intArray.Length - 1;
            while (startNum < endNum)
            {
                for (int i = startNum; i <= endNum - 1; i++)
                {
                    if (intArray[i] > intArray[i + 1])
                    {
                        int tempNum = intArray[i];
                        intArray[i] = intArray[i + 1];
                        intArray[i + 1] = tempNum;
                    }
                }
                endNum--;

                for (int i = endNum; i >= startNum + 1; i--)
                {
                    if (intArray[i] < intArray[i - 1])
                    {
                        int tempNum = intArray[i];
                        intArray[i] = intArray[i - 1];
                        intArray[i - 1] = tempNum;
                    }
                }
                startNum++;
            }
            return intArray;
        }

        /// <summary>
        /// Method sorts array of Int32 with Insertion sort algorithm
        /// </summary>
        /// <param name="intArray"></param>
        /// <returns></returns>
        static int[] InsertionSort(int[] intArray)
        {
            for (int i = 1; i <= intArray.Length - 1; i++)
            {
                if (intArray[i] < intArray[i - 1])
                {
                    int tempNum = intArray[i];
                    int j = i;
                    while ((j > 0) && (intArray[j - 1] > tempNum))
                    {
                        intArray[j] = intArray[j - 1];
                        j--;
                    }
                    intArray[j] = tempNum;
                }
            }
            return intArray;
        }

        /// <summary>
        /// Method sorts array of Int32 with Shellsort algorithm
        /// </summary>
        /// <param name="intArray"></param>
        /// <returns></returns>
        static int[] ShellSort(int[] intArray)                       //АААА!!!! ОНО работает, сука!!
        {
            int[] deltaArray = { 1, 4, 10, 23, 57, 132, 301, 701, 1750 };
            for (int count = deltaArray.Length - 1; count >= 0; count--)
            {
                if (((double)intArray.Length / (double)deltaArray[count]) > 1)
                {
                    int D = deltaArray[count];
                    for (int k = 0; k < D; k++)
                    {
                        for (int i = 0 + k + D; i <= intArray.Length - 1; i = i + D)
                        {
                            if (intArray[i] < intArray[i - D])
                            {
                                int tempNum = intArray[i];
                                int j = i;
                                while ((j >= D) && (intArray[j - D] > tempNum))
                                {
                                    intArray[j] = intArray[j - D];
                                    j = j - D;
                                }
                                intArray[j] = tempNum;
                            }
                        }
                    }
                }
            }
            return intArray;
        }

        /// <summary>
        /// Method sorts array of Int32 with Quicksort algorithm
        /// </summary>
        /// <param name="intArray"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        static int[] QuickSort(int[] intArray, int start, int end)
        {
            if (end - start > 1)
            {
                int medNum = 0;
                int med = ((end - start) / 2) + start;
                if (((intArray[start] < intArray[med]) && (intArray[start] > intArray[end])) || ((intArray[start] > intArray[med]) && (intArray[start] < intArray[end])))   //Find the median number
                {
                    medNum = intArray[start];
                }
                else if (((intArray[med] < intArray[start]) && (intArray[med] > intArray[end])) || ((intArray[med] > intArray[start]) && (intArray[med] < intArray[end])))
                {
                    medNum = intArray[med];
                }
                else
                {
                    medNum = intArray[end];
                }

                int i = start;
                int j = end;
                while (i < j)
                {
                    while ((i <= end) && (intArray[i] < medNum))
                    {
                        i++;
                    }
                    while ((j >= start) && (intArray[j] > medNum))
                    {
                        j--;
                    }

                    if (i < j)
                    {
                        int tempNum = intArray[i];
                        intArray[i] = intArray[j];
                        intArray[j] = tempNum;
                        i++;
                        j--;
                    }
                }

                if (j > start)
                {
                    QuickSort(intArray, start, j);
                }

                if (i < end)
                {
                    QuickSort(intArray, i, end);
                }
            }

            else if (end - start == 1)      //Two elements simple sort
            {
                if (intArray[end] < intArray[start])
                {
                    int tempNum = intArray[start];
                    intArray[start] = intArray[end];
                    intArray[end] = tempNum;
                }
            }
            return intArray;
        }

    }
}