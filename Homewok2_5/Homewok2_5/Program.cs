using System;
using System.Diagnostics;

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

            Console.WriteLine("Массив с рандомом:");
            foreach (int i in numArray)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            int[] sortArray = (int[])numArray.Clone();

            //Console.WriteLine("Каким алгоритмом вы хотите отстртировать массив:");
            //Console.WriteLine("1 - Шейкерная сортировка;");
            //Console.WriteLine("2 - Сортировка вставками;");
            //Console.WriteLine("3 - Сортировка Шелла;");
            //Console.WriteLine("4 - Быстрая сортировка.");
            //string answer = Console.ReadLine();
            //switch (answer)
            //{
            //    case "1":
            //        sw.Start();
            //        ArraySort1(sortArray);
            //        sw.Stop();
            //        Console.WriteLine($"Шейкерная сортировка заняла {sw.ElapsedMilliseconds} миллисекунды");
            //        break;
            //    case "2":
            //        sw.Start();
            //        ArraySort2(sortArray);
            //        sw.Stop();
            //        Console.WriteLine($"Cортировка вставками заняла {sw.ElapsedMilliseconds} миллисекунды");
            //        break;
            //    case "3":
            //        sw.Start();
            //        ArraySort3(sortArray);
            //        sw.Stop();
            //        Console.WriteLine($"Сортировка Шелла заняла {sw.ElapsedMilliseconds} миллисекунды");
            //        break;
            //    //    case "4":
            //    //        sw.Start();
            //    //        ArraySort5(sortArray);
            //    //        sw.Stop();
            //    //        Console.WriteLine($"Быстрая сортировка заняла {sw.ElapsedMilliseconds} миллисекунды");
            //    //        break;
            //    default:
            //        Console.WriteLine("Вы нажали что-то не то");
            //        break;
            //}

            ArraySort4(sortArray);

            Console.WriteLine("Отсортированный массив:");
            foreach (int i in sortArray)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        static int[] ArraySort1(int[] Array1)  //Shaker Sort
        {
            int startNum = 0;
            int endNum = Array1.Length - 1;
            while (startNum < endNum)
            {
                for (int i = startNum; i <= endNum - 1; i++)
                {
                    if (Array1[i] > Array1[i + 1])
                    {
                        int tempNum = Array1[i];
                        Array1[i] = Array1[i + 1];
                        Array1[i + 1] = tempNum;
                    }
                }
                endNum--;

                for (int i = endNum; i >= startNum + 1; i--)
                {
                    if (Array1[i] < Array1[i - 1])
                    {
                        int tempNum = Array1[i];
                        Array1[i] = Array1[i - 1];
                        Array1[i - 1] = tempNum;
                    }
                }
                startNum++;
            }
            return Array1;
        }

        static int[] ArraySort2(int[] Array2)  //Insertion Sort
        {
            for (int i = 1; i <= Array2.Length - 1; i++)
            {
                if (Array2[i] < Array2[i - 1])
                {
                    int tempNum = Array2[i];
                    int j = i;
                    while ((j > 0) && (Array2[j - 1] > tempNum))
                    {
                        Array2[j] = Array2[j - 1];
                        j--;
                    }
                    Array2[j] = tempNum;
                }
            }
            return Array2;
        }

        static int[] ArraySort3(int[] Array3)  //Insertion Sort             //АААА!!!! ОНО работает, сука!!
        {
            int[] deltaArray = { 1, 4, 10, 23, 57, 132, 301, 701, 1750 };
            for (int count = deltaArray.Length - 1; count >= 0; count--)
            {
                if (((double)Array3.Length / (double)deltaArray[count]) > 1)
                {
                    int D = deltaArray[count];
                    for (int k = 0; k < D; k++)
                    {
                        for (int i = 0 + k + D; i <= Array3.Length - 1; i = i + D)
                        {
                            if (Array3[i] < Array3[i - D])
                            {
                                int tempNum = Array3[i];
                                int j = i;
                                while ((j >= D) && (Array3[j - D] > tempNum))
                                {
                                    Array3[j] = Array3[j - D];
                                    j = j - D;
                                }
                                Array3[j] = tempNum;
                            }
                        }
                    }
                }
            }
            return Array3;
        }

        static int[] ArraySort4(int[] Array4)  //Quicksort main
        {
            int midNum = Array4[Array4.Length / 2];
            int i = 0;
            int j = Array4.Length - 1;
            while (i < j)
            {
                while (Array4[i] < midNum)
                {
                    i++;
                }
                while (Array4[j] >= midNum)
                {
                    j--;
                }

                if (i < j)
                {
                    int tempNum = Array4[i];
                    Array4[i] = Array4[j];
                    Array4[j] = tempNum;
                    i++;
                    j--;
                }
            }
            return Array4;
        }

        static int[] quickSort(int[] Array4, int i, int j)
            {

            return ()
            }

    }
}