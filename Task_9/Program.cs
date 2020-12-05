using System;
using System.Text;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            
            MyArray myArray = new MyArray();
            myArray.InputAndCheckData();
            myArray.FillAndDisplayArray();
            myArray.Deleg = myArray.ConditionCheck;
            myArray.InputAndSearchKey();
            myArray.SearchMaxInRows();
            Console.WriteLine("\nПісля виконання умови ConditionCheck: ");
            myArray.MyCalculation(myArray.arr, myArray.Deleg);
            Console.WriteLine("\nПісля виконання умови лямбда-виразу: ");
            myArray.MyCalculation(myArray.arr, x => x > 31);
            Console.ReadKey();
        }
    }

    class MyArray
    {
        private int m;
        private int n;
        private int key;
        private int rows;
        private int columns;
        public int[,] arr;

        private isEqual deleg;
        public delegate bool isEqual(int x);
        public isEqual Deleg
        {
            get => deleg;
            set => deleg = value;
        }

        public void InputAndCheckData()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введіть кількість рядків масиву: ");
                    m = int.Parse(Console.ReadLine());
                    Console.Write("Введіть кількість стовбців масиву: ");
                    n = int.Parse(Console.ReadLine());
                    if (m < 1 || n < 1)
                    {
                        throw new Exception("Число рядків та стовбців має бути більше рівне 1! Спробуйте ще раз.\n");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введіть лише ціле натуральне число!\n");
                }
                
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}.");
                }
            }
        }

        public void FillAndDisplayArray()
        {
            arr = new int[m, n];
            rows = arr.GetUpperBound(0) + 1;
            columns = arr.GetUpperBound(1) + 1;
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    arr[i, j] = random.Next(1, 41);
                }
            }
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
            
                Console.WriteLine();
            }
        }

        public void InputAndSearchKey()
        {
            while (true)
            {
                try
                {
                    Console.Write("\nВведіть ключ, який потрібно знайти: ");
                    key = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введіть лише ціле число!\n");
                }
            }

            Console.WriteLine();
            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                
                for (int j = 0; j < columns; j++)
                {
                    if (arr[i, j] == key)
                    {
                        counter++;
                        Console.WriteLine($"Ключ {key} знайдений за індексом ({i}, {j}).");
                    }
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"Ключ {key} не знайдено.");
            }
        }
        
        public void SearchMaxInRows()
        {
            Console.WriteLine();
            int iIndex = 0;
            for (int j = 0; j < columns; j++)
            {
                int max = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        iIndex = i;
                    }
                }
                Console.WriteLine($"Максимальний елемент в стовпчику {j} дорівнює {max}. Його індекс: {iIndex}, {j}.");
            }
        }

        public bool ConditionCheck(int x) => x % 3 != 0;

        public void MyCalculation(int[,] arr, isEqual filter)
        {
            int iIndex = 0;
            for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
            {
                int max = 0;
                for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
                {
                    if (arr[i, j] > max && filter(arr[i, j]))
                    {
                        max = arr[i, j];
                        iIndex = i;
                    }
                }

                if (max != 0)
                {
                    Console.WriteLine($"Максимальний елемент в стовпчику {j} дорівнює {max}. Його індекс: {iIndex}, {j}.");    
                }
                else
                {
                    Console.WriteLine($"В стовпчику {j} немає максимального елемента, який би задовольняв умову.");
                }
                
            }
        }
    }
}