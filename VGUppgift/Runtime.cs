using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VGUppgift
{
    class Runtime
    {
        int[] ReadNumbersFromFile(int v)
        {
            var filePath = Environment.CurrentDirectory + "\\data"+v.ToString()+".txt";
            var lines = File.ReadAllLines(filePath);
            var data = lines[0].Split('\t');

            return Array.ConvertAll(data, int.Parse);

        }
        internal void Start()
        {
            Gui.StartMenu();
            do
            {
                //Console.Clear();
                GetChoice();

            } while (true);
        }

        private void GetChoice()
        {
            Console.ResetColor();
            Console.WriteLine("Ditt val: ");
            var input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    GenerateAndSort(1);
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    GenerateAndSort(2);
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    GenerateAndSort(4);
                    break;
            }
        }

        private void GenerateAndSort(int v)
        {
            //var numbersForBubble = GenerateNumbers(v);
            var numbersForBubble = ReadNumbersFromFile(v);
            var numbersForQuick = ReadNumbersFromFile(v);
            BubbleSort(numbersForBubble, v);
            QuickSort(numbersForQuick, v);
        }

        private int[] GenerateNumbers(int v)
        {
            v = v * 10000;
            int[] randomNumbers = new int[v];

            for (int i = 0; i < v; i++)
            {
                int number;
                Random random = new Random();
                do number = random.Next(-25000,25000);
                while (randomNumbers.Contains(number));

                randomNumbers[i]= number ;
            }

            return randomNumbers;
        }

        #region BubbleSort
        public void BubbleSort<T>(T[] numbers, int v)
        {
            //Starting the execution´s timer
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = numbers.Length - 1; j > 0; j--)
                {
                    if (Comparer<T>.Default.Compare(numbers[j], numbers[j - 1]) < 0)
                    {
                        var temp = numbers[j];
                        numbers[j] = numbers[j - 1];
                        numbers[j - 1] = temp;
                    }
                }
            }

            //Stopping the execution´s timer
            watch.Stop();
            var bubbleSortExeecutionTime = watch.ElapsedMilliseconds;
            Print(numbers, "Bubble", bubbleSortExeecutionTime, v);
        }

        #endregion

        #region QuickSort
        internal void QuickSort<T>(T[] numbers, int v)
        {
            //Starting the execution´s timer
            var watch = System.Diagnostics.Stopwatch.StartNew();
            QuickSort(numbers, 0, numbers.Length - 1);
            watch.Stop();
            var quickSortExeecutionTime = watch.ElapsedMilliseconds;
            Print(numbers, "Quick", quickSortExeecutionTime, v);
        }
        internal void QuickSort<T>(T[] numbers, int left, int right)
        {
            if (Comparer<int>.Default.Compare(left, right) < 0)
            {
                int index = Partition(numbers, left, right);

                QuickSort(numbers, left, index - 1);
                QuickSort(numbers, index + 1, right);
            }
        }

        private int Partition<T>(T[] numbers, int left, int right)
        {
            T pivot = numbers[right];
            T temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if (Comparer<T>.Default.Compare(numbers[j], pivot) <= 0)
                {
                    temp = numbers[j];
                    numbers[j] = numbers[i];
                    numbers[i] = temp;
                    i++;
                }
            }

            numbers[right] = numbers[i];
            numbers[i] = pivot;

            return i;
        }
        #endregion

        public void Print<T>(T[] numbers, string type, Int64 excutionTime, int v)
        {
            v = v * 10000;
            if (type == "Bubble")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Data qunatity : {0} Bubble sorted:   (Execution time: {1} ms)", v , excutionTime);

            }
            else if (type == "Quick")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Data quantity : {0} Quick sorted:   (Execution time: {1} ms)", v, excutionTime);
            }
            //var index = 1;
            //foreach (var number in numbers)
            //{
            //    Console.Write("  " + number);
            //    if (index % 10 == 0)
            //    {
            //        Console.WriteLine("");
            //    }
            //    index++;
            //}
            //Console.WriteLine("");
        }
    }
}
