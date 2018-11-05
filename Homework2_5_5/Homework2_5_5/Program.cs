using System;

namespace Homework2_5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте диапазон для генерации случайных чисел.");
            Console.Write("MIN: ");
            int minRandom = Int32.Parse(Console.ReadLine());
            Console.Write("MAX: ");
            int maxRandom = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nЗадайте размерность массива.");
            Console.Write("Количество строк:    ");
            int rows = Int32.Parse(Console.ReadLine());
            Console.Write("Количество столбцов: ");
            int columns = Int32.Parse(Console.ReadLine());
            int[,] numArray = new int[rows, columns];

            Console.WriteLine("\nМассив случайных чисел:");
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    numArray[i, j] = random.Next(minRandom, maxRandom);
                    Console.Write($"{numArray[i, j]} \t");
                }
                Console.WriteLine();
            }

            for (int k = numArray.Length - 1; k > 0; k--)
            {
                for (int l = 0; l < k; l++)
                {
                    int i1 = l / columns;
                    int j1 = l - i1 * columns;
                    int i2 = (l + 1) / columns;
                    int j2 = (l + 1) - i2 * columns;
                    if (numArray[i1, j1] > numArray[i2, j2])
                    {
                        int tempNum = numArray[i1, j1];
                        numArray[i1, j1] = numArray[i2, j2];
                        numArray[i2, j2] = tempNum;
                    }
                }
            }

            Console.WriteLine("\nОтсортированный массив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{numArray[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}


